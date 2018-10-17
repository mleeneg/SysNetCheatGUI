﻿namespace SysNetCheatGUI
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
            this.gbValueSize = new System.Windows.Forms.GroupBox();
            this.radU64 = new System.Windows.Forms.RadioButton();
            this.radU32 = new System.Windows.Forms.RadioButton();
            this.radU16 = new System.Windows.Forms.RadioButton();
            this.radU8 = new System.Windows.Forms.RadioButton();
            this.gbValueSize.SuspendLayout();
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
            this.label4.Location = new System.Drawing.Point(10, 107);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Value";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(140, 136);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(56, 19);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(201, 136);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 19);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(80, 3);
            this.txtName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(178, 20);
            this.txtName.TabIndex = 6;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(80, 31);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(178, 20);
            this.txtAddress.TabIndex = 7;
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(81, 105);
            this.txtValue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(178, 20);
            this.txtValue.TabIndex = 8;
            // 
            // gbValueSize
            // 
            this.gbValueSize.Controls.Add(this.radU64);
            this.gbValueSize.Controls.Add(this.radU32);
            this.gbValueSize.Controls.Add(this.radU16);
            this.gbValueSize.Controls.Add(this.radU8);
            this.gbValueSize.Location = new System.Drawing.Point(12, 54);
            this.gbValueSize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbValueSize.Name = "gbValueSize";
            this.gbValueSize.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbValueSize.Size = new System.Drawing.Size(246, 41);
            this.gbValueSize.TabIndex = 9;
            this.gbValueSize.TabStop = false;
            this.gbValueSize.Text = "Value Size";
            // 
            // radU64
            // 
            this.radU64.AutoSize = true;
            this.radU64.Location = new System.Drawing.Point(202, 17);
            this.radU64.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radU64.Name = "radU64";
            this.radU64.Size = new System.Drawing.Size(43, 17);
            this.radU64.TabIndex = 3;
            this.radU64.TabStop = true;
            this.radU64.Text = "u64";
            this.radU64.UseVisualStyleBackColor = true;
            // 
            // radU32
            // 
            this.radU32.AutoSize = true;
            this.radU32.Location = new System.Drawing.Point(141, 17);
            this.radU32.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radU32.Name = "radU32";
            this.radU32.Size = new System.Drawing.Size(43, 17);
            this.radU32.TabIndex = 2;
            this.radU32.TabStop = true;
            this.radU32.Text = "u32";
            this.radU32.UseVisualStyleBackColor = true;
            // 
            // radU16
            // 
            this.radU16.AutoSize = true;
            this.radU16.Location = new System.Drawing.Point(69, 17);
            this.radU16.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radU16.Name = "radU16";
            this.radU16.Size = new System.Drawing.Size(43, 17);
            this.radU16.TabIndex = 1;
            this.radU16.TabStop = true;
            this.radU16.Text = "u16";
            this.radU16.UseVisualStyleBackColor = true;
            // 
            // radU8
            // 
            this.radU8.AutoSize = true;
            this.radU8.Location = new System.Drawing.Point(13, 17);
            this.radU8.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radU8.Name = "radU8";
            this.radU8.Size = new System.Drawing.Size(37, 17);
            this.radU8.TabIndex = 0;
            this.radU8.TabStop = true;
            this.radU8.Text = "u8";
            this.radU8.UseVisualStyleBackColor = true;
            // 
            // FrmAddAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 160);
            this.Controls.Add(this.gbValueSize);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddAddress";
            this.ShowIcon = false;
            this.Text = "Add Address";
            this.gbValueSize.ResumeLayout(false);
            this.gbValueSize.PerformLayout();
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
        private System.Windows.Forms.GroupBox gbValueSize;
        private System.Windows.Forms.RadioButton radU64;
        private System.Windows.Forms.RadioButton radU32;
        private System.Windows.Forms.RadioButton radU16;
        private System.Windows.Forms.RadioButton radU8;
    }
}