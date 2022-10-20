namespace Jinisys.Hotel.ConfigurationHotel.Presentation
{
	partial class TransactionSourceDocumentUI
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
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionSourceDocumentUI));
this.grpMain = new System.Windows.Forms.GroupBox();
this.lblSourceId = new System.Windows.Forms.Label();
this.txtAbbreviation = new System.Windows.Forms.TextBox();
this.label7 = new System.Windows.Forms.Label();
this.txtDescription = new System.Windows.Forms.TextBox();
this.label2 = new System.Windows.Forms.Label();
this.Label1 = new System.Windows.Forms.Label();
this.gbxCommands = new System.Windows.Forms.GroupBox();
this.btnClose = new System.Windows.Forms.Button();
this.btnDelete = new System.Windows.Forms.Button();
this.btnSave = new System.Windows.Forms.Button();
this.btnNew = new System.Windows.Forms.Button();
this.btnCancel = new System.Windows.Forms.Button();
this.grdTransactionSources = new C1.Win.C1FlexGrid.Classic.C1FlexGridClassic();
this.grpMain.SuspendLayout();
this.gbxCommands.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.grdTransactionSources)).BeginInit();
this.SuspendLayout();
// 
// grpMain
// 
this.grpMain.BackColor = System.Drawing.Color.Transparent;
this.grpMain.Controls.Add(this.lblSourceId);
this.grpMain.Controls.Add(this.txtAbbreviation);
this.grpMain.Controls.Add(this.label7);
this.grpMain.Controls.Add(this.txtDescription);
this.grpMain.Controls.Add(this.label2);
this.grpMain.Controls.Add(this.Label1);
this.grpMain.Location = new System.Drawing.Point(228, 6);
this.grpMain.Name = "grpMain";
this.grpMain.Size = new System.Drawing.Size(315, 433);
this.grpMain.TabIndex = 1;
this.grpMain.TabStop = false;
// 
// lblSourceId
// 
this.lblSourceId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
this.lblSourceId.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.lblSourceId.Location = new System.Drawing.Point(98, 40);
this.lblSourceId.Name = "lblSourceId";
this.lblSourceId.Size = new System.Drawing.Size(84, 20);
this.lblSourceId.TabIndex = 2;
this.lblSourceId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
// 
// txtAbbreviation
// 
this.txtAbbreviation.BackColor = System.Drawing.SystemColors.Info;
this.txtAbbreviation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtAbbreviation.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtAbbreviation.Location = new System.Drawing.Point(98, 102);
this.txtAbbreviation.MaxLength = 10;
this.txtAbbreviation.Name = "txtAbbreviation";
this.txtAbbreviation.Size = new System.Drawing.Size(104, 20);
this.txtAbbreviation.TabIndex = 4;
// 
// label7
// 
this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label7.Location = new System.Drawing.Point(17, 105);
this.label7.Name = "label7";
this.label7.Size = new System.Drawing.Size(76, 17);
this.label7.TabIndex = 62;
this.label7.Text = "Abbreviation :";
// 
// txtDescription
// 
this.txtDescription.BackColor = System.Drawing.SystemColors.Info;
this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtDescription.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtDescription.Location = new System.Drawing.Point(98, 136);
this.txtDescription.MaxLength = 50;
this.txtDescription.Name = "txtDescription";
this.txtDescription.Size = new System.Drawing.Size(192, 20);
this.txtDescription.TabIndex = 5;
// 
// label2
// 
this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label2.Location = new System.Drawing.Point(17, 139);
this.label2.Name = "label2";
this.label2.Size = new System.Drawing.Size(76, 17);
this.label2.TabIndex = 56;
this.label2.Text = "Description :";
// 
// Label1
// 
this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label1.Location = new System.Drawing.Point(17, 43);
this.Label1.Name = "Label1";
this.Label1.Size = new System.Drawing.Size(76, 17);
this.Label1.TabIndex = 54;
this.Label1.Text = "Document Id :";
// 
// gbxCommands
// 
this.gbxCommands.Controls.Add(this.btnClose);
this.gbxCommands.Controls.Add(this.btnDelete);
this.gbxCommands.Controls.Add(this.btnSave);
this.gbxCommands.Controls.Add(this.btnNew);
this.gbxCommands.Controls.Add(this.btnCancel);
this.gbxCommands.Location = new System.Drawing.Point(8, 445);
this.gbxCommands.Name = "gbxCommands";
this.gbxCommands.Size = new System.Drawing.Size(535, 47);
this.gbxCommands.TabIndex = 2;
this.gbxCommands.TabStop = false;
// 
// btnClose
// 
this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnClose.Location = new System.Drawing.Point(463, 10);
this.btnClose.Name = "btnClose";
this.btnClose.Size = new System.Drawing.Size(66, 31);
this.btnClose.TabIndex = 14;
this.btnClose.Text = "Cl&ose";
this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
// 
// btnDelete
// 
this.btnDelete.Cursor = System.Windows.Forms.Cursors.Default;
this.btnDelete.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnDelete.Location = new System.Drawing.Point(6, 10);
this.btnDelete.Name = "btnDelete";
this.btnDelete.Size = new System.Drawing.Size(66, 31);
this.btnDelete.TabIndex = 9;
this.btnDelete.Text = "&Delete";
this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
// 
// btnSave
// 
this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
this.btnSave.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnSave.Location = new System.Drawing.Point(326, 10);
this.btnSave.Name = "btnSave";
this.btnSave.Size = new System.Drawing.Size(66, 31);
this.btnSave.TabIndex = 12;
this.btnSave.Text = "&Save";
this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
// 
// btnNew
// 
this.btnNew.Cursor = System.Windows.Forms.Cursors.Default;
this.btnNew.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnNew.Location = new System.Drawing.Point(257, 10);
this.btnNew.Name = "btnNew";
this.btnNew.Size = new System.Drawing.Size(66, 31);
this.btnNew.TabIndex = 11;
this.btnNew.Text = "&New";
this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
// 
// btnCancel
// 
this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
this.btnCancel.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnCancel.Location = new System.Drawing.Point(395, 10);
this.btnCancel.Name = "btnCancel";
this.btnCancel.Size = new System.Drawing.Size(66, 31);
this.btnCancel.TabIndex = 13;
this.btnCancel.Text = "&Cancel";
this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
// 
// grdTransactionSources
// 
this.grdTransactionSources.AllowUserResizing = C1.Win.C1FlexGrid.Classic.AllowUserResizeSettings.flexResizeColumns;
this.grdTransactionSources.BackColorSel = System.Drawing.SystemColors.Info;
this.grdTransactionSources.Cols = 2;
this.grdTransactionSources.ColumnInfo = "2,0,0,0,0,85,Columns:0{Width:52;Caption:\"Code\";TextAlign:LeftCenter;TextAlignFixe" +
    "d:CenterCenter;}\t1{Width:95;Caption:\"Sub-Account\";TextAlign:LeftCenter;TextAlign" +
    "Fixed:CenterCenter;}\t";
this.grdTransactionSources.ExtendLastCol = true;
this.grdTransactionSources.FixedCols = 0;
this.grdTransactionSources.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
this.grdTransactionSources.Font = new System.Drawing.Font("Arial", 8.25F);
this.grdTransactionSources.ForeColorSel = System.Drawing.Color.Black;
this.grdTransactionSources.GridColorFixed = System.Drawing.SystemColors.ControlDark;
this.grdTransactionSources.Location = new System.Drawing.Point(8, 12);
this.grdTransactionSources.Name = "grdTransactionSources";
this.grdTransactionSources.NodeClosedPicture = null;
this.grdTransactionSources.NodeOpenPicture = null;
this.grdTransactionSources.OutlineCol = -1;
this.grdTransactionSources.SelectionMode = C1.Win.C1FlexGrid.Classic.SelModeSettings.flexSelectionByRow;
this.grdTransactionSources.Size = new System.Drawing.Size(214, 427);
this.grdTransactionSources.StyleInfo = resources.GetString("grdTransactionSources.StyleInfo");
this.grdTransactionSources.TabIndex = 0;
this.grdTransactionSources.TreeColor = System.Drawing.Color.DarkGray;
this.grdTransactionSources.RowColChange += new System.EventHandler(this.grdTransactionSourceDocuments_RowColChange);
// 
// TransactionSourceDocumentUI
// 
this.CancelButton = this.btnClose;
this.ClientSize = new System.Drawing.Size(555, 505);
this.Controls.Add(this.grdTransactionSources);
this.Controls.Add(this.grpMain);
this.Controls.Add(this.gbxCommands);
this.Name = "TransactionSourceDocumentUI";
this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
this.Text = "Transaction Source Documents";
this.TextChanged += new System.EventHandler(this.TransactionSourceDocumentUI_TextChanged);
this.Load += new System.EventHandler(this.TransactionSourceDocumentUI_Load);
this.grpMain.ResumeLayout(false);
this.grpMain.PerformLayout();
this.gbxCommands.ResumeLayout(false);
((System.ComponentModel.ISupportInitialize)(this.grdTransactionSources)).EndInit();
this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.GroupBox grpMain;
		public System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.GroupBox gbxCommands;
		internal System.Windows.Forms.Button btnDelete;
		internal System.Windows.Forms.Button btnSave;
		internal System.Windows.Forms.Button btnNew;
		internal System.Windows.Forms.Button btnCancel;
		public System.Windows.Forms.TextBox txtDescription;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox txtAbbreviation;
		public System.Windows.Forms.Label label7;
		public System.Windows.Forms.Label lblSourceId;
		internal System.Windows.Forms.Button btnClose;
		internal C1.Win.C1FlexGrid.Classic.C1FlexGridClassic grdTransactionSources;
	}
}
