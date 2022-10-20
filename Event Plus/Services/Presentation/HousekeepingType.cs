/*
 * Jinisys Softwares, Inc.
 * Copyright © 2006
 * 
 * 
*/


using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Services.BusinessLayer;


namespace Jinisys.Hotel.Services.Presentation
{
		public class HousekeepingTypeUI : System.Windows.Forms.Form, ClassMaintenanceInterface
		{

			#region " Windows Form Designer generated code "
			
			//Form overrides dispose to clean up the component list.
			protected override void Dispose(bool disposing)
			{
				if (disposing)
				{
					if (!(components == null))
					{
						components.Dispose();
					}
				}
				base.Dispose(disposing);
			}
			
			//Required by the Windows Form Designer
			private System.ComponentModel.Container components = null;
			
			//NOTE: The following procedure is required by the Windows Form Designer
			//It can be modified using the Windows Form Designer.
			//Do not modify it using the code editor.
			public System.Windows.Forms.Label Label2;
            internal System.Windows.Forms.GroupBox GroupBox3;
			internal System.Windows.Forms.GroupBox gbxCommands;
			internal System.Windows.Forms.Button btnDelete;
			internal System.Windows.Forms.Button btnSave;
			internal System.Windows.Forms.Button btnNew;
			internal System.Windows.Forms.Button btnCancel;
            public System.Windows.Forms.TextBox txtId;
            internal Button btnSearch;
            internal Panel pnlSearch;
            private Label label4;
            internal Label picClose;
            internal Label Label16;
            internal Label Label6;
            internal Button btnCloseSearch;
            internal Button btnFind;
            internal TextBox txtSearch;
            public TextBox txtCode;
            public Label label3;
            public Label label1;
            public TextBox txtName;
			internal C1.Win.C1FlexGrid.Classic.C1FlexGridClassic grdHousekeepingTypes;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HousekeepingTypeUI));
this.txtId = new System.Windows.Forms.TextBox();
this.Label2 = new System.Windows.Forms.Label();
this.GroupBox3 = new System.Windows.Forms.GroupBox();
this.txtName = new System.Windows.Forms.TextBox();
this.txtCode = new System.Windows.Forms.TextBox();
this.label3 = new System.Windows.Forms.Label();
this.label1 = new System.Windows.Forms.Label();
this.gbxCommands = new System.Windows.Forms.GroupBox();
this.btnSearch = new System.Windows.Forms.Button();
this.btnDelete = new System.Windows.Forms.Button();
this.btnSave = new System.Windows.Forms.Button();
this.btnNew = new System.Windows.Forms.Button();
this.btnCancel = new System.Windows.Forms.Button();
this.grdHousekeepingTypes = new C1.Win.C1FlexGrid.Classic.C1FlexGridClassic();
this.pnlSearch = new System.Windows.Forms.Panel();
this.label4 = new System.Windows.Forms.Label();
this.picClose = new System.Windows.Forms.Label();
this.Label16 = new System.Windows.Forms.Label();
this.Label6 = new System.Windows.Forms.Label();
this.btnCloseSearch = new System.Windows.Forms.Button();
this.btnFind = new System.Windows.Forms.Button();
this.txtSearch = new System.Windows.Forms.TextBox();
this.GroupBox3.SuspendLayout();
this.gbxCommands.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.grdHousekeepingTypes)).BeginInit();
this.pnlSearch.SuspendLayout();
this.SuspendLayout();
// 
// txtId
// 
this.txtId.BackColor = System.Drawing.SystemColors.Info;
this.txtId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtId.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtId.Location = new System.Drawing.Point(92, 22);
this.txtId.MaxLength = 20;
this.txtId.Name = "txtId";
this.txtId.Size = new System.Drawing.Size(108, 20);
this.txtId.TabIndex = 111;
// 
// Label2
// 
this.Label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label2.Location = new System.Drawing.Point(13, 25);
this.Label2.Name = "Label2";
this.Label2.Size = new System.Drawing.Size(73, 13);
this.Label2.TabIndex = 112;
this.Label2.Text = "HK Id:";
// 
// GroupBox3
// 
this.GroupBox3.Controls.Add(this.txtName);
this.GroupBox3.Controls.Add(this.txtCode);
this.GroupBox3.Controls.Add(this.label3);
this.GroupBox3.Controls.Add(this.label1);
this.GroupBox3.Controls.Add(this.txtId);
this.GroupBox3.Controls.Add(this.Label2);
this.GroupBox3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.GroupBox3.Location = new System.Drawing.Point(222, -3);
this.GroupBox3.Name = "GroupBox3";
this.GroupBox3.Size = new System.Drawing.Size(304, 314);
this.GroupBox3.TabIndex = 114;
this.GroupBox3.TabStop = false;
// 
// txtName
// 
this.txtName.BackColor = System.Drawing.Color.White;
this.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtName.Location = new System.Drawing.Point(92, 48);
this.txtName.MaxLength = 20;
this.txtName.Name = "txtName";
this.txtName.Size = new System.Drawing.Size(204, 20);
this.txtName.TabIndex = 123;
// 
// txtCode
// 
this.txtCode.BackColor = System.Drawing.Color.White;
this.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtCode.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtCode.Location = new System.Drawing.Point(92, 75);
this.txtCode.MaxLength = 20;
this.txtCode.Name = "txtCode";
this.txtCode.Size = new System.Drawing.Size(108, 20);
this.txtCode.TabIndex = 117;
// 
// label3
// 
this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label3.Location = new System.Drawing.Point(13, 77);
this.label3.Name = "label3";
this.label3.Size = new System.Drawing.Size(73, 13);
this.label3.TabIndex = 118;
this.label3.Text = "Code:";
// 
// label1
// 
this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label1.Location = new System.Drawing.Point(13, 51);
this.label1.Name = "label1";
this.label1.Size = new System.Drawing.Size(73, 13);
this.label1.TabIndex = 114;
this.label1.Text = "Name:";
// 
// gbxCommands
// 
this.gbxCommands.Controls.Add(this.btnSearch);
this.gbxCommands.Controls.Add(this.btnDelete);
this.gbxCommands.Controls.Add(this.btnSave);
this.gbxCommands.Controls.Add(this.btnNew);
this.gbxCommands.Controls.Add(this.btnCancel);
this.gbxCommands.Location = new System.Drawing.Point(3, 308);
this.gbxCommands.Name = "gbxCommands";
this.gbxCommands.Size = new System.Drawing.Size(523, 48);
this.gbxCommands.TabIndex = 116;
this.gbxCommands.TabStop = false;
// 
// btnSearch
// 
this.btnSearch.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnSearch.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnSearch.Location = new System.Drawing.Point(239, 11);
this.btnSearch.Name = "btnSearch";
this.btnSearch.Size = new System.Drawing.Size(66, 32);
this.btnSearch.TabIndex = 10;
this.btnSearch.Text = "Searc&h";
this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
// 
// btnDelete
// 
this.btnDelete.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnDelete.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnDelete.Location = new System.Drawing.Point(6, 10);
this.btnDelete.Name = "btnDelete";
this.btnDelete.Size = new System.Drawing.Size(66, 32);
this.btnDelete.TabIndex = 4;
this.btnDelete.Text = "&Delete";
this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
// 
// btnSave
// 
this.btnSave.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnSave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnSave.Location = new System.Drawing.Point(382, 11);
this.btnSave.Name = "btnSave";
this.btnSave.Size = new System.Drawing.Size(66, 32);
this.btnSave.TabIndex = 8;
this.btnSave.Text = "&Save";
this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
// 
// btnNew
// 
this.btnNew.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnNew.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnNew.Location = new System.Drawing.Point(311, 11);
this.btnNew.Name = "btnNew";
this.btnNew.Size = new System.Drawing.Size(66, 32);
this.btnNew.TabIndex = 5;
this.btnNew.Text = "&New";
this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
// 
// btnCancel
// 
this.btnCancel.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnCancel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnCancel.Location = new System.Drawing.Point(452, 11);
this.btnCancel.Name = "btnCancel";
this.btnCancel.Size = new System.Drawing.Size(66, 32);
this.btnCancel.TabIndex = 9;
this.btnCancel.Text = "&Cancel";
this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
// 
// grdHousekeepingTypes
// 
this.grdHousekeepingTypes.AllowUserResizing = C1.Win.C1FlexGrid.Classic.AllowUserResizeSettings.flexResizeColumns;
this.grdHousekeepingTypes.Cols = 2;
this.grdHousekeepingTypes.ColumnInfo = "2,0,0,0,0,85,Columns:0{Width:37;Caption:\"Id\";}\t1{Width:139;Caption:\"Name\";TextAli" +
    "gn:LeftCenter;TextAlignFixed:CenterCenter;}\t";
this.grdHousekeepingTypes.ExtendLastCol = true;
this.grdHousekeepingTypes.FixedCols = 0;
this.grdHousekeepingTypes.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
this.grdHousekeepingTypes.Font = new System.Drawing.Font("Arial", 8.25F);
this.grdHousekeepingTypes.GridColorFixed = System.Drawing.SystemColors.ControlDark;
this.grdHousekeepingTypes.Location = new System.Drawing.Point(3, 3);
this.grdHousekeepingTypes.Name = "grdHousekeepingTypes";
this.grdHousekeepingTypes.NodeClosedPicture = null;
this.grdHousekeepingTypes.NodeOpenPicture = null;
this.grdHousekeepingTypes.OutlineCol = -1;
this.grdHousekeepingTypes.SelectionMode = C1.Win.C1FlexGrid.Classic.SelModeSettings.flexSelectionByRow;
this.grdHousekeepingTypes.Size = new System.Drawing.Size(214, 308);
this.grdHousekeepingTypes.StyleInfo = resources.GetString("grdHousekeepingTypes.StyleInfo");
this.grdHousekeepingTypes.TabIndex = 189;
this.grdHousekeepingTypes.TreeColor = System.Drawing.Color.DarkGray;
this.grdHousekeepingTypes.Click += new System.EventHandler(this.grdHousekeepingTypeTypes_Click);
this.grdHousekeepingTypes.RowColChange += new System.EventHandler(this.grdHousekeepingTypes_RowColChange);
// 
// pnlSearch
// 
this.pnlSearch.BackColor = System.Drawing.Color.White;
this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
this.pnlSearch.Controls.Add(this.label4);
this.pnlSearch.Controls.Add(this.picClose);
this.pnlSearch.Controls.Add(this.Label16);
this.pnlSearch.Controls.Add(this.Label6);
this.pnlSearch.Controls.Add(this.btnCloseSearch);
this.pnlSearch.Controls.Add(this.btnFind);
this.pnlSearch.Controls.Add(this.txtSearch);
this.pnlSearch.Location = new System.Drawing.Point(75, 85);
this.pnlSearch.Name = "pnlSearch";
this.pnlSearch.Size = new System.Drawing.Size(251, 149);
this.pnlSearch.TabIndex = 190;
this.pnlSearch.Visible = false;
// 
// label4
// 
this.label4.BackColor = System.Drawing.Color.Transparent;
this.label4.Enabled = false;
this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.label4.Location = new System.Drawing.Point(200, 99);
this.label4.Name = "label4";
this.label4.Size = new System.Drawing.Size(48, 47);
this.label4.TabIndex = 6;
// 
// picClose
// 
this.picClose.BackColor = System.Drawing.Color.SteelBlue;
this.picClose.Image = ((System.Drawing.Image)(resources.GetObject("picClose.Image")));
this.picClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.picClose.Location = new System.Drawing.Point(229, 3);
this.picClose.Name = "picClose";
this.picClose.Size = new System.Drawing.Size(18, 16);
this.picClose.TabIndex = 5;
// 
// Label16
// 
this.Label16.BackColor = System.Drawing.Color.SteelBlue;
this.Label16.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
this.Label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
this.Label16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
this.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.Label16.Location = new System.Drawing.Point(1, 1);
this.Label16.Name = "Label16";
this.Label16.Size = new System.Drawing.Size(247, 21);
this.Label16.TabIndex = 0;
this.Label16.Text = " Search";
this.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
// 
// Label6
// 
this.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.Label6.Location = new System.Drawing.Point(16, 42);
this.Label6.Name = "Label6";
this.Label6.Size = new System.Drawing.Size(141, 15);
this.Label6.TabIndex = 4;
this.Label6.Text = "Input Search string here";
// 
// btnCloseSearch
// 
this.btnCloseSearch.BackColor = System.Drawing.SystemColors.Control;
this.btnCloseSearch.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnCloseSearch.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnCloseSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.btnCloseSearch.Location = new System.Drawing.Point(118, 97);
this.btnCloseSearch.Name = "btnCloseSearch";
this.btnCloseSearch.Size = new System.Drawing.Size(63, 30);
this.btnCloseSearch.TabIndex = 188;
this.btnCloseSearch.Text = "&Close";
this.btnCloseSearch.UseVisualStyleBackColor = false;
this.btnCloseSearch.Click += new System.EventHandler(this.btnCloseSearch_Click);
// 
// btnFind
// 
this.btnFind.BackColor = System.Drawing.SystemColors.Control;
this.btnFind.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnFind.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnFind.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.btnFind.Location = new System.Drawing.Point(50, 97);
this.btnFind.Name = "btnFind";
this.btnFind.Size = new System.Drawing.Size(63, 30);
this.btnFind.TabIndex = 187;
this.btnFind.Text = "&Find";
this.btnFind.UseVisualStyleBackColor = false;
this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
// 
// txtSearch
// 
this.txtSearch.BackColor = System.Drawing.SystemColors.Info;
this.txtSearch.Font = new System.Drawing.Font("Arial", 9.75F);
this.txtSearch.Location = new System.Drawing.Point(16, 62);
this.txtSearch.Name = "txtSearch";
this.txtSearch.Size = new System.Drawing.Size(221, 22);
this.txtSearch.TabIndex = 3;

// 
// HousekeepingTypeUI
// 
this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
this.ClientSize = new System.Drawing.Size(530, 359);
this.Controls.Add(this.pnlSearch);
this.Controls.Add(this.GroupBox3);
this.Controls.Add(this.gbxCommands);
this.Controls.Add(this.grdHousekeepingTypes);
this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
this.MaximizeBox = false;
this.Name = "HousekeepingTypeUI";
this.Text = "Housekeeping Types";
this.Closing += new System.ComponentModel.CancelEventHandler(this.HousekeepingType_Closing);
this.TextChanged += new System.EventHandler(this.HousekeepingType_TextChanged);
this.Load += new System.EventHandler(this.HousekeepingType_Load);
this.GroupBox3.ResumeLayout(false);
this.GroupBox3.PerformLayout();
this.gbxCommands.ResumeLayout(false);
((System.ComponentModel.ISupportInitialize)(this.grdHousekeepingTypes)).EndInit();
this.pnlSearch.ResumeLayout(false);
this.pnlSearch.PerformLayout();
this.ResumeLayout(false);

			}
			
			#endregion

            /// <summary>
            /// Local Variables are Camel Casing ( ex. camelCasing )
            /// Variables prefixed by "o" is an Object Instance ( ex. oCurrencyCode )
            /// </summary>
            #region " VARIABLES/CONSTANTS "

            enum OperationMode { ADD, EDIT };
            private OperationMode mOperationMode;
      
            private ControlListener oControlListener;
            private DatasetBinder oDatasetBinder;
            
            private HousekeepingType oHousekeepingType;
            private HousekeepingTypeFacade oHousekeepingTypeFacade;

            public static string HousekeepingTypeTypeCode = "";

            #endregion

            #region " CONSTRUCTORS "

           
            public HousekeepingTypeUI()
            {
                InitializeComponent();

                oControlListener = new ControlListener();
                oDatasetBinder = new DatasetBinder();

            }
			
            #endregion

            #region " METHODS "

            /********************************************************
           * Purpose: Retrieve data from the database
           *********************************************************/
            public bool load()
            {
                try
                {
                    oHousekeepingTypeFacade = new HousekeepingTypeFacade();
                    oHousekeepingType = new HousekeepingType();
                    oHousekeepingType = (HousekeepingType)oHousekeepingTypeFacade.getHousekeepingType();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }

            /********************************************************
           * Purpose: Insert new item into the database
           *********************************************************/
            public int insert()
            {
                try
                {
                    int rowsAdded = 0;
                    oHousekeepingTypeFacade = new HousekeepingTypeFacade();
                    rowsAdded = oHousekeepingTypeFacade.insertHousekeepingType(oHousekeepingType);
                    return rowsAdded;
                }
                catch (Exception)
                {
                    return 0;
                }
            }

            /********************************************************
           * Purpose: Update existing item 
           *********************************************************/
            public int update()
            {
                try
                {
                    int rowsAffected = 0;
                    oHousekeepingTypeFacade = new HousekeepingTypeFacade();
                    rowsAffected = oHousekeepingTypeFacade.updateHousekeepingType(ref oHousekeepingType);
                    return rowsAffected;
                }
                catch (Exception)
                {
                    return 0;
                }

            }
        
            private bool hasChanges()
            {
                if (this.Text.IndexOf("*") > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            private bool bindRowToControls()
			{
				try
                {
                    if (hasChanges())
                    {
                        if (MessageBox.Show("Save changes made to HousekeepingTypeUI Type '" + this.txtId.Text + "'", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            assignEntityValues();
                            update();
                        }
                        else
                        {
                            this.BindingContext[oHousekeepingType.Tables[0]].CancelCurrentEdit();
                            this.Text = "Housekeeping Types";
                        }
                    }

					oControlListener.StopListen(this);
					this.BindingContext[oHousekeepingType.Tables["HousekeepingTypes"]].Position = findItemInDataset(this.grdHousekeepingTypes.get_TextMatrix(this.grdHousekeepingTypes.Row, 0));


                    return true;
				}
				catch (Exception)
                { 
                    return false;
                }
				finally
				{
                    if (this.pnlSearch.Visible == false)
                    {
                        oControlListener.Listen(this);
                    }
				}
			}

            private bool assignEntityValues()
			{

                oHousekeepingType.Id= this.txtId.Text;
                oHousekeepingType.Name= this.txtName.Text;
                oHousekeepingType.Code = this.txtCode.Text;
                
                return true;
			}

            /********************************************************
           * Purpose: Mark existing item as DELETED
           *********************************************************/
            public int delete()
            {
                try
                {
                    int rowsAffected = 0;
                    oHousekeepingTypeFacade = new HousekeepingTypeFacade();
                    assignEntityValues();

                    rowsAffected = oHousekeepingTypeFacade.deleteHousekeepingType(ref oHousekeepingType);
                    return rowsAffected;
                }
                catch (Exception)
                {
                    return 0;
                }
            }

			
            /********************************************************
            * Purpose: Set the state of the button
            *********************************************************/
            private void setActionButtonStates(bool state)
            {
                this.btnSearch.Enabled = state;
                this.btnNew.Enabled = state;
                this.btnDelete.Enabled = state;
                this.btnSave.Enabled = !state;
                this.btnCancel.Enabled = !state;
            }

            /*********************************************************
           * Purpose: Check if control has a valid value
           *********************************************************/
            private bool isRequiredEntriesFilled()
            {
                if (this.txtId.Text.Trim().Length > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

			// >> Limits textbox to numbers only
			private bool numOnly(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
                switch (e.KeyChar)
                {
                    case '0': case '1': case '2': case '3': case '4':
                    case '5': case '6': case '7': case '8': case '9':
                        e.Handled = false;
                        break;
                    default :
                        e.Handled = true;
                        break;
                }

                return true;

			}

            /// <summary>
            /// Searches the Item-Key in the Dataset and returns the Index of the Item...
            /// </summary>
            /// <param name="key"> string "key" usually the unique index </param>
            /// <returns> integer (index) </returns>
            private int findItemInDataset(string key)
            {
                int i;

                i = 0;
                foreach (DataRow drGuest in oHousekeepingType.Tables[0].Rows)
                {
                    if (drGuest["Id"].ToString() == key)
                    {
                        return i;
                    }
                    else
                    {
                        i++;
                    }
                }
                return 0;
            }

            /*********************************************************
             * Purpose: Populate record to Grid Control
             *********************************************************/
            public bool populateDataGrid(DataTable a_HousekeepingTypeType)
            {
                int i = 0;
                try
                {
                    this.grdHousekeepingTypes.Rows = 1;

                    foreach (DataRow dRow in a_HousekeepingTypeType.Rows)
                    {
                        i = this.grdHousekeepingTypes.Rows;
                        this.grdHousekeepingTypes.Rows++;

                        this.grdHousekeepingTypes.set_TextMatrix(i, 0, dRow["Id"].ToString());
                        this.grdHousekeepingTypes.set_TextMatrix(i, 1, dRow["Name"].ToString());
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Populating Data Grid.");
                    return false;
                }
            }

            /*********************************************************
             * Purpose: Ready for new transaction
             *********************************************************/
            private void setOperationMode(OperationMode a_OperationMode)
            {
                mOperationMode = a_OperationMode;
            }

			#endregion
                
            #region " EVENTS "

            private void HousekeepingType_Load(object sender, System.EventArgs e)
            {
                if (load() == true)
                {
                   
                    if (!oHousekeepingType.Equals(null))
                    {
                        object obj = (object)oHousekeepingType;
                        oDatasetBinder.BindControls(this, ref obj, new ArrayList());

                        populateDataGrid(oHousekeepingType.Tables[0]);
                    }

                    this.Text = "Housekeeping Types";
                    this.txtId.Enabled = false;
                    oControlListener.Listen(this);
                }
                this.setActionButtonStates(true);
            }

            private void btnNew_Click(System.Object sender, System.EventArgs e)
            {
                // Set operation mode to ADD
                setOperationMode(OperationMode.ADD);

                // Disable control listeners for all controls in the form
                oControlListener.StopListen(this);

                // Suspend binding context for all controls
                this.BindingContext[oHousekeepingType.Tables[0]].SuspendBinding();

                // Set action button states
                setActionButtonStates(false);

                // Enable Currency code textbox
                this.txtId.Enabled = true;

                // Set focus to Currency code textbox
                this.txtId.Focus();
            }

            private void HousekeepingType_Closing(object sender, System.ComponentModel.CancelEventArgs e)
            {
                if (hasChanges())
                {
                    if (MessageBox.Show("Save changes made to HousekeepingType '" + this.txtId.Text + "'", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        assignEntityValues();
                        update();
                    }
                    else
                    {
                        this.BindingContext[oHousekeepingType.Tables[0]].CancelCurrentEdit();
                        this.Text = "Housekeeping Types";
                    }
                }
            }

            private void btnSave_Click(System.Object sender, System.EventArgs e)
            {
                if (isRequiredEntriesFilled())
                {
                    assignEntityValues();

                    switch (mOperationMode)
                    {
                        case OperationMode.ADD:
                            if (insert() > 0)
                            {
                                MessageBox.Show("Item successfully added.", "HousekeepingTypeUI Type", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                this.grdHousekeepingTypes.Rows++;
                                this.grdHousekeepingTypes.set_TextMatrix(this.grdHousekeepingTypes.Rows - 1, 0, oHousekeepingType.Id);

                                // >> Resume Binding
                                this.BindingContext[oHousekeepingType.Tables[0]].ResumeBinding();
                                this.Text = "Housekeeping Types";

                                //mode = "";
                                this.txtId.Enabled = false;

                                setActionButtonStates(true);
                                oControlListener.Listen(this);

                            }
                            else
                            {
                                MessageBox.Show("No rows added", "Database Insert Error");
                            }

                            break;
                        case OperationMode.EDIT:
                            if (update() > 0)
                            {
                                MessageBox.Show("Item successfully updated.", "HousekeepingTypes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                this.BindingContext[oHousekeepingType.Tables[0]].ResumeBinding();
                                this.Text = "Housekeeping Types";
                                this.txtId.Enabled = false;
                                setActionButtonStates(true);
                                oControlListener.Listen(this);

                            }
                            else
                            {
                                MessageBox.Show("No rows updated", "Database Update Error");
                            }
                            break;
                        default:
                            MessageBox.Show("Invalid operation mode", "Abort operation");
                            break;
                    }
                    populateDataGrid(oHousekeepingType.Tables[0]);
                }
                else
                {
                    //MessageBox.Show("Please input currency code!", "Save Error");
                    this.txtId.Focus();
                    return;
                }
            }

            private void btnCancel_Click(System.Object sender, System.EventArgs e)
            {
                if (mOperationMode.Equals(OperationMode.ADD))
                {
                    if (this.grdHousekeepingTypes.Rows > 1)
                    {
                        this.grdHousekeepingTypes.Row = 1;
                    }
                }
                else
                {
                    this.BindingContext[oHousekeepingType.Tables[0]].CancelCurrentEdit();
                }
                oControlListener.Listen(this);
                this.BindingContext[oHousekeepingType.Tables[0]].ResumeBinding();

                this.Text = "Housekeeping Types";
                this.txtId.Enabled = false;

                setActionButtonStates(true);
                
            }

            private void btnDelete_Click(System.Object sender, System.EventArgs e)
            {
                this.oControlListener.StopListen(this);
                if (MessageBox.Show("Are you certain you want to remove HousekeepingTypeUI Type '" + this.txtId.Text + "'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (delete() > 0)
                    {
                        this.grdHousekeepingTypes.RemoveItem(this.grdHousekeepingTypes.Row);
                    }
                    else
                    {
                        MessageBox.Show("No rows deleted", "Database Update Error");
                    }
                }
                this.oControlListener.Listen(this);
            }

            private void HousekeepingType_TextChanged(object sender, System.EventArgs e)
            {
                if (this.Text.IndexOf('*') > 0)
                {
                    setOperationMode(OperationMode.EDIT);
                    setActionButtonStates(false);
                }
                else
                {
                    setActionButtonStates(true);
                }
            }

            private void grdHousekeepingTypeTypes_Click(System.Object sender, System.EventArgs e)
            {
                bindRowToControls();
            }

          
            private void btnSearch_Click(object sender, EventArgs e)
            {
                this.pnlSearch.Visible = true;
                this.txtSearch.Focus();
                this.txtSearch.SelectAll();
            }

            #endregion

            private void btnCloseSearch_Click(object sender, EventArgs e)
            {
                this.pnlSearch.Visible = false;
            }

            private void grdHousekeepingTypes_RowColChange(object sender, EventArgs e)
            {
                bindRowToControls();
            }

            private void btnFind_Click(object sender, EventArgs e)
            {

            }

         


          

            
	}
}	
