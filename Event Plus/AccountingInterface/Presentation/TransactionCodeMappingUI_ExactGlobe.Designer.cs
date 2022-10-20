namespace Jinisys.Hotel.AccountingInterface.Presentation
{
	partial class TransactionCodeMappingUI_ExactGlobe
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
			this.cboTransactionCode = new System.Windows.Forms.ComboBox();
			this.cboDescription = new System.Windows.Forms.ComboBox();
			this.lvwJournalEntries = new System.Windows.Forms.ListView();
			this.colLineNo = new System.Windows.Forms.ColumnHeader();
			this.colGLAccount = new System.Windows.Forms.ColumnHeader();
			this.colGLAccountDescrption = new System.Windows.Forms.ColumnHeader();
			this.colReferenceCol = new System.Windows.Forms.ColumnHeader();
			this.colCostCenter = new System.Windows.Forms.ColumnHeader();
			this.colJournalEntryCode = new System.Windows.Forms.ColumnHeader();
			this.label1 = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cboTransactionCode
			// 
			this.cboTransactionCode.BackColor = System.Drawing.SystemColors.Info;
			this.cboTransactionCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboTransactionCode.FormattingEnabled = true;
			this.cboTransactionCode.Location = new System.Drawing.Point(119, 41);
			this.cboTransactionCode.MaxDropDownItems = 20;
			this.cboTransactionCode.Name = "cboTransactionCode";
			this.cboTransactionCode.Size = new System.Drawing.Size(66, 21);
			this.cboTransactionCode.TabIndex = 0;
			this.cboTransactionCode.SelectedIndexChanged += new System.EventHandler(this.cboTransactionCode_SelectedIndexChanged);
			// 
			// cboDescription
			// 
			this.cboDescription.BackColor = System.Drawing.SystemColors.Info;
			this.cboDescription.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboDescription.FormattingEnabled = true;
			this.cboDescription.Location = new System.Drawing.Point(191, 41);
			this.cboDescription.MaxDropDownItems = 20;
			this.cboDescription.Name = "cboDescription";
			this.cboDescription.Size = new System.Drawing.Size(458, 21);
			this.cboDescription.TabIndex = 1;
			// 
			// lvwJournalEntries
			// 
			this.lvwJournalEntries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLineNo,
            this.colGLAccount,
            this.colGLAccountDescrption,
            this.colReferenceCol,
            this.colCostCenter,
            this.colJournalEntryCode});
			this.lvwJournalEntries.FullRowSelect = true;
			this.lvwJournalEntries.GridLines = true;
			this.lvwJournalEntries.Location = new System.Drawing.Point(6, 19);
			this.lvwJournalEntries.Name = "lvwJournalEntries";
			this.lvwJournalEntries.Size = new System.Drawing.Size(685, 168);
			this.lvwJournalEntries.TabIndex = 2;
			this.lvwJournalEntries.UseCompatibleStateImageBehavior = false;
			this.lvwJournalEntries.View = System.Windows.Forms.View.Details;
			// 
			// colLineNo
			// 
			this.colLineNo.Text = "Line No";
			this.colLineNo.Width = 51;
			// 
			// colGLAccount
			// 
			this.colGLAccount.Text = "GL Account";
			this.colGLAccount.Width = 73;
			// 
			// colGLAccountDescrption
			// 
			this.colGLAccountDescrption.Text = "Description";
			this.colGLAccountDescrption.Width = 217;
			// 
			// colReferenceCol
			// 
			this.colReferenceCol.Text = "Rerence Column";
			this.colReferenceCol.Width = 145;
			// 
			// colCostCenter
			// 
			this.colCostCenter.Text = "Cost Center";
			this.colCostCenter.Width = 89;
			// 
			// colJournalEntryCode
			// 
			this.colJournalEntryCode.Text = "Journal Entry Code";
			this.colJournalEntryCode.Width = 106;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(19, 45);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(94, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Transaction Code ";
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Location = new System.Drawing.Point(553, 204);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(66, 31);
			this.btnSave.TabIndex = 30;
			this.btnSave.Text = "&Add";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(625, 204);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(66, 31);
			this.btnCancel.TabIndex = 29;
			this.btnCancel.Text = "&Remove";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lvwJournalEntries);
			this.groupBox1.Controls.Add(this.btnSave);
			this.groupBox1.Controls.Add(this.btnCancel);
			this.groupBox1.Location = new System.Drawing.Point(16, 116);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(705, 257);
			this.groupBox1.TabIndex = 31;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Journal Entries :";
			// 
			// TransactionCodeMappingUI_ExactGlobe
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(733, 418);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cboDescription);
			this.Controls.Add(this.cboTransactionCode);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TransactionCodeMappingUI_ExactGlobe";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Transaction Code MappingUI - ExactGlobe";
			this.Load += new System.EventHandler(this.TransactionCodeMappingUI_ExactGlobe_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cboTransactionCode;
		private System.Windows.Forms.ComboBox cboDescription;
		private System.Windows.Forms.ListView lvwJournalEntries;
		private System.Windows.Forms.ColumnHeader colLineNo;
		private System.Windows.Forms.ColumnHeader colGLAccount;
		private System.Windows.Forms.ColumnHeader colGLAccountDescrption;
		private System.Windows.Forms.ColumnHeader colReferenceCol;
		private System.Windows.Forms.ColumnHeader colCostCenter;
		private System.Windows.Forms.ColumnHeader colJournalEntryCode;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}