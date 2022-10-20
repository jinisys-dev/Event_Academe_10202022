using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Services.BusinessLayer;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Jinisys.Hotel.UIFramework;

namespace Jinisys.Hotel.Services.Presentation
{
	
		public class EngineeringServiceUI : Maintenance2UI
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
			public System.Windows.Forms.TextBox txtEnggServiceID;
			public System.Windows.Forms.TextBox txtDescription;
			public System.Windows.Forms.TextBox txtServiceName;
			public System.Windows.Forms.Label Label2;
			public System.Windows.Forms.Label Label3;
			internal System.Windows.Forms.GroupBox gbxCommands;
			internal System.Windows.Forms.Button btnSave;
			internal System.Windows.Forms.Button btnNew;
			internal System.Windows.Forms.Button btnCancel;
			internal System.Windows.Forms.Button btnDelete;
			internal System.Windows.Forms.ColumnHeader ColumnHeader2;
			internal System.Windows.Forms.ColumnHeader ColumnHeader3;
			internal System.Windows.Forms.ListView lvwEnggServices;
			internal System.Windows.Forms.Button btnSearch;
			internal System.Windows.Forms.Label Label1;
			internal System.Windows.Forms.Panel pnlSearch;
			internal System.Windows.Forms.Label Label4;
			internal System.Windows.Forms.TextBox txtSearch;
			internal System.Windows.Forms.Label Label16;
            internal Button btnClose;
			internal System.Windows.Forms.Label picClose;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
				System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EngineeringServiceUI));
				this.GroupBox1 = new System.Windows.Forms.GroupBox();
				this.txtEnggServiceID = new System.Windows.Forms.TextBox();
				this.Label1 = new System.Windows.Forms.Label();
				this.txtDescription = new System.Windows.Forms.TextBox();
				this.txtServiceName = new System.Windows.Forms.TextBox();
				this.Label2 = new System.Windows.Forms.Label();
				this.Label3 = new System.Windows.Forms.Label();
				this.gbxCommands = new System.Windows.Forms.GroupBox();
				this.btnClose = new System.Windows.Forms.Button();
				this.btnSearch = new System.Windows.Forms.Button();
				this.btnSave = new System.Windows.Forms.Button();
				this.btnNew = new System.Windows.Forms.Button();
				this.btnCancel = new System.Windows.Forms.Button();
				this.btnDelete = new System.Windows.Forms.Button();
				this.lvwEnggServices = new System.Windows.Forms.ListView();
				this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
				this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
				this.pnlSearch = new System.Windows.Forms.Panel();
				this.picClose = new System.Windows.Forms.Label();
				this.Label4 = new System.Windows.Forms.Label();
				this.txtSearch = new System.Windows.Forms.TextBox();
				this.Label16 = new System.Windows.Forms.Label();
				this.GroupBox1.SuspendLayout();
				this.gbxCommands.SuspendLayout();
				this.pnlSearch.SuspendLayout();
				this.SuspendLayout();
				// 
				// GroupBox1
				// 
				this.GroupBox1.Controls.Add(this.txtEnggServiceID);
				this.GroupBox1.Controls.Add(this.Label1);
				this.GroupBox1.Controls.Add(this.txtDescription);
				this.GroupBox1.Controls.Add(this.txtServiceName);
				this.GroupBox1.Controls.Add(this.Label2);
				this.GroupBox1.Controls.Add(this.Label3);
				this.GroupBox1.Location = new System.Drawing.Point(219, -3);
				this.GroupBox1.Name = "GroupBox1";
				this.GroupBox1.Size = new System.Drawing.Size(309, 312);
				this.GroupBox1.TabIndex = 2;
				this.GroupBox1.TabStop = false;
				// 
				// txtEnggServiceID
				// 
				this.txtEnggServiceID.BackColor = System.Drawing.SystemColors.Info;
				this.txtEnggServiceID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
				this.txtEnggServiceID.Enabled = false;
				this.txtEnggServiceID.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.txtEnggServiceID.Location = new System.Drawing.Point(88, 18);
				this.txtEnggServiceID.MaxLength = 11;
				this.txtEnggServiceID.Name = "txtEnggServiceID";
				this.txtEnggServiceID.Size = new System.Drawing.Size(83, 20);
				this.txtEnggServiceID.TabIndex = 1;
				// 
				// Label1
				// 
				this.Label1.BackColor = System.Drawing.Color.Transparent;
				this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.Label1.Location = new System.Drawing.Point(9, 20);
				this.Label1.Name = "Label1";
				this.Label1.Size = new System.Drawing.Size(87, 16);
				this.Label1.TabIndex = 14;
				this.Label1.Text = "ID. No.";
				// 
				// txtDescription
				// 
				this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
				this.txtDescription.Location = new System.Drawing.Point(88, 80);
				this.txtDescription.MaxLength = 30;
				this.txtDescription.Multiline = true;
				this.txtDescription.Name = "txtDescription";
				this.txtDescription.Size = new System.Drawing.Size(205, 125);
				this.txtDescription.TabIndex = 3;
				// 
				// txtServiceName
				// 
				this.txtServiceName.BackColor = System.Drawing.SystemColors.Info;
				this.txtServiceName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
				this.txtServiceName.Location = new System.Drawing.Point(88, 49);
				this.txtServiceName.MaxLength = 20;
				this.txtServiceName.Name = "txtServiceName";
				this.txtServiceName.Size = new System.Drawing.Size(205, 20);
				this.txtServiceName.TabIndex = 2;
				// 
				// Label2
				// 
				this.Label2.Location = new System.Drawing.Point(9, 51);
				this.Label2.Name = "Label2";
				this.Label2.Size = new System.Drawing.Size(79, 14);
				this.Label2.TabIndex = 11;
				this.Label2.Text = "Service Name";
				// 
				// Label3
				// 
				this.Label3.Location = new System.Drawing.Point(9, 77);
				this.Label3.Name = "Label3";
				this.Label3.Size = new System.Drawing.Size(71, 14);
				this.Label3.TabIndex = 12;
				this.Label3.Text = "Description";
				// 
				// gbxCommands
				// 
				this.gbxCommands.Controls.Add(this.btnClose);
				this.gbxCommands.Controls.Add(this.btnSearch);
				this.gbxCommands.Controls.Add(this.btnSave);
				this.gbxCommands.Controls.Add(this.btnNew);
				this.gbxCommands.Controls.Add(this.btnCancel);
				this.gbxCommands.Controls.Add(this.btnDelete);
				this.gbxCommands.Location = new System.Drawing.Point(2, 305);
				this.gbxCommands.Name = "gbxCommands";
				this.gbxCommands.Size = new System.Drawing.Size(526, 50);
				this.gbxCommands.TabIndex = 19;
				this.gbxCommands.TabStop = false;
				// 
				// btnClose
				// 
				this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
				this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.btnClose.Location = new System.Drawing.Point(454, 13);
				this.btnClose.Name = "btnClose";
				this.btnClose.Size = new System.Drawing.Size(66, 31);
				this.btnClose.TabIndex = 191;
				this.btnClose.Text = "C&lose";
				this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
				// 
				// btnSearch
				// 
				this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
				this.btnSearch.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.btnSearch.Location = new System.Drawing.Point(179, 13);
				this.btnSearch.Name = "btnSearch";
				this.btnSearch.Size = new System.Drawing.Size(66, 31);
				this.btnSearch.TabIndex = 10;
				this.btnSearch.Text = "&Search";
				this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
				// 
				// btnSave
				// 
				this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
				this.btnSave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.btnSave.Location = new System.Drawing.Point(316, 13);
				this.btnSave.Name = "btnSave";
				this.btnSave.Size = new System.Drawing.Size(66, 31);
				this.btnSave.TabIndex = 8;
				this.btnSave.Text = "Save";
				this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
				// 
				// btnNew
				// 
				this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
				this.btnNew.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.btnNew.Location = new System.Drawing.Point(247, 13);
				this.btnNew.Name = "btnNew";
				this.btnNew.Size = new System.Drawing.Size(66, 31);
				this.btnNew.TabIndex = 5;
				this.btnNew.Text = "New";
				this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
				// 
				// btnCancel
				// 
				this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
				this.btnCancel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.btnCancel.Location = new System.Drawing.Point(385, 13);
				this.btnCancel.Name = "btnCancel";
				this.btnCancel.Size = new System.Drawing.Size(66, 31);
				this.btnCancel.TabIndex = 9;
				this.btnCancel.Text = "Cancel";
				this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
				// 
				// btnDelete
				// 
				this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
				this.btnDelete.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.btnDelete.Location = new System.Drawing.Point(7, 13);
				this.btnDelete.Name = "btnDelete";
				this.btnDelete.Size = new System.Drawing.Size(66, 31);
				this.btnDelete.TabIndex = 4;
				this.btnDelete.Text = "Delete";
				this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
				// 
				// lvwEnggServices
				// 
				this.lvwEnggServices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader2,
            this.ColumnHeader3});
				this.lvwEnggServices.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.lvwEnggServices.FullRowSelect = true;
				this.lvwEnggServices.GridLines = true;
				this.lvwEnggServices.Location = new System.Drawing.Point(2, 2);
				this.lvwEnggServices.Name = "lvwEnggServices";
				this.lvwEnggServices.Size = new System.Drawing.Size(214, 306);
				this.lvwEnggServices.TabIndex = 128;
				this.lvwEnggServices.UseCompatibleStateImageBehavior = false;
				this.lvwEnggServices.View = System.Windows.Forms.View.Details;
				this.lvwEnggServices.SelectedIndexChanged += new System.EventHandler(this.lvwEnggServices_SelectedIndexChanged);
				// 
				// ColumnHeader2
				// 
				this.ColumnHeader2.Text = "ID";
				this.ColumnHeader2.Width = 54;
				// 
				// ColumnHeader3
				// 
				this.ColumnHeader3.Text = "Name";
				this.ColumnHeader3.Width = 137;
				// 
				// pnlSearch
				// 
				this.pnlSearch.BackColor = System.Drawing.SystemColors.Info;
				this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
				this.pnlSearch.Controls.Add(this.picClose);
				this.pnlSearch.Controls.Add(this.Label4);
				this.pnlSearch.Controls.Add(this.txtSearch);
				this.pnlSearch.Controls.Add(this.Label16);
				this.pnlSearch.Location = new System.Drawing.Point(129, 125);
				this.pnlSearch.Name = "pnlSearch";
				this.pnlSearch.Size = new System.Drawing.Size(271, 105);
				this.pnlSearch.TabIndex = 184;
				this.pnlSearch.Visible = false;
				// 
				// picClose
				// 
				this.picClose.BackColor = System.Drawing.Color.SteelBlue;
				this.picClose.Image = ((System.Drawing.Image)(resources.GetObject("picClose.Image")));
				this.picClose.Location = new System.Drawing.Point(247, 4);
				this.picClose.Name = "picClose";
				this.picClose.Size = new System.Drawing.Size(18, 16);
				this.picClose.TabIndex = 5;
				this.picClose.Click += new System.EventHandler(this.Close_Click);
				// 
				// Label4
				// 
				this.Label4.Location = new System.Drawing.Point(11, 38);
				this.Label4.Name = "Label4";
				this.Label4.Size = new System.Drawing.Size(240, 15);
				this.Label4.TabIndex = 4;
				this.Label4.Text = "Input Search String here";
				// 
				// txtSearch
				// 
				this.txtSearch.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.txtSearch.Location = new System.Drawing.Point(11, 62);
				this.txtSearch.Name = "txtSearch";
				this.txtSearch.Size = new System.Drawing.Size(248, 22);
				this.txtSearch.TabIndex = 3;
				this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
				// 
				// Label16
				// 
				this.Label16.BackColor = System.Drawing.Color.SteelBlue;
				this.Label16.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.Label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
				this.Label16.Image = ((System.Drawing.Image)(resources.GetObject("Label16.Image")));
				this.Label16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
				this.Label16.Location = new System.Drawing.Point(1, 1);
				this.Label16.Name = "Label16";
				this.Label16.Size = new System.Drawing.Size(267, 20);
				this.Label16.TabIndex = 0;
				this.Label16.Text = "      Search";
				this.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
				// 
				// EngineeringServiceUI
				// 
				this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
				this.CancelButton = this.btnClose;
				this.ClientSize = new System.Drawing.Size(530, 357);
				this.Controls.Add(this.pnlSearch);
				this.Controls.Add(this.lvwEnggServices);
				this.Controls.Add(this.GroupBox1);
				this.Controls.Add(this.gbxCommands);
				this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
				this.Name = "EngineeringServiceUI";
				this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
				this.Text = "Engineering Service";
				this.Closing += new System.ComponentModel.CancelEventHandler(this.EngineeringServiceUI_Closing);
				this.TextChanged += new System.EventHandler(this.EngineeringServiceUI_TextChanged);
				this.Load += new System.EventHandler(this.EngineeringServiceUI_Load);
				this.GroupBox1.ResumeLayout(false);
				this.GroupBox1.PerformLayout();
				this.gbxCommands.ResumeLayout(false);
				this.pnlSearch.ResumeLayout(false);
				this.pnlSearch.PerformLayout();
				this.ResumeLayout(false);

			}
			
			#endregion

            #region Variables and Constants
            private OperationMode mOperationMode;

            private DatasetBinder oDatasetBinder ;
            private ControlListener oControlListener ;

            private EngineeringService oEngineeringService ;
            private EngineeringServiceFacade oEngineeringServiceFacade;

            #endregion

            #region Constructor
            public EngineeringServiceUI()
            {
                oDatasetBinder = new DatasetBinder();
                oControlListener = new ControlListener();
                oEngineeringService = new EngineeringService();
                oEngineeringServiceFacade = new EngineeringServiceFacade();
                InitializeComponent();


            }
            #endregion

			#region Methods

            private void populateDataGrid()
            {
               
                for (int i = 0; i <= oEngineeringService.Tables[0].Rows.Count - 1; i++)
                {
                    ListViewItem lst = new ListViewItem(oEngineeringService.Tables[0].Rows[i]["enggserviceid"].ToString());
                    lst.SubItems.Add(oEngineeringService.Tables[0].Rows[i]["ServiceName"].ToString());

                    this.lvwEnggServices.Items.Add(lst);
                }
				
            }

            private void setOperationMode(OperationMode a_OperationMode)
            {
                mOperationMode = a_OperationMode;
            }
					
		    private bool hasChanges()
            {
                if (this.Text.IndexOf("*") > 0)
                    return true;
                else
                    return false;
            }

			private void bindRowToControls()
			{
				try
				{
					oControlListener.StopListen(this);
					this.BindingContext[oEngineeringService.Tables["EngineeringServices"]].Position = findItemInDataSet(this.lvwEnggServices.SelectedItems[0].Text);
					
					oControlListener.Listen(this);
				}
				catch (Exception)
				{
					
				}
			}
		
	        private bool isRequiredEntriesFilled()
            {
                if (this.txtEnggServiceID.Text.Length == 0 || this.txtServiceName.Text.Length == 0) return false;
                return true;
            }

            private void assignEntityValues()
            {
                oEngineeringService.gHotelId = GlobalVariables.gHotelId;
                oEngineeringService.EnggServiceID = System.Convert.ToInt32(this.txtEnggServiceID.Text);
                oEngineeringService.ServiceName = this.txtServiceName.Text;
                oEngineeringService.Description = this.txtDescription.Text;
                oEngineeringService.CreatedBy = GlobalVariables.gLoggedOnUser;
            }

            private void deselectItem()
		         {
				    for (int i = 0; i <= this.lvwEnggServices.Items.Count - 1; i++)
				    {
					    this.lvwEnggServices.Items[i].Selected = false;
				    }
			    }
			
			private int findItemInDataSet(string a_key)
			{
				DataRow drRoom;
				int i;
				
				i = 0;
				foreach (DataRow tempLoopVar_drRoom in oEngineeringService.Tables[0].Rows)
				{
					drRoom = tempLoopVar_drRoom;
					if ((string) drRoom["EnggServiceId"] == a_key)
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
				
			private void setActionButtonStates(bool a_stat)
			{
				EngineeringServiceUI with_1 = this;
				with_1.btnDelete.Enabled = a_stat;
				with_1.btnNew.Enabled = a_stat;
				with_1.btnSave.Enabled = ! a_stat;
				with_1.btnCancel.Enabled = ! a_stat;
			}
			
			#endregion

            #region Data Access Methods

                public bool load()
                {
                    try
                    {
                        oEngineeringServiceFacade = new EngineeringServiceFacade();
                        oEngineeringService = new EngineeringService();
                        oEngineeringService = oEngineeringServiceFacade.getEngineeringServices();

                        return true;
                    }
                    catch (Exception) { return false; }
                }

                public int insert()
                {
                    try
                    {
                        int rowsAffected = 0;
                        oEngineeringServiceFacade = new EngineeringServiceFacade();
                        rowsAffected = oEngineeringServiceFacade.insertEngineeringService(ref oEngineeringService);
                        return rowsAffected;
                    }
                    catch (Exception) { return 0; }
                }

                public int update()
                {
                    try
                    {
                        int rowsAffected = 0;
                        oEngineeringServiceFacade = new EngineeringServiceFacade();
                        rowsAffected=oEngineeringServiceFacade.updateEngineeringService(ref oEngineeringService);
                        return rowsAffected;
                    }
                    catch (Exception)
                    {
                        return 0;
                    }
                }

                public int delete()
                {
                    try
                    {
                        assignEntityValues();
                        int rowsAffected = 0;
                        oEngineeringServiceFacade = new EngineeringServiceFacade();
                        rowsAffected = oEngineeringServiceFacade.deteleEngineeringService(ref oEngineeringService);
                        return rowsAffected;
                    }
                    catch (Exception)
                    {
                        return 0;
                    }
                }

            #endregion

            #region Events

            private void EngineeringServiceUI_Load(object sender, System.EventArgs e)
            {
                if (load() == true)
                {
                    if (oEngineeringService != null)
                    {
                        object oEService = oEngineeringService;
                        oDatasetBinder.BindControls(this, ref oEService, new ArrayList());
                        populateDataGrid();
                    }
                    this.oControlListener.StopListen(this);
                }

				setActionButtonStates(true);

            }

            private void btnNew_Click(System.Object sender, System.EventArgs e)
            {
                setOperationMode(OperationMode.Add);
                oControlListener.StopListen(this);

                this.BindingContext[oEngineeringService.Tables["EngineeringServices"]].SuspendBinding();

                this.txtEnggServiceID.Enabled = true;
                this.txtEnggServiceID.Focus();

                setActionButtonStates(false);
            }

            private void EngineeringServiceUI_Closing(object sender, System.ComponentModel.CancelEventArgs e)
            {
                if (hasChanges() == true)
                {
                    if (MessageBox.Show("Save changes made to Engineering Service \'" + this.txtServiceName.Text + "\'", "Users", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        if (update() > 0)
                        {
                            this.lvwEnggServices.Items[findItemInDataSet(this.txtEnggServiceID.Text)].SubItems[1].Text = this.txtServiceName.Text;

                            this.BindingContext[oEngineeringService.Tables["EngineeringServices"]].ResumeBinding();
                            this.Text = "Engineering Services";

                            oControlListener.Listen(this);

                        }
                        else
                        {
                            MessageBox.Show("No rows updated", "Database Update Error");
                        }

                    }
                    else
                    {
                        this.BindingContext[oEngineeringService.Tables["EngineeringServices"]].CancelCurrentEdit();
                        this.Text = "Engineering Services";

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

                        case OperationMode.Add:
                            if (insert() > 0)
                            {
                                ListViewItem lst = new ListViewItem(oEngineeringService.EnggServiceID.ToString());
                                lst.SubItems.Add(oEngineeringService.ServiceName);

                                this.lvwEnggServices.Items.Add(lst);

                                this.BindingContext[oEngineeringService.Tables["EngineeringServices"]].ResumeBinding();
                                this.Text = "Engineering Services";

                                setActionButtonStates(true);

                                oControlListener.Listen(this);
                            }
                            else
                            {
                                MessageBox.Show("No rows added", "Database Insert Error");
                            }

                            break;
                        case OperationMode.Edit:
                            if (update() > 0)
                            {
                                this.lvwEnggServices.Items[findItemInDataSet(this.txtEnggServiceID.Text)].SubItems[1].Text = this.txtServiceName.Text;

                                this.BindingContext[oEngineeringService.Tables["EngineeringServices"]].ResumeBinding();
                                this.Text = "Engineering Services";

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
                    MessageBox.Show("Please input necessary field(s)");
                    return;
                }
            }

            private void btnCancel_Click(System.Object sender, System.EventArgs e)
            {
                if (mOperationMode.Equals(OperationMode.Add))
                {
                    if (this.lvwEnggServices.Items.Count > 0)
                    {
                        this.lvwEnggServices.Items[0].Selected = true;
                    }
                }
                else
                {
                    this.BindingContext[oEngineeringService.Tables["EngineeringServices"]].CancelCurrentEdit();
                }

                this.BindingContext[oEngineeringService.Tables["EngineeringServices"]].ResumeBinding();

                this.Text = "Engineering Services";
                setActionButtonStates(true);

                oControlListener.Listen(this);
            }

            private void btnDelete_Click(System.Object sender, System.EventArgs e)
            {
                if (MessageBox.Show("Delete Engineering Service \'" + this.txtServiceName.Text + "\'", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    this.Text = "Engineering Services";
                    oControlListener.StopListen(this);

                    if (delete() > 0)
                    {
                        this.lvwEnggServices.SelectedItems[0].Remove();

                        if (this.lvwEnggServices.Items.Count > 0)
                        {
                            this.lvwEnggServices.Items[0].Selected = true;
                        }
                        oControlListener.Listen(this);
                    }
                }
            }

            private void EngineeringServiceUI_TextChanged(object sender, System.EventArgs e)
            {
                if (this.Text.IndexOf("*") > 0)
                {
                    setOperationMode(OperationMode.Edit);
                    setActionButtonStates(false);
                }
                else
                {
                    setActionButtonStates(true);
                }
            }

            private void grdEngineeringService_CurrentCellChanged(System.Object sender, System.EventArgs e)
            {
                bindRowToControls();
            }

            private void grdEngineeringService_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
            {
                if (hasChanges() == true)
                {
                    if (MessageBox.Show("Save changes made to Engineering Service \'" + this.txtServiceName.Text + "\'", "Users", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        if (update() > 0)
                        {
                            this.lvwEnggServices.Items[findItemInDataSet(this.txtEnggServiceID.Text)].SubItems[1].Text = this.txtServiceName.Text;

                            this.BindingContext[oEngineeringService.Tables["EngineeringServices"]].ResumeBinding();
                            this.Text = "Engineering Services";

                            oControlListener.Listen(this);

                        }
                        else
                        {
                            MessageBox.Show("No rows updated", "Database Update Error");
                        }

                    }
                    else
                    {
                        this.BindingContext[oEngineeringService.Tables["EngineeringServices"]].CancelCurrentEdit();
                        this.Text = "Engineering Services";

                    }
                }
            }
           
            private void btnSearch_Click(System.Object sender, System.EventArgs e)
			{
				
				this.oControlListener.StopListen(this);
				this.pnlSearch.Visible = true;
				this.txtSearch.Focus();
			}

            private void txtSearch_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
            {
                if (e.KeyChar == '\r')
                {
                    this.lvwEnggServices.Focus();

                    deselectItem();

                    for (int i = 0; i <= this.lvwEnggServices.Items.Count - 1; i++)
                    {
                        if (this.lvwEnggServices.Items[i].SubItems[1].Text.ToUpper().Contains(this.txtSearch.Text.ToUpper()) || this.lvwEnggServices.Items[i].Text.ToUpper().Contains(this.txtSearch.Text.ToUpper()))
                        {

                            this.lvwEnggServices.Items[i].Selected = true;

                            this.pnlSearch.Visible = false;

                            this.oControlListener.Listen(this);
                            return;
                        }
                    }

                }
            }
			
			private void Close_Click(System.Object sender, System.EventArgs e)
			{
				this.pnlSearch.Visible = false;
			}
			
			private void lvwEnggServices_SelectedIndexChanged(System.Object sender, System.EventArgs e)
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
	

