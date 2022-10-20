namespace Jinisys.Hotel.Reservation.Presentation
{
	partial class BrowseTransactionCodesUI
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

		#region Windows Form Designer generated lCode

		/// <summary>
		/// Required _method for Designer support - do not modify
		/// the contents of this _method with the lCode editor.
		/// </summary>
		private void InitializeComponent()
		{
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowseTransactionCodesUI));
this.gridTransactionCodes = new C1.Win.C1FlexGrid.Classic.C1FlexGridClassic();
this.btnSelect = new System.Windows.Forms.Button();
this.btnClose = new System.Windows.Forms.Button();
((System.ComponentModel.ISupportInitialize)(this.gridTransactionCodes)).BeginInit();
this.SuspendLayout();
// 
// gridTransactionCodes
// 
this.gridTransactionCodes.AllowUserResizing = C1.Win.C1FlexGrid.Classic.AllowUserResizeSettings.flexResizeColumns;
this.gridTransactionCodes.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor;
this.gridTransactionCodes.BackColorSel = System.Drawing.SystemColors.Info;
this.gridTransactionCodes.Cols = 2;
this.gridTransactionCodes.ColumnInfo = "2,0,0,0,0,85,Columns:0{Width:61;Caption:\"Code\";TextAlign:CenterCenter;TextAlignFi" +
    "xed:CenterCenter;}\t1{Width:104;Caption:\"Memo\";TextAlign:LeftCenter;TextAlignFixe" +
    "d:CenterCenter;}\t";
this.gridTransactionCodes.ExtendLastCol = true;
this.gridTransactionCodes.FixedCols = 0;
this.gridTransactionCodes.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
this.gridTransactionCodes.ForeColorSel = System.Drawing.Color.Black;
this.gridTransactionCodes.GridColorFixed = System.Drawing.SystemColors.ControlDark;
this.gridTransactionCodes.Location = new System.Drawing.Point(12, 12);
this.gridTransactionCodes.Name = "gridTransactionCodes";
this.gridTransactionCodes.NodeClosedPicture = null;
this.gridTransactionCodes.NodeOpenPicture = null;
this.gridTransactionCodes.OutlineCol = -1;
this.gridTransactionCodes.Rows = 9;
this.gridTransactionCodes.SelectionMode = C1.Win.C1FlexGrid.Classic.SelModeSettings.flexSelectionByRow;
this.gridTransactionCodes.Size = new System.Drawing.Size(580, 389);
this.gridTransactionCodes.StyleInfo = resources.GetString("gridTransactionCodes.StyleInfo");
this.gridTransactionCodes.TabIndex = 39;
this.gridTransactionCodes.TreeColor = System.Drawing.Color.DarkGray;
this.gridTransactionCodes.DoubleClick += new System.EventHandler(this.gridTransactionCodes_DoubleClick);
// 
// btnSelect
// 
this.btnSelect.Location = new System.Drawing.Point(454, 416);
this.btnSelect.Name = "btnSelect";
this.btnSelect.Size = new System.Drawing.Size(66, 31);
this.btnSelect.TabIndex = 40;
this.btnSelect.Text = "&Select";
this.btnSelect.UseVisualStyleBackColor = true;
this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
// 
// btnClose
// 
this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
this.btnClose.Location = new System.Drawing.Point(526, 416);
this.btnClose.Name = "btnClose";
this.btnClose.Size = new System.Drawing.Size(66, 31);
this.btnClose.TabIndex = 41;
this.btnClose.Text = "&Close";
this.btnClose.UseVisualStyleBackColor = true;
this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
// 
// BrowseTransactionCodesUI
// 
this.AcceptButton = this.btnSelect;
this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
this.CancelButton = this.btnClose;
this.ClientSize = new System.Drawing.Size(604, 462);
this.Controls.Add(this.btnClose);
this.Controls.Add(this.btnSelect);
this.Controls.Add(this.gridTransactionCodes);
this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
this.MaximizeBox = false;
this.MinimizeBox = false;
this.Name = "BrowseTransactionCodesUI";
this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
this.Text = "Transaction Codes List";
this.Load += new System.EventHandler(this.BrowseTransactionCodesUI_Load);
((System.ComponentModel.ISupportInitialize)(this.gridTransactionCodes)).EndInit();
this.ResumeLayout(false);

		}

		#endregion

		internal C1.Win.C1FlexGrid.Classic.C1FlexGridClassic gridTransactionCodes;
		private System.Windows.Forms.Button btnSelect;
		private System.Windows.Forms.Button btnClose;
	}
}