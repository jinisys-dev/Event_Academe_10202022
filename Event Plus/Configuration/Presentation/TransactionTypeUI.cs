/*
 * Jinisys Softwares, Inc.
 * Copyright © 2006
 * 
 * 
*/

using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;


namespace Jinisys.Hotel.ConfigurationHotel.Presentation
{
    public class TransactionTypeUI : Jinisys.Hotel.UIFramework.MiscellaneousUI, ClassMaintenanceInterface
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
        internal System.Windows.Forms.GroupBox gbxCommands;
        internal System.Windows.Forms.Button btnDelete;
        internal System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.Button btnNew;
        internal System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Label Label8;
        public System.Windows.Forms.Label Label9;
        public System.Windows.Forms.TextBox txtTranTypeId;
        public System.Windows.Forms.TextBox txtTranType;
        public System.Windows.Forms.TextBox txtAcctGroup;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button btnSearch;
        internal Panel pnlSearch;
        private Label label5;
        internal Label picClose;
        internal Label Label16;
        internal Label Label6;
        internal Button btnCloseSearch;
        internal Button btnFind;
        internal TextBox txtSearch;
        internal Button btnClose;
        internal C1.Win.C1FlexGrid.Classic.C1FlexGridClassic grdTransactionTypes;
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionTypeUI));
this.txtTranTypeId = new System.Windows.Forms.TextBox();
this.txtAcctGroup = new System.Windows.Forms.TextBox();
this.txtTranType = new System.Windows.Forms.TextBox();
this.Label2 = new System.Windows.Forms.Label();
this.gbxCommands = new System.Windows.Forms.GroupBox();
this.btnSearch = new System.Windows.Forms.Button();
this.btnDelete = new System.Windows.Forms.Button();
this.btnSave = new System.Windows.Forms.Button();
this.btnNew = new System.Windows.Forms.Button();
this.btnCancel = new System.Windows.Forms.Button();
this.Label8 = new System.Windows.Forms.Label();
this.Label9 = new System.Windows.Forms.Label();
this.GroupBox1 = new System.Windows.Forms.GroupBox();
this.grdTransactionTypes = new C1.Win.C1FlexGrid.Classic.C1FlexGridClassic();
this.pnlSearch = new System.Windows.Forms.Panel();
this.label5 = new System.Windows.Forms.Label();
this.picClose = new System.Windows.Forms.Label();
this.Label16 = new System.Windows.Forms.Label();
this.Label6 = new System.Windows.Forms.Label();
this.btnCloseSearch = new System.Windows.Forms.Button();
this.btnFind = new System.Windows.Forms.Button();
this.txtSearch = new System.Windows.Forms.TextBox();
this.btnClose = new System.Windows.Forms.Button();
this.gbxCommands.SuspendLayout();
this.GroupBox1.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.grdTransactionTypes)).BeginInit();
this.pnlSearch.SuspendLayout();
this.SuspendLayout();
// 
// txtTranTypeId
// 
this.txtTranTypeId.BackColor = System.Drawing.SystemColors.Info;
this.txtTranTypeId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtTranTypeId.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtTranTypeId.Location = new System.Drawing.Point(112, 24);
this.txtTranTypeId.MaxLength = 10;
this.txtTranTypeId.Name = "txtTranTypeId";
this.txtTranTypeId.Size = new System.Drawing.Size(128, 20);
this.txtTranTypeId.TabIndex = 146;
// 
// txtAcctGroup
// 
this.txtAcctGroup.BackColor = System.Drawing.SystemColors.Info;
this.txtAcctGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtAcctGroup.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtAcctGroup.Location = new System.Drawing.Point(112, 87);
this.txtAcctGroup.MaxLength = 20;
this.txtAcctGroup.Name = "txtAcctGroup";
this.txtAcctGroup.Size = new System.Drawing.Size(93, 20);
this.txtAcctGroup.TabIndex = 140;
// 
// txtTranType
// 
this.txtTranType.BackColor = System.Drawing.SystemColors.Info;
this.txtTranType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtTranType.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtTranType.Location = new System.Drawing.Point(112, 56);
this.txtTranType.MaxLength = 50;
this.txtTranType.Name = "txtTranType";
this.txtTranType.Size = new System.Drawing.Size(176, 20);
this.txtTranType.TabIndex = 138;
// 
// Label2
// 
this.Label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label2.Location = new System.Drawing.Point(8, 25);
this.Label2.Name = "Label2";
this.Label2.Size = new System.Drawing.Size(122, 17);
this.Label2.TabIndex = 147;
this.Label2.Text = "TranType ID";
// 
// gbxCommands
// 
this.gbxCommands.Controls.Add(this.btnClose);
this.gbxCommands.Controls.Add(this.btnSearch);
this.gbxCommands.Controls.Add(this.btnDelete);
this.gbxCommands.Controls.Add(this.btnSave);
this.gbxCommands.Controls.Add(this.btnNew);
this.gbxCommands.Controls.Add(this.btnCancel);
this.gbxCommands.Location = new System.Drawing.Point(3, 307);
this.gbxCommands.Name = "gbxCommands";
this.gbxCommands.Size = new System.Drawing.Size(524, 47);
this.gbxCommands.TabIndex = 149;
this.gbxCommands.TabStop = false;
// 
// btnSearch
// 
this.btnSearch.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnSearch.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnSearch.Location = new System.Drawing.Point(180, 11);
this.btnSearch.Name = "btnSearch";
this.btnSearch.Size = new System.Drawing.Size(66, 31);
this.btnSearch.TabIndex = 10;
this.btnSearch.Text = "Searc&h";
this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
// 
// btnDelete
// 
this.btnDelete.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnDelete.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnDelete.Location = new System.Drawing.Point(7, 11);
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
this.btnSave.Location = new System.Drawing.Point(316, 11);
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
this.btnNew.Location = new System.Drawing.Point(248, 11);
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
this.btnCancel.Location = new System.Drawing.Point(384, 11);
this.btnCancel.Name = "btnCancel";
this.btnCancel.Size = new System.Drawing.Size(66, 31);
this.btnCancel.TabIndex = 9;
this.btnCancel.Text = "&Cancel";
this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
// 
// Label8
// 
this.Label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label8.Location = new System.Drawing.Point(8, 56);
this.Label8.Name = "Label8";
this.Label8.Size = new System.Drawing.Size(98, 17);
this.Label8.TabIndex = 142;
this.Label8.Text = "Transaction Type";
// 
// Label9
// 
this.Label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label9.Location = new System.Drawing.Point(8, 88);
this.Label9.Name = "Label9";
this.Label9.Size = new System.Drawing.Size(64, 17);
this.Label9.TabIndex = 144;
this.Label9.Text = "Acct Group";
// 
// GroupBox1
// 
this.GroupBox1.Controls.Add(this.txtAcctGroup);
this.GroupBox1.Controls.Add(this.txtTranTypeId);
this.GroupBox1.Controls.Add(this.Label2);
this.GroupBox1.Controls.Add(this.Label9);
this.GroupBox1.Controls.Add(this.txtTranType);
this.GroupBox1.Controls.Add(this.Label8);
this.GroupBox1.Location = new System.Drawing.Point(218, -4);
this.GroupBox1.Name = "GroupBox1";
this.GroupBox1.Size = new System.Drawing.Size(309, 311);
this.GroupBox1.TabIndex = 150;
this.GroupBox1.TabStop = false;
// 
// grdTransactionTypes
// 
this.grdTransactionTypes.AllowUserResizing = C1.Win.C1FlexGrid.Classic.AllowUserResizeSettings.flexResizeColumns;
this.grdTransactionTypes.BackColorSel = System.Drawing.SystemColors.Info;
this.grdTransactionTypes.Cols = 2;
this.grdTransactionTypes.ColumnInfo = "2,0,0,0,0,85,Columns:0{Width:52;Caption:\"ID\";TextAlign:LeftCenter;TextAlignFixed:" +
    "CenterCenter;}\t1{Width:95;Caption:\"Transaction Type\";TextAlign:LeftCenter;TextAl" +
    "ignFixed:CenterCenter;}\t";
this.grdTransactionTypes.ExtendLastCol = true;
this.grdTransactionTypes.FixedCols = 0;
this.grdTransactionTypes.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
this.grdTransactionTypes.Font = new System.Drawing.Font("Arial", 8.25F);
this.grdTransactionTypes.ForeColorSel = System.Drawing.Color.Black;
this.grdTransactionTypes.GridColorFixed = System.Drawing.SystemColors.ControlDark;
this.grdTransactionTypes.Location = new System.Drawing.Point(2, 2);
this.grdTransactionTypes.Name = "grdTransactionTypes";
this.grdTransactionTypes.NodeClosedPicture = null;
this.grdTransactionTypes.NodeOpenPicture = null;
this.grdTransactionTypes.OutlineCol = -1;
this.grdTransactionTypes.SelectionMode = C1.Win.C1FlexGrid.Classic.SelModeSettings.flexSelectionByRow;
this.grdTransactionTypes.Size = new System.Drawing.Size(214, 305);
this.grdTransactionTypes.StyleInfo = resources.GetString("grdTransactionTypes.StyleInfo");
this.grdTransactionTypes.TabIndex = 192;
this.grdTransactionTypes.TreeColor = System.Drawing.Color.DarkGray;
this.grdTransactionTypes.Click += new System.EventHandler(this.grdTransactionTypes_Click);
this.grdTransactionTypes.RowColChange += new System.EventHandler(this.grdTransactionTypes_RowColChange);
// 
// pnlSearch
// 
this.pnlSearch.BackColor = System.Drawing.Color.White;
this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
this.pnlSearch.Controls.Add(this.label5);
this.pnlSearch.Controls.Add(this.picClose);
this.pnlSearch.Controls.Add(this.Label16);
this.pnlSearch.Controls.Add(this.Label6);
this.pnlSearch.Controls.Add(this.btnCloseSearch);
this.pnlSearch.Controls.Add(this.btnFind);
this.pnlSearch.Controls.Add(this.txtSearch);
this.pnlSearch.Location = new System.Drawing.Point(140, 105);
this.pnlSearch.Name = "pnlSearch";
this.pnlSearch.Size = new System.Drawing.Size(251, 149);
this.pnlSearch.TabIndex = 193;
this.pnlSearch.Visible = false;
this.pnlSearch.VisibleChanged += new System.EventHandler(this.pnlSearch_VisibleChanged);
// 
// label5
// 
this.label5.BackColor = System.Drawing.Color.Transparent;
this.label5.Enabled = false;
this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.label5.Location = new System.Drawing.Point(200, 99);
this.label5.Name = "label5";
this.label5.Size = new System.Drawing.Size(48, 47);
this.label5.TabIndex = 6;
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
this.picClose.Click += new System.EventHandler(this.picClose_Click);
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
this.txtSearch.Font = new System.Drawing.Font("Arial", 8.25F);
this.txtSearch.Location = new System.Drawing.Point(16, 64);
this.txtSearch.Name = "txtSearch";
this.txtSearch.Size = new System.Drawing.Size(221, 20);
this.txtSearch.TabIndex = 3;
this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
// 
// btnClose
// 
this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.btnClose.Location = new System.Drawing.Point(452, 11);
this.btnClose.Name = "btnClose";
this.btnClose.Size = new System.Drawing.Size(66, 31);
this.btnClose.TabIndex = 191;
this.btnClose.Text = "Cl&ose";
this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
// 
// TransactionTypeUI
// 
this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
this.CancelButton = this.btnClose;
this.ClientSize = new System.Drawing.Size(530, 356);
this.Controls.Add(this.pnlSearch);
this.Controls.Add(this.grdTransactionTypes);
this.Controls.Add(this.GroupBox1);
this.Controls.Add(this.gbxCommands);
this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
this.Name = "TransactionTypeUI";
this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
this.Text = "Transaction Type";
this.Closing += new System.ComponentModel.CancelEventHandler(this.TransactionTypeUI_Closing);
this.TextChanged += new System.EventHandler(this.TransactionTypeUI_TextChanged);
this.Load += new System.EventHandler(this.TransactionTypeUI_Load);
this.gbxCommands.ResumeLayout(false);
this.GroupBox1.ResumeLayout(false);
this.GroupBox1.PerformLayout();
((System.ComponentModel.ISupportInitialize)(this.grdTransactionTypes)).EndInit();
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

        private TransactionType oTransactionType;
        private TransactionTypeFacade oTransactionTypeFacade;

        #endregion

        #region " CONSTRUCTORS "

        public TransactionTypeUI()
        {

            //This call is required by the Windows Form Designer.
            InitializeComponent();

            //Add any initialization after the InitializeComponent() 
            oDatasetBinder = new DatasetBinder();
            oControlListener = new ControlListener();
        }

        #endregion

        #region " METHODS "

        public bool populateDataGrid(DataTable a_TransactionType)
        {
            int i = 0;
            this.grdTransactionTypes.Rows = 1;

            foreach (DataRow dRow in a_TransactionType.Rows)
            {
                i = this.grdTransactionTypes.Rows;
                this.grdTransactionTypes.Rows++;

                this.grdTransactionTypes.set_TextMatrix(i, 0, dRow["TranTypeID"].ToString());
                this.grdTransactionTypes.set_TextMatrix(i, 1, dRow["TranType"].ToString());
            }

            return true;
        }

        // Purpose: Ready for new transaction
        private void setOperationMode(OperationMode a_OperationMode)
        {
            mOperationMode = a_OperationMode;
        }

        // Purpose: Check if control has a valid value
        private bool isRequiredEntriesFilled()
        {
            if ( this.txtTranTypeId.Text.Trim().Length > 0 || 
                 this.txtTranType.Text.Trim().Length > 0   ||
                 this.txtAcctGroup.Text.Trim().Length > 0 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Purpose: Retrieve data from the database
        public bool load()
        {
            try
            {
                oTransactionType = new TransactionType();
                oTransactionTypeFacade = new TransactionTypeFacade();
                oTransactionType = (TransactionType)oTransactionTypeFacade.loadObject();
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
                oTransactionTypeFacade = new TransactionTypeFacade();
                rowsAdded = oTransactionTypeFacade.insertObject(ref oTransactionType);
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
                oTransactionTypeFacade = new TransactionTypeFacade();
                rowsAffected = oTransactionTypeFacade.updateObject(ref oTransactionType);
                return rowsAffected;
            }
            catch (Exception)
            {
                return 0;
            }

        }

        /********************************************************
        * Purpose: Mark existing item as DELETED
        *********************************************************/
        public int delete()
        {
            try
            {
                int rowsAffected = 0;

                oTransactionTypeFacade = new TransactionTypeFacade();
                
                rowsAffected = oTransactionTypeFacade.deleteObject(ref oTransactionType);
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
                if ( hasChanges() )
                {
                    if (MessageBox.Show("Save changes made to Transaction Type '" + this.txtTranType.Text + "'", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (isRequiredEntriesFilled())
                        {
                            assignEntityValues();
                            update();
                        }
                        else
                        {
                            MessageBox.Show("Some required fields are empty.", "Update Cancelled");
                        }
                    }
                }

                oControlListener.StopListen(this);
                this.BindingContext[oTransactionType.Tables["TransactionTypes"]].Position = findItemInDataset(this.grdTransactionTypes.get_TextMatrix(this.grdTransactionTypes.Row, 0));

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
            oTransactionType.TranTypeId = this.txtTranTypeId.Text;
            oTransactionType.TranType = this.txtTranType.Text;
            oTransactionType.AcctGroup = this.txtAcctGroup.Text;
            oTransactionType.HotelID = GlobalVariables.gHotelId;
            oTransactionType.CreatedBy = GlobalVariables.gLoggedOnUser;
            oTransactionType.UpdatedBy = GlobalVariables.gLoggedOnUser;

            return true;
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

        /// <summary>
        /// Search the List(grid) starting from the selected Row down
        /// if Not Found then start the Search again from the top..
        /// </summary>
        private void searchItem()
        {
            bool isFound = false;

            if (!this.txtSearch.Text.Equals(""))
            {
                int i = 0;
                for (i = this.grdTransactionTypes.Row + 1; i <= this.grdTransactionTypes.Rows - 1; i++)
                {
                    if (this.grdTransactionTypes.get_TextMatrix(i, 0).ToUpper().Contains(this.txtSearch.Text.ToUpper())
                        ||
                        this.grdTransactionTypes.get_TextMatrix(i, 1).ToUpper().Contains(this.txtSearch.Text.ToUpper()))
                    {

                        this.grdTransactionTypes.Row = i;
                        isFound = true;
                        return;
                    }
                }

                if (!isFound)
                {
                    for (i = 1; i <= this.grdTransactionTypes.Rows - 1; i++)
                    {
                        if (this.grdTransactionTypes.get_TextMatrix(i, 0).ToUpper().Contains(this.txtSearch.Text.ToUpper())
                        ||
                        this.grdTransactionTypes.get_TextMatrix(i, 1).ToUpper().Contains(this.txtSearch.Text.ToUpper()))
                        {

                            this.grdTransactionTypes.Row = i;
                            isFound = true;
                            return;
                        }

                    }
                }

                MessageBox.Show("No matching record found.");
            }

        }

        /// <summary>
        /// Searches the Item-Key in the Dataset and returns the Index of the Item...
        /// </summary>
        /// <param name="key"> string "key" usually the unique index </param>
        /// <returns> integer (index) </returns>
        private int findItemInDataset(string key)
        {
            int i = 0;

            foreach (DataRow drTranType in oTransactionType.Tables[0].Rows)
            {
                if (drTranType["TranTypeId"].ToString() == key)
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

        #endregion

        #region " EVENTS "

        private void TransactionTypeUI_Load(object sender, System.EventArgs e)
        {
            if (load() == true)
            {
                if (!oTransactionType.Equals(null))
                {
                    object obj = (object)oTransactionType;
                    oDatasetBinder.BindControls(this, ref obj, new ArrayList());

                    populateDataGrid(oTransactionType.Tables[0]);
                }

                this.txtTranTypeId.Enabled = false;
                oControlListener.Listen(this);
            }
			setActionButtonStates(true);
        }

        private void btnNew_Click(System.Object sender, System.EventArgs e)
        {
            // Set operation mode to ADD
            setOperationMode(OperationMode.ADD);

            // Disable control listeners for all controls in the form
            oControlListener.StopListen(this);

            // Suspend binding context for all controls
            this.BindingContext[oTransactionType.Tables[0]].SuspendBinding();

            // Set action button states
            setActionButtonStates(false);

            // Enable Currency code textbox
            this.txtTranTypeId.Enabled = true;

            // Set focus to Currency code textbox
            this.txtTranTypeId.Focus();
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
                            MessageBox.Show("Item successfully added.", "Currency", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.grdTransactionTypes.Rows++;
                            this.grdTransactionTypes.set_TextMatrix(this.grdTransactionTypes.Rows - 1, 0, oTransactionType.TranTypeId);
                            this.grdTransactionTypes.set_TextMatrix(this.grdTransactionTypes.Rows - 1, 1, oTransactionType.TranType);

                            // >> Resume Binding
                            this.BindingContext[oTransactionType.Tables[0]].ResumeBinding();
                            this.Text = "Transaction Types";

                            //mode = "";
                            this.txtTranTypeId.Enabled = false;

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
                            MessageBox.Show("Item successfully updated.", "Currency", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.grdTransactionTypes.set_TextMatrix(this.grdTransactionTypes.Row, 1, oTransactionType.TranType);

                            this.BindingContext[oTransactionType.Tables[0]].ResumeBinding();
                            this.Text = "Transaction Types";
                            this.txtTranTypeId.Enabled = false;
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
            }
            else
            {
                MessageBox.Show("Please input transaction type!", "Save Error");
                this.txtTranTypeId.Focus();
                return;
            }
        }

        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            if (mOperationMode.Equals(OperationMode.ADD))
            {
                if (this.grdTransactionTypes.Rows > 1)
                {
                    this.grdTransactionTypes.Row = 1;
                }
            }
            else
            {
                this.BindingContext[oTransactionType.Tables[0]].CancelCurrentEdit();
            }

            this.BindingContext[oTransactionType.Tables[0]].ResumeBinding();

            this.Text = "Transaction Types";
            this.txtTranTypeId.Enabled = false;

            setActionButtonStates(true);
            oControlListener.Listen(this);
        }

        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            this.oControlListener.StopListen(this);
            if (MessageBox.Show("Are you certain you want to remove Transaction Type '" + this.txtTranType.Text + "'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                assignEntityValues(); 

                if (delete() > 0)
                {
                    this.grdTransactionTypes.RemoveItem(this.grdTransactionTypes.Row);
                }
                else
                {
                    MessageBox.Show("No rows deleted", "Database Update Error");
                }
            }
            this.oControlListener.Listen(this);
        }

        private void TransactionTypeUI_TextChanged(object sender, System.EventArgs e)
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

        private void TransactionTypeUI_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (hasChanges())
            {
                if (MessageBox.Show("Save changes made to Transaction Type '" + this.txtTranType.Text + "'", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (isRequiredEntriesFilled())
                    {
                        assignEntityValues();
                        update();
                    }
                    else
                    {
                        MessageBox.Show("Some required fields are empty.", "Update Cancelled");
                    }
                }
                else
                {
                    this.BindingContext[oTransactionType.Tables[0]].CancelCurrentEdit();
                    this.Text = "Transction Types";
                }
            }
        }

        private void btnSearch_Click(System.Object sender, System.EventArgs e)
        {
            this.pnlSearch.Visible = true;
            this.txtSearch.Focus();
            this.txtSearch.SelectAll();
        }

        private void txtSearch_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                searchItem();
            }
        }

        private void Close_Click(System.Object sender, System.EventArgs e)
        {
            this.pnlSearch.Visible = false;
        }

        private void pnlSearch_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlSearch.Visible)
            {
                this.oControlListener.StopListen(this);
                this.gbxCommands.Enabled = false;
            }
            else
            {
                this.oControlListener.Listen(this);
                this.gbxCommands.Enabled = true;
            }

        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.pnlSearch.Visible = false;
        }

        private void btnCloseSearch_Click(object sender, EventArgs e)
        {
            this.pnlSearch.Visible = false;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            searchItem();
        }

        private void grdTransactionTypes_Click(object sender, EventArgs e)
        {
            bindRowToControls();
        }

        private void grdTransactionTypes_RowColChange(object sender, EventArgs e)
        {
            bindRowToControls();
        }


        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}