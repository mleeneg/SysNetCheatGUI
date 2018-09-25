using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace SysNetCheatGUI
{
    public partial class FrmMain : Form
    {
        public Switch MySwitch;

        public bool OkayToStartSearch = false;


        public FrmMain()
        {
            InitializeComponent();
            //MySwitch = new Switch(txtConsole, lvAddress,txtValue.Text);
            radU32.Checked = true;
            txtIPAddress.Text = "192.168.1.140";
        }

        private void btnConnectSwitch_Click(object sender, EventArgs e)
        {
            if (MySwitch == null)
            {
                MySwitch = new Switch(this);
                if (!MySwitch.Connected)
                {
                    string ip = txtIPAddress.Text;
                    MySwitch.Connect(ip);
                    if (MySwitch.SwitchSocket.Connected)
                    {
                        EnableForm(true);
                    }
                }
            }
            else
            {
                //MySwitch = null;
                MessageBox.Show(this, "Cannot Connect");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            MySwitch.ClickedSearch = true;
            if (GetSearchSize() != "X_X")
            {
                OkayToStartSearch = true;
            }
            else
            {
                MessageBox.Show("Select a Search Value Size.");
            }

            if (txtValue.Text != null || txtValue.Text.Trim().Equals(""))
            {
                if (MySwitch.SwitchSocket.Connected && OkayToStartSearch)
                {
                    gbValueSize.Enabled = false;
                    lvAddress.Items.Clear();
                    txtConsole.Clear();
                    //Send Command
                    string searchString = MySwitch.SearchString(GetSearchSize(), txtValue.Text);
                    MySwitch.SendPacket(Encoding.Default.GetBytes(searchString));
                    //clear the write buffer
                    MySwitch.ClearWriteBuffer();
                }
            }

        }

        public void EnableForm(bool b)
        {

            btnNewSearch.Enabled = b;
            btnSearch.Enabled = b;
            txtValue.Enabled = b;
            gbValueSize.Enabled = b;
            lvAddress.Enabled = b;
        }

        /// <summary>
        /// Gets the Search size.
        /// String: u8, u16, u32, or u64
        /// </summary>
        /// <returns></returns>
        private string GetSearchSize()
        {
            if (radU8.Checked)
                return "u8";
            if (radU16.Checked)
                return "u16";
            if (radU32.Checked)
                return "u32";
            if (radU64.Checked)
                return "u64";
            return "X_X";
        }

        private void btnNewSearch_Click(object sender, EventArgs e)
        {
            MySwitch.IsNewSearch = true;
            gbValueSize.Enabled = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //MySwitch.Disconnect();
        }

        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) 13)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void txtIPAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) 13)
            {
                btnConnectSwitch_Click(sender, e);
            }
        }

        private void lvAddress_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            AddAddress();
        }

        private void AddAddress()
        {
            int index = lvAddress.SelectedIndex();

            using (FrmEditValue editValue = new FrmEditValue())
            {
                if (editValue.ShowDialog() == DialogResult.OK)
                {
                    //Check if address exist
                    //Get Stored Address Count
                    //If more than 0 
                    int count = lvStoredAddresses.Items.Count;
                    if (count > 0)
                    {
                        bool found = false;
                        //Loop thru the addresses
                        for (int i = 0; i < count; i++)
                        {

                            string address = lvStoredAddresses.Items[i].SubItems[2].Text;
                            address = address.Split(' ')[0];
                            //If address found
                            if (lvAddress.Items[index].SubItems[0].Text == address)
                            {
                                found = true;
                                //Edit Existing Address
                                lvStoredAddresses.Items[i].SubItems[5].Text = editValue.Value;
                                break;
                            }

                        }
                        if (!found)
                        {
                            //Else Add a new Address
                            lvStoredAddresses.Items.Add(AddListViewItem(
                                lvAddress.Items[index].SubItems[0].Text, "", GetSearchSize(),
                                editValue.Value));
                        }
                    }
                    else
                    {
                        //Else Add a new Address
                        lvStoredAddresses.Items.Add(AddListViewItem(lvAddress.Items[index].SubItems[0].Text, "",
                            GetSearchSize(), editValue.Value));
                    }
                }

                string command = MySwitch.Command(Commands.PokeAddress, lvAddress.Items[index].SubItems[0].Text,
                    GetSearchSize(), editValue.Value, "");
                byte[] byteCommand = Encoding.Default.GetBytes(command);
                MySwitch.SendPacket(byteCommand);
                MySwitch.ClearWriteBuffer();
            }
        }


        private void EditAddress()
        {
            int index = lvStoredAddresses.SelectedIndex();
            using (FrmEditValue editValue = new FrmEditValue())
            {
                if (editValue.ShowDialog() == DialogResult.OK)
                {
                    //Edit Existing Address
                    lvStoredAddresses.Items[index].SubItems[5].Text = editValue.Value;
     
                    string command = MySwitch.Command(Commands.PokeAddress, lvStoredAddresses.Items[index].SubItems[2].Text,
                        GetSearchSize(), editValue.Value, "");
                    byte[] byteCommand = Encoding.Default.GetBytes(command);
                    MySwitch.SendPacket(byteCommand);
                    MySwitch.ClearWriteBuffer();
                }
            }
        }

        private ListViewItem AddListViewItem(string address, string name, string valueType, string value)
        {
            //Create new Instance of Object
            //Declearing it empty so subset 0 is a checkbox.
            ListViewItem item = new ListViewItem();
            //Add to Item subset 1 Address
            item.SubItems.Add("");

            //Add to Item subset 2 Address
            item.SubItems.Add(address);

            //Add to Item subset 3 Name
            item.SubItems.Add(name);

            //Add to Item subset 4 ValueType
            item.SubItems.Add(valueType);

            //Add to Item subset 5 Value
            item.SubItems.Add(value);

            return item;

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            EnableForm(false);
            ;
        }

        private void editValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditAddress();
        }
    }
}
