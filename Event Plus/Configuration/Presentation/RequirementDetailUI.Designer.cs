namespace Jinisys.Hotel.Configuration.Presentation
{
    partial class RequirementDetailUI
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
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequirementDetailUI));
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
this.grpMain.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.grdRequirements)).BeginInit();
this.gbxCommands.SuspendLayout();
this.SuspendLayout();
// 
// grpMain
// 
this.grpMain.BackColor = System.Drawing.Color.Transparent;
this.grpMain.Controls.Add(this.txtRequirementID);
this.grpMain.Controls.Add(this.txtDescription);
this.grpMain.Controls.Add(this.label7);
this.grpMain.Controls.Add(this.Label1);
this.grpMain.Location = new System.Drawing.Point(231, 6);
this.grpMain.Name = "grpMain";
this.grpMain.Size = new System.Drawing.Size(296, 304);
this.grpMain.TabIndex = 13;
this.grpMain.TabStop = false;
// 
// txtRequirementID
// 
this.txtRequirementID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
this.txtRequirementID.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtRequirementID.Location = new System.Drawing.Point(102, 50);
this.txtRequirementID.Name = "txtRequirementID";
this.txtRequirementID.Size = new System.Drawing.Size(84, 20);
this.txtRequirementID.TabIndex = 63;
this.txtRequirementID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
// 
// txtDescription
// 
this.txtDescription.BackColor = System.Drawing.SystemColors.Info;
this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtDescription.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtDescription.Location = new System.Drawing.Point(102, 87);
this.txtDescription.MaxLength = 50;
this.txtDescription.Multiline = true;
this.txtDescription.Name = "txtDescription";
this.txtDescription.Size = new System.Drawing.Size(175, 63);
this.txtDescription.TabIndex = 64;
// 
// label7
// 
this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label7.Location = new System.Drawing.Point(28, 89);
this.label7.Name = "label7";
this.label7.Size = new System.Drawing.Size(72, 17);
this.label7.TabIndex = 66;
this.label7.Text = "Description";
// 
// Label1
// 
this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label1.Location = new System.Drawing.Point(15, 53);
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
this.grdRequirements.Location = new System.Drawing.Point(11, 11);
this.grdRequirements.Name = "grdRequirements";
this.grdRequirements.NodeClosedPicture = null;
this.grdRequirements.NodeOpenPicture = null;
this.grdRequirements.OutlineCol = -1;
this.grdRequirements.SelectionMode = C1.Win.C1FlexGrid.Classic.SelModeSettings.flexSelectionByRow;
this.grdRequirements.Size = new System.Drawing.Size(214, 299);
this.grdRequirements.StyleInfo = resources.GetString("grdRequirements.StyleInfo");
this.grdRequirements.TabIndex = 12;
this.grdRequirements.TreeColor = System.Drawing.Color.DarkGray;
// 
// gbxCommands
// 
this.gbxCommands.Controls.Add(this.btnClose);
this.gbxCommands.Controls.Add(this.btnDelete);
this.gbxCommands.Controls.Add(this.btnSave);
this.gbxCommands.Controls.Add(this.btnNew);
this.gbxCommands.Controls.Add(this.btnCancel);
this.gbxCommands.Location = new System.Drawing.Point(9, 311);
this.gbxCommands.Name = "gbxCommands";
this.gbxCommands.Size = new System.Drawing.Size(518, 47);
this.gbxCommands.TabIndex = 14;
this.gbxCommands.TabStop = false;
// 
// btnClose
// 
this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnClose.Location = new System.Drawing.Point(444, 10);
this.btnClose.Name = "btnClose";
this.btnClose.Size = new System.Drawing.Size(66, 31);
this.btnClose.TabIndex = 14;
this.btnClose.Text = "Cl&ose";
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
// 
// btnSave
// 
this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
this.btnSave.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnSave.Location = new System.Drawing.Point(307, 10);
this.btnSave.Name = "btnSave";
this.btnSave.Size = new System.Drawing.Size(66, 31);
this.btnSave.TabIndex = 12;
this.btnSave.Text = "&Save";
// 
// btnNew
// 
this.btnNew.Cursor = System.Windows.Forms.Cursors.Default;
this.btnNew.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnNew.Location = new System.Drawing.Point(238, 10);
this.btnNew.Name = "btnNew";
this.btnNew.Size = new System.Drawing.Size(66, 31);
this.btnNew.TabIndex = 11;
this.btnNew.Text = "&New";
// 
// btnCancel
// 
this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
this.btnCancel.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnCancel.Location = new System.Drawing.Point(376, 10);
this.btnCancel.Name = "btnCancel";
this.btnCancel.Size = new System.Drawing.Size(66, 31);
this.btnCancel.TabIndex = 13;
this.btnCancel.Text = "&Cancel";
// 
// RequirementDetailUI
// 
this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
this.ClientSize = new System.Drawing.Size(536, 365);
this.Controls.Add(this.grpMain);
this.Controls.Add(this.grdRequirements);
this.Controls.Add(this.gbxCommands);
this.Name = "RequirementDetailUI";
this.Text = "RequirementDetailUI";
this.grpMain.ResumeLayout(false);
this.grpMain.PerformLayout();
((System.ComponentModel.ISupportInitialize)(this.grdRequirements)).EndInit();
this.gbxCommands.ResumeLayout(false);
this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox grpMain;
        public System.Windows.Forms.Label txtRequirementID;
        public System.Windows.Forms.TextBox txtDescription;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label Label1;
        internal C1.Win.C1FlexGrid.Classic.C1FlexGridClassic grdRequirements;
        internal System.Windows.Forms.GroupBox gbxCommands;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Button btnDelete;
        internal System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.Button btnNew;
        internal System.Windows.Forms.Button btnCancel;
    }
}