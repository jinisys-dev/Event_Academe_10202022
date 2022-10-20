/*
 * Jinisys Softwares, Inc.
 * Copyright © 2006
 * 
 * 
*/

using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Jinisys.Hotel.ConfigurationHotel.Presentation
{
	public class RoomAmenityUI : Jinisys.Hotel.UIFramework.Maintenance2UI, ClassMaintenanceInterface
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
		public System.Windows.Forms.GroupBox GroupBox1;
		public System.Windows.Forms.TextBox txtName;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.TextBox txtAmenityID;
		public System.Windows.Forms.TextBox txtDescription;
		internal System.Windows.Forms.Button btnDelete;
		internal System.Windows.Forms.Button btnSave;
		internal System.Windows.Forms.Button btnNew;
		internal System.Windows.Forms.Button btnCancel;
		internal System.Windows.Forms.GroupBox gbxCommands;
		internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label4;
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
		internal C1.Win.C1FlexGrid.Classic.C1FlexGridClassic grdAmenities;
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomAmenityUI));
this.GroupBox1 = new System.Windows.Forms.GroupBox();
this.txtName = new System.Windows.Forms.TextBox();
this.Label2 = new System.Windows.Forms.Label();
this.txtAmenityID = new System.Windows.Forms.TextBox();
this.Label1 = new System.Windows.Forms.Label();
this.Label4 = new System.Windows.Forms.Label();
this.txtDescription = new System.Windows.Forms.TextBox();
this.btnDelete = new System.Windows.Forms.Button();
this.btnSave = new System.Windows.Forms.Button();
this.btnNew = new System.Windows.Forms.Button();
this.btnCancel = new System.Windows.Forms.Button();
this.gbxCommands = new System.Windows.Forms.GroupBox();
this.btnSearch = new System.Windows.Forms.Button();
this.grdAmenities = new C1.Win.C1FlexGrid.Classic.C1FlexGridClassic();
this.pnlSearch = new System.Windows.Forms.Panel();
this.label5 = new System.Windows.Forms.Label();
this.picClose = new System.Windows.Forms.Label();
this.Label16 = new System.Windows.Forms.Label();
this.Label6 = new System.Windows.Forms.Label();
this.btnCloseSearch = new System.Windows.Forms.Button();
this.btnFind = new System.Windows.Forms.Button();
this.txtSearch = new System.Windows.Forms.TextBox();
this.btnClose = new System.Windows.Forms.Button();
this.GroupBox1.SuspendLayout();
this.gbxCommands.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.grdAmenities)).BeginInit();
this.pnlSearch.SuspendLayout();
this.SuspendLayout();
// 
// GroupBox1
// 
this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
this.GroupBox1.Controls.Add(this.txtName);
this.GroupBox1.Controls.Add(this.Label2);
this.GroupBox1.Controls.Add(this.txtAmenityID);
this.GroupBox1.Controls.Add(this.Label1);
this.GroupBox1.Controls.Add(this.Label4);
this.GroupBox1.Controls.Add(this.txtDescription);
this.GroupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.GroupBox1.Location = new System.Drawing.Point(219, -3);
this.GroupBox1.Name = "GroupBox1";
this.GroupBox1.Size = new System.Drawing.Size(307, 314);
this.GroupBox1.TabIndex = 4;
this.GroupBox1.TabStop = false;
// 
// txtName
// 
this.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtName.Location = new System.Drawing.Point(93, 48);
this.txtName.MaxLength = 20;
this.txtName.Name = "txtName";
this.txtName.Size = new System.Drawing.Size(204, 20);
this.txtName.TabIndex = 2;
// 
// Label2
// 
this.Label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label2.Location = new System.Drawing.Point(14, 50);
this.Label2.Name = "Label2";
this.Label2.Size = new System.Drawing.Size(52, 17);
this.Label2.TabIndex = 49;
this.Label2.Text = "Name";
// 
// txtAmenityID
// 
this.txtAmenityID.BackColor = System.Drawing.SystemColors.Info;
this.txtAmenityID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtAmenityID.Enabled = false;
this.txtAmenityID.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtAmenityID.Location = new System.Drawing.Point(93, 18);
this.txtAmenityID.MaxLength = 5;
this.txtAmenityID.Multiline = true;
this.txtAmenityID.Name = "txtAmenityID";
this.txtAmenityID.Size = new System.Drawing.Size(138, 21);
this.txtAmenityID.TabIndex = 1;
// 
// Label1
// 
this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label1.Location = new System.Drawing.Point(14, 20);
this.Label1.Name = "Label1";
this.Label1.Size = new System.Drawing.Size(74, 17);
this.Label1.TabIndex = 47;
this.Label1.Text = "Amenity ID";
// 
// Label4
// 
this.Label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label4.Location = new System.Drawing.Point(14, 78);
this.Label4.Name = "Label4";
this.Label4.Size = new System.Drawing.Size(65, 17);
this.Label4.TabIndex = 49;
this.Label4.Text = "Description";
// 
// txtDescription
// 
this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtDescription.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtDescription.Location = new System.Drawing.Point(93, 77);
this.txtDescription.MaxLength = 50;
this.txtDescription.Multiline = true;
this.txtDescription.Name = "txtDescription";
this.txtDescription.Size = new System.Drawing.Size(204, 51);
this.txtDescription.TabIndex = 3;
// 
// btnDelete
// 
this.btnDelete.Cursor = System.Windows.Forms.Cursors.Default;
this.btnDelete.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnDelete.Location = new System.Drawing.Point(7, 12);
this.btnDelete.Name = "btnDelete";
this.btnDelete.Size = new System.Drawing.Size(66, 31);
this.btnDelete.TabIndex = 4;
this.btnDelete.Text = "&Delete";
this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
// 
// btnSave
// 
this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
this.btnSave.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnSave.Location = new System.Drawing.Point(319, 12);
this.btnSave.Name = "btnSave";
this.btnSave.Size = new System.Drawing.Size(66, 31);
this.btnSave.TabIndex = 8;
this.btnSave.Text = "&Save";
this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
// 
// btnNew
// 
this.btnNew.Cursor = System.Windows.Forms.Cursors.Default;
this.btnNew.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnNew.Location = new System.Drawing.Point(251, 12);
this.btnNew.Name = "btnNew";
this.btnNew.Size = new System.Drawing.Size(66, 31);
this.btnNew.TabIndex = 5;
this.btnNew.Text = "&New";
this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
// 
// btnCancel
// 
this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
this.btnCancel.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnCancel.Location = new System.Drawing.Point(387, 12);
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
this.gbxCommands.Controls.Add(this.btnSave);
this.gbxCommands.Controls.Add(this.btnNew);
this.gbxCommands.Controls.Add(this.btnCancel);
this.gbxCommands.Controls.Add(this.btnDelete);
this.gbxCommands.Location = new System.Drawing.Point(1, 307);
this.gbxCommands.Name = "gbxCommands";
this.gbxCommands.Size = new System.Drawing.Size(525, 49);
this.gbxCommands.TabIndex = 10;
this.gbxCommands.TabStop = false;
// 
// btnSearch
// 
this.btnSearch.Cursor = System.Windows.Forms.Cursors.Default;
this.btnSearch.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnSearch.Location = new System.Drawing.Point(183, 12);
this.btnSearch.Name = "btnSearch";
this.btnSearch.Size = new System.Drawing.Size(66, 31);
this.btnSearch.TabIndex = 10;
this.btnSearch.Text = "Searc&h";
this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
// 
// grdAmenities
// 
this.grdAmenities.AllowUserResizing = C1.Win.C1FlexGrid.Classic.AllowUserResizeSettings.flexResizeColumns;
this.grdAmenities.BackColorSel = System.Drawing.SystemColors.Info;
this.grdAmenities.Cols = 2;
this.grdAmenities.ColumnInfo = "2,0,0,0,0,85,Columns:0{Width:56;Caption:\"ID\";TextAlign:LeftCenter;TextAlignFixed:" +
    "CenterCenter;}\t1{Width:133;Caption:\"Name\";TextAlign:LeftCenter;TextAlignFixed:Ce" +
    "nterCenter;}\t";
this.grdAmenities.ExtendLastCol = true;
this.grdAmenities.FixedCols = 0;
this.grdAmenities.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
this.grdAmenities.Font = new System.Drawing.Font("Arial", 8.25F);
this.grdAmenities.ForeColorSel = System.Drawing.Color.Black;
this.grdAmenities.GridColorFixed = System.Drawing.SystemColors.ControlDark;
this.grdAmenities.Location = new System.Drawing.Point(1, 3);
this.grdAmenities.Name = "grdAmenities";
this.grdAmenities.NodeClosedPicture = null;
this.grdAmenities.NodeOpenPicture = null;
this.grdAmenities.OutlineCol = -1;
this.grdAmenities.SelectionMode = C1.Win.C1FlexGrid.Classic.SelModeSettings.flexSelectionByRow;
this.grdAmenities.Size = new System.Drawing.Size(214, 308);
this.grdAmenities.StyleInfo = resources.GetString("grdAmenities.StyleInfo");
this.grdAmenities.TabIndex = 188;
this.grdAmenities.TreeColor = System.Drawing.Color.DarkGray;
this.grdAmenities.Click += new System.EventHandler(this.grdAmenities_Click);
this.grdAmenities.RowColChange += new System.EventHandler(this.grdAmenities_RowColChange);
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
// btnClose
// 
this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.btnClose.Location = new System.Drawing.Point(455, 12);
this.btnClose.Name = "btnClose";
this.btnClose.Size = new System.Drawing.Size(66, 31);
this.btnClose.TabIndex = 190;
this.btnClose.Text = "Cl&ose";
this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
// 
// RoomAmenityUI
// 
this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
this.CancelButton = this.btnClose;
this.ClientSize = new System.Drawing.Size(530, 359);
this.Controls.Add(this.pnlSearch);
this.Controls.Add(this.GroupBox1);
this.Controls.Add(this.grdAmenities);
this.Controls.Add(this.gbxCommands);
this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
this.Name = "RoomAmenityUI";
this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
this.Text = "Amenity";
this.Closing += new System.ComponentModel.CancelEventHandler(this.RoomAmenityUI_Closing);
this.TextChanged += new System.EventHandler(this.RoomAmenityUI_TextChanged);
this.Load += new System.EventHandler(this.AmenityUI_Load);
this.GroupBox1.ResumeLayout(false);
this.GroupBox1.PerformLayout();
this.gbxCommands.ResumeLayout(false);
((System.ComponentModel.ISupportInitialize)(this.grdAmenities)).EndInit();
this.pnlSearch.ResumeLayout(false);
this.pnlSearch.PerformLayout();
this.ResumeLayout(false);

		}
		
		#endregion

        /// <summary>
        /// Local Variables are Camel Casing ( ex. camelCasing )
        /// Variables prefixed by "o" is an Object Instance ( ex. oAmenity )
        /// </summary>
        #region " VARIABLES "

        enum OperationMode { ADD, EDIT };
        private OperationMode mOperationMode;
        
        private DatasetBinder oDataSetBinder;
        private ControlListener oControlListener;

        private Amenity oAmenity;
        private AmenityFacade oAmenityFacade;
		
        #endregion

        #region " CONSTRUCTORS "

        public RoomAmenityUI()
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
                oAmenityFacade = new AmenityFacade();
                oAmenity = new Amenity();
                oAmenity = (Amenity)oAmenityFacade.loadObject();
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
                oAmenityFacade = new AmenityFacade();
                rowsAdded = oAmenityFacade.insertObject(ref oAmenity);
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
                oAmenityFacade = new AmenityFacade();
                rowsAffected = oAmenityFacade.updateObject(ref oAmenity);
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
                oAmenityFacade = new AmenityFacade();
                assignEntityValues();
                rowsAffected = oAmenityFacade.deleteObject(ref oAmenity);
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
                    if (MessageBox.Show("Save changes made to Amenity '" + this.txtAmenityID.Text + "'", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        assignEntityValues();
                        update();
                    }
                    else
                    {
                        this.BindingContext[oAmenity.Tables[0]].CancelCurrentEdit();
                        this.Text = "Amenities";
                    }
                }


				oControlListener.StopListen(this);
				
				this.BindingContext[oAmenity.Tables[0]].Position = findItemInDataset(this.grdAmenities.get_TextMatrix(this.grdAmenities.Row, 0));

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
			oAmenity.AmenityId = this.txtAmenityID.Text;
			oAmenity.Name = this.txtName.Text;
			oAmenity.Description = this.txtDescription.Text;
			oAmenity.HotelID = GlobalVariables.gHotelId;
			oAmenity.CreatedBy = GlobalVariables.gLoggedOnUser;

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


        // Method: searchItem()
        // Description: Search the List of Currency Codes starting 
        // from the Selected Row down
        // if Not Found then start the Search again from the top..
        private void searchItem()
        {
            bool isFound = false;

            if (!this.txtSearch.Text.Equals(""))
            {
                int i = 0;
                for (i = this.grdAmenities.Row + 1; i <= this.grdAmenities.Rows - 1; i++)
                {
                    if (this.grdAmenities.get_TextMatrix(i, 0).ToUpper().Contains(this.txtSearch.Text.ToUpper())
                            ||
                            this.grdAmenities.get_TextMatrix(i, 1).ToUpper().Contains(this.txtSearch.Text.ToUpper()))
                    {

                        this.grdAmenities.Row = i;
                        isFound = true;
                        return;
                    }
                }

                if (!isFound)
                {
                    for (i = 1; i <= this.grdAmenities.Rows - 1; i++)
                    {
                        if ( this.grdAmenities.get_TextMatrix(i, 0).ToUpper().Contains( this.txtSearch.Text.ToUpper() )
                            ||
                            this.grdAmenities.get_TextMatrix(i, 1).ToUpper().Contains( this.txtSearch.Text.ToUpper()) )
                        {

                            this.grdAmenities.Row = i;
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
            int i;

            i = 0;
            foreach (DataRow drGuest in oAmenity.Tables[0].Rows)
            {
                if (drGuest["AmenityId"].ToString() == key)
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

        /*********************************************************
           * Purpose: Check if control has a valid value
           *********************************************************/
        private bool isRequiredEntriesFilled()
        {
            if (this.txtAmenityID.Text.Trim().Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /*********************************************************
            * Purpose: Populate record to Grid Control
            *********************************************************/
        public bool populateDataGrid( DataTable a_Amenity )
        {
            int i = 0;
            try
            {
                this.grdAmenities.Rows = 1;

                foreach (DataRow dRow in a_Amenity.Rows)
                {
                    i = this.grdAmenities.Rows;
                    this.grdAmenities.Rows++;

                    this.grdAmenities.set_TextMatrix(i, 0, dRow["AmenityId"].ToString());
                    this.grdAmenities.set_TextMatrix(i, 1, dRow["Name"].ToString());
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Populating Data Grid.");
                return false;
            }
        }


		#endregion
		
		#region " EVENTS "

        private void AmenityUI_Load(object sender, System.EventArgs e)
        {
            if (load() == true)
            {
                if (!oAmenity.Equals(null))
                {
                    object obj = (object)oAmenity;
                    oDataSetBinder.BindControls(this, ref obj, new ArrayList());

                    populateDataGrid(oAmenity.Tables[0]);
                }

                this.txtAmenityID.Enabled = false;
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
            this.BindingContext[oAmenity.Tables[0]].SuspendBinding();

            // Set action button states
            setActionButtonStates(false);

            // Enable Currency code textbox
            this.txtAmenityID.Enabled = true;

            // Set focus to Currency code textbox
            this.txtAmenityID.Focus();
        }

        private void RoomAmenityUI_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (hasChanges())
            {
                if (MessageBox.Show("Save changes made to Amenity '" + this.txtAmenityID.Text + "'", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    assignEntityValues();
                    update();
                }
                else
                {
                    this.BindingContext[oAmenity.Tables[0]].CancelCurrentEdit();
                    this.Text = "Amenities";
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
                            MessageBox.Show("Item successfully added.", "Amenities", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.grdAmenities.Rows++;
                            this.grdAmenities.set_TextMatrix(this.grdAmenities.Rows - 1, 0, oAmenity.AmenityId);
                            this.grdAmenities.set_TextMatrix(this.grdAmenities.Rows - 1, 1, oAmenity.Name);

                            // >> Resume Binding
                            this.BindingContext[oAmenity.Tables[0]].ResumeBinding();
                            this.Text = "Amenities";

                            //mode = "";
                            this.txtAmenityID.Enabled = false;

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
                            MessageBox.Show("Item successfully updated.", "Amenities", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.grdAmenities.set_TextMatrix(this.grdAmenities.Row, 1, oAmenity.Name);

                            this.BindingContext[oAmenity.Tables[0]].ResumeBinding();
                            this.Text = "Amenities";
                            this.txtAmenityID.Enabled = false;
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
                MessageBox.Show("Please input Amenities code!", "Save Error");
                this.txtAmenityID.Focus();
                return;
            }
        }

        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            if (mOperationMode.Equals(OperationMode.ADD))
            {
                if (this.grdAmenities.Rows > 1)
                {
                    this.grdAmenities.Row = 1;
                }
            }
            else
            {
                this.BindingContext[oAmenity.Tables[0]].CancelCurrentEdit();
            }

            this.BindingContext[oAmenity.Tables[0]].ResumeBinding();

            this.Text = "Amenities";
            this.txtAmenityID.Enabled = false;

            setActionButtonStates(true);
            oControlListener.Listen(this);
        }

        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            this.oControlListener.StopListen(this);
            if (MessageBox.Show("Are you certain you want to remove Amenity '" + this.grdAmenities.get_TextMatrix(this.grdAmenities.Row, 0) + "'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (delete() > 0)
                {
                    this.grdAmenities.RemoveItem(this.grdAmenities.Row);
                }
                else
                {
                    MessageBox.Show("No rows deleted", "Database Update Error");
                }
            }
            this.oControlListener.Listen(this);
        }

        private void RoomAmenityUI_TextChanged(object sender, System.EventArgs e)
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

        private void grdAmenities_Click(System.Object sender, System.EventArgs e)
        {
            bindRowToControls();
        }

        private void grdAmenities_RowColChange(object sender, System.EventArgs e)
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

        private void btnSearch_Click(System.Object sender, System.EventArgs e)
        {
            this.pnlSearch.Visible = true;
            this.txtSearch.Focus();
            this.txtSearch.SelectAll();
        }

        private void Close_Click(System.Object sender, System.EventArgs e)
        {
            this.pnlSearch.Visible = false;
        }

        private void txtSearch_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                searchItem();

            }
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

	}
}