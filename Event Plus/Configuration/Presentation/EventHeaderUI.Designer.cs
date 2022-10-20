namespace Jinisys.Hotel.ConfigurationHotel
{
    namespace Presentation
    {
        partial class EventHeaderUI
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
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventHeaderUI));
this.btnRemove = new System.Windows.Forms.Button();
this.btnAdd = new System.Windows.Forms.Button();
this.btnSave = new System.Windows.Forms.Button();
this.btnNew = new System.Windows.Forms.Button();
this.btnCancel = new System.Windows.Forms.Button();
this.grid = new C1.Win.C1FlexGrid.Classic.C1FlexGridClassic();
this.gbxDetails = new System.Windows.Forms.GroupBox();
this.grpMain = new System.Windows.Forms.GroupBox();
this.txtDescription = new System.Windows.Forms.TextBox();
this.label2 = new System.Windows.Forms.Label();
this.txtEventID = new System.Windows.Forms.Label();
this.txtEventType = new System.Windows.Forms.ComboBox();
this.label7 = new System.Windows.Forms.Label();
this.Label1 = new System.Windows.Forms.Label();
this.btnDelete = new System.Windows.Forms.Button();
this.grdEventTypes = new C1.Win.C1FlexGrid.Classic.C1FlexGridClassic();
this.btnClose = new System.Windows.Forms.Button();
this.gbxCommands = new System.Windows.Forms.GroupBox();
this.chkParty = new System.Windows.Forms.CheckBox();
((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
this.gbxDetails.SuspendLayout();
this.grpMain.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.grdEventTypes)).BeginInit();
this.gbxCommands.SuspendLayout();
this.SuspendLayout();
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
// grid
// 
this.grid.AllowUserResizing = C1.Win.C1FlexGrid.Classic.AllowUserResizeSettings.flexResizeColumns;
this.grid.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
this.grid.Cols = 1;
this.grid.ColumnInfo = "1,0,0,0,0,85,Columns:0{Caption:\"Description\";TextAlignFixed:CenterCenter;}\t";
this.grid.Editable = C1.Win.C1FlexGrid.Classic.EditableSettings.flexEDKbdMouse;
this.grid.ExplorerBar = ((C1.Win.C1FlexGrid.Classic.ExplorerBarSettings)(((C1.Win.C1FlexGrid.Classic.ExplorerBarSettings.flexExSort | C1.Win.C1FlexGrid.Classic.ExplorerBarSettings.flexExMove) 
            | C1.Win.C1FlexGrid.Classic.ExplorerBarSettings.flexExSort)));
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
// gbxDetails
// 
this.gbxDetails.Controls.Add(this.btnRemove);
this.gbxDetails.Controls.Add(this.btnAdd);
this.gbxDetails.Controls.Add(this.grid);
this.gbxDetails.Location = new System.Drawing.Point(227, 181);
this.gbxDetails.Name = "gbxDetails";
this.gbxDetails.Size = new System.Drawing.Size(321, 199);
this.gbxDetails.TabIndex = 16;
this.gbxDetails.TabStop = false;
// 
// grpMain
// 
this.grpMain.BackColor = System.Drawing.Color.Transparent;
this.grpMain.Controls.Add(this.chkParty);
this.grpMain.Controls.Add(this.txtDescription);
this.grpMain.Controls.Add(this.label2);
this.grpMain.Controls.Add(this.txtEventID);
this.grpMain.Controls.Add(this.txtEventType);
this.grpMain.Controls.Add(this.label7);
this.grpMain.Controls.Add(this.Label1);
this.grpMain.Location = new System.Drawing.Point(227, 3);
this.grpMain.Name = "grpMain";
this.grpMain.Size = new System.Drawing.Size(321, 177);
this.grpMain.TabIndex = 14;
this.grpMain.TabStop = false;
// 
// txtDescription
// 
this.txtDescription.BackColor = System.Drawing.SystemColors.Info;
this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtDescription.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtDescription.Location = new System.Drawing.Point(84, 95);
this.txtDescription.MaxLength = 50;
this.txtDescription.Multiline = true;
this.txtDescription.Name = "txtDescription";
this.txtDescription.Size = new System.Drawing.Size(224, 47);
this.txtDescription.TabIndex = 67;
// 
// label2
// 
this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label2.Location = new System.Drawing.Point(4, 97);
this.label2.Name = "label2";
this.label2.Size = new System.Drawing.Size(78, 17);
this.label2.TabIndex = 68;
this.label2.Text = "Description";
this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
// 
// txtEventID
// 
this.txtEventID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
this.txtEventID.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtEventID.Location = new System.Drawing.Point(84, 33);
this.txtEventID.Name = "txtEventID";
this.txtEventID.Size = new System.Drawing.Size(97, 20);
this.txtEventID.TabIndex = 63;
this.txtEventID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
// 
// txtEventType
// 
this.txtEventType.BackColor = System.Drawing.SystemColors.Info;
this.txtEventType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
this.txtEventType.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtEventType.Location = new System.Drawing.Point(84, 65);
this.txtEventType.MaxLength = 50;
this.txtEventType.Name = "txtEventType";
this.txtEventType.Size = new System.Drawing.Size(153, 20);
this.txtEventType.TabIndex = 64;
// 
// label7
// 
this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label7.Location = new System.Drawing.Point(4, 67);
this.label7.Name = "label7";
this.label7.Size = new System.Drawing.Size(78, 17);
this.label7.TabIndex = 66;
this.label7.Text = "Event Type";
this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
// 
// Label1
// 
this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label1.Location = new System.Drawing.Point(6, 36);
this.Label1.Name = "Label1";
this.Label1.Size = new System.Drawing.Size(76, 17);
this.Label1.TabIndex = 65;
this.Label1.Text = "Event Type ID";
this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
// grdEventTypes
// 
this.grdEventTypes.AllowUserResizing = C1.Win.C1FlexGrid.Classic.AllowUserResizeSettings.flexResizeColumns;
this.grdEventTypes.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor;
this.grdEventTypes.BackColorSel = System.Drawing.SystemColors.Info;
this.grdEventTypes.Cols = 2;
this.grdEventTypes.ColumnInfo = "2,0,0,0,0,85,Columns:0{Width:0;Caption:\"ID\";Visible:False;}\t1{Width:115;Caption:\"" +
    "Name\";}\t";
this.grdEventTypes.ExplorerBar = ((C1.Win.C1FlexGrid.Classic.ExplorerBarSettings)(((C1.Win.C1FlexGrid.Classic.ExplorerBarSettings.flexExSort | C1.Win.C1FlexGrid.Classic.ExplorerBarSettings.flexExMove) 
            | C1.Win.C1FlexGrid.Classic.ExplorerBarSettings.flexExSort)));
this.grdEventTypes.ExtendLastCol = true;
this.grdEventTypes.FixedCols = 0;
this.grdEventTypes.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
this.grdEventTypes.Font = new System.Drawing.Font("Arial", 8.25F);
this.grdEventTypes.ForeColorSel = System.Drawing.Color.Black;
this.grdEventTypes.GridColorFixed = System.Drawing.SystemColors.ControlDark;
this.grdEventTypes.Location = new System.Drawing.Point(7, 8);
this.grdEventTypes.Name = "grdEventTypes";
this.grdEventTypes.NodeClosedPicture = null;
this.grdEventTypes.NodeOpenPicture = null;
this.grdEventTypes.OutlineCol = -1;
this.grdEventTypes.SelectionMode = C1.Win.C1FlexGrid.Classic.SelModeSettings.flexSelectionByRow;
this.grdEventTypes.Size = new System.Drawing.Size(214, 373);
this.grdEventTypes.StyleInfo = resources.GetString("grdEventTypes.StyleInfo");
this.grdEventTypes.TabIndex = 13;
this.grdEventTypes.TreeColor = System.Drawing.Color.DarkGray;
this.grdEventTypes.RowColChange += new System.EventHandler(this.grdEventTypes_RowColChange);
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
// gbxCommands
// 
this.gbxCommands.Controls.Add(this.btnClose);
this.gbxCommands.Controls.Add(this.btnDelete);
this.gbxCommands.Controls.Add(this.btnSave);
this.gbxCommands.Controls.Add(this.btnNew);
this.gbxCommands.Controls.Add(this.btnCancel);
this.gbxCommands.Location = new System.Drawing.Point(5, 382);
this.gbxCommands.Name = "gbxCommands";
this.gbxCommands.Size = new System.Drawing.Size(543, 47);
this.gbxCommands.TabIndex = 15;
this.gbxCommands.TabStop = false;
// 
// chkParty
// 
this.chkParty.AutoSize = true;
this.chkParty.Location = new System.Drawing.Point(242, 66);
this.chkParty.Name = "chkParty";
this.chkParty.Size = new System.Drawing.Size(66, 17);
this.chkParty.TabIndex = 69;
this.chkParty.Text = "Banquet";
this.chkParty.UseVisualStyleBackColor = true;
// 
// EventHeaderUI
// 
this.ClientSize = new System.Drawing.Size(554, 436);
this.Controls.Add(this.gbxDetails);
this.Controls.Add(this.grpMain);
this.Controls.Add(this.grdEventTypes);
this.Controls.Add(this.gbxCommands);
this.Name = "EventHeaderUI";
this.Text = "Event";
this.TextChanged += new System.EventHandler(this.EventHeaderUI_TextChanged);
this.Load += new System.EventHandler(this.EventHeaderUI_Load);
((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
this.gbxDetails.ResumeLayout(false);
this.grpMain.ResumeLayout(false);
this.grpMain.PerformLayout();
((System.ComponentModel.ISupportInitialize)(this.grdEventTypes)).EndInit();
this.gbxCommands.ResumeLayout(false);
this.ResumeLayout(false);

        }

            #endregion

            public System.Windows.Forms.Button btnRemove;
            internal System.Windows.Forms.Button btnAdd;
            internal System.Windows.Forms.Button btnSave;
            internal System.Windows.Forms.Button btnNew;
            internal System.Windows.Forms.Button btnCancel;
            private C1.Win.C1FlexGrid.Classic.C1FlexGridClassic grid;
            private System.Windows.Forms.GroupBox gbxDetails;
            public System.Windows.Forms.GroupBox grpMain;
            public System.Windows.Forms.Label txtEventID;
            public System.Windows.Forms.ComboBox txtEventType;
            public System.Windows.Forms.Label label7;
            public System.Windows.Forms.Label Label1;
            internal System.Windows.Forms.Button btnDelete;
            internal C1.Win.C1FlexGrid.Classic.C1FlexGridClassic grdEventTypes;
            internal System.Windows.Forms.Button btnClose;
            internal System.Windows.Forms.GroupBox gbxCommands;
            public System.Windows.Forms.TextBox txtDescription;
            public System.Windows.Forms.Label label2;
            private System.Windows.Forms.CheckBox chkParty;
        }
    }
}