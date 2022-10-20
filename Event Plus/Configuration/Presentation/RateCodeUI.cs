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

using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;


namespace Jinisys.Hotel.ConfigurationHotel.Presentation
{
    public class RateCodeUI : Jinisys.Hotel.UIFramework.Maintenance2UI, ClassMaintenanceInterface
    {

        #region " Windows Form Designer generated code 
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
        public System.Windows.Forms.GroupBox GroupBox1;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button btnDelete;
        internal System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.Button btnNew;
        internal System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.TextBox txtRateCode;
        public System.Windows.Forms.TextBox txtDescription;
        internal System.Windows.Forms.GroupBox gbxCommands;
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
        internal C1.Win.C1FlexGrid.Classic.C1FlexGridClassic grdRateCodes;
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RateCodeUI));
this.GroupBox1 = new System.Windows.Forms.GroupBox();
this.Label1 = new System.Windows.Forms.Label();
this.txtRateCode = new System.Windows.Forms.TextBox();
this.txtDescription = new System.Windows.Forms.TextBox();
this.Label2 = new System.Windows.Forms.Label();
this.btnDelete = new System.Windows.Forms.Button();
this.btnSave = new System.Windows.Forms.Button();
this.btnNew = new System.Windows.Forms.Button();
this.btnCancel = new System.Windows.Forms.Button();
this.gbxCommands = new System.Windows.Forms.GroupBox();
this.btnClose = new System.Windows.Forms.Button();
this.btnSearch = new System.Windows.Forms.Button();
this.grdRateCodes = new C1.Win.C1FlexGrid.Classic.C1FlexGridClassic();
this.pnlSearch = new System.Windows.Forms.Panel();
this.label5 = new System.Windows.Forms.Label();
this.picClose = new System.Windows.Forms.Label();
this.Label16 = new System.Windows.Forms.Label();
this.Label6 = new System.Windows.Forms.Label();
this.btnCloseSearch = new System.Windows.Forms.Button();
this.btnFind = new System.Windows.Forms.Button();
this.txtSearch = new System.Windows.Forms.TextBox();
this.GroupBox1.SuspendLayout();
this.gbxCommands.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.grdRateCodes)).BeginInit();
this.pnlSearch.SuspendLayout();
this.SuspendLayout();
// 
// GroupBox1
// 
this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
this.GroupBox1.Controls.Add(this.Label1);
this.GroupBox1.Controls.Add(this.txtRateCode);
this.GroupBox1.Controls.Add(this.txtDescription);
this.GroupBox1.Controls.Add(this.Label2);
this.GroupBox1.Location = new System.Drawing.Point(219, -2);
this.GroupBox1.Name = "GroupBox1";
this.GroupBox1.Size = new System.Drawing.Size(333, 314);
this.GroupBox1.TabIndex = 95;
this.GroupBox1.TabStop = false;
// 
// Label1
// 
this.Label1.Location = new System.Drawing.Point(21, 36);
this.Label1.Name = "Label1";
this.Label1.Size = new System.Drawing.Size(64, 17);
this.Label1.TabIndex = 54;
this.Label1.Text = "Rate Code";
// 
// txtRateCode
// 
this.txtRateCode.BackColor = System.Drawing.SystemColors.Info;
this.txtRateCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtRateCode.Enabled = false;
this.txtRateCode.Location = new System.Drawing.Point(94, 33);
this.txtRateCode.MaxLength = 50;
this.txtRateCode.Multiline = true;
this.txtRateCode.Name = "txtRateCode";
this.txtRateCode.Size = new System.Drawing.Size(204, 20);
this.txtRateCode.TabIndex = 1;
// 
// txtDescription
// 
this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtDescription.Location = new System.Drawing.Point(94, 64);
this.txtDescription.MaxLength = 100;
this.txtDescription.Multiline = true;
this.txtDescription.Name = "txtDescription";
this.txtDescription.Size = new System.Drawing.Size(205, 64);
this.txtDescription.TabIndex = 2;
// 
// Label2
// 
this.Label2.Location = new System.Drawing.Point(21, 67);
this.Label2.Name = "Label2";
this.Label2.Size = new System.Drawing.Size(67, 17);
this.Label2.TabIndex = 49;
this.Label2.Text = "Description";
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
// gbxCommands
// 
this.gbxCommands.Controls.Add(this.btnClose);
this.gbxCommands.Controls.Add(this.btnSearch);
this.gbxCommands.Controls.Add(this.btnDelete);
this.gbxCommands.Controls.Add(this.btnSave);
this.gbxCommands.Controls.Add(this.btnNew);
this.gbxCommands.Controls.Add(this.btnCancel);
this.gbxCommands.Location = new System.Drawing.Point(1, 309);
this.gbxCommands.Name = "gbxCommands";
this.gbxCommands.Size = new System.Drawing.Size(551, 47);
this.gbxCommands.TabIndex = 97;
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
// btnSearch
// 
this.btnSearch.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnSearch.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnSearch.Location = new System.Drawing.Point(205, 10);
this.btnSearch.Name = "btnSearch";
this.btnSearch.Size = new System.Drawing.Size(66, 31);
this.btnSearch.TabIndex = 186;
this.btnSearch.Text = "Searc&h";
this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
// 
// grdRateCodes
// 
this.grdRateCodes.AllowUserResizing = C1.Win.C1FlexGrid.Classic.AllowUserResizeSettings.flexResizeColumns;
this.grdRateCodes.BackColorSel = System.Drawing.SystemColors.Info;
this.grdRateCodes.Cols = 1;
this.grdRateCodes.ColumnInfo = "1,0,0,0,0,85,Columns:0{Width:176;Caption:\"Code\";TextAlign:LeftCenter;TextAlignFix" +
    "ed:CenterCenter;}\t";
this.grdRateCodes.ExtendLastCol = true;
this.grdRateCodes.FixedCols = 0;
this.grdRateCodes.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
this.grdRateCodes.Font = new System.Drawing.Font("Arial", 8.25F);
this.grdRateCodes.ForeColorSel = System.Drawing.Color.Black;
this.grdRateCodes.GridColorFixed = System.Drawing.SystemColors.ControlDark;
this.grdRateCodes.Location = new System.Drawing.Point(1, 3);
this.grdRateCodes.Name = "grdRateCodes";
this.grdRateCodes.NodeClosedPicture = null;
this.grdRateCodes.NodeOpenPicture = null;
this.grdRateCodes.OutlineCol = -1;
this.grdRateCodes.SelectionMode = C1.Win.C1FlexGrid.Classic.SelModeSettings.flexSelectionByRow;
this.grdRateCodes.Size = new System.Drawing.Size(214, 308);
this.grdRateCodes.StyleInfo = resources.GetString("grdRateCodes.StyleInfo");
this.grdRateCodes.TabIndex = 188;
this.grdRateCodes.TreeColor = System.Drawing.Color.DarkGray;
this.grdRateCodes.Click += new System.EventHandler(this.grdRateCodes_Click);
this.grdRateCodes.RowColChange += new System.EventHandler(this.grdRateCodes_RowColChange);
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
this.pnlSearch.Location = new System.Drawing.Point(-256, 106);
this.pnlSearch.Name = "pnlSearch";
this.pnlSearch.Size = new System.Drawing.Size(251, 149);
this.pnlSearch.TabIndex = 189;
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
this.txtSearch.Font = new System.Drawing.Font("Arial", 9.75F);
this.txtSearch.Location = new System.Drawing.Point(16, 62);
this.txtSearch.Name = "txtSearch";
this.txtSearch.Size = new System.Drawing.Size(221, 22);
this.txtSearch.TabIndex = 3;
this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
// 
// RateCodeUI
// 
this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
this.CancelButton = this.btnClose;
this.ClientSize = new System.Drawing.Size(555, 361);
this.Controls.Add(this.pnlSearch);
this.Controls.Add(this.grdRateCodes);
this.Controls.Add(this.GroupBox1);
this.Controls.Add(this.gbxCommands);
this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
this.Name = "RateCodeUI";
this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
this.Text = "Rate Code";
this.Closing += new System.ComponentModel.CancelEventHandler(this.RateCodeUI_Closing);
this.TextChanged += new System.EventHandler(this.RateCodeUI_TextChanged);
this.Load += new System.EventHandler(this.RateCodeUI_Load);
this.GroupBox1.ResumeLayout(false);
this.GroupBox1.PerformLayout();
this.gbxCommands.ResumeLayout(false);
((System.ComponentModel.ISupportInitialize)(this.grdRateCodes)).EndInit();
this.pnlSearch.ResumeLayout(false);
this.pnlSearch.PerformLayout();
this.ResumeLayout(false);

        }

        #endregion

        #region " VARIABLES "

        enum OperationMode { ADD, EDIT };
        private OperationMode mOperationMode;

        private DatasetBinder oDataSetBinder;
        private ControlListener oControlListener;

        private RateCode oRateCode;
        private RateCodeFacade oRateCodeFacade;

        #endregion

        #region " CONSTRUCTORS "

        // >> Constructor for RateCode with db connection
        public RateCodeUI()
        {
            InitializeComponent();
            
            oDataSetBinder = new DatasetBinder();
            oControlListener = new ControlListener();
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
                oRateCodeFacade = new RateCodeFacade();
                oRateCode = new RateCode();
                oRateCode = (RateCode)oRateCodeFacade.loadObject();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /*********************************************************
             * Purpose: Populate record to Grid Control
             *********************************************************/
        public bool populateDataGrid(DataTable a_RateType)
        {
            int i = 0;
            try
            {
                this.grdRateCodes.Rows = 1;

                foreach (DataRow dRow in a_RateType.Rows)
                {
                    i = this.grdRateCodes.Rows;
                    this.grdRateCodes.Rows++;

                    this.grdRateCodes.set_TextMatrix(i, 0, dRow["RateCode"].ToString());
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Populating Data Grid.");
                return false;
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
                    if (MessageBox.Show("Save changes made to Rate code '" + this.txtRateCode.Text + "'", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        assignEntityValues();
                        update();
                    }
                    else
                    {
                        this.BindingContext[oRateCode.Tables[0]].CancelCurrentEdit();
                        this.Text = "Rate Codes";
                    }
                }

                oControlListener.StopListen(this);
                this.BindingContext[oRateCode.Tables[0]].Position = findItemInDataset(this.grdRateCodes.get_TextMatrix(this.grdRateCodes.Row, 0));

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
                    this.oControlListener.Listen(this);
                }
            }


        }

        /*********************************************************
           * Purpose: Check if control has a valid value
           *********************************************************/
        private bool isRequiredEntriesFilled()
        {
            if (this.txtRateCode.Text.Trim().Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void assignEntityValues()
        {
            oRateCode.RateCodeName = this.txtRateCode.Text;
            oRateCode.Description = this.txtDescription.Text;
            oRateCode.UpdatedBy = GlobalVariables.gLoggedOnUser;
            oRateCode.CreatedBy = GlobalVariables.gLoggedOnUser;
            oRateCode.HotelID = GlobalVariables.gHotelId;
        }


        /********************************************************
           * Purpose: Insert new item into the database
           *********************************************************/
        public int insert()
        {
            try
            {
                int rowsAdded = 0;
                oRateCodeFacade = new RateCodeFacade();
                rowsAdded = oRateCodeFacade.insertObject(ref oRateCode);
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
                oRateCodeFacade = new RateCodeFacade();
                rowsAffected = oRateCodeFacade.updateObject(ref oRateCode);
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
                oRateCodeFacade = new RateCodeFacade();
                assignEntityValues();
                rowsAffected = oRateCodeFacade.deleteObject(ref oRateCode );
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
                for (i = this.grdRateCodes.Row + 1; i <= this.grdRateCodes.Rows - 1; i++)
                {
                    if ( this.grdRateCodes.get_TextMatrix(i, 0).ToUpper().Contains( this.txtSearch.Text.ToUpper() ) )
                    {

                        this.grdRateCodes.Row = i;
                        isFound = true;
                        return;
                    }
                }

                if (!isFound)
                {
                    for (i = 1; i <= this.grdRateCodes.Rows - 1; i++)
                    {
                        if (this.grdRateCodes.get_TextMatrix(i, 0).ToUpper().Contains(this.txtSearch.Text.ToUpper()))
                        {

                            this.grdRateCodes.Row = i;
                            isFound = true;
                            return;
                        }

                    }
                }

                MessageBox.Show("No matching record found.");
            }

        }

        private int findItemInDataset(string key)
        {
            int i;

            i = 0;
            foreach (DataRow drRateCode in oRateCode.Tables[0].Rows)
            {
                if (drRateCode["RateCode"].ToString() == key)
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
             * Purpose: Ready for new transaction
             *********************************************************/
        private void setOperationMode(OperationMode a_OperationMode)
        {
            mOperationMode = a_OperationMode;
        }


        #endregion

        #region " EVENTS "

        private void RateCodeUI_Load(object sender, System.EventArgs e)
        {
            if (load() == true)
            {
                if (!oRateCode.Equals(null))
                {
                    object obj = (object)oRateCode;
                    oDataSetBinder.BindControls(this, ref obj, new ArrayList());

                    populateDataGrid(oRateCode.Tables[0]);
                }

                this.txtRateCode.Enabled = false;
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
            this.BindingContext[oRateCode.Tables[0]].SuspendBinding();

            // Set action button states
            setActionButtonStates(false);

            // Enable Currency code textbox
            this.txtRateCode.Enabled = true;

            // Set focus to Currency code textbox
            this.txtRateCode.Focus();
        }

        private void RateCodeUI_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (hasChanges())
            {
                if (MessageBox.Show("Save changes made to Rate code '" + this.txtRateCode.Text + "'", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    assignEntityValues();
                    update();
                }
                else
                {
                    this.BindingContext[oRateCode.Tables[0]].CancelCurrentEdit();
                    this.Text = "Rate Codes";
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
                            MessageBox.Show("Item successfully added.", "Rate Codes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.grdRateCodes.Rows++;
                            this.grdRateCodes.set_TextMatrix(this.grdRateCodes.Rows - 1, 0, oRateCode.RateCodeName);

                            // >> Resume Binding
                            this.BindingContext[oRateCode.Tables[0]].ResumeBinding();
                            this.Text = "Rate Codes";

                            //mode = "";
                            this.txtRateCode.Enabled = false;

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
                            MessageBox.Show("Item successfully updated.", "Rate Codes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.BindingContext[oRateCode.Tables[0]].ResumeBinding();
                            this.Text = "Rate Codes";
                            this.txtRateCode.Enabled = false;
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
                MessageBox.Show("Please input currency code!", "Save Error");
                this.txtRateCode.Focus();
                return;
            }
        }

        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            if (mOperationMode.Equals(OperationMode.ADD))
            {
                if (this.grdRateCodes.Rows > 1)
                {
                    this.grdRateCodes.Row = 1;
                }
            }
            else
            {
                this.BindingContext[oRateCode.Tables[0]].CancelCurrentEdit();
            }

            this.BindingContext[oRateCode.Tables[0]].ResumeBinding();

            int _currentRow = grdRateCodes.Row;
            grdRateCodes.Select(0, 0);
            grdRateCodes.Select(_currentRow, 0);
            
            this.Text = "Rate Codes";
            this.txtRateCode.Enabled = false;

            setActionButtonStates(true);
            oControlListener.Listen(this);
        }

        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            this.oControlListener.StopListen(this);
            if (MessageBox.Show("Are you certain you want to remove Rate Code '" + this.grdRateCodes.get_TextMatrix(this.grdRateCodes.Row, 0) + "'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (delete() > 0)
                {
                    this.grdRateCodes.RemoveItem(this.grdRateCodes.Row);
                }
                else
                {
                    MessageBox.Show("No rows deleted", "Database Update Error");
                }
            }
            this.oControlListener.Listen(this);
        }

        private void RateCodeUI_TextChanged(object sender, System.EventArgs e)
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

        private void picClose_Click(System.Object sender, System.EventArgs e)
        {
            this.pnlSearch.Visible = false;
        }

        private void grdRateCodes_Click(System.Object sender, System.EventArgs e)
        {
            bindRowToControls();
        }

        private void grdRateCodes_RowColChange(object sender, System.EventArgs e)
        {
            bindRowToControls();
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

        private void btnCloseSearch_Click(object sender, EventArgs e)
        {
            this.pnlSearch.Visible = false;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            searchItem();
        }


        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}