namespace Jinisys.Hotel.ConfigurationHotel.Presentation
{
    partial class EventPackageUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventPackageUI));
            this.gbxCommands = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grid = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grpMain = new System.Windows.Forms.GroupBox();
            this.txtRateAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboEventType = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtPackageID = new System.Windows.Forms.TextBox();
            this.txtDaysApplied = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.grpRequirements = new System.Windows.Forms.GroupBox();
            this.lvwDetails = new System.Windows.Forms.ListView();
            this.label45 = new System.Windows.Forms.Label();
            this.cboRequirementType = new System.Windows.Forms.ComboBox();
            this.gridMain = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nudMinPax = new System.Windows.Forms.NumericUpDown();
            this.nudMaxPax = new System.Windows.Forms.NumericUpDown();
            this.gbxCommands.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.grpMain.SuspendLayout();
            this.grpRequirements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinPax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPax)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxCommands
            // 
            this.gbxCommands.Controls.Add(this.btnClose);
            this.gbxCommands.Controls.Add(this.btnDelete);
            this.gbxCommands.Controls.Add(this.btnSave);
            this.gbxCommands.Controls.Add(this.btnSearch);
            this.gbxCommands.Controls.Add(this.btnCancel);
            this.gbxCommands.Controls.Add(this.btnNew);
            this.gbxCommands.Location = new System.Drawing.Point(3, 494);
            this.gbxCommands.Name = "gbxCommands";
            this.gbxCommands.Size = new System.Drawing.Size(798, 51);
            this.gbxCommands.TabIndex = 14;
            this.gbxCommands.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(716, 13);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 31);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "Cl&ose";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(10, 13);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(66, 31);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(576, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 31);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(436, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(66, 31);
            this.btnSearch.TabIndex = 16;
            this.btnSearch.Text = "&Search";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(646, 13);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 31);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(506, 13);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(66, 31);
            this.btnNew.TabIndex = 17;
            this.btnNew.Text = "&New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grid);
            this.groupBox1.Controls.Add(this.btnRemove);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Location = new System.Drawing.Point(488, 165);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 322);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Charges";
            // 
            // grid
            // 
            this.grid.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both;
            this.grid.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            this.grid.ColumnInfo = resources.GetString("grid.ColumnInfo");
            this.grid.ExtendLastCol = true;
            this.grid.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grid.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grid.Location = new System.Drawing.Point(6, 46);
            this.grid.Name = "grid";
            this.grid.Rows.DefaultSize = 17;
            this.grid.Size = new System.Drawing.Size(301, 270);
            this.grid.StyleInfo = resources.GetString("grid.StyleInfo");
            this.grid.TabIndex = 13;
            this.grid.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grid_AfterEdit);
            this.grid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grid_MouseUp);
            this.grid.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grid_BeforeEdit);
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(219, 14);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(66, 26);
            this.btnRemove.TabIndex = 12;
            this.btnRemove.Text = "&Remove";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(148, 14);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(66, 26);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "&Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.nudMaxPax);
            this.grpMain.Controls.Add(this.nudMinPax);
            this.grpMain.Controls.Add(this.label7);
            this.grpMain.Controls.Add(this.label6);
            this.grpMain.Controls.Add(this.txtRateAmount);
            this.grpMain.Controls.Add(this.label4);
            this.grpMain.Controls.Add(this.label3);
            this.grpMain.Controls.Add(this.cboEventType);
            this.grpMain.Controls.Add(this.Label2);
            this.grpMain.Controls.Add(this.txtDescription);
            this.grpMain.Controls.Add(this.Label1);
            this.grpMain.Controls.Add(this.txtPackageID);
            this.grpMain.Controls.Add(this.txtDaysApplied);
            this.grpMain.Controls.Add(this.Label5);
            this.grpMain.Location = new System.Drawing.Point(209, 3);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(592, 156);
            this.grpMain.TabIndex = 1;
            this.grpMain.TabStop = false;
            // 
            // txtRateAmount
            // 
            this.txtRateAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRateAmount.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRateAmount.Location = new System.Drawing.Point(126, 118);
            this.txtRateAmount.MaxLength = 20;
            this.txtRateAmount.Name = "txtRateAmount";
            this.txtRateAmount.Size = new System.Drawing.Size(78, 20);
            this.txtRateAmount.TabIndex = 6;
            this.txtRateAmount.Text = "0.00";
            this.txtRateAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 17);
            this.label4.TabIndex = 72;
            this.label4.Text = "Package Amount";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 70;
            this.label3.Text = "Event Type";
            // 
            // cboEventType
            // 
            this.cboEventType.FormattingEnabled = true;
            this.cboEventType.Location = new System.Drawing.Point(126, 93);
            this.cboEventType.Name = "cboEventType";
            this.cboEventType.Size = new System.Drawing.Size(129, 21);
            this.cboEventType.TabIndex = 5;
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(38, 51);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(83, 17);
            this.Label2.TabIndex = 62;
            this.Label2.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescription.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(126, 49);
            this.txtDescription.MaxLength = 150;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(370, 39);
            this.txtDescription.TabIndex = 3;
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(38, 28);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(83, 17);
            this.Label1.TabIndex = 60;
            this.Label1.Text = "Package Id";
            // 
            // txtPackageID
            // 
            this.txtPackageID.BackColor = System.Drawing.SystemColors.Info;
            this.txtPackageID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPackageID.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPackageID.Location = new System.Drawing.Point(126, 25);
            this.txtPackageID.MaxLength = 50;
            this.txtPackageID.Multiline = true;
            this.txtPackageID.Name = "txtPackageID";
            this.txtPackageID.Size = new System.Drawing.Size(129, 20);
            this.txtPackageID.TabIndex = 2;
            // 
            // txtDaysApplied
            // 
            this.txtDaysApplied.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDaysApplied.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDaysApplied.Location = new System.Drawing.Point(126, 50);
            this.txtDaysApplied.MaxLength = 20;
            this.txtDaysApplied.Name = "txtDaysApplied";
            this.txtDaysApplied.Size = new System.Drawing.Size(129, 20);
            this.txtDaysApplied.TabIndex = 4;
            this.txtDaysApplied.Visible = false;
            // 
            // Label5
            // 
            this.Label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(38, 52);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(81, 17);
            this.Label5.TabIndex = 68;
            this.Label5.Text = "Days applied";
            this.Label5.Visible = false;
            // 
            // grpRequirements
            // 
            this.grpRequirements.Controls.Add(this.lvwDetails);
            this.grpRequirements.Controls.Add(this.label45);
            this.grpRequirements.Controls.Add(this.cboRequirementType);
            this.grpRequirements.Location = new System.Drawing.Point(209, 165);
            this.grpRequirements.Name = "grpRequirements";
            this.grpRequirements.Size = new System.Drawing.Size(275, 322);
            this.grpRequirements.TabIndex = 7;
            this.grpRequirements.TabStop = false;
            this.grpRequirements.Text = "Requirements";
            // 
            // lvwDetails
            // 
            this.lvwDetails.CheckBoxes = true;
            this.lvwDetails.Location = new System.Drawing.Point(8, 66);
            this.lvwDetails.Name = "lvwDetails";
            this.lvwDetails.Size = new System.Drawing.Size(258, 250);
            this.lvwDetails.TabIndex = 9;
            this.lvwDetails.UseCompatibleStateImageBehavior = false;
            this.lvwDetails.View = System.Windows.Forms.View.List;
            this.lvwDetails.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvwDetails_ItemChecked);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(14, 21);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(94, 14);
            this.label45.TabIndex = 174;
            this.label45.Text = "Requirement Type";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboRequirementType
            // 
            this.cboRequirementType.Location = new System.Drawing.Point(8, 38);
            this.cboRequirementType.Name = "cboRequirementType";
            this.cboRequirementType.Size = new System.Drawing.Size(218, 21);
            this.cboRequirementType.TabIndex = 8;
            this.cboRequirementType.SelectedValueChanged += new System.EventHandler(this.cboRequirementType_SelectedIndexChanged);
            // 
            // gridMain
            // 
            this.gridMain.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both;
            this.gridMain.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor;
            this.gridMain.ColumnInfo = "2,0,0,0,0,85,Columns:0{Width:0;Caption:\"ID\";TextAlign:LeftCenter;TextAlignFixed:L" +
                "eftCenter;}\t1{Width:115;Caption:\"Description\";TextAlignFixed:CenterCenter;}\t";
            this.gridMain.ExtendLastCol = true;
            this.gridMain.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
            this.gridMain.Font = new System.Drawing.Font("Arial", 8.25F);
            this.gridMain.Location = new System.Drawing.Point(4, 8);
            this.gridMain.Name = "gridMain";
            this.gridMain.Rows.Count = 1;
            this.gridMain.Rows.DefaultSize = 17;
            this.gridMain.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
            this.gridMain.Size = new System.Drawing.Size(201, 479);
            this.gridMain.StyleInfo = resources.GetString("gridMain.StyleInfo");
            this.gridMain.TabIndex = 0;
            this.gridMain.Click += new System.EventHandler(this.gridMain_RowColChange);
            this.gridMain.RowColChange += new System.EventHandler(this.gridMain_RowColChange);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(286, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 17);
            this.label6.TabIndex = 73;
            this.label6.Text = "Minimum Pax";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(285, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 17);
            this.label7.TabIndex = 74;
            this.label7.Text = "Maximum Pax";
            // 
            // nudMinPax
            // 
            this.nudMinPax.Location = new System.Drawing.Point(365, 94);
            this.nudMinPax.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.nudMinPax.Name = "nudMinPax";
            this.nudMinPax.Size = new System.Drawing.Size(63, 20);
            this.nudMinPax.TabIndex = 75;
            // 
            // nudMaxPax
            // 
            this.nudMaxPax.Location = new System.Drawing.Point(365, 118);
            this.nudMaxPax.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.nudMaxPax.Name = "nudMaxPax";
            this.nudMaxPax.Size = new System.Drawing.Size(63, 20);
            this.nudMaxPax.TabIndex = 76;
            // 
            // EventPackageUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(805, 551);
            this.Controls.Add(this.gridMain);
            this.Controls.Add(this.grpMain);
            this.Controls.Add(this.grpRequirements);
            this.Controls.Add(this.gbxCommands);
            this.Controls.Add(this.groupBox1);
            this.Name = "EventPackageUI";
            this.Text = "Event Package";
            this.TextChanged += new System.EventHandler(this.EventPackageUI_TextChanged);
            this.Load += new System.EventHandler(this.EventPackageUI_Load);
            this.gbxCommands.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.grpMain.ResumeLayout(false);
            this.grpMain.PerformLayout();
            this.grpRequirements.ResumeLayout(false);
            this.grpRequirements.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinPax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPax)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxCommands;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.Button btnSearch;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnNew;
        internal System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button btnRemove;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.GroupBox grpMain;
        public System.Windows.Forms.TextBox txtDaysApplied;
        public System.Windows.Forms.Label Label5;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.TextBox txtDescription;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.TextBox txtPackageID;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboEventType;
        private System.Windows.Forms.GroupBox grpRequirements;
        private System.Windows.Forms.ListView lvwDetails;
        public System.Windows.Forms.Label label45;
        internal System.Windows.Forms.ComboBox cboRequirementType;
        public System.Windows.Forms.TextBox txtRateAmount;
        public System.Windows.Forms.Label label4;
        internal C1.Win.C1FlexGrid.C1FlexGrid gridMain;
        private C1.Win.C1FlexGrid.C1FlexGrid grid;
        private System.Windows.Forms.NumericUpDown nudMaxPax;
        private System.Windows.Forms.NumericUpDown nudMinPax;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label6;
    }
}