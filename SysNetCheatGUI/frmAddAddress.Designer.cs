namespace SysNetCheatGUI
{
    partial class FrmAddAddress
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.cbValueType = new System.Windows.Forms.ComboBox();
            this.lblValueType = new System.Windows.Forms.Label();
            this.cbPoke = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 91);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Value";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(141, 109);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(56, 19);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(202, 109);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 19);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(93, 3);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(165, 20);
            this.txtName.TabIndex = 6;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(93, 31);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(2);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(165, 20);
            this.txtAddress.TabIndex = 7;
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(93, 84);
            this.txtValue.Margin = new System.Windows.Forms.Padding(2);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(165, 20);
            this.txtValue.TabIndex = 8;
            // 
            // cbValueType
            // 
            this.cbValueType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbValueType.FormattingEnabled = true;
            this.cbValueType.Items.AddRange(new object[] {
            "u8",
            "u16",
            "u32",
            "u64"});
            this.cbValueType.Location = new System.Drawing.Point(93, 58);
            this.cbValueType.Name = "cbValueType";
            this.cbValueType.Size = new System.Drawing.Size(165, 21);
            this.cbValueType.TabIndex = 24;
            // 
            // lblValueType
            // 
            this.lblValueType.AutoSize = true;
            this.lblValueType.Location = new System.Drawing.Point(9, 61);
            this.lblValueType.Name = "lblValueType";
            this.lblValueType.Size = new System.Drawing.Size(61, 13);
            this.lblValueType.TabIndex = 23;
            this.lblValueType.Text = "Value Type";
            // 
            // cbPoke
            // 
            this.cbPoke.AutoSize = true;
            this.cbPoke.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbPoke.Location = new System.Drawing.Point(10, 112);
            this.cbPoke.Name = "cbPoke";
            this.cbPoke.Size = new System.Drawing.Size(98, 17);
            this.cbPoke.TabIndex = 25;
            this.cbPoke.Text = "Poke Address?";
            this.cbPoke.UseVisualStyleBackColor = true;
            // 
            // FrmAddAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 131);
            this.Controls.Add(this.cbPoke);
            this.Controls.Add(this.cbValueType);
            this.Controls.Add(this.lblValueType);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddAddress";
            this.ShowIcon = false;
            this.Text = "Add Address";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.ComboBox cbValueType;
        private System.Windows.Forms.Label lblValueType;
        private System.Windows.Forms.CheckBox cbPoke;
    }
}