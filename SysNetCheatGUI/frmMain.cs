using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SysNetCheatGUI
{
    public partial class FrmMain : Form
    {
        public Switch MySwitch;

        public bool InhibitAutoCheck;
        public bool OkayToStartSearch = false;
        private string _editValue = "Edit Value";
        private string _editName = "Edit Name";

        public FrmMain()
        {
            InitializeComponent();
            cbValueType.SelectedIndex = 2;
            txtDisplayAmount.Text = "1000";
        }

        private void btnConnectSwitch_Click(object sender, EventArgs e)
        {
            //if MySwitch does not exist
            if (MySwitch == null)
            {
                //Instantiate a New MySwitch
                MySwitch = new Switch(this);
                //if Not IsConnected
                if (!MySwitch.IsConnected)
                {
                    //ip = text of txtIPAddress
                    string ip = txtIPAddress.Text;
                    
                    try
                    {
                        //Try to connect to Ip Address
                        MySwitch.Connect(ip);
                        //if IsConnected
                        if (MySwitch.IsConnected)
                        {
                            //Enable all form objects
                            EnableForm(true,false);
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
            bool validDisplayAmount = int.TryParse(txtDisplayAmount.Text, out MySwitch.DisplayAmount);
            if (MySwitch.DisplayAmount < 100 || MySwitch.DisplayAmount > 10000)
            {
                validDisplayAmount = false;
            }
            bool valid = int.TryParse(txtValue.Text,out int value);
            //if GetSearchSize doesn't return Invalid response
            if (SearchSize!= "0" && valid && validDisplayAmount)
            {
                //set OkayToStartSearch to true
                OkayToStartSearch = true;
            }
            else
            {
                MessageBox.Show("Search Not Valid!");
            }
            //If txtValue.Text is not Null/Empty/Blank
            if (!txtValue.Text.Trim().Equals(""))
            {
                //if both are true
                if (!MySwitch.SwitchClient.Connected || !OkayToStartSearch) return;
                //Disable value type
                cbValueType.Enabled = false;
                //Clear listView
                lvAddress.Items.Clear();
                lblCountFound.Text = "Searching";
                MySwitch.ClearAddresses();
                //Send MakeCommandString
                MySwitch.SendCommand(MySwitch.SearchString(),"","",SearchSize,value.ToString());
            }
            else
            {
                MessageBox.Show("Value Must Be Entered!");
            }
        }

        private void btnNewSearch_Click(object sender, EventArgs e)
        {
            MySwitch.IsNewSearch = true;
            cbValueType.Enabled = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MySwitch?.Disconnect(false);
        }

        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
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
            MySwitch?.Disconnect(false);
            this.Close();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            EnableForm(false,false);
            txtIPAddress.Text = Properties.Settings.Default.IPAddress;
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
            DeleteAddress();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            MySwitch?.Disconnect(false);
        }

        private void editDescriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditDescriptionValue();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FrmAbout about = new FrmAbout())
            {
                about.ShowDialog();
            }
        }

        public void EnableForm(bool offOn, bool isInvoke)
        {
            if (isInvoke)
            {
                ObjectInvokeEnable(btnNewSearch, offOn);
                ObjectInvokeEnable(btnSearch, offOn);
                ObjectInvokeEnable(txtValue, offOn);
                ObjectInvokeClearText(txtValue);                
                ObjectInvokeEnable(lvAddress, offOn);
                ObjectInvokeEnable(lvStoredAddresses, offOn);
                ObjectInvokeEnable(btnAddAddress, offOn);
                ObjectInvokeEnable(btnRemoveAddress, offOn);
                ObjectInvokeEnable(cbValueType, offOn);
                ObjectInvokeEnable(txtDisplayAmount, offOn);
            }
            else
            {
                btnNewSearch.Enabled = offOn;
                btnSearch.Enabled = offOn;
                txtValue.Enabled = offOn;
                txtValue.Text = "";
                lvAddress.Enabled = offOn;
                lvStoredAddresses.Enabled = offOn;
                btnAddAddress.Enabled = offOn;
                btnRemoveAddress.Enabled = offOn;
                cbValueType.Enabled = offOn;
                txtDisplayAmount.Enabled = offOn;
            }

        }

        private void ObjectInvokeEnable(Control o, bool b)
        {
            if (o.InvokeRequired)
                o.Invoke(new Action(() => { o.Enabled = b; }));
        }
        private void ObjectInvokeClearText(Control o)
        {
            if (o.InvokeRequired)
                o.Invoke(new Action(() => { o.Text = ""; }));
        }
        /// <summary>
        /// Gets the Search size.
        /// String: u8, u16, u32, or u64
        /// </summary>
        /// <returns></returns>
        private string SearchSize
        {
            get
            {
                string valueType = "0";
                switch (cbValueType.SelectedIndex)
                {
                    case 0:
                        valueType = "u8";
                        break;
                    case 1:
                        valueType = "u16";
                        break;
                    case 2:
                        valueType = "u32";
                        break;
                    case 3:
                        valueType = "u64";
                        break;
                }

                return valueType;
            }
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
                                lvAddress.Items[index].SubItems[0].Text, "", SearchSize,
                                editValue.Value));
                        }
                    }
                    else
                    {
                        //Else Add a new Address
                        lvStoredAddresses.Items.Add(AddListViewItem(lvAddress.Items[index].SubItems[0].Text, "",
                            SearchSize, editValue.Value));
                    }
                }

                MySwitch.SendCommand(Commands.PokeAddress, "", lvAddress.Items[index].SubItems[0].Text,
                    SearchSize, editValue.Value);
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
                        lvStoredAddresses.Items[i].SubItems[3].Text = frmAddAddress.AddressName;
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
                lvStoredAddresses.Items.Add(AddListViewItem(frmAddAddress.Address, frmAddAddress.AddressName,
                    frmAddAddress.ValueSize,
                    frmAddAddress.Value));
            }
            if(frmAddAddress.PokeAddress)
                MySwitch.SendCommand(Commands.PokeAddress, "", frmAddAddress.Address,
                frmAddAddress.ValueSize, frmAddAddress.Value);
        }

        private void EditAddressValue()
        {
            int index = lvStoredAddresses.SelectedIndex();
            try
            {
                if (lvStoredAddresses.Items[index].SubItems[2].Text == "") return;
                using (FrmEditDialog editValue = new FrmEditDialog(_editValue))
                {
                    if (editValue.ShowDialog() != DialogResult.OK) return;
                    //Edit Existing Address
                    lvStoredAddresses.Items[index].SubItems[5].Text = editValue.Value;

                    MySwitch.SendCommand(Commands.PokeAddress, "", lvStoredAddresses.Items[index].SubItems[2].Text,
                        SearchSize, editValue.Value);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No Valid Address!");
            }
        }

        private void EditDescriptionValue()
        {
            int index = lvStoredAddresses.SelectedIndex();
            try
            {
                if (lvStoredAddresses.Items[index].SubItems[2].Text == "") return;
                using (FrmEditDialog editValue = new FrmEditDialog(_editName))
                {
                    if (editValue.ShowDialog() == DialogResult.OK)
                    {
                        //Edit Name
                        lvStoredAddresses.Items[index].SubItems[3].Text = editValue.Value;
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No Valid Address!");
            }
        }

        private ListViewItem AddListViewItem(string address, string name, string valueType, string value)
        {
            //Create new Instance of Object
            //Declaring it empty so subset 0 is a checkbox.
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
            InhibitAutoCheck = true;
        }

        private void lvStoredAddresses_MouseUp(object sender, MouseEventArgs e)
        {
            InhibitAutoCheck = false;
        }

        private void lvStoredAddresses_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (InhibitAutoCheck)
                e.NewValue = e.CurrentValue;
        }

        private void lvStoredAddresses_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            int count = 0;
            for (int i = 0; i < lvStoredAddresses.Items.Count; i++)
            {
                if (lvStoredAddresses.Items[i].Checked)
                {
                    count++;
                }
            }
            AddToFreeze(count);
            DeleteFromFreeze();
        }

        private void DeleteFromFreeze()
        {
            //loop thru list
            for (int i = 0; i < lvStoredAddresses.Items.Count; i++)
            {
                string id = lvStoredAddresses.Items[i].SubItems[1].Text;
                //Check if Checkboxes are checked and their IDs are not blank
                if (lvStoredAddresses.Items[i].Checked || id.Equals("")) continue;
                //Remove Frozen address at Index
                MySwitch.SendCommand(Commands.UnFreezeAddress, id, "", "", "");
                //Set ID to blank
                lvStoredAddresses.Items[i].SubItems[1].Text = "";
                //Modify IDs of other address.
                for (int p = 0; p < lvStoredAddresses.Items.Count; p++)
                {
                    if (!lvStoredAddresses.Items[p].Checked ||
                        int.Parse(lvStoredAddresses.Items[p].SubItems[1].Text) <= int.Parse(id)) continue;
                    int newId = int.Parse(lvStoredAddresses.Items[p].SubItems[1].Text) - 1;
                    lvStoredAddresses.Items[p].SubItems[1].Text = newId.ToString();
                }
            }
        }

        private void AddToFreeze(int count)
        {
            //Loop thru list
            for (int i = 0; i < lvStoredAddresses.Items.Count; i++)
            {
                string id = lvStoredAddresses.Items[i].SubItems[1].Text;
                //if checked & id is blank
                if (!lvStoredAddresses.Items[i].Checked || !id.Equals("")) continue;
                string address = lvStoredAddresses.Items[i].SubItems[2].Text;
                string valueSize = lvStoredAddresses.Items[i].SubItems[4].Text;
                string value = lvStoredAddresses.Items[i].SubItems[5].Text;

                lvStoredAddresses.Items[i].SubItems[1].Text = (count - 1).ToString();
                MySwitch.SendCommand(Commands.FreezeAddress, "", address, valueSize, value);
            }
        }

        private void DeleteAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteAddress();
        }

        private void DeleteAddress()
        {
            try
            {
                int index = lvStoredAddresses.SelectedIndices[0];
                lvStoredAddresses.Items.RemoveAt(index);
            }
            catch
            {
                MessageBox.Show(this.Owner, "Could not delete address.");
            }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.IPAddress = txtIPAddress.Text;
            Properties.Settings.Default.Save();
        }

        private void txtDisplayAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
