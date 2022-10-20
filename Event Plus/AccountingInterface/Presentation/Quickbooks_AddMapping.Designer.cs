namespace Jinisys.Hotel.AccountingInterface.Presentation
{
    partial class Quickbooks_AddMapping
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Quickbooks_AddMapping));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.cboMappingType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFolioTransaction = new System.Windows.Forms.Label();
            this.cboTransactionCode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboGLAccount = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.cboMappingType);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.lblFolioTransaction);
            this.pnlMain.Controls.Add(this.cboTransactionCode);
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.cboGLAccount);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMain.Location = new System.Drawing.Point(10, 10);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(417, 150);
            this.pnlMain.TabIndex = 0;
            // 
            // cboMappingType
            // 
            this.cboMappingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMappingType.FormattingEnabled = true;
            this.cboMappingType.Items.AddRange(new object[] {
            "Cash"});
            this.cboMappingType.Location = new System.Drawing.Point(149, 101);
            this.cboMappingType.Name = "cboMappingType";
            this.cboMappingType.Size = new System.Drawing.Size(257, 21);
            this.cboMappingType.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mapping Type:";
            // 
            // lblFolioTransaction
            // 
            this.lblFolioTransaction.AutoSize = true;
            this.lblFolioTransaction.Location = new System.Drawing.Point(146, 76);
            this.lblFolioTransaction.Name = "lblFolioTransaction";
            this.lblFolioTransaction.Size = new System.Drawing.Size(27, 13);
            this.lblFolioTransaction.TabIndex = 4;
            this.lblFolioTransaction.Text = "N/A";
            // 
            // cboTransactionCode
            // 
            this.cboTransactionCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransactionCode.FormattingEnabled = true;
            this.cboTransactionCode.Location = new System.Drawing.Point(149, 52);
            this.cboTransactionCode.Name = "cboTransactionCode";
            this.cboTransactionCode.Size = new System.Drawing.Size(257, 21);
            this.cboTransactionCode.TabIndex = 3;
            this.cboTransactionCode.SelectedIndexChanged += new System.EventHandler(this.cboTransactionCode_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Folio Transaction  Code:";
            // 
            // cboGLAccount
            // 
            this.cboGLAccount.FormattingEnabled = true;
            this.cboGLAccount.Location = new System.Drawing.Point(149, 16);
            this.cboGLAccount.Name = "cboGLAccount";
            this.cboGLAccount.Size = new System.Drawing.Size(257, 21);
            this.cboGLAccount.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "QuickBooks GL Account:";
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(349, 166);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(268, 166);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "&Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Quickbooks_AddMapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 202);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlMain);
            this.Name = "Quickbooks_AddMapping";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Mapping";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cboGLAccount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFolioTransaction;
        private System.Windows.Forms.ComboBox cboTransactionCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboMappingType;
    }
}