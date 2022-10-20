namespace Jinisys.Hotel.AccountingInterface.Presentation
{
	partial class Exact_CostCenterUI
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
            this.lvwCostCenter = new System.Windows.Forms.ListView();
            this.colCostCenterCode = new System.Windows.Forms.ColumnHeader();
            this.colDescription = new System.Windows.Forms.ColumnHeader();
            this.lblCostCenterCode = new System.Windows.Forms.Label();
            this.txtCostCenterCode = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblStatusFlag = new System.Windows.Forms.Label();
            this.txtStatusFlag = new System.Windows.Forms.TextBox();
            this.lblCreatedDate = new System.Windows.Forms.Label();
            this.txtCreatedDate = new System.Windows.Forms.TextBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.txtCreatedBy = new System.Windows.Forms.TextBox();
            this.lblUpdatedDate = new System.Windows.Forms.Label();
            this.txtUpdatedDate = new System.Windows.Forms.TextBox();
            this.lblUpdatedBy = new System.Windows.Forms.Label();
            this.txtUpdatedBy = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSetActive = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwCostCenter
            // 
            this.lvwCostCenter.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCostCenterCode,
            this.colDescription});
            this.lvwCostCenter.FullRowSelect = true;
            this.lvwCostCenter.GridLines = true;
            this.lvwCostCenter.Location = new System.Drawing.Point(6, 19);
            this.lvwCostCenter.Name = "lvwCostCenter";
            this.lvwCostCenter.Size = new System.Drawing.Size(493, 218);
            this.lvwCostCenter.TabIndex = 14;
            this.lvwCostCenter.UseCompatibleStateImageBehavior = false;
            this.lvwCostCenter.View = System.Windows.Forms.View.Details;
            this.lvwCostCenter.SelectedIndexChanged += new System.EventHandler(this.lvwCostCenter_SelectedIndexChanged);
            // 
            // colCostCenterCode
            // 
            this.colCostCenterCode.Text = "Cost Center Code";
            this.colCostCenterCode.Width = 102;
            // 
            // colDescription
            // 
            this.colDescription.Text = "Description";
            this.colDescription.Width = 373;
            // 
            // lblCostCenterCode
            // 
            this.lblCostCenterCode.AutoSize = true;
            this.lblCostCenterCode.Location = new System.Drawing.Point(17, 32);
            this.lblCostCenterCode.Name = "lblCostCenterCode";
            this.lblCostCenterCode.Size = new System.Drawing.Size(90, 13);
            this.lblCostCenterCode.TabIndex = 1;
            this.lblCostCenterCode.Text = "Cost Center Code";
            // 
            // txtCostCenterCode
            // 
            this.txtCostCenterCode.Location = new System.Drawing.Point(118, 28);
            this.txtCostCenterCode.Name = "txtCostCenterCode";
            this.txtCostCenterCode.Size = new System.Drawing.Size(127, 20);
            this.txtCostCenterCode.TabIndex = 15;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(17, 58);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(118, 54);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(282, 20);
            this.txtDescription.TabIndex = 16;
            // 
            // lblStatusFlag
            // 
            this.lblStatusFlag.AutoSize = true;
            this.lblStatusFlag.Location = new System.Drawing.Point(17, 84);
            this.lblStatusFlag.Name = "lblStatusFlag";
            this.lblStatusFlag.Size = new System.Drawing.Size(60, 13);
            this.lblStatusFlag.TabIndex = 5;
            this.lblStatusFlag.Text = "Status Flag";
            // 
            // txtStatusFlag
            // 
            this.txtStatusFlag.Location = new System.Drawing.Point(118, 80);
            this.txtStatusFlag.Name = "txtStatusFlag";
            this.txtStatusFlag.ReadOnly = true;
            this.txtStatusFlag.Size = new System.Drawing.Size(127, 20);
            this.txtStatusFlag.TabIndex = 17;
            this.txtStatusFlag.TextChanged += new System.EventHandler(this.txtStatusFlag_TextChanged);
            // 
            // lblCreatedDate
            // 
            this.lblCreatedDate.AutoSize = true;
            this.lblCreatedDate.Location = new System.Drawing.Point(17, 110);
            this.lblCreatedDate.Name = "lblCreatedDate";
            this.lblCreatedDate.Size = new System.Drawing.Size(70, 13);
            this.lblCreatedDate.TabIndex = 7;
            this.lblCreatedDate.Text = "Created Date";
            // 
            // txtCreatedDate
            // 
            this.txtCreatedDate.Location = new System.Drawing.Point(118, 106);
            this.txtCreatedDate.Name = "txtCreatedDate";
            this.txtCreatedDate.ReadOnly = true;
            this.txtCreatedDate.Size = new System.Drawing.Size(127, 20);
            this.txtCreatedDate.TabIndex = 18;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Location = new System.Drawing.Point(17, 136);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(59, 13);
            this.lblCreatedBy.TabIndex = 9;
            this.lblCreatedBy.Text = "Created By";
            // 
            // txtCreatedBy
            // 
            this.txtCreatedBy.Location = new System.Drawing.Point(118, 132);
            this.txtCreatedBy.Name = "txtCreatedBy";
            this.txtCreatedBy.ReadOnly = true;
            this.txtCreatedBy.Size = new System.Drawing.Size(127, 20);
            this.txtCreatedBy.TabIndex = 19;
            // 
            // lblUpdatedDate
            // 
            this.lblUpdatedDate.AutoSize = true;
            this.lblUpdatedDate.Location = new System.Drawing.Point(17, 162);
            this.lblUpdatedDate.Name = "lblUpdatedDate";
            this.lblUpdatedDate.Size = new System.Drawing.Size(74, 13);
            this.lblUpdatedDate.TabIndex = 11;
            this.lblUpdatedDate.Text = "Updated Date";
            // 
            // txtUpdatedDate
            // 
            this.txtUpdatedDate.Location = new System.Drawing.Point(118, 158);
            this.txtUpdatedDate.Name = "txtUpdatedDate";
            this.txtUpdatedDate.ReadOnly = true;
            this.txtUpdatedDate.Size = new System.Drawing.Size(127, 20);
            this.txtUpdatedDate.TabIndex = 20;
            // 
            // lblUpdatedBy
            // 
            this.lblUpdatedBy.AutoSize = true;
            this.lblUpdatedBy.Location = new System.Drawing.Point(17, 188);
            this.lblUpdatedBy.Name = "lblUpdatedBy";
            this.lblUpdatedBy.Size = new System.Drawing.Size(63, 13);
            this.lblUpdatedBy.TabIndex = 13;
            this.lblUpdatedBy.Text = "Updated By";
            // 
            // txtUpdatedBy
            // 
            this.txtUpdatedBy.Location = new System.Drawing.Point(118, 184);
            this.txtUpdatedBy.Name = "txtUpdatedBy";
            this.txtUpdatedBy.ReadOnly = true;
            this.txtUpdatedBy.Size = new System.Drawing.Size(127, 20);
            this.txtUpdatedBy.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lvwCostCenter);
            this.groupBox1.Location = new System.Drawing.Point(16, 224);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(508, 249);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List of Cost Centers";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(16, 494);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(66, 31);
            this.btnDelete.TabIndex = 23;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(458, 494);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 31);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "Cl&ose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(386, 494);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 31);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(314, 494);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 31);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(239, 494);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(66, 31);
            this.btnNew.TabIndex = 27;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSetActive
            // 
            this.btnSetActive.Location = new System.Drawing.Point(252, 79);
            this.btnSetActive.Name = "btnSetActive";
            this.btnSetActive.Size = new System.Drawing.Size(70, 21);
            this.btnSetActive.TabIndex = 28;
            this.btnSetActive.Text = "Set Active";
            this.btnSetActive.UseVisualStyleBackColor = true;
            this.btnSetActive.Visible = false;
            this.btnSetActive.Click += new System.EventHandler(this.btnSetActive_Click);
            // 
            // Exact_CostCenterUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 544);
            this.Controls.Add(this.btnSetActive);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblCostCenterCode);
            this.Controls.Add(this.txtCostCenterCode);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblStatusFlag);
            this.Controls.Add(this.txtStatusFlag);
            this.Controls.Add(this.lblCreatedDate);
            this.Controls.Add(this.txtCreatedDate);
            this.Controls.Add(this.lblCreatedBy);
            this.Controls.Add(this.txtCreatedBy);
            this.Controls.Add(this.lblUpdatedDate);
            this.Controls.Add(this.txtUpdatedDate);
            this.Controls.Add(this.lblUpdatedBy);
            this.Controls.Add(this.txtUpdatedBy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Exact_CostCenterUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cost Center - Exact";
            this.TextChanged += new System.EventHandler(this.CostCenterUI_ExactGlobe_TextChanged);
            this.Load += new System.EventHandler(this.CostCenterUI_ExactGlobe_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private System.Windows.Forms.Label lblCostCenterCode;
		private System.Windows.Forms.TextBox txtCostCenterCode;
		private System.Windows.Forms.Label lblDescription;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.Label lblStatusFlag;
		private System.Windows.Forms.TextBox txtStatusFlag;
		private System.Windows.Forms.Label lblCreatedDate;
		private System.Windows.Forms.TextBox txtCreatedDate;
		private System.Windows.Forms.Label lblCreatedBy;
		private System.Windows.Forms.TextBox txtCreatedBy;
		private System.Windows.Forms.Label lblUpdatedDate;
		private System.Windows.Forms.TextBox txtUpdatedDate;
		private System.Windows.Forms.Label lblUpdatedBy;
		private System.Windows.Forms.TextBox txtUpdatedBy;
		private System.Windows.Forms.ListView lvwCostCenter;
		private System.Windows.Forms.ColumnHeader colCostCenterCode;
		private System.Windows.Forms.ColumnHeader colDescription; 




		#endregion
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSetActive;
	}
}