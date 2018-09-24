namespace SysNetCheatGUI
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.lblSwitchIPAddress = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.btnNewSearch = new System.Windows.Forms.Button();
            this.lblValue = new System.Windows.Forms.Label();
            this.gbValueSize = new System.Windows.Forms.GroupBox();
            this.radU64 = new System.Windows.Forms.RadioButton();
            this.radU32 = new System.Windows.Forms.RadioButton();
            this.radU16 = new System.Windows.Forms.RadioButton();
            this.radU8 = new System.Windows.Forms.RadioButton();
            this.btnConnectSwitch = new System.Windows.Forms.Button();
            this.lbAddress = new System.Windows.Forms.ListBox();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.clbAddresses = new System.Windows.Forms.CheckedListBox();
            this.lblConsole = new System.Windows.Forms.Label();
            this.gbValueSize.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(104, 7);
            this.txtIPAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(98, 20);
            this.txtIPAddress.TabIndex = 0;
            this.txtIPAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIPAddress_KeyPress);
            // 
            // lblSwitchIPAddress
            // 
            this.lblSwitchIPAddress.AutoSize = true;
            this.lblSwitchIPAddress.Location = new System.Drawing.Point(9, 7);
            this.lblSwitchIPAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSwitchIPAddress.Name = "lblSwitchIPAddress";
            this.lblSwitchIPAddress.Size = new System.Drawing.Size(93, 13);
            this.lblSwitchIPAddress.TabIndex = 1;
            this.lblSwitchIPAddress.Text = "Switch IP Address";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(298, 37);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(89, 19);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(243, 65);
            this.txtValue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(146, 20);
            this.txtValue.TabIndex = 0;
            this.txtValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValue_KeyPress);
            // 
            // btnNewSearch
            // 
            this.btnNewSearch.Location = new System.Drawing.Point(208, 37);
            this.btnNewSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNewSearch.Name = "btnNewSearch";
            this.btnNewSearch.Size = new System.Drawing.Size(86, 19);
            this.btnNewSearch.TabIndex = 2;
            this.btnNewSearch.Text = "New Search";
            this.btnNewSearch.UseVisualStyleBackColor = true;
            this.btnNewSearch.Click += new System.EventHandler(this.btnNewSearch_Click);
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(206, 67);
            this.lblValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(34, 13);
            this.lblValue.TabIndex = 3;
            this.lblValue.Text = "Value";
            // 
            // gbValueSize
            // 
            this.gbValueSize.Controls.Add(this.radU64);
            this.gbValueSize.Controls.Add(this.radU32);
            this.gbValueSize.Controls.Add(this.radU16);
            this.gbValueSize.Controls.Add(this.radU8);
            this.gbValueSize.Location = new System.Drawing.Point(208, 88);
            this.gbValueSize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbValueSize.Name = "gbValueSize";
            this.gbValueSize.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbValueSize.Size = new System.Drawing.Size(180, 41);
            this.gbValueSize.TabIndex = 4;
            this.gbValueSize.TabStop = false;
            this.gbValueSize.Text = "Value Size";
            // 
            // radU64
            // 
            this.radU64.AutoSize = true;
            this.radU64.Location = new System.Drawing.Point(126, 17);
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
            this.radU32.Location = new System.Drawing.Point(86, 17);
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
            this.radU16.Location = new System.Drawing.Point(46, 17);
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
            // btnConnectSwitch
            // 
            this.btnConnectSwitch.Location = new System.Drawing.Point(208, 7);
            this.btnConnectSwitch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnConnectSwitch.Name = "btnConnectSwitch";
            this.btnConnectSwitch.Size = new System.Drawing.Size(180, 19);
            this.btnConnectSwitch.TabIndex = 5;
            this.btnConnectSwitch.Text = "Connect";
            this.btnConnectSwitch.UseVisualStyleBackColor = true;
            this.btnConnectSwitch.Click += new System.EventHandler(this.btnConnectSwitch_Click);
            // 
            // lbAddress
            // 
            this.lbAddress.ColumnWidth = 15;
            this.lbAddress.FormattingEnabled = true;
            this.lbAddress.Items.AddRange(new object[] {
            "Address; Value"});
            this.lbAddress.Location = new System.Drawing.Point(9, 36);
            this.lbAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbAddress.MultiColumn = true;
            this.lbAddress.Name = "lbAddress";
            this.lbAddress.Size = new System.Drawing.Size(193, 225);
            this.lbAddress.TabIndex = 8;
            this.lbAddress.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbAddress_MouseDoubleClick);
            // 
            // txtConsole
            // 
            this.txtConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsole.Location = new System.Drawing.Point(209, 148);
            this.txtConsole.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConsole.Size = new System.Drawing.Size(180, 251);
            this.txtConsole.TabIndex = 9;
            // 
            // clbAddresses
            // 
            this.clbAddresses.FormattingEnabled = true;
            this.clbAddresses.Location = new System.Drawing.Point(9, 275);
            this.clbAddresses.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.clbAddresses.Name = "clbAddresses";
            this.clbAddresses.Size = new System.Drawing.Size(193, 124);
            this.clbAddresses.TabIndex = 11;
            // 
            // lblConsole
            // 
            this.lblConsole.AutoSize = true;
            this.lblConsole.Location = new System.Drawing.Point(206, 132);
            this.lblConsole.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConsole.Name = "lblConsole";
            this.lblConsole.Size = new System.Drawing.Size(45, 13);
            this.lblConsole.TabIndex = 12;
            this.lblConsole.Text = "Console";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 410);
            this.Controls.Add(this.lblConsole);
            this.Controls.Add(this.clbAddresses);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.lbAddress);
            this.Controls.Add(this.btnConnectSwitch);
            this.Controls.Add(this.gbValueSize);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.btnNewSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.lblSwitchIPAddress);
            this.Controls.Add(this.txtIPAddress);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmMain";
            this.Text = "sys-netcheat GUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.gbValueSize.ResumeLayout(false);
            this.gbValueSize.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.Label lblSwitchIPAddress;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Button btnNewSearch;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.GroupBox gbValueSize;
        private System.Windows.Forms.RadioButton radU64;
        private System.Windows.Forms.RadioButton radU32;
        private System.Windows.Forms.RadioButton radU16;
        private System.Windows.Forms.RadioButton radU8;
        private System.Windows.Forms.Button btnConnectSwitch;
        private System.Windows.Forms.ListBox lbAddress;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.CheckedListBox clbAddresses;
        private System.Windows.Forms.Label lblConsole;
    }
}

