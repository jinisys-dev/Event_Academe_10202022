
using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Accounts.BusinessLayer;
using Jinisys.Hotel.Accounts.DataAccessLayer;
using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.Reservation.DataAccessLayer;


namespace Jinisys.Hotel.Reservation.Presentation
{
    public class GroupAccountLookUP : Jinisys.Hotel.UIFramework.LookUPUI
    {

        #region " Windows Form Designer generated lCode "

        public GroupAccountLookUP()
        {

            //This call is required by the Windows Form Designer.
            InitializeComponent();

            //Add any initialization after the InitializeComponent() call

        }

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
        internal System.Windows.Forms.ColumnHeader ColumnHeader1;
        internal System.Windows.Forms.ColumnHeader ColumnHeader2;
        internal System.Windows.Forms.ColumnHeader ColumnHeader3;
        internal System.Windows.Forms.ColumnHeader ColumnHeader4;
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupAccountLookUP));
            this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwLookUp
            // 
            this.lvwLookUp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader4,
            this.ColumnHeader2,
            this.ColumnHeader3});
            this.lvwLookUp.HideSelection = false;
            this.lvwLookUp.Location = new System.Drawing.Point(3, 68);
            this.lvwLookUp.MultiSelect = false;
            this.lvwLookUp.Size = new System.Drawing.Size(519, 281);
            this.lvwLookUp.DoubleClick += new System.EventHandler(this.lvwLookUp_DoubleClick);
            this.lvwLookUp.Click += new System.EventHandler(this.lvwLookUp_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Location = new System.Drawing.Point(2, -3);
            this.GroupBox1.Size = new System.Drawing.Size(523, 68);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(482, 28);
            this.btnSearch.Size = new System.Drawing.Size(30, 21);
            this.btnSearch.Text = "OK";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.Location = new System.Drawing.Point(170, 30);
            this.txtSearch.Size = new System.Drawing.Size(257, 20);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // cboCriteria
            // 
            this.cboCriteria.Size = new System.Drawing.Size(160, 22);
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(159, 12);
            this.Label2.Size = new System.Drawing.Size(294, 16);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(455, 354);
            this.btnClose.Size = new System.Drawing.Size(66, 31);
            this.btnClose.Text = "Cl&ose";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSelect.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.Location = new System.Drawing.Point(386, 354);
            this.btnSelect.Size = new System.Drawing.Size(66, 31);
            this.btnSelect.Text = "&Select";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "ID";
            this.ColumnHeader1.Width = 100;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Company Name";
            this.ColumnHeader2.Width = 120;
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "Address";
            this.ColumnHeader3.Width = 100;
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "Company Code";
            this.ColumnHeader4.Width = 100;
            // 
            // GroupAccountLookUP
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(527, 392);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GroupAccountLookUP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company Account LookUP";
            this.Load += new System.EventHandler(this.GroupAccountLookUP_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        #region " VARIABLES "

        private Company oCompany = new Company();
        private Agent oAgent = new Agent();
        private CompanyFacade oCompanyFacade = new CompanyFacade();
        private AgentFacade oAgentFacade = new AgentFacade();
        private FormToObjectInstanceBinder oFormToObjectInstance = new FormToObjectInstanceBinder();
        private ListviewHelper oListviewHelper = new ListviewHelper();

        private TextBox txtcomName;
        private TextBox txtcomAcode;
        private TextBox txtComID;
        //**added Apr. 28, 2008
        private TextBox txtGstType;
        private TextBox txtThresholdLevel;
        private TextBox txtSales;
        //**
        private string mAccntType;

        #endregion

        #region " MEMBER VARIABLES "

        private static string mAccountType;
        public static string AccountType
        {
            set
            {
                mAccountType = value;
            }
        }

        private static string mFlag;
        public static string Flag
        {
            set
            {
                mFlag = value;
            }
        }

        #endregion

        #region " CONSTRUCTORS "

        public GroupAccountLookUP(TextBox txtcompCode, TextBox txtcompName, TextBox txtCOmpanyID, string AccntType)
        {
            InitializeComponent();
            txtcomAcode = txtcompCode;
            txtcomName = txtcompName;
            txtComID = txtCOmpanyID;
            mAccntType = AccntType;
            LoadGroup();
        }

        //>> by Genny: added Apr. 28, 2008
        public GroupAccountLookUP(TextBox txtcompCode, TextBox txtcompName, TextBox txtCOmpanyID, string AccntType, TextBox txtGuestType, TextBox txtThreshold, TextBox txtTotalSales)
        {
            InitializeComponent();
            txtcomAcode = txtcompCode;
            txtcomName = txtcompName;
            txtComID = txtCOmpanyID;
            mAccntType = AccntType;
            txtGstType = txtGuestType;
            txtThresholdLevel = txtThreshold;
            txtSales = txtTotalSales;
            LoadGroup();
        }
        //<<


        #endregion

        #region " METHODS "

        private void LoadGroup()
        {
			if (mAccntType == "COMPANY" || mAccntType == "Individual")
            {
                oCompanyFacade = new CompanyFacade();
                FormToObjectInstanceBinder.LoadDataToListview(oCompanyFacade.getCompanyAccounts().Tables["Company"], lvwLookUp, "");
            }
            else if (mAccntType == "AGENT")
            {
                oAgentFacade = new AgentFacade();
                FormToObjectInstanceBinder.LoadDataToListview(oAgentFacade.getAgentAccounts().Tables["Agent"], lvwLookUp, "");
            }
        }

        #endregion

        #region " EVENTS "

        private void btnClose_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void GroupAccountLookUP_Load(object sender, System.EventArgs e)
        {
            oListviewHelper.formatColumnListviewWidth((mAccntType == "AGENT" ? "25|265|350|100" : "80|100|200|350"), lvwLookUp);
            if (mAccntType != "AGENT")
            {
                cboCriteria.Items.Add("");
                cboCriteria.Items.Add("COMPANYCODE");
                cboCriteria.Items.Add("COMPANYNAME");
                cboCriteria.Text = "COMPANYNAME";
            }
            else
            {
                //cboCriteria.Items.Add("ACCOUNTID")
                cboCriteria.Items.Add("AGENTNAME");
                cboCriteria.Text = "AGENTNAME";
            }
        }

        private void lvwLookUp_DoubleClick(System.Object sender, System.EventArgs e)
        {
            try
            {
                switch (mFlag)
                {
                    case "GroupReservation":

                        if (mAccntType != "AGENT")
                        {
                            txtComID.Text = lvwLookUp.SelectedItems[0].SubItems[0].Text;
                            txtcomAcode.Text = lvwLookUp.SelectedItems[0].SubItems[1].Text;
                            txtcomName.Text = lvwLookUp.SelectedItems[0].SubItems[2].Text;
                            txtGstType.Text = lvwLookUp.SelectedItems[0].SubItems[6].Text;
                            txtThresholdLevel.Text = lvwLookUp.SelectedItems[0].SubItems[7].Text;
                            txtSales.Text = lvwLookUp.SelectedItems[0].SubItems[8].Text;
                        }
                        else
                        {
                            txtcomAcode.Text = lvwLookUp.SelectedItems[0].SubItems[0].Text;
                            txtcomName.Text = lvwLookUp.SelectedItems[0].SubItems[1].Text;
                            //txtComID.Text = lvwLookUp.SelectedItems(0).SubItems(0).Text
                        }
                        this.Hide();
                        break;
                    case "IndividualReservation":

                        if (mAccntType != "AGENT")
                        {
                            txtcomAcode.Text = lvwLookUp.SelectedItems[0].SubItems[1].Text;
                            txtcomName.Text = lvwLookUp.SelectedItems[0].SubItems[2].Text;
                            txtComID.Text = lvwLookUp.SelectedItems[0].SubItems[0].Text;
                            //ReservationFolioUI.companyid = lvwLookUp.SelectedItems[0].SubItems[1].Text;
                        }
                        else
                        {
                            txtcomAcode.Text = lvwLookUp.SelectedItems[0].SubItems[0].Text;
                            txtcomName.Text = lvwLookUp.SelectedItems[0].SubItems[1].Text;
                            // txtComID.Text = lvwLookUp.SelectedItems(0).SubItems(0).Text
                        }
                        this.Hide();
                        break;
                }
            }
            catch { }
        }

        private void btnSearch_Click(System.Object sender, System.EventArgs e)
        {
            int col;
            if (mAccntType == "AGENT")
            {
                col = 1;
            }
            else
            {
                col = cboCriteria.SelectedIndex;
                //col = cboCriteria.Text.ToUpper() == "COMPANYCODE" ? 1 : 2;
            }

            lvwLookUp.Focus();
            int row = 0;
            try
            {
                row = lvwLookUp.SelectedItems[0].Index;
            }
            catch { }

            for (int i = row + 1; i <= lvwLookUp.Items.Count - 1; i++)
            {
                if ( lvwLookUp.Items[i].SubItems[col].Text.ToUpper().StartsWith( txtSearch.Text.ToUpper() ) )
                {
                    lvwLookUp.Items[i].Selected = true;
                    lvwLookUp.EnsureVisible(i);
                    break;
                }
            }
            txtSearch.Focus();
        }

        private void txtSearch_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            int col;
            if (mAccntType == "AGENT")
            {
                col = 1;
            }
            else
            {
                col = cboCriteria.SelectedIndex;
                //col = cboCriteria.Text == "CompanyCode" ? 1 : 2;
            }

            if (e.KeyChar == '\r')
            {
                lvwLookUp.Focus();
                int row = 0;
                try
                {
                    row = lvwLookUp.SelectedItems[0].Index;
                }
                catch { }

                for (int i = row + 1; i <= lvwLookUp.Items.Count - 1; i++)
                {
                    if (lvwLookUp.Items[i].SubItems[col].Text.ToUpper().StartsWith(txtSearch.Text.ToUpper()))
                    {
                        lvwLookUp.Items[i].Selected = true;
                        lvwLookUp.EnsureVisible(i);
                        break;
                    }
                    else
                    {
                        
                    }
                }
            }

            txtSearch.Focus();
        }

        private void lvwLookUp_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (mAccntType == "AGENT")
                {
                    txtcomAcode.Text = lvwLookUp.SelectedItems[0].SubItems[0].Text;
                    txtcomName.Text = lvwLookUp.SelectedItems[0].SubItems[1].Text;
                }
                else
                {
                    txtcomAcode.Text = lvwLookUp.SelectedItems[0].SubItems[0].Text;
                    txtcomName.Text = lvwLookUp.SelectedItems[0].SubItems[2].Text;
                    txtComID.Text = lvwLookUp.SelectedItems[0].SubItems[0].Text;
                }
            }
            catch { }
        }

        private void btnSelect_Click(System.Object sender, System.EventArgs e)
        {
            lvwLookUp_DoubleClick(sender, new EventArgs());
            this.Hide();
        }

        #endregion
      

    }
}