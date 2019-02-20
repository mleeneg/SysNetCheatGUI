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
        public string AddressName = "";
        public string Address = "";
        public string Value = "";
        public string ValueSize = "";
        public bool PokeAddress = false;
        public FrmAddAddress()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddressName = txtName.Text;
            Address = txtAddress.Text;
            Value = txtValue.Text;
            ValueSize = SearchSize;
            if (cbPoke.Checked)
            {
                PokeAddress = true;
            }
            if (ValueSize != "0")
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
    }
}
