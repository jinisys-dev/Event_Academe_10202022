namespace Jinisys.Hotel.AccountingInterface.Presentation
{
    partial class Peachtree_FolioAccountMapping
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
            this.cboAccountID = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTransactionCode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblPeachtree = new System.Windows.Forms.Label();
            this.lblFolio = new System.Windows.Forms.Label();
            this.cboMappingType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboAccountID
            // 
            this.cboAccountID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAccountID.FormattingEnabled = true;
            this.cboAccountID.Location = new System.Drawing.Point(134, 12);
            this.cboAccountID.Name = "cboAccountID";
            this.cboAccountID.Size = new System.Drawing.Size(154, 21);
            this.cboAccountID.TabIndex = 0;
            this.cboAccountID.SelectedIndexChanged += new System.EventHandler(this.cboAccountID_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Peachtree Account ID:";
            // 
            // cboTransactionCode
            // 
            this.cboTransactionCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransactionCode.FormattingEnabled = true;
            this.cboTransactionCode.Location = new System.Drawing.Point(134, 67);
            this.cboTransactionCode.Name = "cboTransactionCode";
            this.cboTransactionCode.Size = new System.Drawing.Size(154, 21);
            this.cboTransactionCode.TabIndex = 2;
            this.cboTransactionCode.SelectedIndexChanged += new System.EventHandler(this.cboTransactionCode_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Folio Transaction Code:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(227, 152);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 34);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblPeachtree
            // 
            this.lblPeachtree.AutoSize = true;
            this.lblPeachtree.Location = new System.Drawing.Point(131, 36);
            this.lblPeachtree.Name = "lblPeachtree";
            this.lblPeachtree.Size = new System.Drawing.Size(27, 13);
            this.lblPeachtree.TabIndex = 5;
            this.lblPeachtree.Text = "N/A";
            // 
            // lblFolio
            // 
            this.lblFolio.AutoSize = true;
            this.lblFolio.Location = new System.Drawing.Point(132, 91);
            this.lblFolio.Name = "lblFolio";
            this.lblFolio.Size = new System.Drawing.Size(27, 13);
            this.lblFolio.TabIndex = 6;
            this.lblFolio.Text = "N/A";
            // 
            // cboMappingType
            // 
            this.cboMappingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMappingType.FormattingEnabled = true;
            this.cboMappingType.Items.AddRange(new object[] {
            "ACCOUNTS RECEIVABLE",
            "ACCOUNTS PAYABLE",
            "SALES TAX PAYABLE",
            "SALES",
            "CASH"});
            this.cboMappingType.Location = new System.Drawing.Point(134, 119);
            this.cboMappingType.Name = "cboMappingType";
            this.cboMappingType.Size = new System.Drawing.Size(153, 21);
            this.cboMappingType.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Mapping Type:";
            // 
            // Peachtree_FolioAccountMapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 189);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboMappingType);
            this.Controls.Add(this.lblFolio);
            this.Controls.Add(this.lblPeachtree);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboTransactionCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboAccountID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Peachtree_FolioAccountMapping";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Mapping";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboAccountID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTransactionCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblPeachtree;
        private System.Windows.Forms.Label lblFolio;
        private System.Windows.Forms.ComboBox cboMappingType;
        private System.Windows.Forms.Label label3;
    }
}