namespace Jinisys.Hotel.AccountingInterface.Presentation
{
    partial class Quickbooks_IntegrationSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Quickbooks_IntegrationSetup));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabQBAIS = new System.Windows.Forms.TabControl();
            this.tabGlAccounts = new System.Windows.Forms.TabPage();
            this.gridGLAccounts = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.tsQBAIS = new System.Windows.Forms.ToolStrip();
            this.tsbAddAccount = new System.Windows.Forms.ToolStripButton();
            this.tsbRefreshAccounts = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDeleteAccount = new System.Windows.Forms.ToolStripButton();
            this.tabAccountMapping = new System.Windows.Forms.TabPage();
            this.gridMapping = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAddMapping = new System.Windows.Forms.ToolStripButton();
            this.tsbRefreshMapping = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDeleteMapping = new System.Windows.Forms.ToolStripButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlMain.SuspendLayout();
            this.tabQBAIS.SuspendLayout();
            this.tabGlAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGLAccounts)).BeginInit();
            this.tsQBAIS.SuspendLayout();
            this.tabAccountMapping.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMapping)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.tabQBAIS);
            this.pnlMain.Controls.Add(this.pictureBox1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(10, 10);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(557, 479);
            this.pnlMain.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(114, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Accounting Integration Setup";
            // 
            // tabQBAIS
            // 
            this.tabQBAIS.Controls.Add(this.tabGlAccounts);
            this.tabQBAIS.Controls.Add(this.tabAccountMapping);
            this.tabQBAIS.Location = new System.Drawing.Point(3, 98);
            this.tabQBAIS.Name = "tabQBAIS";
            this.tabQBAIS.SelectedIndex = 0;
            this.tabQBAIS.Size = new System.Drawing.Size(551, 381);
            this.tabQBAIS.TabIndex = 1;
            // 
            // tabGlAccounts
            // 
            this.tabGlAccounts.Controls.Add(this.gridGLAccounts);
            this.tabGlAccounts.Controls.Add(this.tsQBAIS);
            this.tabGlAccounts.Location = new System.Drawing.Point(4, 22);
            this.tabGlAccounts.Name = "tabGlAccounts";
            this.tabGlAccounts.Padding = new System.Windows.Forms.Padding(3);
            this.tabGlAccounts.Size = new System.Drawing.Size(543, 355);
            this.tabGlAccounts.TabIndex = 0;
            this.tabGlAccounts.Text = "QuickBooks GL Accounts";
            this.tabGlAccounts.UseVisualStyleBackColor = true;
            // 
            // gridGLAccounts
            // 
            this.gridGLAccounts.ColumnInfo = resources.GetString("gridGLAccounts.ColumnInfo");
            this.gridGLAccounts.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridGLAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridGLAccounts.Location = new System.Drawing.Point(3, 28);
            this.gridGLAccounts.Name = "gridGLAccounts";
            this.gridGLAccounts.Rows.Count = 1;
            this.gridGLAccounts.Rows.DefaultSize = 17;
            this.gridGLAccounts.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox;
            this.gridGLAccounts.Size = new System.Drawing.Size(537, 324);
            this.gridGLAccounts.TabIndex = 2;
            // 
            // tsQBAIS
            // 
            this.tsQBAIS.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsQBAIS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddAccount,
            this.tsbRefreshAccounts,
            this.toolStripSeparator1,
            this.tsbDeleteAccount});
            this.tsQBAIS.Location = new System.Drawing.Point(3, 3);
            this.tsQBAIS.Name = "tsQBAIS";
            this.tsQBAIS.Size = new System.Drawing.Size(537, 25);
            this.tsQBAIS.TabIndex = 1;
            // 
            // tsbAddAccount
            // 
            this.tsbAddAccount.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddAccount.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddAccount.Image")));
            this.tsbAddAccount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddAccount.Name = "tsbAddAccount";
            this.tsbAddAccount.Size = new System.Drawing.Size(23, 22);
            this.tsbAddAccount.Text = "Add an Account";
            this.tsbAddAccount.Click += new System.EventHandler(this.tsbAddAccount_Click);
            // 
            // tsbRefreshAccounts
            // 
            this.tsbRefreshAccounts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefreshAccounts.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefreshAccounts.Image")));
            this.tsbRefreshAccounts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefreshAccounts.Name = "tsbRefreshAccounts";
            this.tsbRefreshAccounts.Size = new System.Drawing.Size(23, 22);
            this.tsbRefreshAccounts.Text = "Refresh";
            this.tsbRefreshAccounts.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbDeleteAccount
            // 
            this.tsbDeleteAccount.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeleteAccount.Image = ((System.Drawing.Image)(resources.GetObject("tsbDeleteAccount.Image")));
            this.tsbDeleteAccount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteAccount.Name = "tsbDeleteAccount";
            this.tsbDeleteAccount.Size = new System.Drawing.Size(23, 22);
            this.tsbDeleteAccount.Text = "Delete";
            this.tsbDeleteAccount.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tabAccountMapping
            // 
            this.tabAccountMapping.Controls.Add(this.gridMapping);
            this.tabAccountMapping.Controls.Add(this.toolStrip1);
            this.tabAccountMapping.Location = new System.Drawing.Point(4, 22);
            this.tabAccountMapping.Name = "tabAccountMapping";
            this.tabAccountMapping.Padding = new System.Windows.Forms.Padding(3);
            this.tabAccountMapping.Size = new System.Drawing.Size(543, 355);
            this.tabAccountMapping.TabIndex = 1;
            this.tabAccountMapping.Text = "GL Account Mapping";
            this.tabAccountMapping.UseVisualStyleBackColor = true;
            // 
            // gridMapping
            // 
            this.gridMapping.ColumnInfo = resources.GetString("gridMapping.ColumnInfo");
            this.gridMapping.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridMapping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMapping.Location = new System.Drawing.Point(3, 28);
            this.gridMapping.Name = "gridMapping";
            this.gridMapping.Rows.Count = 1;
            this.gridMapping.Rows.DefaultSize = 17;
            this.gridMapping.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox;
            this.gridMapping.Size = new System.Drawing.Size(537, 324);
            this.gridMapping.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddMapping,
            this.tsbRefreshMapping,
            this.toolStripSeparator2,
            this.tsbDeleteMapping});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(537, 25);
            this.toolStrip1.TabIndex = 2;
            // 
            // tsbAddMapping
            // 
            this.tsbAddMapping.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddMapping.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddMapping.Image")));
            this.tsbAddMapping.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddMapping.Name = "tsbAddMapping";
            this.tsbAddMapping.Size = new System.Drawing.Size(23, 22);
            this.tsbAddMapping.Text = "Add an Account";
            this.tsbAddMapping.Click += new System.EventHandler(this.tsbAddMapping_Click);
            // 
            // tsbRefreshMapping
            // 
            this.tsbRefreshMapping.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefreshMapping.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefreshMapping.Image")));
            this.tsbRefreshMapping.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefreshMapping.Name = "tsbRefreshMapping";
            this.tsbRefreshMapping.Size = new System.Drawing.Size(23, 22);
            this.tsbRefreshMapping.Text = "Refresh";
            this.tsbRefreshMapping.Click += new System.EventHandler(this.tsbRefreshMapping_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbDeleteMapping
            // 
            this.tsbDeleteMapping.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeleteMapping.Image = ((System.Drawing.Image)(resources.GetObject("tsbDeleteMapping.Image")));
            this.tsbDeleteMapping.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteMapping.Name = "tsbDeleteMapping";
            this.tsbDeleteMapping.Size = new System.Drawing.Size(23, 22);
            this.tsbDeleteMapping.Text = "Delete";
            this.tsbDeleteMapping.Click += new System.EventHandler(this.tsbDeleteMapping_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 89);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Quickbooks_IntegrationSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 499);
            this.Controls.Add(this.pnlMain);
            this.MaximizeBox = false;
            this.Name = "Quickbooks_IntegrationSetup";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quickbooks Integration Setup";
            this.Activated += new System.EventHandler(this.Quickbooks_IntegrationSetup_Activated);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.tabQBAIS.ResumeLayout(false);
            this.tabGlAccounts.ResumeLayout(false);
            this.tabGlAccounts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGLAccounts)).EndInit();
            this.tsQBAIS.ResumeLayout(false);
            this.tsQBAIS.PerformLayout();
            this.tabAccountMapping.ResumeLayout(false);
            this.tabAccountMapping.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMapping)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabQBAIS;
        private System.Windows.Forms.TabPage tabGlAccounts;
        private System.Windows.Forms.TabPage tabAccountMapping;
        private System.Windows.Forms.ToolStrip tsQBAIS;
        private System.Windows.Forms.ToolStripButton tsbAddAccount;
        private System.Windows.Forms.ToolStripButton tsbRefreshAccounts;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbDeleteAccount;
        private C1.Win.C1FlexGrid.C1FlexGrid gridGLAccounts;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAddMapping;
        private System.Windows.Forms.ToolStripButton tsbRefreshMapping;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbDeleteMapping;
        private C1.Win.C1FlexGrid.C1FlexGrid gridMapping;
    }
}