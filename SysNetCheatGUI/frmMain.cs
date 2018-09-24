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
    public partial class frmMain : Form
    {
        public Switch MySwitch;
        
        public bool OkayToStartSearch = false;
        

        public frmMain()
        {
            InitializeComponent();
            
            btnNewSearch.Enabled = false;
            btnSearch.Enabled = false;
            txtValue.Enabled = false;
            gbValueSize.Enabled = false;
            lbAddress.Enabled = false;
            clbAddresses.Enabled = false;
            radU32.Checked = true;
            txtIPAddress.Text = "192.168.1.140";
            txtValue.Text = "638";
        }

        private void btnConnectSwitch_Click(object sender, EventArgs e)
        {
            if (MySwitch == null)
            {
                MySwitch = new Switch(txtConsole, lbAddress);
                if (!MySwitch.SwitchSocket.Connected)
                {
                    string ip = txtIPAddress.Text;
                    MySwitch.Connect(ip);
                    if (MySwitch.SwitchSocket.Connected)
                    {
                        btnNewSearch.Enabled = true;
                        btnSearch.Enabled = true;
                        txtValue.Enabled = true;
                        gbValueSize.Enabled = true;
                        lbAddress.Enabled = true;
                        clbAddresses.Enabled = true;
                    }
                }
            }
            else
            {
                if (!MySwitch.SwitchSocket.Connected)
                {
                    string ip = txtIPAddress.Text;
                    MySwitch.Connect(ip);
                    if (MySwitch.SwitchSocket.Connected)
                    {
                        btnNewSearch.Enabled = true;
                        btnSearch.Enabled = true;
                        txtValue.Enabled = true;
                        gbValueSize.Enabled = true;
                        lbAddress.Enabled = true;
                        clbAddresses.Enabled = true;
                    }
                }
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

            if (MySwitch.SwitchSocket.Connected && OkayToStartSearch)
            {

                lbAddress.Items.Clear();
                txtConsole.Clear();
                //Send Command
                string searchString = MySwitch.SearchString(GetSearchSize(), txtValue.Text);
                MySwitch.SendPacket(Encoding.Default.GetBytes(searchString));
                //clear the write buffer
                MySwitch.ClearWriteBuffer();
            }
            
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
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //MySwitch.Disconnect();
        }

        public static byte[] ReadFully(Stream stream, TextBox text)
        {
            byte[] buffer = new byte[32768];
            using (MemoryStream ms = new MemoryStream())
            {
                while (true)
                {
                    int read = stream.Read(buffer, 0, buffer.Length);
                    if (read <= 0)
                        return ms.ToArray();
                    ms.Write(buffer, 0, read);
                }
            }
        }

        public byte[] ReadAllBytes(Stream stream)
        {
            using (var ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }

        private void lbAddress_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.lbAddress.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                using (frmEditValue editValue = new frmEditValue())
                {
                    if (editValue.ShowDialog() == DialogResult.OK)
                    {
                        //Check if address exist
                        if(clbAddresses.Items.Count > 0)
                        {
                            for (int i = 0; i < clbAddresses.Items.Count; i++)
                            {
                                string address = clbAddresses.Items[i].ToString();
                                address = address.Split(' ')[0];
                                if (lbAddress.Items[index].ToString() == address)
                                {
                                    clbAddresses.Items[i] = lbAddress.Items[index].ToString() + " : " + editValue.Value;

                                }
                                else
                                {
                                    clbAddresses.Items.Add(lbAddress.Items[index].ToString() + " : " + editValue.Value);
                                }
                            }
                        }
                        else
                        {
                            clbAddresses.Items.Add(lbAddress.Items[index].ToString() + " : " + editValue.Value);
                        }
                        string command = MySwitch.Command(Commands.PokeAddress, lbAddress.Items[index].ToString(),
                            GetSearchSize(), editValue.Value, "");
                        byte[] byteCommand = Encoding.Default.GetBytes(command);
                        MySwitch.SendPacket(byteCommand);
                        MySwitch.ClearWriteBuffer();
                    }
                }
                    
               
            }
        }

        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (MySwitch.Connected)
            {
                if (e.KeyChar == (char)13)
                {
                    btnSearch_Click(sender, e);
                }
            }
        }

        private void txtIPAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnConnectSwitch_Click(sender, e);
            }
        }
    }
}
