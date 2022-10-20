namespace Jinisys.Hotel.Cashier.Presentation
{
	partial class TransferDebitUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransferDebitUI));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBrowseDestinationFolio = new System.Windows.Forms.Button();
            this.gridDestinationSubFolio = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.txtDestinationCompany = new System.Windows.Forms.TextBox();
            this.txtDestinationRoomNo = new System.Windows.Forms.TextBox();
            this.txtDestinationGuestName = new System.Windows.Forms.TextBox();
            this.txtDestinationFolioId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grbOriginFolio = new System.Windows.Forms.GroupBox();
            this.txtOriginCompany = new System.Windows.Forms.TextBox();
            this.txtOriginRoomNo = new System.Windows.Forms.TextBox();
            this.txtOriginGuestName = new System.Windows.Forms.TextBox();
            this.txtOriginFolioId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.gridOriginSubFolio = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDestinationSubFolio)).BeginInit();
            this.grbOriginFolio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridOriginSubFolio)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBrowseDestinationFolio);
            this.groupBox1.Controls.Add(this.gridDestinationSubFolio);
            this.groupBox1.Controls.Add(this.txtDestinationCompany);
            this.groupBox1.Controls.Add(this.txtDestinationRoomNo);
            this.groupBox1.Controls.Add(this.txtDestinationGuestName);
            this.groupBox1.Controls.Add(this.txtDestinationFolioId);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(483, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(404, 391);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Destination Folio";
            // 
            // btnBrowseDestinationFolio
            // 
            this.btnBrowseDestinationFolio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseDestinationFolio.Image = global::Jinisys.Hotel.Cashier.Properties.Resources.search_small;
            this.btnBrowseDestinationFolio.Location = new System.Drawing.Point(220, 44);
            this.btnBrowseDestinationFolio.Name = "btnBrowseDestinationFolio";
            this.btnBrowseDestinationFolio.Size = new System.Drawing.Size(31, 29);
            this.btnBrowseDestinationFolio.TabIndex = 8;
            this.btnBrowseDestinationFolio.UseVisualStyleBackColor = true;
            this.btnBrowseDestinationFolio.Click += new System.EventHandler(this.btnBrowseDestinationFolio_Click);
            // 
            // gridDestinationSubFolio
            // 
            this.gridDestinationSubFolio.AllowEditing = false;
            this.gridDestinationSubFolio.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.gridDestinationSubFolio.ColumnInfo = resources.GetString("gridDestinationSubFolio.ColumnInfo");
            this.gridDestinationSubFolio.ExtendLastCol = true;
            this.gridDestinationSubFolio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridDestinationSubFolio.Location = new System.Drawing.Point(11, 238);
            this.gridDestinationSubFolio.Name = "gridDestinationSubFolio";
            this.gridDestinationSubFolio.Rows.Count = 6;
            this.gridDestinationSubFolio.Rows.DefaultSize = 17;
            this.gridDestinationSubFolio.Size = new System.Drawing.Size(387, 109);
            this.gridDestinationSubFolio.StyleInfo = resources.GetString("gridDestinationSubFolio.StyleInfo");
            this.gridDestinationSubFolio.TabIndex = 12;
            // 
            // txtDestinationCompany
            // 
            this.txtDestinationCompany.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDestinationCompany.Location = new System.Drawing.Point(116, 150);
            this.txtDestinationCompany.Name = "txtDestinationCompany";
            this.txtDestinationCompany.ReadOnly = true;
            this.txtDestinationCompany.Size = new System.Drawing.Size(200, 20);
            this.txtDestinationCompany.TabIndex = 11;
            // 
            // txtDestinationRoomNo
            // 
            this.txtDestinationRoomNo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDestinationRoomNo.Location = new System.Drawing.Point(116, 48);
            this.txtDestinationRoomNo.Name = "txtDestinationRoomNo";
            this.txtDestinationRoomNo.ReadOnly = true;
            this.txtDestinationRoomNo.Size = new System.Drawing.Size(97, 20);
            this.txtDestinationRoomNo.TabIndex = 7;
            // 
            // txtDestinationGuestName
            // 
            this.txtDestinationGuestName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDestinationGuestName.Location = new System.Drawing.Point(116, 116);
            this.txtDestinationGuestName.Name = "txtDestinationGuestName";
            this.txtDestinationGuestName.ReadOnly = true;
            this.txtDestinationGuestName.Size = new System.Drawing.Size(200, 20);
            this.txtDestinationGuestName.TabIndex = 10;
            // 
            // txtDestinationFolioId
            // 
            this.txtDestinationFolioId.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDestinationFolioId.Location = new System.Drawing.Point(116, 82);
            this.txtDestinationFolioId.Name = "txtDestinationFolioId";
            this.txtDestinationFolioId.ReadOnly = true;
            this.txtDestinationFolioId.Size = new System.Drawing.Size(97, 20);
            this.txtDestinationFolioId.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 14);
            this.label2.TabIndex = 28;
            this.label2.Text = "Company :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 14);
            this.label3.TabIndex = 26;
            this.label3.Text = "Room No. :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 14);
            this.label4.TabIndex = 24;
            this.label4.Text = "Guest Name :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 14);
            this.label5.TabIndex = 22;
            this.label5.Text = "Folio Id :";
            // 
            // grbOriginFolio
            // 
            this.grbOriginFolio.Controls.Add(this.txtOriginCompany);
            this.grbOriginFolio.Controls.Add(this.txtOriginRoomNo);
            this.grbOriginFolio.Controls.Add(this.txtOriginGuestName);
            this.grbOriginFolio.Controls.Add(this.txtOriginFolioId);
            this.grbOriginFolio.Controls.Add(this.label7);
            this.grbOriginFolio.Controls.Add(this.label8);
            this.grbOriginFolio.Controls.Add(this.label9);
            this.grbOriginFolio.Controls.Add(this.label10);
            this.grbOriginFolio.Controls.Add(this.gridOriginSubFolio);
            this.grbOriginFolio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbOriginFolio.Location = new System.Drawing.Point(10, 16);
            this.grbOriginFolio.Name = "grbOriginFolio";
            this.grbOriginFolio.Size = new System.Drawing.Size(467, 391);
            this.grbOriginFolio.TabIndex = 0;
            this.grbOriginFolio.TabStop = false;
            this.grbOriginFolio.Text = "Origin Folio";
            // 
            // txtOriginCompany
            // 
            this.txtOriginCompany.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOriginCompany.Location = new System.Drawing.Point(116, 150);
            this.txtOriginCompany.Name = "txtOriginCompany";
            this.txtOriginCompany.ReadOnly = true;
            this.txtOriginCompany.Size = new System.Drawing.Size(200, 20);
            this.txtOriginCompany.TabIndex = 4;
            // 
            // txtOriginRoomNo
            // 
            this.txtOriginRoomNo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOriginRoomNo.Location = new System.Drawing.Point(116, 48);
            this.txtOriginRoomNo.Name = "txtOriginRoomNo";
            this.txtOriginRoomNo.ReadOnly = true;
            this.txtOriginRoomNo.Size = new System.Drawing.Size(97, 20);
            this.txtOriginRoomNo.TabIndex = 1;
            // 
            // txtOriginGuestName
            // 
            this.txtOriginGuestName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOriginGuestName.Location = new System.Drawing.Point(116, 116);
            this.txtOriginGuestName.Name = "txtOriginGuestName";
            this.txtOriginGuestName.ReadOnly = true;
            this.txtOriginGuestName.Size = new System.Drawing.Size(200, 20);
            this.txtOriginGuestName.TabIndex = 3;
            // 
            // txtOriginFolioId
            // 
            this.txtOriginFolioId.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOriginFolioId.Location = new System.Drawing.Point(116, 82);
            this.txtOriginFolioId.Name = "txtOriginFolioId";
            this.txtOriginFolioId.ReadOnly = true;
            this.txtOriginFolioId.Size = new System.Drawing.Size(97, 20);
            this.txtOriginFolioId.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(23, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 14);
            this.label7.TabIndex = 18;
            this.label7.Text = "Company :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(23, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 14);
            this.label8.TabIndex = 16;
            this.label8.Text = "Room No. :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(23, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 14);
            this.label9.TabIndex = 14;
            this.label9.Text = "Guest Name :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(23, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 14);
            this.label10.TabIndex = 12;
            this.label10.Text = "Folio Id :";
            // 
            // gridOriginSubFolio
            // 
            this.gridOriginSubFolio.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.gridOriginSubFolio.ColumnInfo = resources.GetString("gridOriginSubFolio.ColumnInfo");
            this.gridOriginSubFolio.ExtendLastCol = true;
            this.gridOriginSubFolio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridOriginSubFolio.Location = new System.Drawing.Point(7, 238);
            this.gridOriginSubFolio.Name = "gridOriginSubFolio";
            this.gridOriginSubFolio.Rows.Count = 6;
            this.gridOriginSubFolio.Rows.DefaultSize = 17;
            this.gridOriginSubFolio.Size = new System.Drawing.Size(454, 109);
            this.gridOriginSubFolio.StyleInfo = resources.GetString("gridOriginSubFolio.StyleInfo");
            this.gridOriginSubFolio.TabIndex = 5;
            this.gridOriginSubFolio.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.gridOriginSubFolio_AfterEdit);
            this.gridOriginSubFolio.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.gridOriginSubFolio_AfterRowColChange);
            this.gridOriginSubFolio.Click += new System.EventHandler(this.gridOriginSubFolio_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(817, 432);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 31);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(745, 432);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 31);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // TransferDebitUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(897, 484);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grbOriginFolio);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TransferDebitUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transfer Debit / Credit";
            this.Load += new System.EventHandler(this.TransferDebitUI_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDestinationSubFolio)).EndInit();
            this.grbOriginFolio.ResumeLayout(false);
            this.grbOriginFolio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridOriginSubFolio)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox grbOriginFolio;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnSave;
		private C1.Win.C1FlexGrid.C1FlexGrid gridOriginSubFolio;
		private System.Windows.Forms.TextBox txtOriginCompany;
		private System.Windows.Forms.TextBox txtOriginRoomNo;
		private System.Windows.Forms.TextBox txtOriginGuestName;
		private System.Windows.Forms.TextBox txtOriginFolioId;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtDestinationCompany;
		private System.Windows.Forms.TextBox txtDestinationRoomNo;
		private System.Windows.Forms.TextBox txtDestinationGuestName;
		private System.Windows.Forms.TextBox txtDestinationFolioId;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private C1.Win.C1FlexGrid.C1FlexGrid gridDestinationSubFolio;
		private System.Windows.Forms.Button btnBrowseDestinationFolio;
	}
}