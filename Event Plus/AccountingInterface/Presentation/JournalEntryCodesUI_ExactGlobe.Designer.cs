namespace Jinisys.Hotel.AccountingInterface.Presentation
{
	partial class JournalEntryCodesUI_ExactGlobe
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
			this.lvwJournalEntryCodes = new System.Windows.Forms.ListView();
			this.colJournalEntryCode = new System.Windows.Forms.ColumnHeader();
			this.colDescription = new System.Windows.Forms.ColumnHeader();
			this.lblJournalEntryCode = new System.Windows.Forms.Label();
			this.txtJournalEntryCode = new System.Windows.Forms.TextBox();
			this.lblDescription = new System.Windows.Forms.Label();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.lblStatusFlag = new System.Windows.Forms.Label();
			this.txtStatusFlag = new System.Windows.Forms.TextBox();
			this.lblCreatedBy = new System.Windows.Forms.Label();
			this.txtCreatedBy = new System.Windows.Forms.TextBox();
			this.lblCreatedDate = new System.Windows.Forms.Label();
			this.txtCreatedDate = new System.Windows.Forms.TextBox();
			this.lblUpdatedBy = new System.Windows.Forms.Label();
			this.txtUpdatedBy = new System.Windows.Forms.TextBox();
			this.lblUpdatedDate = new System.Windows.Forms.Label();
			this.txtUpdatedDate = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnNew = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnSetActive = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvwJournalEntryCodes
			// 
			this.lvwJournalEntryCodes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colJournalEntryCode,
            this.colDescription});
			this.lvwJournalEntryCodes.FullRowSelect = true;
			this.lvwJournalEntryCodes.Location = new System.Drawing.Point(6, 19);
			this.lvwJournalEntryCodes.Name = "lvwJournalEntryCodes";
			this.lvwJournalEntryCodes.Size = new System.Drawing.Size(498, 195);
			this.lvwJournalEntryCodes.TabIndex = 14;
			this.lvwJournalEntryCodes.UseCompatibleStateImageBehavior = false;
			this.lvwJournalEntryCodes.View = System.Windows.Forms.View.Details;
			this.lvwJournalEntryCodes.SelectedIndexChanged += new System.EventHandler(this.lvwJournalEntryCodes_SelectedIndexChanged);
			// 
			// colJournalEntryCode
			// 
			this.colJournalEntryCode.Text = "Journal Entry Code";
			this.colJournalEntryCode.Width = 128;
			// 
			// colDescription
			// 
			this.colDescription.Text = "Description";
			this.colDescription.Width = 350;
			// 
			// lblJournalEntryCode
			// 
			this.lblJournalEntryCode.AutoSize = true;
			this.lblJournalEntryCode.Location = new System.Drawing.Point(23, 33);
			this.lblJournalEntryCode.Name = "lblJournalEntryCode";
			this.lblJournalEntryCode.Size = new System.Drawing.Size(96, 13);
			this.lblJournalEntryCode.TabIndex = 1;
			this.lblJournalEntryCode.Text = "Journal Entry Code";
			// 
			// txtJournalEntryCode
			// 
			this.txtJournalEntryCode.Location = new System.Drawing.Point(124, 29);
			this.txtJournalEntryCode.Name = "txtJournalEntryCode";
			this.txtJournalEntryCode.Size = new System.Drawing.Size(127, 20);
			this.txtJournalEntryCode.TabIndex = 15;
			// 
			// lblDescription
			// 
			this.lblDescription.AutoSize = true;
			this.lblDescription.Location = new System.Drawing.Point(23, 59);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(60, 13);
			this.lblDescription.TabIndex = 3;
			this.lblDescription.Text = "Description";
			// 
			// txtDescription
			// 
			this.txtDescription.Location = new System.Drawing.Point(124, 55);
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(312, 20);
			this.txtDescription.TabIndex = 16;
			// 
			// lblStatusFlag
			// 
			this.lblStatusFlag.AutoSize = true;
			this.lblStatusFlag.Location = new System.Drawing.Point(23, 85);
			this.lblStatusFlag.Name = "lblStatusFlag";
			this.lblStatusFlag.Size = new System.Drawing.Size(60, 13);
			this.lblStatusFlag.TabIndex = 5;
			this.lblStatusFlag.Text = "Status Flag";
			// 
			// txtStatusFlag
			// 
			this.txtStatusFlag.Location = new System.Drawing.Point(124, 81);
			this.txtStatusFlag.Name = "txtStatusFlag";
			this.txtStatusFlag.ReadOnly = true;
			this.txtStatusFlag.Size = new System.Drawing.Size(127, 20);
			this.txtStatusFlag.TabIndex = 17;
			this.txtStatusFlag.TextChanged += new System.EventHandler(this.txtStatusFlag_TextChanged);
			// 
			// lblCreatedBy
			// 
			this.lblCreatedBy.AutoSize = true;
			this.lblCreatedBy.Location = new System.Drawing.Point(23, 111);
			this.lblCreatedBy.Name = "lblCreatedBy";
			this.lblCreatedBy.Size = new System.Drawing.Size(59, 13);
			this.lblCreatedBy.TabIndex = 7;
			this.lblCreatedBy.Text = "Created By";
			// 
			// txtCreatedBy
			// 
			this.txtCreatedBy.Location = new System.Drawing.Point(124, 107);
			this.txtCreatedBy.Name = "txtCreatedBy";
			this.txtCreatedBy.ReadOnly = true;
			this.txtCreatedBy.Size = new System.Drawing.Size(127, 20);
			this.txtCreatedBy.TabIndex = 18;
			// 
			// lblCreatedDate
			// 
			this.lblCreatedDate.AutoSize = true;
			this.lblCreatedDate.Location = new System.Drawing.Point(23, 137);
			this.lblCreatedDate.Name = "lblCreatedDate";
			this.lblCreatedDate.Size = new System.Drawing.Size(70, 13);
			this.lblCreatedDate.TabIndex = 9;
			this.lblCreatedDate.Text = "Created Date";
			// 
			// txtCreatedDate
			// 
			this.txtCreatedDate.Location = new System.Drawing.Point(124, 133);
			this.txtCreatedDate.Name = "txtCreatedDate";
			this.txtCreatedDate.ReadOnly = true;
			this.txtCreatedDate.Size = new System.Drawing.Size(127, 20);
			this.txtCreatedDate.TabIndex = 19;
			// 
			// lblUpdatedBy
			// 
			this.lblUpdatedBy.AutoSize = true;
			this.lblUpdatedBy.Location = new System.Drawing.Point(23, 163);
			this.lblUpdatedBy.Name = "lblUpdatedBy";
			this.lblUpdatedBy.Size = new System.Drawing.Size(63, 13);
			this.lblUpdatedBy.TabIndex = 11;
			this.lblUpdatedBy.Text = "Updated By";
			// 
			// txtUpdatedBy
			// 
			this.txtUpdatedBy.Location = new System.Drawing.Point(124, 159);
			this.txtUpdatedBy.Name = "txtUpdatedBy";
			this.txtUpdatedBy.ReadOnly = true;
			this.txtUpdatedBy.Size = new System.Drawing.Size(127, 20);
			this.txtUpdatedBy.TabIndex = 20;
			// 
			// lblUpdatedDate
			// 
			this.lblUpdatedDate.AutoSize = true;
			this.lblUpdatedDate.Location = new System.Drawing.Point(23, 189);
			this.lblUpdatedDate.Name = "lblUpdatedDate";
			this.lblUpdatedDate.Size = new System.Drawing.Size(74, 13);
			this.lblUpdatedDate.TabIndex = 13;
			this.lblUpdatedDate.Text = "Updated Date";
			// 
			// txtUpdatedDate
			// 
			this.txtUpdatedDate.Location = new System.Drawing.Point(124, 185);
			this.txtUpdatedDate.Name = "txtUpdatedDate";
			this.txtUpdatedDate.ReadOnly = true;
			this.txtUpdatedDate.Size = new System.Drawing.Size(127, 20);
			this.txtUpdatedDate.TabIndex = 21;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.lvwJournalEntryCodes);
			this.groupBox1.Location = new System.Drawing.Point(20, 229);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(516, 228);
			this.groupBox1.TabIndex = 22;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "List of Journal Entry Codes";
			// 
			// btnNew
			// 
			this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNew.Location = new System.Drawing.Point(251, 476);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(66, 31);
			this.btnNew.TabIndex = 32;
			this.btnNew.Text = "&New";
			this.btnNew.UseVisualStyleBackColor = true;
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Location = new System.Drawing.Point(326, 476);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(66, 31);
			this.btnSave.TabIndex = 31;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(398, 476);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(66, 31);
			this.btnCancel.TabIndex = 30;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.Location = new System.Drawing.Point(470, 476);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(66, 31);
			this.btnClose.TabIndex = 29;
			this.btnClose.Text = "Cl&ose";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnDelete.Location = new System.Drawing.Point(20, 476);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(66, 31);
			this.btnDelete.TabIndex = 28;
			this.btnDelete.Text = "&Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnSetActive
			// 
			this.btnSetActive.Location = new System.Drawing.Point(257, 80);
			this.btnSetActive.Name = "btnSetActive";
			this.btnSetActive.Size = new System.Drawing.Size(70, 21);
			this.btnSetActive.TabIndex = 33;
			this.btnSetActive.Text = "Set Active";
			this.btnSetActive.UseVisualStyleBackColor = true;
			this.btnSetActive.Visible = false;
			this.btnSetActive.Click += new System.EventHandler(this.btnSetActive_Click);
			// 
			// JournalEntryCodesUI_ExactGlobe
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(558, 524);
			this.Controls.Add(this.btnSetActive);
			this.Controls.Add(this.btnNew);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.lblJournalEntryCode);
			this.Controls.Add(this.txtJournalEntryCode);
			this.Controls.Add(this.lblDescription);
			this.Controls.Add(this.txtDescription);
			this.Controls.Add(this.lblStatusFlag);
			this.Controls.Add(this.txtStatusFlag);
			this.Controls.Add(this.lblCreatedBy);
			this.Controls.Add(this.txtCreatedBy);
			this.Controls.Add(this.lblCreatedDate);
			this.Controls.Add(this.txtCreatedDate);
			this.Controls.Add(this.lblUpdatedBy);
			this.Controls.Add(this.txtUpdatedBy);
			this.Controls.Add(this.lblUpdatedDate);
			this.Controls.Add(this.txtUpdatedDate);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "JournalEntryCodesUI_ExactGlobe";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Journal Entry Codes - Exact Globe";
			this.TextChanged += new System.EventHandler(this.JournalEntryCodesUI_ExactGlobe_TextChanged);
			this.Load += new System.EventHandler(this.JournalEntryCodesUI_ExactGlobe_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private System.Windows.Forms.Label lblJournalEntryCode;
		private System.Windows.Forms.TextBox txtJournalEntryCode;
		private System.Windows.Forms.Label lblDescription;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.Label lblStatusFlag;
		private System.Windows.Forms.TextBox txtStatusFlag;
		private System.Windows.Forms.Label lblCreatedBy;
		private System.Windows.Forms.TextBox txtCreatedBy;
		private System.Windows.Forms.Label lblCreatedDate;
		private System.Windows.Forms.TextBox txtCreatedDate;
		private System.Windows.Forms.Label lblUpdatedBy;
		private System.Windows.Forms.TextBox txtUpdatedBy;
		private System.Windows.Forms.Label lblUpdatedDate;
		private System.Windows.Forms.TextBox txtUpdatedDate;
		private System.Windows.Forms.ListView lvwJournalEntryCodes;
		private System.Windows.Forms.ColumnHeader colJournalEntryCode;
		private System.Windows.Forms.ColumnHeader colDescription; 




		#endregion
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnNew;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnSetActive;
	}
}