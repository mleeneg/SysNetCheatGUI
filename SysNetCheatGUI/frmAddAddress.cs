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
    public partial class FrmAddAddress : Form
    {
        private string _addressValue;
        public string Description = "";
        public string Address = "";
        public string AddressValue
        {
            get { return _addressValue;}
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
        public string ValueType = "";
        public bool PokeAddress = false;
        public FrmAddAddress()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Description = txtDescription.Text;
            Address = txtAddress.Text;
            AddressValue = txtValue.Text;
            ValueType = SearchSize;
            if (cbPoke.Checked)
            {
                PokeAddress = true;
            }
            if (ValueType != "0")
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

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
    }
}
