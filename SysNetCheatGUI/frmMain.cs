using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Windows.Forms;

namespace SysNetCheatGUI
{
    public partial class FrmMain : Form
    {
        public Switch MySwitch;

        private bool inhibitAutoCheck;
        public bool OkayToStartSearch = false;
        private string _editValue = "Edit Value";
        private string _editName = "Edit Name";

        public FrmMain()
        {
            InitializeComponent();
            radU32.Checked = true;
        }

        private void btnConnectSwitch_Click(object sender, EventArgs e)
        {
            //if MySwitch does not exist
            if (MySwitch == null)
            {
                //Instanciate a New MySwitch
                MySwitch = new Switch(this);
                //if Not Connected
                if (!MySwitch.Connected)
                {
                    //ip = text of txtIPAddress
                    string ip = txtIPAddress.Text;
                    
                    try
                    {
                        //Try to connect to Ip Address
                        MySwitch.Connect(ip);
                        //if Connected
                        if (MySwitch.SwitchSocket.Connected)
                        {
                            //Enable all form objects
                            EnableForm(true);
                        }
                    }
                    catch
                    {
                        // ignored
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Set ClickSearch to true
            MySwitch.ClickedSearch = true;
            //if GetSearchSize doesn't return Invalid response
            if (GetSearchSize() != "X_X")
            {
                //set OkayToStartSearch to true
                OkayToStartSearch = true;
            }
            else
            {
                //No Search size was selected.
                MessageBox.Show("Select a Search Value Size.");
            }
            //If txtValue.Text is not Null/Empty/Blank
            if (txtValue.Text != null || txtValue.Text.Trim().Equals(""))
            {
                //if both are true
                if (MySwitch.SwitchSocket.Connected && OkayToStartSearch)
                {
                    //Disable Groupbox
                    gbValueSize.Enabled = false;
                    //Clear listView
                    lvAddress.Items.Clear();
                    //Clear Console textbox
                    txtConsole.Clear();
                    //Send CommandString
                    MySwitch.SendCommand(MySwitch.SearchString(), "","",GetSearchSize(),txtValue.Text);
                }
            }
        }

        private void btnNewSearch_Click(object sender, EventArgs e)
        {
            MySwitch.IsNewSearch = true;
            gbValueSize.Enabled = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MySwitch?.Disconnect();
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySwitch?.Disconnect();
            this.Close();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            EnableForm(false);
        }

        private void editValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditAddressValue();
        }

        private void btnAddAddress_Click(object sender, EventArgs e)
        {
            using (FrmAddAddress addAddress = new FrmAddAddress())
            {
                if (addAddress.ShowDialog() == DialogResult.OK)
                {
                    ManuallyAddAddress(addAddress);
                }
            }
        }

        private void btnRemoveAddress_Click(object sender, EventArgs e)
        {
            try
            {
                int index = lvStoredAddresses.SelectedIndex();
                lvStoredAddresses.Items.RemoveAt(index);
            }
            catch
            {
                MessageBox.Show(this.Owner, "Could not delete address.");
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            MySwitch?.Disconnect();
        }

        private void editNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditNameValue();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FrmAbout about = new FrmAbout())
            {
                about.ShowDialog();
            }
        }

        public void EnableForm(bool offOn)
        {
            btnNewSearch.Enabled = offOn;
            btnSearch.Enabled = offOn;
            txtValue.Enabled = offOn;
            gbValueSize.Enabled = offOn;
            lvAddress.Enabled = offOn;
            lvStoredAddresses.Enabled = offOn;
            btnAddAddress.Enabled = offOn;
            btnRemoveAddress.Enabled = offOn;
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

        private void AddAddress()
        {
            int index = lvAddress.SelectedIndex();

            using (FrmEditDialog editValue = new FrmEditDialog(_editValue))
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

                MySwitch.SendCommand(Commands.PokeAddress, "", lvAddress.Items[index].SubItems[0].Text,
                    GetSearchSize(), editValue.Value);
            }
        }

        private void ManuallyAddAddress(FrmAddAddress frmAddAddress)
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
                    if (frmAddAddress.Address == address)
                    {
                        found = true;
                        //Edit Existing Address
                        lvStoredAddresses.Items[i].SubItems[3].Text = frmAddAddress.Name;
                        lvStoredAddresses.Items[i].SubItems[4].Text = frmAddAddress.ValueSize;
                        lvStoredAddresses.Items[i].SubItems[5].Text = frmAddAddress.Value;
                        break;
                    }

                }
                if (!found)
                {
                    //Else Add a new Address
                    lvStoredAddresses.Items.Add(AddListViewItem(frmAddAddress.Address, frmAddAddress.Name,
                        frmAddAddress.ValueSize,
                        frmAddAddress.Value));
                }
            }
            else
            {
                //Else Add a new Address
                lvStoredAddresses.Items.Add(AddListViewItem(frmAddAddress.Address, frmAddAddress.Name,
                    frmAddAddress.ValueSize,
                    frmAddAddress.Value));
            }

            MySwitch.SendCommand(Commands.PokeAddress, "", frmAddAddress.Address,
                frmAddAddress.ValueSize, frmAddAddress.Value);
        }

        private void EditAddressValue()
        {
            int index = lvStoredAddresses.SelectedIndex();
            using (FrmEditDialog editValue = new FrmEditDialog(_editValue))
            {
                if (editValue.ShowDialog() == DialogResult.OK)
                {
                    //Edit Existing Address
                    lvStoredAddresses.Items[index].SubItems[5].Text = editValue.Value;

                    MySwitch.SendCommand(Commands.PokeAddress, "", lvStoredAddresses.Items[index].SubItems[2].Text,
                        GetSearchSize(), editValue.Value);
                }
            }
        }

        private void EditNameValue()
        {
            int index = lvStoredAddresses.SelectedIndex();
            using (FrmEditDialog editValue = new FrmEditDialog(_editName))
            {
                if (editValue.ShowDialog() == DialogResult.OK)
                {
                    //Edit Name
                    lvStoredAddresses.Items[index].SubItems[3].Text = editValue.Value;
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

        public void lvStoredAddresses_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int index = lvStoredAddresses.SelectedIndex();
                MySwitch.SendCommand(Commands.PokeAddress, lvStoredAddresses.Items[index].SubItems[1].Text,
                    lvStoredAddresses.Items[index].SubItems[2].Text, lvStoredAddresses.Items[index].SubItems[4].Text,
                    lvStoredAddresses.Items[index].SubItems[5].Text);
            }
            catch
            {
                MessageBox.Show("Could not send command");
            }
        }

        private void lvStoredAddresses_MouseDown(object sender, MouseEventArgs e)
        {
            inhibitAutoCheck = true;
        }

        private void lvStoredAddresses_MouseUp(object sender, MouseEventArgs e)
        {
            inhibitAutoCheck = false;
        }

        private void lvStoredAddresses_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (inhibitAutoCheck)
                e.NewValue = e.CurrentValue;
        }
    }
}
