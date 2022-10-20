using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.UIFramework;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Services.BusinessLayer;

namespace Jinisys.Hotel.Services.Presentation
{
	    public class ServicesLookUpUI : MiscellaneousUI
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
			internal System.Windows.Forms.GroupBox gbxEngineeringService;
			public System.Windows.Forms.TextBox txtEnggServiceId;
			public System.Windows.Forms.TextBox txtServiceName;
			public System.Windows.Forms.TextBox txtDescription;
			public System.Windows.Forms.Label Label3;
			public System.Windows.Forms.Label Label4;
			public System.Windows.Forms.Label Label1;
			internal System.Windows.Forms.ListView lvwLookUp;
			internal System.Windows.Forms.Button btnClose;
			internal System.Windows.Forms.Button btnSelect;
			public System.Windows.Forms.Label Label2;
			public System.Windows.Forms.Label Label5;
			public System.Windows.Forms.Label Label6;
			public System.Windows.Forms.TextBox txtHousekeeperId;
			public System.Windows.Forms.TextBox txtLastName;
			public System.Windows.Forms.TextBox txtFirstName;
			internal System.Windows.Forms.GroupBox gbxHousekeeper;
			internal System.Windows.Forms.ColumnHeader ColumnHeader1;
			internal System.Windows.Forms.ColumnHeader ColumnHeader2;
			internal System.Windows.Forms.ColumnHeader ColumnHeader3;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServicesLookUpUI));
                this.gbxEngineeringService = new System.Windows.Forms.GroupBox();
                this.txtEnggServiceId = new System.Windows.Forms.TextBox();
                this.txtServiceName = new System.Windows.Forms.TextBox();
                this.txtDescription = new System.Windows.Forms.TextBox();
                this.Label3 = new System.Windows.Forms.Label();
                this.Label4 = new System.Windows.Forms.Label();
                this.Label1 = new System.Windows.Forms.Label();
                this.lvwLookUp = new System.Windows.Forms.ListView();
                this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
                this.btnClose = new System.Windows.Forms.Button();
                this.btnSelect = new System.Windows.Forms.Button();
                this.gbxHousekeeper = new System.Windows.Forms.GroupBox();
                this.txtHousekeeperId = new System.Windows.Forms.TextBox();
                this.txtLastName = new System.Windows.Forms.TextBox();
                this.txtFirstName = new System.Windows.Forms.TextBox();
                this.Label2 = new System.Windows.Forms.Label();
                this.Label5 = new System.Windows.Forms.Label();
                this.Label6 = new System.Windows.Forms.Label();
                this.gbxEngineeringService.SuspendLayout();
                this.gbxHousekeeper.SuspendLayout();
                this.SuspendLayout();
                // 
                // gbxEngineeringService
                // 
                this.gbxEngineeringService.Controls.Add(this.txtEnggServiceId);
                this.gbxEngineeringService.Controls.Add(this.txtServiceName);
                this.gbxEngineeringService.Controls.Add(this.txtDescription);
                this.gbxEngineeringService.Controls.Add(this.Label3);
                this.gbxEngineeringService.Controls.Add(this.Label4);
                this.gbxEngineeringService.Controls.Add(this.Label1);
                this.gbxEngineeringService.Location = new System.Drawing.Point(4, -1);
                this.gbxEngineeringService.Name = "gbxEngineeringService";
                this.gbxEngineeringService.Size = new System.Drawing.Size(380, 119);
                this.gbxEngineeringService.TabIndex = 9;
                this.gbxEngineeringService.TabStop = false;
                // 
                // txtEnggServiceId
                // 
                this.txtEnggServiceId.BackColor = System.Drawing.SystemColors.Info;
                this.txtEnggServiceId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtEnggServiceId.Location = new System.Drawing.Point(100, 24);
                this.txtEnggServiceId.Name = "txtEnggServiceId";
                this.txtEnggServiceId.Size = new System.Drawing.Size(99, 20);
                this.txtEnggServiceId.TabIndex = 44;
                // 
                // txtServiceName
                // 
                this.txtServiceName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtServiceName.Location = new System.Drawing.Point(100, 56);
                this.txtServiceName.Name = "txtServiceName";
                this.txtServiceName.Size = new System.Drawing.Size(197, 20);
                this.txtServiceName.TabIndex = 41;
                // 
                // txtDescription
                // 
                this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtDescription.Location = new System.Drawing.Point(100, 80);
                this.txtDescription.Name = "txtDescription";
                this.txtDescription.Size = new System.Drawing.Size(197, 20);
                this.txtDescription.TabIndex = 40;
                // 
                // Label3
                // 
                this.Label3.Location = new System.Drawing.Point(16, 56);
                this.Label3.Name = "Label3";
                this.Label3.Size = new System.Drawing.Size(81, 15);
                this.Label3.TabIndex = 42;
                this.Label3.Text = "Service Name";
                // 
                // Label4
                // 
                this.Label4.Location = new System.Drawing.Point(16, 80);
                this.Label4.Name = "Label4";
                this.Label4.Size = new System.Drawing.Size(73, 14);
                this.Label4.TabIndex = 43;
                this.Label4.Text = "Description";
                // 
                // Label1
                // 
                this.Label1.Location = new System.Drawing.Point(16, 24);
                this.Label1.Name = "Label1";
                this.Label1.Size = new System.Drawing.Size(81, 15);
                this.Label1.TabIndex = 42;
                this.Label1.Text = "Service ID";
                // 
                // lvwLookUp
                // 
                this.lvwLookUp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2,
            this.ColumnHeader3});
                this.lvwLookUp.FullRowSelect = true;
                this.lvwLookUp.Location = new System.Drawing.Point(4, 120);
                this.lvwLookUp.MultiSelect = false;
                this.lvwLookUp.Name = "lvwLookUp";
                this.lvwLookUp.Size = new System.Drawing.Size(380, 296);
                this.lvwLookUp.TabIndex = 10;
                this.lvwLookUp.UseCompatibleStateImageBehavior = false;
                this.lvwLookUp.View = System.Windows.Forms.View.Details;
                this.lvwLookUp.DoubleClick += new System.EventHandler(this.lvwLookUp_DoubleClick);
                this.lvwLookUp.Click += new System.EventHandler(this.lvwLookUp_Click);
                // 
                // ColumnHeader1
                // 
                this.ColumnHeader1.Text = "ID";
                this.ColumnHeader1.Width = 64;
                // 
                // ColumnHeader2
                // 
                this.ColumnHeader2.Text = "First Name";
                this.ColumnHeader2.Width = 135;
                // 
                // ColumnHeader3
                // 
                this.ColumnHeader3.Text = "Last Name";
                this.ColumnHeader3.Width = 159;
                // 
                // btnClose
                // 
                this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnClose.Location = new System.Drawing.Point(312, 424);
                this.btnClose.Name = "btnClose";
                this.btnClose.Size = new System.Drawing.Size(66, 31);
                this.btnClose.TabIndex = 11;
                this.btnClose.Text = "&Close";
                this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
                // 
                // btnSelect
                // 
                this.btnSelect.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnSelect.Location = new System.Drawing.Point(238, 424);
                this.btnSelect.Name = "btnSelect";
                this.btnSelect.Size = new System.Drawing.Size(66, 31);
                this.btnSelect.TabIndex = 12;
                this.btnSelect.Text = "&Select";
                this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
                // 
                // gbxHousekeeper
                // 
                this.gbxHousekeeper.Controls.Add(this.txtHousekeeperId);
                this.gbxHousekeeper.Controls.Add(this.txtLastName);
                this.gbxHousekeeper.Controls.Add(this.txtFirstName);
                this.gbxHousekeeper.Controls.Add(this.Label2);
                this.gbxHousekeeper.Controls.Add(this.Label5);
                this.gbxHousekeeper.Controls.Add(this.Label6);
                this.gbxHousekeeper.Location = new System.Drawing.Point(4, -1);
                this.gbxHousekeeper.Name = "gbxHousekeeper";
                this.gbxHousekeeper.Size = new System.Drawing.Size(380, 121);
                this.gbxHousekeeper.TabIndex = 13;
                this.gbxHousekeeper.TabStop = false;
                // 
                // txtHousekeeperId
                // 
                this.txtHousekeeperId.BackColor = System.Drawing.SystemColors.Info;
                this.txtHousekeeperId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtHousekeeperId.Location = new System.Drawing.Point(95, 22);
                this.txtHousekeeperId.Name = "txtHousekeeperId";
                this.txtHousekeeperId.Size = new System.Drawing.Size(99, 20);
                this.txtHousekeeperId.TabIndex = 44;
                // 
                // txtLastName
                // 
                this.txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtLastName.Location = new System.Drawing.Point(95, 46);
                this.txtLastName.Name = "txtLastName";
                this.txtLastName.Size = new System.Drawing.Size(197, 20);
                this.txtLastName.TabIndex = 41;
                // 
                // txtFirstName
                // 
                this.txtFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtFirstName.Location = new System.Drawing.Point(95, 70);
                this.txtFirstName.Name = "txtFirstName";
                this.txtFirstName.Size = new System.Drawing.Size(197, 20);
                this.txtFirstName.TabIndex = 40;
                // 
                // Label2
                // 
                this.Label2.Location = new System.Drawing.Point(15, 46);
                this.Label2.Name = "Label2";
                this.Label2.Size = new System.Drawing.Size(81, 15);
                this.Label2.TabIndex = 42;
                this.Label2.Text = "Last Name";
                // 
                // Label5
                // 
                this.Label5.Location = new System.Drawing.Point(15, 70);
                this.Label5.Name = "Label5";
                this.Label5.Size = new System.Drawing.Size(73, 14);
                this.Label5.TabIndex = 43;
                this.Label5.Text = "First Name";
                // 
                // Label6
                // 
                this.Label6.Location = new System.Drawing.Point(15, 22);
                this.Label6.Name = "Label6";
                this.Label6.Size = new System.Drawing.Size(81, 15);
                this.Label6.TabIndex = 42;
                this.Label6.Text = "ID";
                // 
                // ServicesLookUpUI
                // 
                this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
                this.CancelButton = this.btnClose;
                this.ClientSize = new System.Drawing.Size(387, 462);
                this.Controls.Add(this.gbxHousekeeper);
                this.Controls.Add(this.btnSelect);
                this.Controls.Add(this.btnClose);
                this.Controls.Add(this.lvwLookUp);
                this.Controls.Add(this.gbxEngineeringService);
                this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.Name = "ServicesLookUpUI";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "Housekeepers";
                this.Load += new System.EventHandler(this.ServicesLookUPUI_Load);
                this.gbxEngineeringService.ResumeLayout(false);
                this.gbxEngineeringService.PerformLayout();
                this.gbxHousekeeper.ResumeLayout(false);
                this.gbxHousekeeper.PerformLayout();
                this.ResumeLayout(false);

			}
			
			#endregion

            #region Variables and Constants

            private string ServiceNeeded;

            private DatasetBinder oDatasetBinder ;
            private HouseKeeper oHouseKeeper ;
            private HouseKeeperFacade oHousekeeperFacade ;
            private EngineeringService oEngineeringService ;
            private EngineeringServiceFacade oEngineeringServiceFacade ;

            private TextBox mServiceId;
            private TextBox mServiceName ;
            private TextBox mHousekeeperId;
            private TextBox mFirstName;
            private TextBox mLastName;

            #endregion

            #region Constructors

                public ServicesLookUpUI()
                {
                    initializeObjectMember();
                    InitializeComponent();
                }

                public ServicesLookUpUI(TextBox ServiceId, TextBox ServiceName)
                {
                    initializeObjectMember();

                    InitializeComponent();
                    mServiceId = ServiceId;
                    mServiceName = ServiceName;
                    ServiceNeeded = "Engineering Services";
                    this.Text = "Engineering Services";
                }

                public ServicesLookUpUI(TextBox HousekeeperId, TextBox FirstName, TextBox LastName)
                {
                    initializeObjectMember();
                    InitializeComponent();

                    mHousekeeperId = HousekeeperId;
                    mFirstName = FirstName;
                    mLastName = LastName;

                    ServiceNeeded = "Housekeepers";
                    this.Text = "Housekeepers";
                }

            #endregion

            #region Methods

            private void initializeObjectMember()
            {
                oDatasetBinder = new DatasetBinder();
                oHouseKeeper = new HouseKeeper();
                oHousekeeperFacade = new HouseKeeperFacade();
                oEngineeringService = new EngineeringService();
                oEngineeringServiceFacade = new EngineeringServiceFacade();
            }

            // >> Hides LookUp UI
            private void closeEngineeringServicesLookUpUI()
            {
                this.Close();
            }

            // >> Loads All Available Engineering Services
            private void loadEngineeringServices()
            {
                try
                {
                    oEngineeringService = new EngineeringService();
                    oEngineeringServiceFacade = new EngineeringServiceFacade();

                    oEngineeringService = oEngineeringServiceFacade.getEngineeringServices();

                    loadToListView(oEngineeringService.Tables["EngineeringServices"]);

                    this.gbxEngineeringService.Visible = true;
                    this.gbxHousekeeper.Visible = false;
                    object temp_object = oEngineeringService;
                    oDatasetBinder.BindControls(this, ref temp_object, new ArrayList());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot Load Engineering Services @loadEngineeringServices()" + ex.Message);
                }
            }

            private void loadHousekeepers()
            {
                try
                {
                    oHouseKeeper = new HouseKeeper();
                    oHousekeeperFacade = new HouseKeeperFacade();

                    oHouseKeeper = oHousekeeperFacade.getHouseKeeper();

                    loadToListView(oHouseKeeper.Tables["Housekeepers"]);

                    this.gbxEngineeringService.Visible = false;
                    this.gbxHousekeeper.Visible = true;
                    object temp_object = oHouseKeeper;
                    oDatasetBinder.BindControls(this, ref temp_object, new ArrayList());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot Load HouseKeepers@loadHousekeepers()" + ex.Message);
                }
            }
               
            // >> Passes Lookup data to engineering jobs

            private void passLookUpData()
            {
                switch (ServiceNeeded.ToUpper())
                {
                    case "ENGINEERING SERVICES":

                        mServiceId.Text = this.lvwLookUp.SelectedItems[0].Text;
                        mServiceName.Text = this.lvwLookUp.SelectedItems[0].SubItems[1].Text;
                        break;
                    case "HOUSEKEEPERS":

                        mHousekeeperId.Text = this.lvwLookUp.SelectedItems[0].Text;
                        mLastName.Text = this.lvwLookUp.SelectedItems[0].SubItems[1].Text;
                        mFirstName.Text = this.lvwLookUp.SelectedItems[0].SubItems[2].Text;
                        break;
                }

                this.Close();
            }

            private void loadToListView(DataTable a_dt)
            {
                switch (ServiceNeeded.ToUpper())
                {
                    case "HOUSEKEEPERS":

                       
                        this.lvwLookUp.Columns[0].Text = "ID";
                        this.lvwLookUp.Columns[1].Text = "First Name";
                        this.lvwLookUp.Columns[2].Text = "Last Name";

                        for (int i = 0; i <= a_dt.Rows.Count - 1; i++)
                        {
                            ListViewItem lst = new ListViewItem(a_dt.Rows[i]["HousekeeperId"].ToString());
                            lst.SubItems.Add(a_dt.Rows[i]["FirstName"].ToString());
                            lst.SubItems.Add(a_dt.Rows[i]["LastName"].ToString());

                            this.lvwLookUp.Items.Add(lst);
                        }
                        break;
                    case "ENGINEERING SERVICES":

                       
                        this.lvwLookUp.Columns[0].Text = "ID";
                        this.lvwLookUp.Columns[1].Text = "Service Name";
                        this.lvwLookUp.Columns[2].Text = "Description";

                        for (int i = 0; i <= a_dt.Rows.Count - 1; i++)
                        {
                            ListViewItem lst = new ListViewItem(a_dt.Rows[i]["EnggServiceId"].ToString());
                            lst.SubItems.Add(a_dt.Rows[i]["ServiceName"].ToString());
                            lst.SubItems.Add(a_dt.Rows[i]["Description"].ToString());

                            this.lvwLookUp.Items.Add(lst);
                        }
                        break;
                }
            }

            #endregion

            #region Events

            private void ServicesLookUPUI_Load(object sender, System.EventArgs e)
            {
                switch (ServiceNeeded.ToUpper())
                {
                    case "ENGINEERING SERVICES":

                        loadEngineeringServices();
                        break;
                    case "HOUSEKEEPERS":

                        loadHousekeepers();
                        break;
                }
            }

            private void lvwLookUp_Click(System.Object sender, System.EventArgs e)
            {
                switch (ServiceNeeded.ToUpper())
                {
                    case "ENGINEERING SERVICES":

                        if (this.lvwLookUp.Items.Count > 0)
                        {
                            this.BindingContext[oEngineeringService.Tables[0]].Position = this.lvwLookUp.SelectedIndices[0];
                        }
                        break;
                    case "HOUSEKEEPERS":

                        if (this.lvwLookUp.Items.Count > 0)
                        {
                            this.BindingContext[oHouseKeeper.Tables[0]].Position = this.lvwLookUp.SelectedIndices[0];
                        }
                        break;
                }
            }

            private void lvwLookUp_DoubleClick(System.Object sender, System.EventArgs e)
            {
                passLookUpData();
            }

            private void btnSelect_Click(System.Object sender, System.EventArgs e)
            {
                passLookUpData();
            }

            private void btnClose_Click(System.Object sender, System.EventArgs e)
            {
                this.Close();
            }

            #endregion
            
	    }
	}

