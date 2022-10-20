namespace Jinisys.Hotel.ConfigurationHotel.Presentation
{
    partial class RequirementHeaderUI
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
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequirementHeaderUI));
this.grpMain = new System.Windows.Forms.GroupBox();
this.txtRequirementID = new System.Windows.Forms.Label();
this.txtDescription = new System.Windows.Forms.TextBox();
this.label7 = new System.Windows.Forms.Label();
this.Label1 = new System.Windows.Forms.Label();
this.grdRequirements = new C1.Win.C1FlexGrid.Classic.C1FlexGridClassic();
this.gbxCommands = new System.Windows.Forms.GroupBox();
this.btnClose = new System.Windows.Forms.Button();
this.btnDelete = new System.Windows.Forms.Button();
this.btnSave = new System.Windows.Forms.Button();
this.btnNew = new System.Windows.Forms.Button();
this.btnCancel = new System.Windows.Forms.Button();
this.gbxDetails = new System.Windows.Forms.GroupBox();
this.btnRemove = new System.Windows.Forms.Button();
this.btnAdd = new System.Windows.Forms.Button();
this.grid = new C1.Win.C1FlexGrid.Classic.C1FlexGridClassic();
this.grpMain.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.grdRequirements)).BeginInit();
this.gbxCommands.SuspendLayout();
this.gbxDetails.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
this.SuspendLayout();
// 
// grpMain
// 
this.grpMain.BackColor = System.Drawing.Color.Transparent;
this.grpMain.Controls.Add(this.txtRequirementID);
this.grpMain.Controls.Add(this.txtDescription);
this.grpMain.Controls.Add(this.label7);
this.grpMain.Controls.Add(this.Label1);
this.grpMain.Location = new System.Drawing.Point(228, 1);
this.grpMain.Name = "grpMain";
this.grpMain.Size = new System.Drawing.Size(321, 177);
this.grpMain.TabIndex = 10;
this.grpMain.TabStop = false;
// 
// txtRequirementID
// 
this.txtRequirementID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
this.txtRequirementID.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtRequirementID.Location = new System.Drawing.Point(102, 41);
this.txtRequirementID.Name = "txtRequirementID";
this.txtRequirementID.Size = new System.Drawing.Size(97, 20);
this.txtRequirementID.TabIndex = 63;
this.txtRequirementID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
// 
// txtDescription
// 
this.txtDescription.BackColor = System.Drawing.SystemColors.Info;
this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtDescription.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtDescription.Location = new System.Drawing.Point(102, 78);
this.txtDescription.MaxLength = 50;
this.txtDescription.Multiline = true;
this.txtDescription.Name = "txtDescription";
this.txtDescription.Size = new System.Drawing.Size(196, 63);
this.txtDescription.TabIndex = 64;
// 
// label7
// 
this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label7.Location = new System.Drawing.Point(28, 80);
this.label7.Name = "label7";
this.label7.Size = new System.Drawing.Size(72, 17);
this.label7.TabIndex = 66;
this.label7.Text = "Description";
// 
// Label1
// 
this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label1.Location = new System.Drawing.Point(15, 44);
this.Label1.Name = "Label1";
this.Label1.Size = new System.Drawing.Size(85, 17);
this.Label1.TabIndex = 65;
this.Label1.Text = "Requirement ID";
// 
// grdRequirements
// 
this.grdRequirements.AllowUserResizing = C1.Win.C1FlexGrid.Classic.AllowUserResizeSettings.flexResizeColumns;
this.grdRequirements.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor;
this.grdRequirements.BackColorSel = System.Drawing.SystemColors.Info;
this.grdRequirements.Cols = 2;
this.grdRequirements.ColumnInfo = "2,0,0,0,0,85,Columns:0{Width:0;Caption:\"ID\";Visible:False;}\t1{Width:115;Caption:\"" +
    "Name\";}\t";
this.grdRequirements.ExtendLastCol = true;
this.grdRequirements.FixedCols = 0;
this.grdRequirements.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
this.grdRequirements.Font = new System.Drawing.Font("Arial", 8.25F);
this.grdRequirements.ForeColorSel = System.Drawing.Color.Black;
this.grdRequirements.GridColorFixed = System.Drawing.SystemColors.ControlDark;
this.grdRequirements.Location = new System.Drawing.Point(8, 6);
this.grdRequirements.Name = "grdRequirements";
this.grdRequirements.NodeClosedPicture = null;
this.grdRequirements.NodeOpenPicture = null;
this.grdRequirements.OutlineCol = -1;
this.grdRequirements.SelectionMode = C1.Win.C1FlexGrid.Classic.SelModeSettings.flexSelectionByRow;
this.grdRequirements.Size = new System.Drawing.Size(214, 373);
this.grdRequirements.StyleInfo = resources.GetString("grdRequirements.StyleInfo");
this.grdRequirements.TabIndex = 9;
this.grdRequirements.TreeColor = System.Drawing.Color.DarkGray;
this.grdRequirements.RowColChange += new System.EventHandler(this.grdRequirements_RowColChange);
// 
// gbxCommands
// 
this.gbxCommands.Controls.Add(this.btnClose);
this.gbxCommands.Controls.Add(this.btnDelete);
this.gbxCommands.Controls.Add(this.btnSave);
this.gbxCommands.Controls.Add(this.btnNew);
this.gbxCommands.Controls.Add(this.btnCancel);
this.gbxCommands.Location = new System.Drawing.Point(6, 380);
this.gbxCommands.Name = "gbxCommands";
this.gbxCommands.Size = new System.Drawing.Size(543, 47);
this.gbxCommands.TabIndex = 11;
this.gbxCommands.TabStop = false;
// 
// btnClose
// 
this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnClose.Location = new System.Drawing.Point(470, 10);
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
this.btnSave.Location = new System.Drawing.Point(333, 10);
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
this.btnNew.Location = new System.Drawing.Point(264, 10);
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
this.btnCancel.Location = new System.Drawing.Point(402, 10);
this.btnCancel.Name = "btnCancel";
this.btnCancel.Size = new System.Drawing.Size(66, 31);
this.btnCancel.TabIndex = 13;
this.btnCancel.Text = "&Cancel";
this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
// 
// gbxDetails
// 
this.gbxDetails.Controls.Add(this.btnRemove);
this.gbxDetails.Controls.Add(this.btnAdd);
this.gbxDetails.Controls.Add(this.grid);
this.gbxDetails.Location = new System.Drawing.Point(228, 179);
this.gbxDetails.Name = "gbxDetails";
this.gbxDetails.Size = new System.Drawing.Size(321, 199);
this.gbxDetails.TabIndex = 12;
this.gbxDetails.TabStop = false;
// 
// btnRemove
// 
this.btnRemove.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnRemove.Location = new System.Drawing.Point(248, 14);
this.btnRemove.Name = "btnRemove";
this.btnRemove.Size = new System.Drawing.Size(66, 26);
this.btnRemove.TabIndex = 141;
this.btnRemove.Text = "&Remove";
this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
// 
// btnAdd
// 
this.btnAdd.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnAdd.Location = new System.Drawing.Point(177, 14);
this.btnAdd.Name = "btnAdd";
this.btnAdd.Size = new System.Drawing.Size(66, 26);
this.btnAdd.TabIndex = 142;
this.btnAdd.Text = "&Add";
this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
// 
// grid
// 
this.grid.AllowUserResizing = C1.Win.C1FlexGrid.Classic.AllowUserResizeSettings.flexResizeColumns;
this.grid.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
this.grid.Cols = 1;
this.grid.ColumnInfo = "1,0,0,0,0,85,Columns:0{Caption:\"Description\";TextAlignFixed:CenterCenter;}\t";
this.grid.Editable = C1.Win.C1FlexGrid.Classic.EditableSettings.flexEDKbdMouse;
this.grid.ExtendLastCol = true;
this.grid.FixedCols = 0;
this.grid.GridColorFixed = System.Drawing.SystemColors.ControlDark;
this.grid.Location = new System.Drawing.Point(7, 46);
this.grid.Name = "grid";
this.grid.NodeClosedPicture = null;
this.grid.NodeOpenPicture = null;
this.grid.OutlineCol = -1;
this.grid.Rows = 1;
this.grid.SelectionMode = C1.Win.C1FlexGrid.Classic.SelModeSettings.flexSelectionByRow;
this.grid.Size = new System.Drawing.Size(307, 147);
this.grid.StyleInfo = resources.GetString("grid.StyleInfo");
this.grid.TabIndex = 1;
this.grid.TreeColor = System.Drawing.Color.DarkGray;
// 
// RequirementHeaderUI
// 
this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
this.ClientSize = new System.Drawing.Size(562, 461);
this.Controls.Add(this.gbxDetails);
this.Controls.Add(this.grpMain);
this.Controls.Add(this.grdRequirements);
this.Controls.Add(this.gbxCommands);
this.Name = "RequirementHeaderUI";
this.Text = "Requirement";
this.TextChanged += new System.EventHandler(this.RequirementUI_TextChanged);
this.Load += new System.EventHandler(this.RequirementUI_Load);
this.grpMain.ResumeLayout(false);
this.grpMain.PerformLayout();
((System.ComponentModel.ISupportInitialize)(this.grdRequirements)).EndInit();
this.gbxCommands.ResumeLayout(false);
this.gbxDetails.ResumeLayout(false);
((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox grpMain;
        internal C1.Win.C1FlexGrid.Classic.C1FlexGridClassic grdRequirements;
        internal System.Windows.Forms.GroupBox gbxCommands;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Button btnDelete;
        internal System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.Button btnNew;
        internal System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Label txtRequirementID;
        public System.Windows.Forms.TextBox txtDescription;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label Label1;
        private System.Windows.Forms.GroupBox gbxDetails;
        private C1.Win.C1FlexGrid.Classic.C1FlexGridClassic grid;
        public System.Windows.Forms.Button btnRemove;
        internal System.Windows.Forms.Button btnAdd;
    }
}