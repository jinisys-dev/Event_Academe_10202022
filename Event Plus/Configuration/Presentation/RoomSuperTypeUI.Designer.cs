namespace Jinisys.Hotel.ConfigurationHotel.Presentation
{
    partial class RoomSuperTypeUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomSuperTypeUI));
            this.grdRateCodes = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtRoomSuperType = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.gbxCommands = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdRateCodes)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.gbxCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdRateCodes
            // 
            this.grdRateCodes.AllowEditing = false;
            this.grdRateCodes.ColumnInfo = "1,0,0,0,0,85,Columns:0{Width:176;Caption:\"Code\";TextAlign:LeftCenter;TextAlignFix" +
                "ed:CenterCenter;}\t";
            this.grdRateCodes.ExtendLastCol = true;
            this.grdRateCodes.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
            this.grdRateCodes.Font = new System.Drawing.Font("Arial", 8.25F);
            this.grdRateCodes.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus;
            this.grdRateCodes.Location = new System.Drawing.Point(1, 5);
            this.grdRateCodes.Name = "grdRateCodes";
            this.grdRateCodes.Rows.DefaultSize = 17;
            this.grdRateCodes.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
            this.grdRateCodes.Size = new System.Drawing.Size(214, 308);
            this.grdRateCodes.StyleInfo = resources.GetString("grdRateCodes.StyleInfo");
            this.grdRateCodes.TabIndex = 191;
            this.grdRateCodes.Click += new System.EventHandler(this.grdRateCodes_RowColChange);
            this.grdRateCodes.SelChange += new System.EventHandler(this.grdRateCodes_RowColChange);
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.txtRoomSuperType);
            this.GroupBox1.Controls.Add(this.txtDescription);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Location = new System.Drawing.Point(219, 0);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(333, 314);
            this.GroupBox1.TabIndex = 189;
            this.GroupBox1.TabStop = false;
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(6, 36);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(111, 17);
            this.Label1.TabIndex = 54;
            this.Label1.Text = "Room Super Type";
            // 
            // txtRoomSuperType
            // 
            this.txtRoomSuperType.BackColor = System.Drawing.SystemColors.Info;
            this.txtRoomSuperType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRoomSuperType.Enabled = false;
            this.txtRoomSuperType.Location = new System.Drawing.Point(123, 33);
            this.txtRoomSuperType.MaxLength = 50;
            this.txtRoomSuperType.Multiline = true;
            this.txtRoomSuperType.Name = "txtRoomSuperType";
            this.txtRoomSuperType.Size = new System.Drawing.Size(184, 20);
            this.txtRoomSuperType.TabIndex = 1;
            // 
            // txtDescription
            // 
            this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescription.Location = new System.Drawing.Point(123, 64);
            this.txtDescription.MaxLength = 100;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(185, 64);
            this.txtDescription.TabIndex = 2;
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(39, 67);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(74, 19);
            this.Label2.TabIndex = 49;
            this.Label2.Text = "Description";
            // 
            // gbxCommands
            // 
            this.gbxCommands.Controls.Add(this.btnClose);
            this.gbxCommands.Controls.Add(this.btnDelete);
            this.gbxCommands.Controls.Add(this.btnSave);
            this.gbxCommands.Controls.Add(this.btnNew);
            this.gbxCommands.Controls.Add(this.btnCancel);
            this.gbxCommands.Location = new System.Drawing.Point(1, 311);
            this.gbxCommands.Name = "gbxCommands";
            this.gbxCommands.Size = new System.Drawing.Size(551, 47);
            this.gbxCommands.TabIndex = 190;
            this.gbxCommands.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(479, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 31);
            this.btnClose.TabIndex = 189;
            this.btnClose.Text = "Cl&ose";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnDelete.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btnDelete.Location = new System.Drawing.Point(6, 9);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(66, 31);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnSave.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btnSave.Location = new System.Drawing.Point(343, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 31);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnNew.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btnNew.Location = new System.Drawing.Point(274, 9);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(66, 31);
            this.btnNew.TabIndex = 5;
            this.btnNew.Text = "&New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(411, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 31);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // RoomSuperTypeUI
            // 
            this.ClientSize = new System.Drawing.Size(553, 359);
            this.Controls.Add(this.grdRateCodes);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.gbxCommands);
            this.Name = "RoomSuperTypeUI";
            this.Text = "Room Super Type";
            this.Load += new System.EventHandler(this.RoomSuperTypeUI_Load);
            this.TextChanged += new System.EventHandler(this.RoomSuperTypeUI_TextChanged);
            ((System.ComponentModel.ISupportInitialize)(this.grdRateCodes)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.gbxCommands.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal C1.Win.C1FlexGrid.C1FlexGrid grdRateCodes;
        public System.Windows.Forms.GroupBox GroupBox1;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.TextBox txtRoomSuperType;
        public System.Windows.Forms.TextBox txtDescription;
        public System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.GroupBox gbxCommands;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Button btnDelete;
        internal System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.Button btnNew;
        internal System.Windows.Forms.Button btnCancel;

    }
}