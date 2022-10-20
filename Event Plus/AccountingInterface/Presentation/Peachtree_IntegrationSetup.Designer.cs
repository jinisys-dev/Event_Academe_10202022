namespace Jinisys.Hotel.AccountingInterface.Presentation
{
    partial class Peachtree_IntegrationSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Peachtree_IntegrationSetup));
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.btnAddMapping = new System.Windows.Forms.Button();
            this.tabMapping = new System.Windows.Forms.TabControl();
            this.tabPeachtreeGLAccounts = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.gridPeachtreeAccounts = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.cmsDeleteGL = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabAccountMapping = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.gridAccountMapping = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.cmsDeleteMapping = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabTemplates = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tvwTemplates = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNewTemplate = new System.Windows.Forms.Button();
            this.btnSaveTemplateSettings = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlSub = new System.Windows.Forms.Panel();
            this.tabMapping.SuspendLayout();
            this.tabPeachtreeGLAccounts.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPeachtreeAccounts)).BeginInit();
            this.cmsDeleteGL.SuspendLayout();
            this.tabAccountMapping.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAccountMapping)).BeginInit();
            this.cmsDeleteMapping.SuspendLayout();
            this.tabTemplates.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlSub.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAddAccount.Location = new System.Drawing.Point(379, 308);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(108, 34);
            this.btnAddAccount.TabIndex = 1;
            this.btnAddAccount.Text = "Add New GL Account";
            this.btnAddAccount.UseVisualStyleBackColor = true;
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
            // 
            // btnAddMapping
            // 
            this.btnAddMapping.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAddMapping.Location = new System.Drawing.Point(393, 308);
            this.btnAddMapping.Name = "btnAddMapping";
            this.btnAddMapping.Size = new System.Drawing.Size(94, 34);
            this.btnAddMapping.TabIndex = 2;
            this.btnAddMapping.Text = "Add New Mapping";
            this.btnAddMapping.UseVisualStyleBackColor = true;
            this.btnAddMapping.Click += new System.EventHandler(this.btnAddMapping_Click);
            // 
            // tabMapping
            // 
            this.tabMapping.Controls.Add(this.tabPeachtreeGLAccounts);
            this.tabMapping.Controls.Add(this.tabAccountMapping);
            this.tabMapping.Controls.Add(this.tabTemplates);
            this.tabMapping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMapping.HotTrack = true;
            this.tabMapping.Location = new System.Drawing.Point(5, 5);
            this.tabMapping.Name = "tabMapping";
            this.tabMapping.SelectedIndex = 0;
            this.tabMapping.Size = new System.Drawing.Size(504, 377);
            this.tabMapping.TabIndex = 3;
            // 
            // tabPeachtreeGLAccounts
            // 
            this.tabPeachtreeGLAccounts.Controls.Add(this.tableLayoutPanel2);
            this.tabPeachtreeGLAccounts.Location = new System.Drawing.Point(4, 22);
            this.tabPeachtreeGLAccounts.Name = "tabPeachtreeGLAccounts";
            this.tabPeachtreeGLAccounts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPeachtreeGLAccounts.Size = new System.Drawing.Size(496, 351);
            this.tabPeachtreeGLAccounts.TabIndex = 0;
            this.tabPeachtreeGLAccounts.Text = "Peachtree GL Accounts";
            this.tabPeachtreeGLAccounts.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.gridPeachtreeAccounts, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnAddAccount, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(490, 345);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // gridPeachtreeAccounts
            // 
            this.gridPeachtreeAccounts.ColumnInfo = resources.GetString("gridPeachtreeAccounts.ColumnInfo");
            this.gridPeachtreeAccounts.ContextMenuStrip = this.cmsDeleteGL;
            this.gridPeachtreeAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPeachtreeAccounts.Location = new System.Drawing.Point(3, 3);
            this.gridPeachtreeAccounts.Name = "gridPeachtreeAccounts";
            this.gridPeachtreeAccounts.Rows.Count = 1;
            this.gridPeachtreeAccounts.Rows.DefaultSize = 17;
            this.gridPeachtreeAccounts.Size = new System.Drawing.Size(484, 299);
            this.gridPeachtreeAccounts.TabIndex = 0;
            // 
            // cmsDeleteGL
            // 
            this.cmsDeleteGL.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.cmsDeleteGL.Name = "cmsDeleteGL";
            this.cmsDeleteGL.Size = new System.Drawing.Size(117, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // tabAccountMapping
            // 
            this.tabAccountMapping.Controls.Add(this.tableLayoutPanel3);
            this.tabAccountMapping.Location = new System.Drawing.Point(4, 22);
            this.tabAccountMapping.Name = "tabAccountMapping";
            this.tabAccountMapping.Padding = new System.Windows.Forms.Padding(3);
            this.tabAccountMapping.Size = new System.Drawing.Size(496, 351);
            this.tabAccountMapping.TabIndex = 1;
            this.tabAccountMapping.Text = "Account Mapping";
            this.tabAccountMapping.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.gridAccountMapping, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnAddMapping, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(490, 345);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // gridAccountMapping
            // 
            this.gridAccountMapping.ColumnInfo = resources.GetString("gridAccountMapping.ColumnInfo");
            this.gridAccountMapping.ContextMenuStrip = this.cmsDeleteMapping;
            this.gridAccountMapping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAccountMapping.Location = new System.Drawing.Point(3, 3);
            this.gridAccountMapping.Name = "gridAccountMapping";
            this.gridAccountMapping.Rows.Count = 1;
            this.gridAccountMapping.Rows.DefaultSize = 17;
            this.gridAccountMapping.Size = new System.Drawing.Size(484, 299);
            this.gridAccountMapping.TabIndex = 0;
            // 
            // cmsDeleteMapping
            // 
            this.cmsDeleteMapping.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem1});
            this.cmsDeleteMapping.Name = "cmsDeleteMapping";
            this.cmsDeleteMapping.Size = new System.Drawing.Size(117, 26);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem1_Click);
            // 
            // tabTemplates
            // 
            this.tabTemplates.Controls.Add(this.tableLayoutPanel1);
            this.tabTemplates.Location = new System.Drawing.Point(4, 22);
            this.tabTemplates.Name = "tabTemplates";
            this.tabTemplates.Padding = new System.Windows.Forms.Padding(3);
            this.tabTemplates.Size = new System.Drawing.Size(496, 351);
            this.tabTemplates.TabIndex = 2;
            this.tabTemplates.Text = "Templates";
            this.tabTemplates.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tvwTemplates, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(490, 345);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tvwTemplates
            // 
            this.tvwTemplates.CheckBoxes = true;
            this.tvwTemplates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwTemplates.Location = new System.Drawing.Point(3, 3);
            this.tvwTemplates.Name = "tvwTemplates";
            this.tvwTemplates.Size = new System.Drawing.Size(484, 299);
            this.tvwTemplates.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnNewTemplate);
            this.panel1.Controls.Add(this.btnSaveTemplateSettings);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(191, 308);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(296, 34);
            this.panel1.TabIndex = 4;
            // 
            // btnNewTemplate
            // 
            this.btnNewTemplate.Location = new System.Drawing.Point(99, 0);
            this.btnNewTemplate.Name = "btnNewTemplate";
            this.btnNewTemplate.Size = new System.Drawing.Size(94, 34);
            this.btnNewTemplate.TabIndex = 4;
            this.btnNewTemplate.Text = "&New Template";
            this.btnNewTemplate.UseVisualStyleBackColor = true;
            this.btnNewTemplate.Click += new System.EventHandler(this.btnNewTemplate_Click);
            // 
            // btnSaveTemplateSettings
            // 
            this.btnSaveTemplateSettings.Location = new System.Drawing.Point(199, 0);
            this.btnSaveTemplateSettings.Name = "btnSaveTemplateSettings";
            this.btnSaveTemplateSettings.Size = new System.Drawing.Size(94, 34);
            this.btnSaveTemplateSettings.TabIndex = 3;
            this.btnSaveTemplateSettings.Text = "&Save Template Settings";
            this.btnSaveTemplateSettings.UseVisualStyleBackColor = true;
            this.btnSaveTemplateSettings.Click += new System.EventHandler(this.btnSaveTemplateSettings_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.pictureBox1);
            this.pnlMain.Controls.Add(this.pnlSub);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(10, 10);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(516, 446);
            this.pnlMain.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(177, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Accounting Integration Setup";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(175, 50);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pnlSub
            // 
            this.pnlSub.Controls.Add(this.tabMapping);
            this.pnlSub.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSub.Location = new System.Drawing.Point(0, 57);
            this.pnlSub.Name = "pnlSub";
            this.pnlSub.Padding = new System.Windows.Forms.Padding(5);
            this.pnlSub.Size = new System.Drawing.Size(514, 387);
            this.pnlSub.TabIndex = 4;
            // 
            // Peachtree_IntegrationSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 466);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Peachtree_IntegrationSetup";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Peachtree Integration Setup";
            this.tabMapping.ResumeLayout(false);
            this.tabPeachtreeGLAccounts.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPeachtreeAccounts)).EndInit();
            this.cmsDeleteGL.ResumeLayout(false);
            this.tabAccountMapping.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAccountMapping)).EndInit();
            this.cmsDeleteMapping.ResumeLayout(false);
            this.tabTemplates.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlSub.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddAccount;
        private System.Windows.Forms.Button btnAddMapping;
        private System.Windows.Forms.TabControl tabMapping;
        private System.Windows.Forms.TabPage tabPeachtreeGLAccounts;
        private System.Windows.Forms.TabPage tabAccountMapping;
        private System.Windows.Forms.TabPage tabTemplates;
        private C1.Win.C1FlexGrid.C1FlexGrid gridAccountMapping;
        private C1.Win.C1FlexGrid.C1FlexGrid gridPeachtreeAccounts;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ContextMenuStrip cmsDeleteGL;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.TreeView tvwTemplates;
        private System.Windows.Forms.Button btnSaveTemplateSettings;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNewTemplate;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlSub;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cmsDeleteMapping;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
    }
}