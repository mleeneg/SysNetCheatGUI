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
            this.btnConnectSwitch = new System.Windows.Forms.Button();
            this.lvAddress = new System.Windows.Forms.ListView();
            this.colAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvStoredAddresses = new System.Windows.Forms.ListView();
            this.cFreeze = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cValueType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsStoredAddress = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editDescriptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblCountFound = new System.Windows.Forms.Label();
            this.btnAddAddress = new System.Windows.Forms.Button();
            this.btnRemoveAddress = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.lblValueType = new System.Windows.Forms.Label();
            this.cbValueType = new System.Windows.Forms.ComboBox();
            this.lblDisplayAmount = new System.Windows.Forms.Label();
            this.txtDisplayAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.cmsStoredAddress.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(104, 29);
            this.txtIPAddress.Margin = new System.Windows.Forms.Padding(2);
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
            this.btnSearch.Location = new System.Drawing.Point(328, 70);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(130, 19);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(266, 95);
            this.txtValue.Margin = new System.Windows.Forms.Padding(2);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(192, 20);
            this.txtValue.TabIndex = 0;
            this.txtValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValue_KeyPress);
            // 
            // btnNewSearch
            // 
            this.btnNewSearch.Location = new System.Drawing.Point(206, 70);
            this.btnNewSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewSearch.Name = "btnNewSearch";
            this.btnNewSearch.Size = new System.Drawing.Size(118, 19);
            this.btnNewSearch.TabIndex = 2;
            this.btnNewSearch.Text = "New Search";
            this.btnNewSearch.UseVisualStyleBackColor = true;
            this.btnNewSearch.Click += new System.EventHandler(this.btnNewSearch_Click);
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(204, 98);
            this.lblValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(34, 13);
            this.lblValue.TabIndex = 3;
            this.lblValue.Text = "Value";
            // 
            // btnConnectSwitch
            // 
            this.btnConnectSwitch.Location = new System.Drawing.Point(206, 29);
            this.btnConnectSwitch.Margin = new System.Windows.Forms.Padding(2);
            this.btnConnectSwitch.Name = "btnConnectSwitch";
            this.btnConnectSwitch.Size = new System.Drawing.Size(82, 19);
            this.btnConnectSwitch.TabIndex = 5;
            this.btnConnectSwitch.Text = "Connect";
            this.btnConnectSwitch.UseVisualStyleBackColor = true;
            this.btnConnectSwitch.Click += new System.EventHandler(this.btnConnectSwitch_Click);
            // 
            // lvAddress
            // 
            this.lvAddress.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAddress,
            this.colValue});
            this.lvAddress.FullRowSelect = true;
            this.lvAddress.GridLines = true;
            this.lvAddress.Location = new System.Drawing.Point(9, 69);
            this.lvAddress.Margin = new System.Windows.Forms.Padding(2);
            this.lvAddress.MultiSelect = false;
            this.lvAddress.Name = "lvAddress";
            this.lvAddress.Size = new System.Drawing.Size(192, 225);
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
            this.lvStoredAddresses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvStoredAddresses.CheckBoxes = true;
            this.lvStoredAddresses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cFreeze,
            this.cID,
            this.cDescription,
            this.cValueType,
            this.cAddress,
            this.cValue});
            this.lvStoredAddresses.ContextMenuStrip = this.cmsStoredAddress;
            this.lvStoredAddresses.FullRowSelect = true;
            this.lvStoredAddresses.GridLines = true;
            this.lvStoredAddresses.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvStoredAddresses.Location = new System.Drawing.Point(9, 299);
            this.lvStoredAddresses.Margin = new System.Windows.Forms.Padding(2);
            this.lvStoredAddresses.MultiSelect = false;
            this.lvStoredAddresses.Name = "lvStoredAddresses";
            this.lvStoredAddresses.Size = new System.Drawing.Size(453, 236);
            this.lvStoredAddresses.TabIndex = 14;
            this.lvStoredAddresses.UseCompatibleStateImageBehavior = false;
            this.lvStoredAddresses.View = System.Windows.Forms.View.Details;
            this.lvStoredAddresses.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvStoredAddresses_ItemCheck);
            this.lvStoredAddresses.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvStoredAddresses_ItemChecked);
            this.lvStoredAddresses.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvStoredAddresses_MouseDoubleClick);
            this.lvStoredAddresses.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvStoredAddresses_MouseDown);
            this.lvStoredAddresses.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvStoredAddresses_MouseUp);
            // 
            // cFreeze
            // 
            this.cFreeze.Text = "";
            this.cFreeze.Width = 25;
            // 
            // cID
            // 
            this.cID.Text = "ID";
            this.cID.Width = 50;
            // 
            // cDescription
            // 
            this.cDescription.Text = "Description";
            this.cDescription.Width = 130;
            // 
            // cValueType
            // 
            this.cValueType.Text = "ValueType";
            this.cValueType.Width = 86;
            // 
            // cAddress
            // 
            this.cAddress.Text = "Address";
            this.cAddress.Width = 100;
            // 
            // cValue
            // 
            this.cValue.Text = "Value";
            // 
            // cmsStoredAddress
            // 
            this.cmsStoredAddress.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsStoredAddress.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editDescriptionToolStripMenuItem,
            this.editValueToolStripMenuItem,
            this.deleteAddressToolStripMenuItem});
            this.cmsStoredAddress.Name = "cmsStoredAddress";
            this.cmsStoredAddress.Size = new System.Drawing.Size(168, 70);
            // 
            // editDescriptionToolStripMenuItem
            // 
            this.editDescriptionToolStripMenuItem.Name = "editDescriptionToolStripMenuItem";
            this.editDescriptionToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.editDescriptionToolStripMenuItem.Text = "Edit Description";
            this.editDescriptionToolStripMenuItem.Click += new System.EventHandler(this.editDescriptionToolStripMenuItem_Click);
            // 
            // editValueToolStripMenuItem
            // 
            this.editValueToolStripMenuItem.Name = "editValueToolStripMenuItem";
            this.editValueToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.editValueToolStripMenuItem.Text = "Edit AddressValue";
            this.editValueToolStripMenuItem.Click += new System.EventHandler(this.editValueToolStripMenuItem_Click);
            // 
            // deleteAddressToolStripMenuItem
            // 
            this.deleteAddressToolStripMenuItem.Name = "deleteAddressToolStripMenuItem";
            this.deleteAddressToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.deleteAddressToolStripMenuItem.Text = "Delete Address";
            this.deleteAddressToolStripMenuItem.Click += new System.EventHandler(this.DeleteAddressToolStripMenuItem_Click);
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
            this.menuStrip1.Size = new System.Drawing.Size(470, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
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
            // lblCountFound
            // 
            this.lblCountFound.AutoSize = true;
            this.lblCountFound.Location = new System.Drawing.Point(10, 53);
            this.lblCountFound.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCountFound.Name = "lblCountFound";
            this.lblCountFound.Size = new System.Drawing.Size(75, 13);
            this.lblCountFound.TabIndex = 17;
            this.lblCountFound.Text = "Displaying 0/0";
            // 
            // btnAddAddress
            // 
            this.btnAddAddress.Location = new System.Drawing.Point(206, 276);
            this.btnAddAddress.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddAddress.Name = "btnAddAddress";
            this.btnAddAddress.Size = new System.Drawing.Size(100, 19);
            this.btnAddAddress.TabIndex = 18;
            this.btnAddAddress.Text = "Add Address";
            this.btnAddAddress.UseVisualStyleBackColor = true;
            this.btnAddAddress.Click += new System.EventHandler(this.btnAddAddress_Click);
            // 
            // btnRemoveAddress
            // 
            this.btnRemoveAddress.Location = new System.Drawing.Point(313, 276);
            this.btnRemoveAddress.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveAddress.Name = "btnRemoveAddress";
            this.btnRemoveAddress.Size = new System.Drawing.Size(148, 19);
            this.btnRemoveAddress.TabIndex = 19;
            this.btnRemoveAddress.Text = "Remove Selected Address";
            this.btnRemoveAddress.UseVisualStyleBackColor = true;
            this.btnRemoveAddress.Click += new System.EventHandler(this.btnRemoveAddress_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(292, 29);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(2);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(84, 19);
            this.btnDisconnect.TabIndex = 20;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // lblValueType
            // 
            this.lblValueType.AutoSize = true;
            this.lblValueType.Location = new System.Drawing.Point(203, 122);
            this.lblValueType.Name = "lblValueType";
            this.lblValueType.Size = new System.Drawing.Size(61, 13);
            this.lblValueType.TabIndex = 21;
            this.lblValueType.Text = "Value Type";
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
            this.cbValueType.Location = new System.Drawing.Point(266, 120);
            this.cbValueType.Name = "cbValueType";
            this.cbValueType.Size = new System.Drawing.Size(191, 21);
            this.cbValueType.TabIndex = 22;
            // 
            // lblDisplayAmount
            // 
            this.lblDisplayAmount.AutoSize = true;
            this.lblDisplayAmount.Location = new System.Drawing.Point(203, 149);
            this.lblDisplayAmount.Name = "lblDisplayAmount";
            this.lblDisplayAmount.Size = new System.Drawing.Size(41, 13);
            this.lblDisplayAmount.TabIndex = 23;
            this.lblDisplayAmount.Text = "Display";
            // 
            // txtDisplayAmount
            // 
            this.txtDisplayAmount.Location = new System.Drawing.Point(266, 146);
            this.txtDisplayAmount.Margin = new System.Windows.Forms.Padding(2);
            this.txtDisplayAmount.Name = "txtDisplayAmount";
            this.txtDisplayAmount.Size = new System.Drawing.Size(191, 20);
            this.txtDisplayAmount.TabIndex = 24;
            this.txtDisplayAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDisplayAmount_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(263, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Between 100-10000";
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.Filter = "Code Files|*.json|All Files|*.*";
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.Filter = "Code File|*.json";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 546);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDisplayAmount);
            this.Controls.Add(this.lblDisplayAmount);
            this.Controls.Add(this.cbValueType);
            this.Controls.Add(this.lblValueType);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnRemoveAddress);
            this.Controls.Add(this.btnAddAddress);
            this.Controls.Add(this.lblCountFound);
            this.Controls.Add(this.lvStoredAddresses);
            this.Controls.Add(this.lvAddress);
            this.Controls.Add(this.btnConnectSwitch);
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
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.Text = "SysNetCheatGUI v1.0.14.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
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
        private System.Windows.Forms.Button btnConnectSwitch;
        private System.Windows.Forms.ColumnHeader colAddress;
        private System.Windows.Forms.ColumnHeader colValue;
        private System.Windows.Forms.ColumnHeader cFreeze;
        private System.Windows.Forms.ColumnHeader cAddress;
        private System.Windows.Forms.ColumnHeader cDescription;
        private System.Windows.Forms.ColumnHeader cValueType;
        private System.Windows.Forms.ColumnHeader cValue;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        public System.Windows.Forms.TextBox txtValue;
        public System.Windows.Forms.ListView lvAddress;
        public System.Windows.Forms.Label lblCountFound;
        private System.Windows.Forms.ColumnHeader cID;
        private System.Windows.Forms.Button btnAddAddress;
        private System.Windows.Forms.Button btnRemoveAddress;
        private System.Windows.Forms.ContextMenuStrip cmsStoredAddress;
        private System.Windows.Forms.ToolStripMenuItem editDescriptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editValueToolStripMenuItem;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.ToolStripMenuItem deleteAddressToolStripMenuItem;
        private System.Windows.Forms.Label lblValueType;
        private System.Windows.Forms.ComboBox cbValueType;
        private System.Windows.Forms.Label lblDisplayAmount;
        public System.Windows.Forms.TextBox txtDisplayAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        public System.Windows.Forms.ListView lvStoredAddresses;
    }
}

