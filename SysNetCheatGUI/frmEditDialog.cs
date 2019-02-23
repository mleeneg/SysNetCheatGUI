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
    public partial class FrmEditDialog : Form
    {
        private string _addressValue;
        public string ValueType;

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

        public FrmEditDialog(string labeltext)
        {
            InitializeComponent();
            lblText.Text = labeltext;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            AddressValue = txtValue.Text;
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
