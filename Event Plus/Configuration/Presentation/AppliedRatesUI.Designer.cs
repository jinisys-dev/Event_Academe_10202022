namespace Jinisys.Hotel.ConfigurationHotel
{
    namespace Presentation
    {
        partial class AppliedRatesUI
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
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppliedRatesUI));
this.label4 = new System.Windows.Forms.Label();
this.btnNew = new System.Windows.Forms.Button();
this.lblAppliedID = new System.Windows.Forms.Label();
this.gridMain = new C1.Win.C1FlexGrid.Classic.C1FlexGridClassic();
this.txtDESCRIPTION = new System.Windows.Forms.TextBox();
this.gbxItems = new System.Windows.Forms.GroupBox();
this.label3 = new System.Windows.Forms.Label();
this.cboRateType = new System.Windows.Forms.ComboBox();
this.nudNumberOccupants = new System.Windows.Forms.NumericUpDown();
this.label2 = new System.Windows.Forms.Label();
this.label1 = new System.Windows.Forms.Label();
this.btnCancel = new System.Windows.Forms.Button();
this.btnDelete = new System.Windows.Forms.Button();
this.btnClose = new System.Windows.Forms.Button();
this.btnSave = new System.Windows.Forms.Button();
this.gbxControls = new System.Windows.Forms.GroupBox();
this.btnSearch = new System.Windows.Forms.Button();
((System.ComponentModel.ISupportInitialize)(this.gridMain)).BeginInit();
this.gbxItems.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.nudNumberOccupants)).BeginInit();
this.gbxControls.SuspendLayout();
this.SuspendLayout();
// 
// label4
// 
this.label4.Location = new System.Drawing.Point(16, 101);
this.label4.Name = "label4";
this.label4.Size = new System.Drawing.Size(86, 16);
this.label4.TabIndex = 35;
this.label4.Text = "Description";
// 
// btnNew
// 
this.btnNew.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnNew.Location = new System.Drawing.Point(298, 12);
this.btnNew.Name = "btnNew";
this.btnNew.Size = new System.Drawing.Size(66, 31);
this.btnNew.TabIndex = 191;
this.btnNew.Text = "&New";
this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
// 
// lblAppliedID
// 
this.lblAppliedID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
this.lblAppliedID.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.lblAppliedID.Location = new System.Drawing.Point(104, 55);
this.lblAppliedID.Name = "lblAppliedID";
this.lblAppliedID.Size = new System.Drawing.Size(118, 20);
this.lblAppliedID.TabIndex = 45;
this.lblAppliedID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
// 
// gridMain
// 
this.gridMain.AllowUserResizing = C1.Win.C1FlexGrid.Classic.AllowUserResizeSettings.flexResizeColumns;
this.gridMain.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor;
this.gridMain.BackColorSel = System.Drawing.SystemColors.Info;
this.gridMain.Cols = 2;
this.gridMain.ColumnInfo = "2,0,0,0,0,85,Columns:0{Width:0;Caption:\"ID\";}\t1{Width:115;Caption:\"Description\";}" +
    "\t";
this.gridMain.ExtendLastCol = true;
this.gridMain.FixedCols = 0;
this.gridMain.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
this.gridMain.Font = new System.Drawing.Font("Arial", 8.25F);
this.gridMain.ForeColorSel = System.Drawing.Color.Black;
this.gridMain.GridColorFixed = System.Drawing.SystemColors.ControlDark;
this.gridMain.Location = new System.Drawing.Point(5, 9);
this.gridMain.Name = "gridMain";
this.gridMain.NodeClosedPicture = null;
this.gridMain.NodeOpenPicture = null;
this.gridMain.OutlineCol = -1;
this.gridMain.SelectionMode = C1.Win.C1FlexGrid.Classic.SelModeSettings.flexSelectionByRow;
this.gridMain.Size = new System.Drawing.Size(210, 414);
this.gridMain.StyleInfo = resources.GetString("gridMain.StyleInfo");
this.gridMain.TabIndex = 198;
this.gridMain.TreeColor = System.Drawing.Color.DarkGray;
this.gridMain.RowColChange += new System.EventHandler(this.gridMain_RowColChange);
// 
// txtDESCRIPTION
// 
this.txtDESCRIPTION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtDESCRIPTION.Location = new System.Drawing.Point(104, 96);
this.txtDESCRIPTION.Multiline = true;
this.txtDESCRIPTION.Name = "txtDESCRIPTION";
this.txtDESCRIPTION.Size = new System.Drawing.Size(247, 55);
this.txtDESCRIPTION.TabIndex = 30;
// 
// gbxItems
// 
this.gbxItems.Controls.Add(this.label3);
this.gbxItems.Controls.Add(this.cboRateType);
this.gbxItems.Controls.Add(this.nudNumberOccupants);
this.gbxItems.Controls.Add(this.label2);
this.gbxItems.Controls.Add(this.lblAppliedID);
this.gbxItems.Controls.Add(this.txtDESCRIPTION);
this.gbxItems.Controls.Add(this.label4);
this.gbxItems.Controls.Add(this.label1);
this.gbxItems.Location = new System.Drawing.Point(217, 3);
this.gbxItems.Name = "gbxItems";
this.gbxItems.Size = new System.Drawing.Size(368, 420);
this.gbxItems.TabIndex = 196;
this.gbxItems.TabStop = false;
// 
// label3
// 
this.label3.Location = new System.Drawing.Point(16, 210);
this.label3.Name = "label3";
this.label3.Size = new System.Drawing.Size(86, 16);
this.label3.TabIndex = 49;
this.label3.Text = "Rate Type";
// 
// cboRateType
// 
this.cboRateType.FormattingEnabled = true;
this.cboRateType.Items.AddRange(new object[] {
            "ROOM RATES",
            "MEAL RATES"});
this.cboRateType.Location = new System.Drawing.Point(104, 207);
this.cboRateType.Name = "cboRateType";
this.cboRateType.Size = new System.Drawing.Size(121, 21);
this.cboRateType.TabIndex = 48;
// 
// nudNumberOccupants
// 
this.nudNumberOccupants.Location = new System.Drawing.Point(104, 171);
this.nudNumberOccupants.Name = "nudNumberOccupants";
this.nudNumberOccupants.Size = new System.Drawing.Size(120, 20);
this.nudNumberOccupants.TabIndex = 47;
// 
// label2
// 
this.label2.Location = new System.Drawing.Point(16, 176);
this.label2.Name = "label2";
this.label2.Size = new System.Drawing.Size(86, 16);
this.label2.TabIndex = 46;
this.label2.Text = "No. Occupants";
// 
// label1
// 
this.label1.Location = new System.Drawing.Point(16, 59);
this.label1.Name = "label1";
this.label1.Size = new System.Drawing.Size(86, 16);
this.label1.TabIndex = 26;
this.label1.Text = "Rate ID";
// 
// btnCancel
// 
this.btnCancel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnCancel.Location = new System.Drawing.Point(438, 12);
this.btnCancel.Name = "btnCancel";
this.btnCancel.Size = new System.Drawing.Size(66, 31);
this.btnCancel.TabIndex = 189;
this.btnCancel.Text = "&Cancel";
this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
// 
// btnDelete
// 
this.btnDelete.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnDelete.Location = new System.Drawing.Point(8, 12);
this.btnDelete.Name = "btnDelete";
this.btnDelete.Size = new System.Drawing.Size(66, 31);
this.btnDelete.TabIndex = 194;
this.btnDelete.Text = "&Delete";
this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
// 
// btnClose
// 
this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.btnClose.Location = new System.Drawing.Point(508, 12);
this.btnClose.Name = "btnClose";
this.btnClose.Size = new System.Drawing.Size(66, 31);
this.btnClose.TabIndex = 193;
this.btnClose.Text = "Cl&ose";
this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
// 
// btnSave
// 
this.btnSave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnSave.Location = new System.Drawing.Point(368, 12);
this.btnSave.Name = "btnSave";
this.btnSave.Size = new System.Drawing.Size(66, 31);
this.btnSave.TabIndex = 190;
this.btnSave.Text = "&Save";
this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
// 
// gbxControls
// 
this.gbxControls.Controls.Add(this.btnDelete);
this.gbxControls.Controls.Add(this.btnClose);
this.gbxControls.Controls.Add(this.btnSave);
this.gbxControls.Controls.Add(this.btnSearch);
this.gbxControls.Controls.Add(this.btnCancel);
this.gbxControls.Controls.Add(this.btnNew);
this.gbxControls.Location = new System.Drawing.Point(5, 425);
this.gbxControls.Name = "gbxControls";
this.gbxControls.Size = new System.Drawing.Size(580, 49);
this.gbxControls.TabIndex = 197;
this.gbxControls.TabStop = false;
// 
// btnSearch
// 
this.btnSearch.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnSearch.Location = new System.Drawing.Point(228, 12);
this.btnSearch.Name = "btnSearch";
this.btnSearch.Size = new System.Drawing.Size(66, 31);
this.btnSearch.TabIndex = 192;
this.btnSearch.Text = "&Search";
// 
// AppliedRatesUI
// 
this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
this.ClientSize = new System.Drawing.Size(591, 477);
this.Controls.Add(this.gridMain);
this.Controls.Add(this.gbxItems);
this.Controls.Add(this.gbxControls);
this.Name = "AppliedRatesUI";
this.Text = "AppliedRatesUI";
this.TextChanged += new System.EventHandler(this.AppliedRatesUI_TextChanged);
this.Load += new System.EventHandler(this.AppliedRatesUI_Load);
((System.ComponentModel.ISupportInitialize)(this.gridMain)).EndInit();
this.gbxItems.ResumeLayout(false);
this.gbxItems.PerformLayout();
((System.ComponentModel.ISupportInitialize)(this.nudNumberOccupants)).EndInit();
this.gbxControls.ResumeLayout(false);
this.ResumeLayout(false);

            }

            #endregion

            private System.Windows.Forms.Label label4;
            internal System.Windows.Forms.Button btnNew;
            public System.Windows.Forms.Label lblAppliedID;
            internal C1.Win.C1FlexGrid.Classic.C1FlexGridClassic gridMain;
            private System.Windows.Forms.TextBox txtDESCRIPTION;
            private System.Windows.Forms.GroupBox gbxItems;
            private System.Windows.Forms.Label label1;
            internal System.Windows.Forms.Button btnCancel;
            internal System.Windows.Forms.Button btnDelete;
            internal System.Windows.Forms.Button btnClose;
            public System.Windows.Forms.Button btnSave;
            private System.Windows.Forms.GroupBox gbxControls;
            internal System.Windows.Forms.Button btnSearch;
            private System.Windows.Forms.NumericUpDown nudNumberOccupants;
            private System.Windows.Forms.Label label2;
            private System.Windows.Forms.Label label3;
            private System.Windows.Forms.ComboBox cboRateType;
        }
    }
}