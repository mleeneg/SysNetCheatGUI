namespace SysNetCheatGUI
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
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
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.lvAddress = new System.Windows.Forms.ListView();
            this.colAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvStoredAddresses = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsStoredAddress = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblFound = new System.Windows.Forms.Label();
            this.lblCountFound = new System.Windows.Forms.Label();
            this.btnAddAddress = new System.Windows.Forms.Button();
            this.btnRemoveAddress = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.gbValueSize.SuspendLayout();
            this.cmsStoredAddress.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(104, 29);
            this.txtIPAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(98, 20);
            this.txtIPAddress.TabIndex = 0;
            this.txtIPAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIPAddress_KeyPress);
            // 
            // lblSwitchIPAddress
            // 
            this.lblSwitchIPAddress.AutoSize = true;
            this.lblSwitchIPAddress.Location = new System.Drawing.Point(9, 29);
            this.lblSwitchIPAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSwitchIPAddress.Name = "lblSwitchIPAddress";
            this.lblSwitchIPAddress.Size = new System.Drawing.Size(93, 13);
            this.lblSwitchIPAddress.TabIndex = 1;
            this.lblSwitchIPAddress.Text = "Switch IP Address";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(292, 59);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(84, 19);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(242, 84);
            this.txtValue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(134, 20);
            this.txtValue.TabIndex = 0;
            this.txtValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValue_KeyPress);
            // 
            // btnNewSearch
            // 
            this.btnNewSearch.Location = new System.Drawing.Point(206, 59);
            this.btnNewSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNewSearch.Name = "btnNewSearch";
            this.btnNewSearch.Size = new System.Drawing.Size(82, 19);
            this.btnNewSearch.TabIndex = 2;
            this.btnNewSearch.Text = "New Search";
            this.btnNewSearch.UseVisualStyleBackColor = true;
            this.btnNewSearch.Click += new System.EventHandler(this.btnNewSearch_Click);
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(204, 87);
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
            this.gbValueSize.Location = new System.Drawing.Point(381, 32);
            this.gbValueSize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbValueSize.Name = "gbValueSize";
            this.gbValueSize.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbValueSize.Size = new System.Drawing.Size(123, 71);
            this.gbValueSize.TabIndex = 4;
            this.gbValueSize.TabStop = false;
            this.gbValueSize.Text = "Value Size";
            // 
            // radU64
            // 
            this.radU64.AutoSize = true;
            this.radU64.Location = new System.Drawing.Point(63, 39);
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
            this.radU32.Location = new System.Drawing.Point(11, 39);
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
            this.radU16.Location = new System.Drawing.Point(63, 17);
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
            this.btnConnectSwitch.Location = new System.Drawing.Point(206, 29);
            this.btnConnectSwitch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnConnectSwitch.Name = "btnConnectSwitch";
            this.btnConnectSwitch.Size = new System.Drawing.Size(82, 19);
            this.btnConnectSwitch.TabIndex = 5;
            this.btnConnectSwitch.Text = "Connect";
            this.btnConnectSwitch.UseVisualStyleBackColor = true;
            this.btnConnectSwitch.Click += new System.EventHandler(this.btnConnectSwitch_Click);
            // 
            // txtConsole
            // 
            this.txtConsole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsole.Location = new System.Drawing.Point(204, 107);
            this.txtConsole.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConsole.Size = new System.Drawing.Size(301, 140);
            this.txtConsole.TabIndex = 9;
            // 
            // lvAddress
            // 
            this.lvAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvAddress.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAddress,
            this.colValue});
            this.lvAddress.FullRowSelect = true;
            this.lvAddress.GridLines = true;
            this.lvAddress.Location = new System.Drawing.Point(9, 59);
            this.lvAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lvAddress.MultiSelect = false;
            this.lvAddress.Name = "lvAddress";
            this.lvAddress.Size = new System.Drawing.Size(192, 224);
            this.lvAddress.TabIndex = 13;
            this.lvAddress.UseCompatibleStateImageBehavior = false;
            this.lvAddress.View = System.Windows.Forms.View.Details;
            this.lvAddress.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvAddress_MouseDoubleClick);
            // 
            // colAddress
            // 
            this.colAddress.Text = "Address";
            this.colAddress.Width = 93;
            // 
            // colValue
            // 
            this.colValue.Text = "Value";
            this.colValue.Width = 100;
            // 
            // lvStoredAddresses
            // 
            this.lvStoredAddresses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvStoredAddresses.CheckBoxes = true;
            this.lvStoredAddresses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader2,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader1});
            this.lvStoredAddresses.ContextMenuStrip = this.cmsStoredAddress;
            this.lvStoredAddresses.FullRowSelect = true;
            this.lvStoredAddresses.GridLines = true;
            this.lvStoredAddresses.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvStoredAddresses.Location = new System.Drawing.Point(9, 288);
            this.lvStoredAddresses.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lvStoredAddresses.MultiSelect = false;
            this.lvStoredAddresses.Name = "lvStoredAddresses";
            this.lvStoredAddresses.Size = new System.Drawing.Size(494, 152);
            this.lvStoredAddresses.TabIndex = 14;
            this.lvStoredAddresses.UseCompatibleStateImageBehavior = false;
            this.lvStoredAddresses.View = System.Windows.Forms.View.Details;
            this.lvStoredAddresses.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvStoredAddresses_ItemCheck);
            this.lvStoredAddresses.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvStoredAddresses_ItemChecked);
            this.lvStoredAddresses.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvStoredAddresses_MouseDoubleClick);
            this.lvStoredAddresses.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvStoredAddresses_MouseDown);
            this.lvStoredAddresses.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvStoredAddresses_MouseUp);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "";
            this.columnHeader4.Width = 25;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ID";
            this.columnHeader2.Width = 50;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Address";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Name";
            this.columnHeader6.Width = 130;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Value Size";
            this.columnHeader7.Width = 86;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Value";
            // 
            // cmsStoredAddress
            // 
            this.cmsStoredAddress.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsStoredAddress.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editNameToolStripMenuItem,
            this.editValueToolStripMenuItem,
            this.deleteAddressToolStripMenuItem});
            this.cmsStoredAddress.Name = "cmsStoredAddress";
            this.cmsStoredAddress.Size = new System.Drawing.Size(153, 70);
            // 
            // editNameToolStripMenuItem
            // 
            this.editNameToolStripMenuItem.Name = "editNameToolStripMenuItem";
            this.editNameToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.editNameToolStripMenuItem.Text = "Edit Name";
            this.editNameToolStripMenuItem.Click += new System.EventHandler(this.editNameToolStripMenuItem_Click);
            // 
            // editValueToolStripMenuItem
            // 
            this.editValueToolStripMenuItem.Name = "editValueToolStripMenuItem";
            this.editValueToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.editValueToolStripMenuItem.Text = "Edit Value";
            this.editValueToolStripMenuItem.Click += new System.EventHandler(this.editValueToolStripMenuItem_Click);
            // 
            // deleteAddressToolStripMenuItem
            // 
            this.deleteAddressToolStripMenuItem.Name = "deleteAddressToolStripMenuItem";
            this.deleteAddressToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteAddressToolStripMenuItem.Text = "Delete Address";
            this.deleteAddressToolStripMenuItem.Click += new System.EventHandler(this.deleteAddressToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(509, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // lblFound
            // 
            this.lblFound.AutoSize = true;
            this.lblFound.Location = new System.Drawing.Point(9, 43);
            this.lblFound.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFound.Name = "lblFound";
            this.lblFound.Size = new System.Drawing.Size(37, 13);
            this.lblFound.TabIndex = 16;
            this.lblFound.Text = "Found";
            // 
            // lblCountFound
            // 
            this.lblCountFound.AutoSize = true;
            this.lblCountFound.Location = new System.Drawing.Point(45, 43);
            this.lblCountFound.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCountFound.Name = "lblCountFound";
            this.lblCountFound.Size = new System.Drawing.Size(13, 13);
            this.lblCountFound.TabIndex = 17;
            this.lblCountFound.Text = "0";
            // 
            // btnAddAddress
            // 
            this.btnAddAddress.Image = ((System.Drawing.Image)(resources.GetObject("btnAddAddress.Image")));
            this.btnAddAddress.Location = new System.Drawing.Point(422, 252);
            this.btnAddAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddAddress.Name = "btnAddAddress";
            this.btnAddAddress.Size = new System.Drawing.Size(39, 31);
            this.btnAddAddress.TabIndex = 18;
            this.btnAddAddress.UseVisualStyleBackColor = true;
            this.btnAddAddress.Click += new System.EventHandler(this.btnAddAddress_Click);
            // 
            // btnRemoveAddress
            // 
            this.btnRemoveAddress.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveAddress.Image")));
            this.btnRemoveAddress.Location = new System.Drawing.Point(465, 252);
            this.btnRemoveAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRemoveAddress.Name = "btnRemoveAddress";
            this.btnRemoveAddress.Size = new System.Drawing.Size(39, 31);
            this.btnRemoveAddress.TabIndex = 19;
            this.btnRemoveAddress.UseVisualStyleBackColor = true;
            this.btnRemoveAddress.Click += new System.EventHandler(this.btnRemoveAddress_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(292, 29);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(84, 19);
            this.btnDisconnect.TabIndex = 20;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 448);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnRemoveAddress);
            this.Controls.Add(this.btnAddAddress);
            this.Controls.Add(this.lblCountFound);
            this.Controls.Add(this.lblFound);
            this.Controls.Add(this.lvStoredAddresses);
            this.Controls.Add(this.lvAddress);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.btnConnectSwitch);
            this.Controls.Add(this.gbValueSize);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.btnNewSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.lblSwitchIPAddress);
            this.Controls.Add(this.txtIPAddress);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.Text = "SysNetCheatGUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.gbValueSize.ResumeLayout(false);
            this.gbValueSize.PerformLayout();
            this.cmsStoredAddress.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.Label lblSwitchIPAddress;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnNewSearch;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.GroupBox gbValueSize;
        private System.Windows.Forms.RadioButton radU64;
        private System.Windows.Forms.RadioButton radU32;
        private System.Windows.Forms.RadioButton radU16;
        private System.Windows.Forms.RadioButton radU8;
        private System.Windows.Forms.Button btnConnectSwitch;
        private System.Windows.Forms.ColumnHeader colAddress;
        private System.Windows.Forms.ColumnHeader colValue;
        private System.Windows.Forms.ListView lvStoredAddresses;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label lblFound;
        public System.Windows.Forms.TextBox txtValue;
        public System.Windows.Forms.TextBox txtConsole;
        public System.Windows.Forms.ListView lvAddress;
        public System.Windows.Forms.Label lblCountFound;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnAddAddress;
        private System.Windows.Forms.Button btnRemoveAddress;
        private System.Windows.Forms.ContextMenuStrip cmsStoredAddress;
        private System.Windows.Forms.ToolStripMenuItem editNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editValueToolStripMenuItem;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.ToolStripMenuItem deleteAddressToolStripMenuItem;
    }
}

