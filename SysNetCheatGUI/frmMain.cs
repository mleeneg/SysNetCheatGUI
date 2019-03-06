using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using SysNetCheatGUI.Properties;

namespace SysNetCheatGUI
{
    public partial class FrmMain : Form
    {
        private readonly string _editName = "Edit Name";
        private readonly string _editValue = "Edit AddressValue";
        private string _addressValue = "";

        public bool InhibitAutoCheck;
        public Switch MySwitch;
        public bool OkayToStartSearch;

        public string AddressValue
        {
            get { return _addressValue; }
            set
            {
                try
                {
                    long num = 0;
                    switch (this.SearchSize)
                    {
                        case "u8":
                            num = int.Parse(value);
                            if (num >= 255)
                            {
                                num = 255;
                                _addressValue = num.ToString();
                            }
                            else
                            {
                                _addressValue = num.ToString();
                            }

                            break;
                        case "u16":
                            num = int.Parse(value);
                            if (num >= ushort.MaxValue)
                            {
                                num = ushort.MaxValue;
                                _addressValue = num.ToString();
                            }
                            else
                            {
                                _addressValue = num.ToString();
                            }

                            break;
                        case "u32":
                            num = Int32.Parse(value);
                            if (num >= uint.MaxValue)
                            {
                                num = uint.MaxValue;
                                _addressValue = num.ToString();
                            }
                            else
                            {
                                _addressValue = num.ToString();
                            }

                            break;
                        case "u64":
                            num = Int64.Parse(value);
                            if (num >= Convert.ToInt64(ulong.MaxValue))
                            {
                                num = Convert.ToInt64(ulong.MaxValue);
                                _addressValue = num.ToString();
                            }
                            else
                            {
                                _addressValue = num.ToString();
                            }

                            break;
                        default:
                            num = Int32.Parse(value);
                            if (num >= uint.MaxValue)
                            {
                                num = uint.MaxValue;
                                _addressValue = num.ToString();
                            }
                            else
                            {
                                _addressValue = num.ToString();
                            }

                            break;
                    }
                }
                catch
                {
                    _addressValue = "0";
                }
            }
        }

        public FrmMain()
        {
            InitializeComponent();
            cbValueType.SelectedIndex = 2;
            txtDisplayAmount.Text = "1000";
            this.cFreeze.Name = "cFreeze";
            this.cID.Name = "cID";
            this.cDescription.Name = "cDescription";
            this.cAddress.Name = "cAddress";
            this.cValueType.Name = "cValueType";
            this.cValue.Name = "cValue";
            this.colAddress.Name = "colAddress";
            this.colValue.Name = "colValue";
        }

        /// <summary>
        ///     Gets the Search size.
        ///     String: u8, u16, u32, or u64
        /// </summary>
        /// <returns></returns>
        private string SearchSize
        {
            get
            {
                var valueType = "0";
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
                    var ip = txtIPAddress.Text;

                    try
                    {
                        //Try to connect to Ip Address
                        MySwitch.Connect(ip);
                        //if IsConnected
                        if (MySwitch.IsConnected) EnableForm(true, false);
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
            var validDisplayAmount = int.TryParse(txtDisplayAmount.Text, out MySwitch.DisplayAmount);
            if (MySwitch.DisplayAmount < 100 || MySwitch.DisplayAmount > 10000) validDisplayAmount = false;

            var valid = int.TryParse(txtValue.Text, out var value);
            //if GetSearchSize doesn't return Invalid response
            if (SearchSize != "0" && valid && validDisplayAmount)
                OkayToStartSearch = true;
            else
                MessageBox.Show("Search Not Valid!");

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
                
                MySwitch.SendCommand(MySwitch.SearchString(),"","",SearchSize, value.ToString());
            }
            else
            {
                MessageBox.Show("AddressValue Must Be Entered!");
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;

            if (e.KeyChar == (char) 13) btnSearch_Click(sender, e);
        }

        private void txtIPAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) 13) btnConnectSwitch_Click(sender, e);
        }

        private void lvAddress_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            AddAddress();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySwitch?.Disconnect(false);
            Close();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            EnableForm(false, false);
            txtIPAddress.Text = Settings.Default.IPAddress;
        }

        private void editValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditAddressValue();
        }

        private void btnAddAddress_Click(object sender, EventArgs e)
        {
            using (var addAddress = new FrmAddAddress())
            {
                if (addAddress.ShowDialog() == DialogResult.OK) ManuallyAddAddress(addAddress);
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
            using (var about = new FrmAbout())
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

        public int GetColumnID(ListView listView, string header)
        {
            return listView.Columns[header].Index;
        }
        private void AddAddress()
        {
            var index = lvAddress.SelectedIndex();

            using (var editValue = new FrmEditDialog(MessageType.AddressValue, cbValueType.Text))
            {
                if (editValue.ShowDialog() == DialogResult.OK)
                {
                    //Check if address exist
                    //Get Stored Address Count
                    //If more than 0 
                    
                    var count = lvStoredAddresses.Items.Count;
                    if (count > 0)
                    {
                        var found = false;
                        //Loop thru the addresses
                        for (var i = 0; i < count; i++)
                        {
                            var address = lvStoredAddresses.Items[i].SubItems[GetColumnID(lvStoredAddresses, "cAddress")].Text;
                            address = address.Split(' ')[0];
                            //If address found
                            if (lvAddress.Items[index].SubItems[GetColumnID(lvAddress,"colAddress")].Text == address)
                            {
                                found = true;
                                //Edit Existing Address
                                lvStoredAddresses.Items[i].SubItems[GetColumnID(lvStoredAddresses, "cValue")].Text = editValue.OutputValue;
                                break;
                            }
                        }

                        if (!found)
                            lvStoredAddresses.Items.Add(AddListViewItem(
                                lvAddress.Items[index].SubItems[GetColumnID(lvAddress, "colAddress")].Text, "", SearchSize,
                                editValue.OutputValue));
                    }
                    else
                    {
                        //Else Add a new Address
                        lvStoredAddresses.Items.Add(AddListViewItem(lvAddress.Items[index].SubItems[GetColumnID(lvAddress, "colAddress")].Text, "",
                            SearchSize, editValue.OutputValue));
                    }
                }

                if (editValue.cbPoke.Checked)
                {
                    MySwitch.SendCommand(Commands.PokeAddress, "",
                        lvAddress.Items[index].SubItems[GetColumnID(lvAddress, "colAddress")].Text,
                        SearchSize, editValue.OutputValue);
                }
            }
        }

        private void ManuallyAddAddress(FrmAddAddress frmAddAddress)
        {
            //Check if address exist
            //Get Stored Address Count
            //If more than 0 
            var count = lvStoredAddresses.Items.Count;
            if (count > 0)
            {
                var found = false;
                //Loop thru the addresses
                for (var i = 0; i < count; i++)
                {
                    var address = lvStoredAddresses.Items[i].SubItems[GetColumnID(lvStoredAddresses, "cAddress")].Text;
                    address = address.Split(' ')[0];
                    //If address found
                    if (frmAddAddress.Address != address) continue;
                    found = true;
                    //Edit Existing Address
                    lvStoredAddresses.Items[i].SubItems[GetColumnID(lvStoredAddresses, "cDescription")].Text = frmAddAddress.Description;
                    lvStoredAddresses.Items[i].SubItems[GetColumnID(lvStoredAddresses, "cValueType")].Text = frmAddAddress.ValueType;
                    lvStoredAddresses.Items[i].SubItems[GetColumnID(lvStoredAddresses, "cValue")].Text = frmAddAddress.AddressValue;
                    break;
                }

                if (!found)
                    lvStoredAddresses.Items.Add(AddListViewItem(frmAddAddress.Address, frmAddAddress.Description,
                        frmAddAddress.ValueType,
                        frmAddAddress.AddressValue));
            }
            else
            {
                //Else Add a new Address
                lvStoredAddresses.Items.Add(AddListViewItem(frmAddAddress.Address, frmAddAddress.Description,
                    frmAddAddress.ValueType,
                    frmAddAddress.AddressValue));
            }

            if (frmAddAddress.PokeAddress)
                MySwitch.SendCommand(Commands.PokeAddress, "", frmAddAddress.Address,
                    frmAddAddress.ValueType, frmAddAddress.AddressValue);
        }

        private void ManuallyAddAddress(AddressItem item)
        {
            //Check if address exist
            //Get Stored Address Count
            //If more than 0 
            var count = lvStoredAddresses.Items.Count;
            if (count > 0)
            {
                var found = false;
                //Loop thru the addresses
                for (var i = 0; i < count; i++)
                {
                    var address = lvStoredAddresses.Items[i].SubItems[GetColumnID(lvStoredAddresses, "cAddress")].Text;
                    address = address.Split(' ')[0];
                    //If address found
                    if (item.Address != address) continue;
                    found = true;
                    //Edit Existing Address
                    lvStoredAddresses.Items[i].SubItems[GetColumnID(lvStoredAddresses, "cDescription")].Text = item.Description;
                    lvStoredAddresses.Items[i].SubItems[GetColumnID(lvStoredAddresses, "cValueType")].Text = item.ValueType;
                    lvStoredAddresses.Items[i].SubItems[GetColumnID(lvStoredAddresses, "cValue")].Text = item.AddressValue;
                    break;
                }

                if (!found)
                    lvStoredAddresses.Items.Add(AddListViewItem(item.Address, item.Description,
                        item.ValueType,
                        item.AddressValue));
            }
            else
            {
                //Else Add a new Address
                lvStoredAddresses.Items.Add(AddListViewItem(item.Address, item.Description,
                    item.ValueType,
                    item.AddressValue));
            }
        }

        private void EditAddressValue()
        {
            var index = lvStoredAddresses.SelectedIndex();
            try
            {
                if (lvStoredAddresses.Items[index].SubItems[GetColumnID(lvStoredAddresses, "cAddress")].Text == "") return;
                using (var editValue = new FrmEditDialog(MessageType.AddressValue, lvStoredAddresses.Items[index]
                    .SubItems[GetColumnID(lvStoredAddresses, "cValueType")].Text))
                {
                    if (editValue.ShowDialog() != DialogResult.OK) return;
                    //Edit Existing Address
                    lvStoredAddresses.Items[index].SubItems[GetColumnID(lvStoredAddresses, "cValue")].Text = editValue.OutputValue;

                    if (editValue.cbPoke.Checked)
                    {
                        MySwitch.SendCommand(Commands.PokeAddress, "",
                            lvStoredAddresses.Items[index].SubItems[GetColumnID(lvStoredAddresses, "cAddress")].Text,
                            SearchSize, editValue.OutputValue);
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No Valid Address!");
            }
        }

        private void EditDescriptionValue()
        {
            var index = lvStoredAddresses.SelectedIndex();
            try
            {
                if (lvStoredAddresses.Items[index].SubItems[GetColumnID(lvStoredAddresses, "cAddress")].Text == "") return;
                using (var editValue = new FrmEditDialog(MessageType.Description))
                {
                    if (editValue.ShowDialog() == DialogResult.OK)
                        lvStoredAddresses.Items[index].SubItems[GetColumnID(lvStoredAddresses, "cDescription")].Text = editValue.OutputValue;
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
            var item = new ListViewItem();
            //Add to Item subset 1 Address
            item.SubItems.Add("");
            //Add to Item subset 2
            item.SubItems.Add(name);
            //Add to Item subset 3
            item.SubItems.Add(valueType);
            //Add to Item subset 4
            item.SubItems.Add(address);
            //Add to Item subset 5
            item.SubItems.Add(value);

            return item;
        }

        public void lvStoredAddresses_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                var index = lvStoredAddresses.SelectedIndex();
                MySwitch.SendCommand(Commands.PokeAddress, lvStoredAddresses.Items[index]);
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
            var count = 0;
            for (var i = 0; i < lvStoredAddresses.Items.Count; i++)
                if (lvStoredAddresses.Items[i].Checked)
                    count++;
                
            AddToFreeze(count);
            DeleteFromFreeze();
        }

        private void DeleteFromFreeze()
        {
            //loop thru list
            for (var i = 0; i < lvStoredAddresses.Items.Count; i++)
            {
                var id = lvStoredAddresses.Items[i].SubItems[GetColumnID(lvStoredAddresses, "cID")].Text;
                //Check if Checkboxes are checked and their IDs are not blank
                if (lvStoredAddresses.Items[i].Checked || id.Equals("")) continue;
                //Remove Frozen address at Index
                MySwitch.SendCommand(Commands.UnFreezeAddress, id, "", "", "");
                //Set ID to blank
                lvStoredAddresses.Items[i].SubItems[GetColumnID(lvStoredAddresses, "cID")].Text = "";
                //Modify IDs of other address.
                for (var p = 0; p < lvStoredAddresses.Items.Count; p++)
                {
                    if (!lvStoredAddresses.Items[p].Checked ||
                        int.Parse(lvStoredAddresses.Items[p].SubItems[GetColumnID(lvStoredAddresses, "cID")].Text) <= int.Parse(id)) continue;
                    var newId = int.Parse(lvStoredAddresses.Items[p].SubItems[GetColumnID(lvStoredAddresses, "cID")].Text) - 1;
                    lvStoredAddresses.Items[p].SubItems[GetColumnID(lvStoredAddresses, "cID")].Text = newId.ToString();
                }
            }
        }

        private void AddToFreeze(int count)
        {
            //Loop thru list
            for (var i = 0; i < lvStoredAddresses.Items.Count; i++)
            {
                var id = lvStoredAddresses.Items[i].SubItems[GetColumnID(lvStoredAddresses, "cID")].Text;
                //if checked & id is blank
                if (!lvStoredAddresses.Items[i].Checked || !id.Equals("")) continue;
                var address = lvStoredAddresses.Items[i].SubItems[GetColumnID(lvStoredAddresses, "cAddress")].Text;
                var valueType = lvStoredAddresses.Items[i].SubItems[GetColumnID(lvStoredAddresses, "cValueType")].Text;
                var value = lvStoredAddresses.Items[i].SubItems[GetColumnID(lvStoredAddresses, "cValue")].Text;

                lvStoredAddresses.Items[i].SubItems[1].Text = (count - 1).ToString();
                MySwitch.SendCommand(Commands.FreezeAddress, "", address, valueType, value);
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
                var index = lvStoredAddresses.SelectedIndices[0];
                lvStoredAddresses.Items.RemoveAt(index);
            }
            catch
            {
                MessageBox.Show(Owner, "Could not delete address.");
            }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.IPAddress = txtIPAddress.Text;
            Settings.Default.Save();
        }

        private void txtDisplayAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvStoredAddresses.Enabled == false)
            {
                MessageBox.Show("Not Connected.");
                return;
            }

            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {

                using (StreamReader r = new StreamReader(OpenFileDialog.FileName))
                {
                    string json = r.ReadToEnd();
                    List<AddressItem> items = JsonConvert.DeserializeObject<List<AddressItem>>(json);
                    switch (MessageBox.Show(
                        "Do you want to keep existing addresses?\r\nNOTE:Will replace old address's current value with new value in file but will not poke address.",
                        "Keep Existing Addresses?",
                        MessageBoxButtons.YesNoCancel))
                    {
                        case DialogResult.Yes:
                            LoadToReplace(items);
                            break;
                        case DialogResult.No:
                            LoadToExisting(items);
                            break;
                        case DialogResult.Cancel:
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void LoadToExisting(List<AddressItem> items)
        {
            foreach (var item in items)
            {
                ManuallyAddAddress(item);
            }
        }

        private void LoadToReplace(List<AddressItem> items)
        {
            lvStoredAddresses.Items.Clear();
            foreach (var item in items)
            {
                ManuallyAddAddress(item);
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvStoredAddresses.Items.Count <= 0)
            {
                MessageBox.Show("No Addresses Found.");
                return;
            }
            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //open file stream
                using (StreamWriter file = File.CreateText(SaveFileDialog.FileName))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    List<AddressItem> _data = new List<AddressItem>();
                    foreach (ListViewItem item in lvStoredAddresses.Items)
                    {
                        _data.Add(new AddressItem()
                        {
                            Description = item.SubItems[GetColumnID(lvStoredAddresses,"cDescription")].Text,
                            ValueType = item.SubItems[GetColumnID(lvStoredAddresses, "cValueType")].Text,
                            Address = item.SubItems[GetColumnID(lvStoredAddresses, "cAddress")].Text,
                            AddressValue = item.SubItems[GetColumnID(lvStoredAddresses, "cValue")].Text
                        });
                    }
                    
                    //serialize object directly into file stream
                    serializer.Formatting = Formatting.Indented;
                    serializer.Serialize(file, _data);
                }
            }
        }
    }
}