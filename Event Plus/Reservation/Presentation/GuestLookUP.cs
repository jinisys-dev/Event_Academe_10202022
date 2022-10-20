
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


//using Microsoft.VisualBasic.CompilerServices;
//using MySql.Data.MySqlClient;
//using Microsoft.VisualBasic;

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
        internal System.Windows.Forms.ListView lvwLookUP;
        internal System.Windows.Forms.Button btnSearch;
        internal System.Windows.Forms.ColumnHeader ColumnHeader1;
        internal System.Windows.Forms.ColumnHeader ColumnHeader2;
        internal System.Windows.Forms.ColumnHeader ColumnHeader3;
        internal System.Windows.Forms.ColumnHeader ColumnHeader4;
        internal System.Windows.Forms.ColumnHeader ColumnHeader5;
        internal System.Windows.Forms.ColumnHeader ColumnHeader6;
        internal System.Windows.Forms.ColumnHeader ColumnHeader7;
        internal System.Windows.Forms.ColumnHeader ColumnHeader8;
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cboCriteria = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.lvwLookUP = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.btnSearch);
            this.GroupBox1.Controls.Add(this.txtSearch);
            this.GroupBox1.Controls.Add(this.cboCriteria);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Location = new System.Drawing.Point(4, -1);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(678, 68);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(483, 31);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(30, 21);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "OK";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.Location = new System.Drawing.Point(131, 32);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(348, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // cboCriteria
            // 
            this.cboCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCriteria.Items.AddRange(new object[] {
            "LASTNAME",
            "ACCOUNTNAME",
            "FIRSTNAME"});
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
            // lvwLookUP
            // 
            this.lvwLookUP.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2,
            this.ColumnHeader3,
            this.ColumnHeader4,
            this.ColumnHeader5,
            this.ColumnHeader6,
            this.ColumnHeader7,
            this.ColumnHeader8});
            this.lvwLookUP.FullRowSelect = true;
            this.lvwLookUP.GridLines = true;
            this.lvwLookUP.Location = new System.Drawing.Point(4, 71);
            this.lvwLookUP.Name = "lvwLookUP";
            this.lvwLookUP.Size = new System.Drawing.Size(679, 292);
            this.lvwLookUP.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwLookUP.TabIndex = 1;
            this.lvwLookUP.UseCompatibleStateImageBehavior = false;
            this.lvwLookUP.View = System.Windows.Forms.View.Details;
            this.lvwLookUP.DoubleClick += new System.EventHandler(this.lvwLookUp_DoubleClick);
            this.lvwLookUP.Click += new System.EventHandler(this.lvwLookUp_Click);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Last Name";
            this.ColumnHeader1.Width = 133;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "First Name";
            this.ColumnHeader2.Width = 190;
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "Middle Name";
            this.ColumnHeader3.Width = 141;
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "Title";
            this.ColumnHeader4.Width = 67;
            // 
            // ColumnHeader5
            // 
            this.ColumnHeader5.Text = "ID";
            // 
            // ColumnHeader6
            // 
            this.ColumnHeader6.Text = "Account Name";
            this.ColumnHeader6.Width = 84;
            // 
            // ColumnHeader7
            // 
            this.ColumnHeader7.Text = "Citizenship";
            // 
            // ColumnHeader8
            // 
            this.ColumnHeader8.Text = "Sex";
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.Location = new System.Drawing.Point(548, 370);
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
            this.btnClose.Location = new System.Drawing.Point(618, 370);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 31);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Cl&ose";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // IndividualGuestLookUP
            // 
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(688, 407);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.lvwLookUP);
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
            this.ResumeLayout(false);

        }

        #endregion

        #region " VARIABLES "

        private GuestFacade GuestFacade = new GuestFacade();
        private Guest pGuest = new Guest();
        private FormToObjectInstanceBinder oFormtoObjectInstance = new FormToObjectInstanceBinder();
        private DataReaderBinder oDataReaderBinder = new DataReaderBinder();
        private Guest oGuest = new Guest();
        private string guestID;

        //private TextBox mFname;
        //private TextBox mLnam;
        //private TextBox mMI;
        private TextBox txtAccntid;
        private ListviewHelper listviewhelper = new ListviewHelper();

        #endregion

        #region " CONSTRUCTORS "

        public IndividualGuestLookUP(TextBox txtcode)
        {
            InitializeComponent();
            GuestFacade = new GuestFacade();
            loadGuestData(GuestFacade.displayListofGuest().Tables["Guests"]);
            txtAccntid = txtcode;

        }
        string mode = "";
        public IndividualGuestLookUP(TextBox txtcode,string inquiry)
        {
            InitializeComponent();
            GuestFacade = new GuestFacade();
            loadGuestData(GuestFacade.displayListofGuest().Tables["Guests"]);
            txtAccntid = txtcode;
            mode = "inquiry";
        }
        public IndividualGuestLookUP(Guest sguest)
        {
            InitializeComponent();
            GuestFacade = new GuestFacade();
            pGuest = sguest;
            loadGuests();
        }

        //================================================================================
        //Newest constructor
        //================================================================================
        public IndividualGuestLookUP()
        {
            InitializeComponent();

            GuestFacade = new GuestFacade();
            loadGuestData(GuestFacade.getGuestList().Tables["Guests"]);
            //loFormToObjectInstance.LoadDataToListview(GuestFacade.FilterGuestRecordRefName(fname, lname).Tables("Guest"), lvwLookUp)
            //listviewhelper.formatColumnListviewWidth("185|185|120|95|35|65", lvwLookUp)
        }

        #endregion

        #region " METHODS "

        private void loadGuests()
        {
            GuestFacade = new GuestFacade();
            loadGuestData(GuestFacade.displayListofGuest().Tables["Guests"]);
        }

        private void loadGuestData(DataTable dt)
                {
                    DataRow dR;
                    // Dim dT As DataTable = GuestFacade.DisplayListofGuest.Tables("Guest")
                    //MsgBox(dT.Rows.Count)
                    foreach (DataRow tempLoopVar_dR in dt.Rows)
                    {
                        dR = tempLoopVar_dR;
                        ListViewItem lvwItem = new ListViewItem(dR["Lastname"].ToString());
                        lvwItem.SubItems.Add(dR["Firstname"].ToString());
                        lvwItem.SubItems.Add(dR["Middlename"].ToString());
                        lvwItem.SubItems.Add(dR["Title"].ToString());
                        lvwItem.SubItems.Add(dR["AccountID"].ToString());
                        lvwItem.SubItems.Add(dR["AccountName"].ToString());
                        lvwItem.SubItems.Add(dR["citizenship"].ToString());
                        lvwItem.SubItems.Add(dR["sex"].ToString());
                        lvwLookUP.Items.Add(lvwItem);
                    }
                }

        private void unselectListviewItems()
        {
            for (int i = 0; i <= lvwLookUP.Items.Count - 1; i++)
            {
                lvwLookUP.Items[i].Selected = false;
            }
        }

        #endregion

        #region " EVENTS "

        private void btnClose_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void lvwLookUp_DoubleClick(System.Object sender, System.EventArgs e)
        {
            if (txtAccntid != null)
            {
                if (mode == "inquiry")
                {
                    txtAccntid.Text = this.lvwLookUP.SelectedItems[0].SubItems[0].Text + ", " + this.lvwLookUP.SelectedItems[0].SubItems[1].Text; ;
                    txtAccntid.Tag = this.lvwLookUP.SelectedItems[0].SubItems[4].Text;
                }
                else
                {
                    txtAccntid.Text = this.lvwLookUP.SelectedItems[0].SubItems[4].Text;
                }
            }
            this.Hide();
        }

        private void lvwLookUp_Click(System.Object sender, System.EventArgs e)
        {
            guestID = lvwLookUP.SelectedItems[0].SubItems[4].Text;
        }

        private void btnSearch_Click(System.Object sender, System.EventArgs e)
        {

            int col;
            if (cboCriteria.Text == "Firstname".ToUpper())
            {
                col = 1;
            }
            else if (cboCriteria.Text == "Lastname".ToUpper())
            {
                col = 0;
            }
            else
            {
                col = 5;
            }


            lvwLookUP.Focus();
            unselectListviewItems();
            for (int i = 0; i <= lvwLookUP.Items.Count - 1; i++)
            {
                if ( lvwLookUP.Items[i].SubItems[col].Text.ToUpper().Contains( txtSearch.Text.ToUpper() ))
                {
                    lvwLookUP.Items[i].Selected = true;
                    lvwLookUP.Items[i].EnsureVisible();
                    //Exit Sub
                }
            }

        }

        private void txtSearch_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            int col;
            if (cboCriteria.Text == "Firstname".ToUpper())
            {
                col = 1;
            }
            else if (cboCriteria.Text == "Lastname".ToUpper())
            {
                col = 0;
            }
            else
            {
                col = 5;
            }

            if (e.KeyChar == '\r')
            {
                lvwLookUP.Focus();
                unselectListviewItems();
                for (int i = 0; i <= lvwLookUP.Items.Count - 1; i++)
                {
                    if ( lvwLookUP.Items[i].SubItems[col].Text.ToUpper().Contains( txtSearch.Text.ToUpper() ) )
                    {
                        lvwLookUP.Items[i].Selected = true;
                        lvwLookUP.Items[i].EnsureVisible();
                        //Exit Sub
                    }
                }
            }
        }

        private void btnSelect_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (txtAccntid != null)
                {
                    if (mode == "inquiry")
                    {
                        txtAccntid.Text = this.lvwLookUP.SelectedItems[0].SubItems[0].Text + ", " + this.lvwLookUP.SelectedItems[0].SubItems[1].Text; ;
                        txtAccntid.Tag = this.lvwLookUP.SelectedItems[0].SubItems[4].Text;
                    }
                    else
                    {
                        txtAccntid.Text = this.lvwLookUP.SelectedItems[0].SubItems[4].Text;
                    }
                }
                this.Hide();
            }
            catch (Exception)
            {

            }
        }

        private void IndividualGuestLookUP_Load(object sender, System.EventArgs e)
        {
            this.cboCriteria.SelectedIndex = 0;
        }

        #endregion
    }
}