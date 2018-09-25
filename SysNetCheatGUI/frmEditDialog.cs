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
        public string Value = "";

        public FrmEditDialog(string labeltext)
        {
            InitializeComponent();
            lblText.Text = labeltext;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Value = txtValue.Text;
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
