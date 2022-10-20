namespace Jinisys.Hotel.Reservation.Presentation
{
	partial class BrowseFolioUI
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.dtgFolio = new System.Windows.Forms.DataGridView();
			this.colRoomId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colFolioId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colTotalContribution = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colAccountId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colArrivalDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colDepartureDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cboSearchCriteria = new System.Windows.Forms.ComboBox();
			this.btnSearch = new System.Windows.Forms.Button();
			this.tabFolios = new System.Windows.Forms.TabControl();
			this.tabIndividual = new System.Windows.Forms.TabPage();
			this.tabGroup = new System.Windows.Forms.TabPage();
			this.dtgGroup = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dtgFolio)).BeginInit();
			this.tabFolios.SuspendLayout();
			this.tabIndividual.SuspendLayout();
			this.tabGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtgGroup)).BeginInit();
			this.SuspendLayout();
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnClose.Location = new System.Drawing.Point(582, 524);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(66, 33);
			this.btnClose.TabIndex = 5;
			this.btnClose.Text = "&Close";
			// 
			// btnOK
			// 
			this.btnOK.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnOK.Location = new System.Drawing.Point(512, 524);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(66, 33);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "&Ok";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// txtSearch
			// 
			this.txtSearch.Location = new System.Drawing.Point(63, 29);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(345, 20);
			this.txtSearch.TabIndex = 0;
			this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
			// 
			// Label1
			// 
			this.Label1.Location = new System.Drawing.Point(16, 31);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(43, 17);
			this.Label1.TabIndex = 7;
			this.Label1.Text = "Search";
			// 
			// dtgFolio
			// 
			this.dtgFolio.AllowUserToAddRows = false;
			this.dtgFolio.AllowUserToDeleteRows = false;
			this.dtgFolio.AllowUserToOrderColumns = true;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.dtgFolio.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dtgFolio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtgFolio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRoomId,
            this.colFolioId,
            this.colLastName,
            this.colFirstName,
            this.colTotalContribution,
            this.colAccountId,
            this.colArrivalDate,
            this.colDepartureDate,
            this.colCompanyName});
			this.dtgFolio.Location = new System.Drawing.Point(8, 11);
			this.dtgFolio.Name = "dtgFolio";
			this.dtgFolio.ReadOnly = true;
			this.dtgFolio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dtgFolio.Size = new System.Drawing.Size(609, 395);
			this.dtgFolio.TabIndex = 3;
			this.dtgFolio.DoubleClick += new System.EventHandler(this.dtgDrivers_DoubleClick);
			this.dtgFolio.SelectionChanged += new System.EventHandler(this.dtgFolio_SelectionChanged);
			this.dtgFolio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtgDrivers_KeyPress);
			// 
			// colRoomId
			// 
			this.colRoomId.HeaderText = "Room Id";
			this.colRoomId.Name = "colRoomId";
			this.colRoomId.ReadOnly = true;
			// 
			// colFolioId
			// 
			this.colFolioId.HeaderText = "Folio Id";
			this.colFolioId.Name = "colFolioId";
			this.colFolioId.ReadOnly = true;
			// 
			// colLastName
			// 
			this.colLastName.HeaderText = "Last Name";
			this.colLastName.Name = "colLastName";
			this.colLastName.ReadOnly = true;
			// 
			// colFirstName
			// 
			this.colFirstName.HeaderText = "First Name";
			this.colFirstName.Name = "colFirstName";
			this.colFirstName.ReadOnly = true;
			// 
			// colTotalContribution
			// 
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle2.Format = "N2";
			this.colTotalContribution.DefaultCellStyle = dataGridViewCellStyle2;
			this.colTotalContribution.HeaderText = "Total Contribution";
			this.colTotalContribution.Name = "colTotalContribution";
			this.colTotalContribution.ReadOnly = true;
			this.colTotalContribution.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.colTotalContribution.Width = 150;
			// 
			// colAccountId
			// 
			this.colAccountId.HeaderText = "Account Id";
			this.colAccountId.Name = "colAccountId";
			this.colAccountId.ReadOnly = true;
			this.colAccountId.Visible = false;
			this.colAccountId.Width = 5;
			// 
			// colArrivalDate
			// 
			this.colArrivalDate.HeaderText = "ArrivalDate";
			this.colArrivalDate.Name = "colArrivalDate";
			this.colArrivalDate.ReadOnly = true;
			this.colArrivalDate.Visible = false;
			// 
			// colDepartureDate
			// 
			this.colDepartureDate.HeaderText = "Departure Date";
			this.colDepartureDate.Name = "colDepartureDate";
			this.colDepartureDate.ReadOnly = true;
			this.colDepartureDate.Visible = false;
			// 
			// colCompanyName
			// 
			this.colCompanyName.HeaderText = "Company Name";
			this.colCompanyName.Name = "colCompanyName";
			this.colCompanyName.ReadOnly = true;
			this.colCompanyName.Visible = false;
			// 
			// cboSearchCriteria
			// 
			this.cboSearchCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboSearchCriteria.FormattingEnabled = true;
			this.cboSearchCriteria.Items.AddRange(new object[] {
            "ROOM NO",
            "FOLIO ID",
            "LAST NAME",
            "FIRST NAME"});
			this.cboSearchCriteria.Location = new System.Drawing.Point(414, 28);
			this.cboSearchCriteria.Name = "cboSearchCriteria";
			this.cboSearchCriteria.Size = new System.Drawing.Size(142, 22);
			this.cboSearchCriteria.TabIndex = 1;
			// 
			// btnSearch
			// 
			this.btnSearch.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSearch.Location = new System.Drawing.Point(568, 24);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(58, 28);
			this.btnSearch.TabIndex = 2;
			this.btnSearch.Text = "&Search";
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// tabFolios
			// 
			this.tabFolios.Controls.Add(this.tabIndividual);
			this.tabFolios.Controls.Add(this.tabGroup);
			this.tabFolios.Location = new System.Drawing.Point(17, 61);
			this.tabFolios.Name = "tabFolios";
			this.tabFolios.SelectedIndex = 0;
			this.tabFolios.Size = new System.Drawing.Size(634, 444);
			this.tabFolios.TabIndex = 8;
			this.tabFolios.SelectedIndexChanged += new System.EventHandler(this.tabFolios_SelectedIndexChanged);
			// 
			// tabIndividual
			// 
			this.tabIndividual.Controls.Add(this.dtgFolio);
			this.tabIndividual.Location = new System.Drawing.Point(4, 23);
			this.tabIndividual.Name = "tabIndividual";
			this.tabIndividual.Padding = new System.Windows.Forms.Padding(3);
			this.tabIndividual.Size = new System.Drawing.Size(626, 417);
			this.tabIndividual.TabIndex = 0;
			this.tabIndividual.Text = "Individual";
			this.tabIndividual.UseVisualStyleBackColor = true;
			// 
			// tabGroup
			// 
			this.tabGroup.Controls.Add(this.dtgGroup);
			this.tabGroup.Location = new System.Drawing.Point(4, 23);
			this.tabGroup.Name = "tabGroup";
			this.tabGroup.Padding = new System.Windows.Forms.Padding(3);
			this.tabGroup.Size = new System.Drawing.Size(626, 417);
			this.tabGroup.TabIndex = 1;
			this.tabGroup.Text = "Group";
			this.tabGroup.UseVisualStyleBackColor = true;
			// 
			// dtgGroup
			// 
			this.dtgGroup.AllowUserToAddRows = false;
			this.dtgGroup.AllowUserToDeleteRows = false;
			this.dtgGroup.AllowUserToOrderColumns = true;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.dtgGroup.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
			this.dtgGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtgGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
			this.dtgGroup.Location = new System.Drawing.Point(8, 11);
			this.dtgGroup.Name = "dtgGroup";
			this.dtgGroup.ReadOnly = true;
			this.dtgGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dtgGroup.Size = new System.Drawing.Size(609, 395);
			this.dtgGroup.TabIndex = 4;
			this.dtgGroup.DoubleClick += new System.EventHandler(this.dtgGroup_DoubleClick);
			this.dtgGroup.SelectionChanged += new System.EventHandler(this.dtgGroup_SelectionChanged);
			this.dtgGroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtgGroup_KeyPress);
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.HeaderText = "Function";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Width = 80;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.HeaderText = "Folio Id";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.Width = 80;
			// 
			// dataGridViewTextBoxColumn3
			// 
			this.dataGridViewTextBoxColumn3.HeaderText = "Event Name";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			this.dataGridViewTextBoxColumn3.Width = 150;
			// 
			// dataGridViewTextBoxColumn4
			// 
			this.dataGridViewTextBoxColumn4.HeaderText = "Company";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			this.dataGridViewTextBoxColumn4.Width = 130;
			// 
			// dataGridViewTextBoxColumn5
			// 
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle4.Format = "N2";
			this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle4;
			this.dataGridViewTextBoxColumn5.HeaderText = "Sales Contribution";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.ReadOnly = true;
			this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			// 
			// dataGridViewTextBoxColumn6
			// 
			this.dataGridViewTextBoxColumn6.HeaderText = "Account Id";
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn6.ReadOnly = true;
			this.dataGridViewTextBoxColumn6.Visible = false;
			this.dataGridViewTextBoxColumn6.Width = 5;
			// 
			// dataGridViewTextBoxColumn7
			// 
			this.dataGridViewTextBoxColumn7.HeaderText = "ArrivalDate";
			this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn7.ReadOnly = true;
			this.dataGridViewTextBoxColumn7.Visible = false;
			// 
			// dataGridViewTextBoxColumn8
			// 
			this.dataGridViewTextBoxColumn8.HeaderText = "Departure Date";
			this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
			this.dataGridViewTextBoxColumn8.ReadOnly = true;
			this.dataGridViewTextBoxColumn8.Visible = false;
			// 
			// BrowseFolioUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(667, 572);
			this.Controls.Add(this.tabFolios);
			this.Controls.Add(this.btnSearch);
			this.Controls.Add(this.cboSearchCriteria);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.txtSearch);
			this.Controls.Add(this.btnOK);
			this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "BrowseFolioUI";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Select Folio";
			this.Load += new System.EventHandler(this.BrowseFolioUI_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtgFolio)).EndInit();
			this.tabFolios.ResumeLayout(false);
			this.tabIndividual.ResumeLayout(false);
			this.tabGroup.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dtgGroup)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Button btnClose;
		internal System.Windows.Forms.Button btnOK;
		internal System.Windows.Forms.TextBox txtSearch;
		internal System.Windows.Forms.Label Label1;
		private System.Windows.Forms.DataGridView dtgFolio;
		private System.Windows.Forms.ComboBox cboSearchCriteria;
		internal System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.DataGridViewTextBoxColumn colRoomId;
		private System.Windows.Forms.DataGridViewTextBoxColumn colFolioId;
		private System.Windows.Forms.DataGridViewTextBoxColumn colLastName;
		private System.Windows.Forms.DataGridViewTextBoxColumn colFirstName;
		private System.Windows.Forms.DataGridViewTextBoxColumn colTotalContribution;
		private System.Windows.Forms.DataGridViewTextBoxColumn colAccountId;
		private System.Windows.Forms.DataGridViewTextBoxColumn colArrivalDate;
		private System.Windows.Forms.DataGridViewTextBoxColumn colDepartureDate;
		private System.Windows.Forms.DataGridViewTextBoxColumn colCompanyName;
		private System.Windows.Forms.TabControl tabFolios;
		private System.Windows.Forms.TabPage tabIndividual;
		private System.Windows.Forms.TabPage tabGroup;
		private System.Windows.Forms.DataGridView dtgGroup;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
	}
}