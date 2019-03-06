using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysNetCheatGUI
{
    public enum MessageType
    {
        Address= 0,
        AddressValue = 1,
        Description = 2
    }

    public partial class FrmEditDialog : Form
    {
        private string _addressValue;
        private string _address;
        private string _description;

        public MessageType MessageType;
        public string OutputValue;
        public string ValueType;
        public string Address { get; set; }
        public string Description { get; set; }
        public string AddressValue
        {
            get { return _addressValue; }
            set
            {
                try
                {
                    long num = 0;
                    switch (this.ValueType)
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

        public FrmEditDialog(MessageType messageType)
        {
            InitializeComponent();
            MessageType = messageType;
            switch (MessageType)
            {
                case MessageType.Address:
                    lblText.Text = "Edit Address";
                    cbPoke.Visible = false;
                    break;
                case MessageType.AddressValue:
                    lblText.Text = "Edit Address Value";
                    cbPoke.Visible = true;
                    break;
                case MessageType.Description:
                    lblText.Text = "Edit Description";
                    cbPoke.Visible = false;
                    break;
            }
        }

        public FrmEditDialog(MessageType messageType, string vType)
        {
            InitializeComponent();
            MessageType = messageType;
            ValueType = vType;
            switch (MessageType)
            {
                case MessageType.Address:
                    lblText.Text = "Edit Address";
                    cbPoke.Visible = false;
                    break;
                case MessageType.AddressValue:
                    lblText.Text = "Edit Address Value";
                    cbPoke.Visible = true;
                    break;
                case MessageType.Description:
                    lblText.Text = "Edit Description";
                    cbPoke.Visible = false;
                    break;
            }
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            //check value
            switch (MessageType)
            {
                case MessageType.Address:
                    Address = txtValue.Text;
                    OutputValue = Address;
                    break;
                case MessageType.AddressValue:
                    AddressValue = txtValue.Text;
                    OutputValue = AddressValue;
                    break;
                case MessageType.Description:
                    Description = txtValue.Text;
                    OutputValue = Description;
                    break;
            }

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnOK_Click(sender, e);
            }
        }
    }
}
