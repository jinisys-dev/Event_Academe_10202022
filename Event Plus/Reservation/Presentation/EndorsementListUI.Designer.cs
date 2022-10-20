namespace Jinisys.Hotel.Reservation.Presentation
{
	partial class EndorsementListUI
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EndorsementListUI));
			this.grdEndorsementList = new C1.Win.C1FlexGrid.C1FlexGrid();
			this.dtpDate = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnAcknowledge = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.grdEndorsementList)).BeginInit();
			this.SuspendLayout();
			// 
			// grdEndorsementList
			// 
			this.grdEndorsementList.AllowEditing = false;
			this.grdEndorsementList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grdEndorsementList.ColumnInfo = resources.GetString("grdEndorsementList.ColumnInfo");
			this.grdEndorsementList.ExtendLastCol = true;
			this.grdEndorsementList.Location = new System.Drawing.Point(12, 110);
			this.grdEndorsementList.Name = "grdEndorsementList";
			this.grdEndorsementList.Rows.DefaultSize = 17;
			this.grdEndorsementList.Size = new System.Drawing.Size(817, 458);
			this.grdEndorsementList.StyleInfo = resources.GetString("grdEndorsementList.StyleInfo");
			this.grdEndorsementList.TabIndex = 0;
			this.grdEndorsementList.DoubleClick += new System.EventHandler(this.grdEndorsementList_DoubleClick);
			this.grdEndorsementList.RowColChange += new System.EventHandler(this.grdEndorsementList_RowColChange);
			// 
			// dtpDate
			// 
			this.dtpDate.Location = new System.Drawing.Point(77, 67);
			this.dtpDate.Name = "dtpDate";
			this.dtpDate.Size = new System.Drawing.Size(200, 20);
			this.dtpDate.TabIndex = 1;
			this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 70);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 14);
			this.label1.TabIndex = 2;
			this.label1.Text = "Date :";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(134, 22);
			this.label2.TabIndex = 3;
			this.label2.Text = "Endorsements";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Location = new System.Drawing.Point(12, 41);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(473, 5);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(520, 29);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(66, 31);
			this.btnAdd.TabIndex = 5;
			this.btnAdd.Text = "&New";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnAcknowledge
			// 
			this.btnAcknowledge.Location = new System.Drawing.Point(664, 29);
			this.btnAcknowledge.Name = "btnAcknowledge";
			this.btnAcknowledge.Size = new System.Drawing.Size(88, 31);
			this.btnAcknowledge.TabIndex = 6;
			this.btnAcknowledge.Text = "&Acknowledge";
			this.btnAcknowledge.UseVisualStyleBackColor = true;
			this.btnAcknowledge.Click += new System.EventHandler(this.btnAcknowledge_Click);
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(758, 29);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(66, 31);
			this.btnClose.TabIndex = 7;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Location = new System.Drawing.Point(592, 29);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(66, 31);
			this.btnEdit.TabIndex = 8;
			this.btnEdit.Text = "&Edit";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// EndorsementListUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(841, 582);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnAcknowledge);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dtpDate);
			this.Controls.Add(this.grdEndorsementList);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "EndorsementListUI";
			this.Text = "EndorsementListUI";
			this.Activated += new System.EventHandler(this.EndorsementListUI_Activated);
			this.Load += new System.EventHandler(this.EndorsementListUI_Load);
			((System.ComponentModel.ISupportInitialize)(this.grdEndorsementList)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private C1.Win.C1FlexGrid.C1FlexGrid grdEndorsementList;
		private System.Windows.Forms.DateTimePicker dtpDate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnAcknowledge;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnEdit;
	}
}