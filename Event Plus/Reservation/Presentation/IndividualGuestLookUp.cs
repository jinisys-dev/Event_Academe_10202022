
using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;


using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Accounts.Presentation;
using Jinisys.Hotel.Accounts.BusinessLayer;
using Jinisys.Hotel.Accounts.DataAccessLayer;
using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.Reservation.DataAccessLayer;
using System.Collections.Generic;

namespace Jinisys.Hotel.Reservation.Presentation
{
    public class IndividualGuestLookUP : System.Windows.Forms.Form
    {


        #region " Windows Form Designer generated lCode "

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
        //Do not modify it using the lCode editor.
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ComboBox cboCriteria;
        internal System.Windows.Forms.TextBox txtSearch;
        internal System.Windows.Forms.Button btnSelect;
		internal System.Windows.Forms.Button btnClose;
		internal System.Windows.Forms.Button btnSearch;
		private C1.Win.C1FlexGrid.C1FlexGrid grdBrowseGuest;
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IndividualGuestLookUP));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cboCriteria = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grdBrowseGuest = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBrowseGuest)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.btnSearch);
            this.GroupBox1.Controls.Add(this.txtSearch);
            this.GroupBox1.Controls.Add(this.cboCriteria);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Location = new System.Drawing.Point(8, 1);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(689, 68);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(609, 31);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(32, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "OK";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.Location = new System.Drawing.Point(131, 32);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(471, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // cboCriteria
            // 
            this.cboCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCriteria.Items.AddRange(new object[] {
            "LASTNAME",
            "FIRSTNAME",
            "MIDDLE NAME",
            "TITLE",
            "ACCOUNT ID",
            "ACCOUNT NAME",
            "CITIZENSHIP"});
            this.cboCriteria.Location = new System.Drawing.Point(12, 31);
            this.cboCriteria.Name = "cboCriteria";
            this.cboCriteria.Size = new System.Drawing.Size(114, 22);
            this.cboCriteria.TabIndex = 0;
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(11, 15);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(100, 20);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Search Criteria";
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(128, 16);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(329, 23);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "Type word(s) that would match to criteria being searched";
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.Location = new System.Drawing.Point(561, 453);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(66, 31);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "&Select";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(631, 453);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 31);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Cl&ose";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grdBrowseGuest
            // 
            this.grdBrowseGuest.AllowEditing = false;
            this.grdBrowseGuest.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor;
            this.grdBrowseGuest.ColumnInfo = resources.GetString("grdBrowseGuest.ColumnInfo");
            this.grdBrowseGuest.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
            this.grdBrowseGuest.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus;
            this.grdBrowseGuest.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdBrowseGuest.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveDown;
            this.grdBrowseGuest.Location = new System.Drawing.Point(8, 75);
            this.grdBrowseGuest.Name = "grdBrowseGuest";
            this.grdBrowseGuest.Rows.DefaultSize = 17;
            this.grdBrowseGuest.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
            this.grdBrowseGuest.Size = new System.Drawing.Size(689, 368);
            this.grdBrowseGuest.StyleInfo = resources.GetString("grdBrowseGuest.StyleInfo");
            this.grdBrowseGuest.TabIndex = 4;
            this.grdBrowseGuest.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdBrowseGuest_KeyPress);
            this.grdBrowseGuest.Click += new System.EventHandler(this.grdBrowseGuest_RowColChange);
            this.grdBrowseGuest.DoubleClick += new System.EventHandler(this.grdBrowseGuest_DoubleClick);
            this.grdBrowseGuest.RowColChange += new System.EventHandler(this.grdBrowseGuest_RowColChange);
            // 
            // IndividualGuestLookUP
            // 
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(706, 494);
            this.Controls.Add(this.grdBrowseGuest);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.GroupBox1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IndividualGuestLookUP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lists of Registered Guests";
            this.Load += new System.EventHandler(this.IndividualGuestLookUP_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBrowseGuest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region " VARIABLES "

        private GuestFacade loGuestFacade = new GuestFacade();
        //private GenericList<Guest> loGuestList = new GenericList<Guest>();
        private DataTable loGuestList = new DataTable();

        //private FormToObjectInstanceBinder oFormtoObjectInstance = new FormToObjectInstanceBinder();
        //private DataReaderBinder oDataReaderBinder = new DataReaderBinder();
        //private Guest oGuest = new Guest();
        //private string guestID;

        //private TextBox mFname;
        //private TextBox mLnam;
        //private TextBox mMI;
        //private TextBox txtAccntid;
        private ListviewHelper listviewhelper = new ListviewHelper();

        #endregion

        #region " CONSTRUCTORS "

        public IndividualGuestLookUP()
        {
            InitializeComponent();
           
			loGuestFacade = new GuestFacade();
            //loGuestList = loGuestFacade.getGuestList();
			loGuestList = loGuestFacade.getGuestAccounts();
        }

		//string mode = "";
		//public IndividualGuestLookUP(TextBox txtcode,string inquiry)
		//{
		//    InitializeComponent();
		//    loGuestFacade = new GuestFacade();
		//    loadGuestData(loGuestFacade.getGuestList());
		//    txtAccntid = txtcode;
		//    mode = "inquiry";
		//}
		//public IndividualGuestLookUP(Guest sguest)
		//{
		//    InitializeComponent();
		//    loGuestFacade = new GuestFacade();
		//    pGuest = sguest;
		//    loadGuests();
		//}

        //================================================================================
        //Newest constructor
        //================================================================================
		//public IndividualGuestLookUP()
		//{
		//    InitializeComponent();

		//    loGuestFacade = new GuestFacade();
		//    loadGuestData(loGuestFacade.getGuestList());
		//    //loFormToObjectInstance.LoadDataToListview(GuestFacade.FilterGuestRecordRefName(fname, lname).Tables("Guest"), lvwLookUp)
		//    //listviewhelper.formatColumnListviewWidth("185|185|120|95|35|65", lvwLookUp)
		//}

        #endregion

        #region " METHODS "

		private void loadGuestList()
		{

            //this.grdBrowseGuest.Rows.Count = loGuestList.Count + 1;
            this.grdBrowseGuest.Rows.Count = loGuestList.Rows.Count + 1;
			int i = 1;


            //foreach (Guest _oGuest in loGuestList)
            //{
            //    this.grdBrowseGuest.SetData(i, 0, _oGuest.LastName);
            //    this.grdBrowseGuest.SetData(i, 1, _oGuest.FirstName);
            //    this.grdBrowseGuest.SetData(i, 2, _oGuest.MiddleName);
            //    this.grdBrowseGuest.SetData(i, 3, _oGuest.Title);
            //    this.grdBrowseGuest.SetData(i, 4, _oGuest.AccountId);
            //    this.grdBrowseGuest.SetData(i, 5, _oGuest.AccountName);
            //    this.grdBrowseGuest.SetData(i, 6, _oGuest.Citizenship);

            //    i++;
            //}

            foreach (DataRow _oGuest in loGuestList.Rows)
            {
                this.grdBrowseGuest.SetData(i, 0, _oGuest["lastname"].ToString());
                this.grdBrowseGuest.SetData(i, 1, _oGuest["firstname"].ToString());
                this.grdBrowseGuest.SetData(i, 2, _oGuest["middlename"].ToString());
                this.grdBrowseGuest.SetData(i, 3, _oGuest["title"].ToString());
                this.grdBrowseGuest.SetData(i, 4, _oGuest["accountid"].ToString());
                this.grdBrowseGuest.SetData(i, 5, _oGuest["accountname"].ToString());
                this.grdBrowseGuest.SetData(i, 6, _oGuest["citizenship"].ToString());

                i++;
            }
		}

       
        #endregion

        #region " EVENTS "

        private void btnClose_Click(System.Object sender, System.EventArgs e)
        {
            lAccountId = "";
            this.Close();
        }

        private void lvwLookUp_DoubleClick(System.Object sender, System.EventArgs e)
        {
			this.Close();
			//if (txtAccntid != null)
			//{
			//    if (mode == "inquiry")
			//    {
			//        txtAccntid.Text = this.lvwLookUP.SelectedItems[0].SubItems[0].Text + ", " + this.lvwLookUP.SelectedItems[0].SubItems[1].Text; ;
			//        txtAccntid.Tag = this.lvwLookUP.SelectedItems[0].SubItems[4].Text;
			//    }
			//    else
			//    {
			//        txtAccntid.Text = this.lvwLookUP.SelectedItems[0].SubItems[4].Text;
			//    }
			//}
			//this.Hide();
        }

		//private void lvwLookUp_Click(System.Object sender, System.EventArgs e)
		//{
		//    guestID = lvwLookUP.SelectedItems[0].SubItems[4].Text;
		//}

        private void btnSearch_Click(System.Object sender, System.EventArgs e)
        {

            int col = this.cboCriteria.SelectedIndex;
            int row = this.grdBrowseGuest.Row;

            //lvwLookUP.Focus();
            //unselectListviewItems();
			//for (int i = 0; i < this.grdBrowseGuest.Rows.Count; i++)
			//{
			//    if ( lvwLookUP.Items[i].SubItems[col].Text.ToUpper().Contains( txtSearch.Text.ToUpper() ))
			//    {

			//        //lvwLookUP.Items[i].Selected = true;
			//        //lvwLookUP.Items[i].EnsureVisible();
			//        //Exit Sub
			//    }
			//}
            if (row > -1)
            {
                for (int i = row + 1; i < this.grdBrowseGuest.Rows.Count; i++)
                {
                    if (this.grdBrowseGuest.GetDataDisplay(i, col).StartsWith(txtSearch.Text.ToUpper()))
                    {
                        //this.grdBrowseGuest.Row = i;
                        this.grdBrowseGuest.Focus();
                        this.grdBrowseGuest.Select(i, col);
                        break;
                    }
                }
            }
            this.txtSearch.Focus();

        }

        private void txtSearch_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
				btnSearch_Click(sender, new EventArgs());
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
			this.Close();
        }

        private void IndividualGuestLookUP_Load(object sender, System.EventArgs e)
        {
			loadGuestList();

            this.cboCriteria.SelectedIndex = 0;

			//try
			//{
			//    this.lvwLookUP.Items[0].Selected = true;
			//}
			//catch { }
        }

        string lAccountId = "";
		public string showDialog()
		{
			base.ShowDialog();

			return lAccountName[1];
		}

        public string showDialogID()
        {
            base.ShowDialog();

            return lAccountName[0];
        }

        public string[] lAccountName = new string[2];
        public string[] showGuests()
        {
            base.ShowDialog();
            return lAccountName;
        }

        #endregion


		private void grdBrowseGuest_RowColChange(object sender, EventArgs e)
		{
            try
            {
                lAccountId = this.grdBrowseGuest.GetDataDisplay(this.grdBrowseGuest.Row, 4);

                lAccountName[0] = this.grdBrowseGuest.GetDataDisplay(this.grdBrowseGuest.Row, 4);
                lAccountName[1] = this.grdBrowseGuest.GetDataDisplay(this.grdBrowseGuest.Row, 0) + ", " + this.grdBrowseGuest.GetDataDisplay(this.grdBrowseGuest.Row, 1);
            }
            catch { }
		}

        public string getAccountID()
        {
            return lAccountId;
        }

		private void grdBrowseGuest_DoubleClick(object sender, EventArgs e)
		{
			this.Close();
		}

        private void grdBrowseGuest_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                int col = cboCriteria.SelectedIndex;
                int row = grdBrowseGuest.Row;

                for (int i = row; i < this.grdBrowseGuest.Rows.Count; i++)
                {
                    if (this.grdBrowseGuest.GetDataDisplay(i, col).Contains(txtSearch.Text.ToUpper()))
                    {
                        //this.grdBrowseGuest.Row = i;
                        this.grdBrowseGuest.Focus();
                        this.grdBrowseGuest.Select(i, col);
                    }
                }
            }
        }

    }
}