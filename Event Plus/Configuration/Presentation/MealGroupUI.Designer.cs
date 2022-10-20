namespace Jinisys.Hotel.ConfigurationHotel
{
    namespace Presentation
    {
        partial class MealGroupUI
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
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MealGroupUI));
this.label1 = new System.Windows.Forms.Label();
this.gbxControls = new System.Windows.Forms.GroupBox();
this.btnDelete = new System.Windows.Forms.Button();
this.btnClose = new System.Windows.Forms.Button();
this.btnSave = new System.Windows.Forms.Button();
this.btnSearch = new System.Windows.Forms.Button();
this.btnCancel = new System.Windows.Forms.Button();
this.btnNew = new System.Windows.Forms.Button();
this.label4 = new System.Windows.Forms.Label();
this.gbxItems = new System.Windows.Forms.GroupBox();
this.cboMainGroupId = new System.Windows.Forms.ComboBox();
this.label2 = new System.Windows.Forms.Label();
this.lblGroupID = new System.Windows.Forms.Label();
this.txtDESCRIPTION = new System.Windows.Forms.TextBox();
this.gridMain = new C1.Win.C1FlexGrid.Classic.C1FlexGridClassic();
this.gbxControls.SuspendLayout();
this.gbxItems.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.gridMain)).BeginInit();
this.SuspendLayout();
// 
// label1
// 
this.label1.AutoSize = true;
this.label1.Location = new System.Drawing.Point(18, 59);
this.label1.Name = "label1";
this.label1.Size = new System.Drawing.Size(49, 14);
this.label1.TabIndex = 26;
this.label1.Text = "Group ID";
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
this.gbxControls.TabIndex = 6;
this.gbxControls.TabStop = false;
// 
// btnDelete
// 
this.btnDelete.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnDelete.Location = new System.Drawing.Point(8, 12);
this.btnDelete.Name = "btnDelete";
this.btnDelete.Size = new System.Drawing.Size(66, 31);
this.btnDelete.TabIndex = 7;
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
this.btnClose.TabIndex = 12;
this.btnClose.Text = "Cl&ose";
this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
// 
// btnSave
// 
this.btnSave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnSave.Location = new System.Drawing.Point(368, 12);
this.btnSave.Name = "btnSave";
this.btnSave.Size = new System.Drawing.Size(66, 31);
this.btnSave.TabIndex = 10;
this.btnSave.Text = "&Save";
this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
// 
// btnSearch
// 
this.btnSearch.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnSearch.Location = new System.Drawing.Point(228, 12);
this.btnSearch.Name = "btnSearch";
this.btnSearch.Size = new System.Drawing.Size(66, 31);
this.btnSearch.TabIndex = 8;
this.btnSearch.Text = "&Search";
// 
// btnCancel
// 
this.btnCancel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnCancel.Location = new System.Drawing.Point(438, 12);
this.btnCancel.Name = "btnCancel";
this.btnCancel.Size = new System.Drawing.Size(66, 31);
this.btnCancel.TabIndex = 11;
this.btnCancel.Text = "&Cancel";
this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
// 
// btnNew
// 
this.btnNew.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnNew.Location = new System.Drawing.Point(298, 12);
this.btnNew.Name = "btnNew";
this.btnNew.Size = new System.Drawing.Size(66, 31);
this.btnNew.TabIndex = 9;
this.btnNew.Text = "&New";
this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
// 
// label4
// 
this.label4.AutoSize = true;
this.label4.Location = new System.Drawing.Point(18, 125);
this.label4.Name = "label4";
this.label4.Size = new System.Drawing.Size(61, 14);
this.label4.TabIndex = 35;
this.label4.Text = "Description";
this.label4.Click += new System.EventHandler(this.label4_Click);
// 
// gbxItems
// 
this.gbxItems.Controls.Add(this.cboMainGroupId);
this.gbxItems.Controls.Add(this.label2);
this.gbxItems.Controls.Add(this.lblGroupID);
this.gbxItems.Controls.Add(this.txtDESCRIPTION);
this.gbxItems.Controls.Add(this.label4);
this.gbxItems.Controls.Add(this.label1);
this.gbxItems.Location = new System.Drawing.Point(217, 3);
this.gbxItems.Name = "gbxItems";
this.gbxItems.Size = new System.Drawing.Size(368, 420);
this.gbxItems.TabIndex = 1;
this.gbxItems.TabStop = false;
// 
// cboMainGroupId
// 
this.cboMainGroupId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.cboMainGroupId.FormattingEnabled = true;
this.cboMainGroupId.Items.AddRange(new object[] {
            "FOOD",
            "BEVERAGE",
            "OTHERS"});
this.cboMainGroupId.Location = new System.Drawing.Point(104, 91);
this.cboMainGroupId.Name = "cboMainGroupId";
this.cboMainGroupId.Size = new System.Drawing.Size(200, 22);
this.cboMainGroupId.TabIndex = 48;
// 
// label2
// 
this.label2.AutoSize = true;
this.label2.Location = new System.Drawing.Point(18, 94);
this.label2.Name = "label2";
this.label2.Size = new System.Drawing.Size(62, 14);
this.label2.TabIndex = 47;
this.label2.Text = "Main Group";
// 
// lblGroupID
// 
this.lblGroupID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
this.lblGroupID.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.lblGroupID.Location = new System.Drawing.Point(104, 55);
this.lblGroupID.Name = "lblGroupID";
this.lblGroupID.Size = new System.Drawing.Size(118, 20);
this.lblGroupID.TabIndex = 3;
this.lblGroupID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
// 
// txtDESCRIPTION
// 
this.txtDESCRIPTION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtDESCRIPTION.Location = new System.Drawing.Point(104, 123);
this.txtDESCRIPTION.Multiline = true;
this.txtDESCRIPTION.Name = "txtDESCRIPTION";
this.txtDESCRIPTION.Size = new System.Drawing.Size(247, 55);
this.txtDESCRIPTION.TabIndex = 5;
this.txtDESCRIPTION.TextChanged += new System.EventHandler(this.txtDESCRIPTION_TextChanged);
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
this.gridMain.TabIndex = 0;
this.gridMain.TreeColor = System.Drawing.Color.DarkGray;
this.gridMain.RowColChange += new System.EventHandler(this.gridMain_RowColChange);
// 
// MealGroupUI
// 
this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
this.CancelButton = this.btnClose;
this.ClientSize = new System.Drawing.Size(591, 477);
this.Controls.Add(this.gridMain);
this.Controls.Add(this.gbxControls);
this.Controls.Add(this.gbxItems);
this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Name = "MealGroupUI";
this.Text = "Meal";
this.TextChanged += new System.EventHandler(this.MealGroupUI_TextChanged);
this.Load += new System.EventHandler(this.MealGroupUI_Load);
this.gbxControls.ResumeLayout(false);
this.gbxItems.ResumeLayout(false);
this.gbxItems.PerformLayout();
((System.ComponentModel.ISupportInitialize)(this.gridMain)).EndInit();
this.ResumeLayout(false);

            }

            #endregion

            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.GroupBox gbxControls;
            internal System.Windows.Forms.Button btnDelete;
            internal System.Windows.Forms.Button btnClose;
            public System.Windows.Forms.Button btnSave;
            internal System.Windows.Forms.Button btnSearch;
            internal System.Windows.Forms.Button btnCancel;
            internal System.Windows.Forms.Button btnNew;
            private System.Windows.Forms.Label label4;
            private System.Windows.Forms.GroupBox gbxItems;
            private System.Windows.Forms.TextBox txtDESCRIPTION;
            internal C1.Win.C1FlexGrid.Classic.C1FlexGridClassic gridMain;
            public System.Windows.Forms.Label lblGroupID;
			private System.Windows.Forms.Label label2;
			private System.Windows.Forms.ComboBox cboMainGroupId;
        }
    }
}