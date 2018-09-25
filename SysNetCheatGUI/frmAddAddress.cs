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

        public FrmAddAddress()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddressName = txtName.Text;
            Address = txtAddress.Text;
            Value = txtValue.Text;
            ValueSize = GetSearchSize();
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

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
    }
}
