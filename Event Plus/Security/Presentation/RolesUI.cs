using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.Security.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using System.Windows.Forms;


namespace Jinisys.Hotel.Security
{
	namespace Presentation
	{
		public class RolesUI : Jinisys.Hotel.UIFramework.Maintenance2UI
		{
			
			
			#region " Windows Form Designer generated code "
			
			public RolesUI()
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
			//Do not modify it using the code editor.
			internal System.Windows.Forms.GroupBox gbxCommands;
			internal System.Windows.Forms.Button btnSave;
			internal System.Windows.Forms.Button btnNew;
			internal System.Windows.Forms.Button btnCancel;
			internal System.Windows.Forms.Button btnDelete;
			public System.Windows.Forms.Label Label2;
			public System.Windows.Forms.TextBox txtDescription;
			public System.Windows.Forms.Label Label1;
			internal System.Windows.Forms.ColumnHeader ColumnHeader1;
			internal System.Windows.Forms.ListView lvwRoles;
            internal Button btnClose;
			private PictureBox picRoleImage;
			public System.Windows.Forms.TextBox txtRoleName;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
				this.gbxCommands = new System.Windows.Forms.GroupBox();
				this.btnClose = new System.Windows.Forms.Button();
				this.btnSave = new System.Windows.Forms.Button();
				this.btnNew = new System.Windows.Forms.Button();
				this.btnCancel = new System.Windows.Forms.Button();
				this.btnDelete = new System.Windows.Forms.Button();
				this.Label2 = new System.Windows.Forms.Label();
				this.txtDescription = new System.Windows.Forms.TextBox();
				this.txtRoleName = new System.Windows.Forms.TextBox();
				this.Label1 = new System.Windows.Forms.Label();
				this.lvwRoles = new System.Windows.Forms.ListView();
				this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
				this.picRoleImage = new System.Windows.Forms.PictureBox();
				this.gbxCommands.SuspendLayout();
				((System.ComponentModel.ISupportInitialize)(this.picRoleImage)).BeginInit();
				this.SuspendLayout();
				// 
				// gbxCommands
				// 
				this.gbxCommands.Controls.Add(this.btnClose);
				this.gbxCommands.Controls.Add(this.btnSave);
				this.gbxCommands.Controls.Add(this.btnNew);
				this.gbxCommands.Controls.Add(this.btnCancel);
				this.gbxCommands.Controls.Add(this.btnDelete);
				this.gbxCommands.Location = new System.Drawing.Point(6, 361);
				this.gbxCommands.Name = "gbxCommands";
				this.gbxCommands.Size = new System.Drawing.Size(532, 47);
				this.gbxCommands.TabIndex = 3;
				this.gbxCommands.TabStop = false;
				// 
				// btnClose
				// 
				this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
				this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
				this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F);
				this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
				this.btnClose.Location = new System.Drawing.Point(461, 10);
				this.btnClose.Name = "btnClose";
				this.btnClose.Size = new System.Drawing.Size(66, 31);
				this.btnClose.TabIndex = 8;
				this.btnClose.Text = "Cl&ose";
				this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
				// 
				// btnSave
				// 
				this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
				this.btnSave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.btnSave.Location = new System.Drawing.Point(321, 10);
				this.btnSave.Name = "btnSave";
				this.btnSave.Size = new System.Drawing.Size(66, 31);
				this.btnSave.TabIndex = 6;
				this.btnSave.Text = "&Save";
				this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
				// 
				// btnNew
				// 
				this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
				this.btnNew.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.btnNew.Location = new System.Drawing.Point(251, 10);
				this.btnNew.Name = "btnNew";
				this.btnNew.Size = new System.Drawing.Size(66, 31);
				this.btnNew.TabIndex = 5;
				this.btnNew.Text = "&New";
				this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
				// 
				// btnCancel
				// 
				this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
				this.btnCancel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.btnCancel.Location = new System.Drawing.Point(391, 10);
				this.btnCancel.Name = "btnCancel";
				this.btnCancel.Size = new System.Drawing.Size(66, 31);
				this.btnCancel.TabIndex = 7;
				this.btnCancel.Text = "&Cancel";
				this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
				// 
				// btnDelete
				// 
				this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
				this.btnDelete.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.btnDelete.Location = new System.Drawing.Point(7, 10);
				this.btnDelete.Name = "btnDelete";
				this.btnDelete.Size = new System.Drawing.Size(66, 31);
				this.btnDelete.TabIndex = 4;
				this.btnDelete.Text = "&Delete";
				this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
				// 
				// Label2
				// 
				this.Label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.Label2.Location = new System.Drawing.Point(229, 117);
				this.Label2.Name = "Label2";
				this.Label2.Size = new System.Drawing.Size(64, 17);
				this.Label2.TabIndex = 64;
				this.Label2.Text = "Description";
				// 
				// txtDescription
				// 
				this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
				this.txtDescription.Location = new System.Drawing.Point(293, 117);
				this.txtDescription.MaxLength = 20;
				this.txtDescription.Multiline = true;
				this.txtDescription.Name = "txtDescription";
				this.txtDescription.Size = new System.Drawing.Size(208, 80);
				this.txtDescription.TabIndex = 2;
				// 
				// txtRoleName
				// 
				this.txtRoleName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
				this.txtRoleName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
				this.txtRoleName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.txtRoleName.Location = new System.Drawing.Point(293, 85);
				this.txtRoleName.MaxLength = 30;
				this.txtRoleName.Multiline = true;
				this.txtRoleName.Name = "txtRoleName";
				this.txtRoleName.Size = new System.Drawing.Size(208, 21);
				this.txtRoleName.TabIndex = 1;
				this.txtRoleName.TextChanged += new System.EventHandler(this.txtRoleName_TextChanged);
				// 
				// Label1
				// 
				this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.Label1.Location = new System.Drawing.Point(229, 85);
				this.Label1.Name = "Label1";
				this.Label1.Size = new System.Drawing.Size(88, 17);
				this.Label1.TabIndex = 66;
				this.Label1.Text = "Role Name";
				// 
				// lvwRoles
				// 
				this.lvwRoles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1});
				this.lvwRoles.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.lvwRoles.FullRowSelect = true;
				this.lvwRoles.GridLines = true;
				this.lvwRoles.Location = new System.Drawing.Point(7, 4);
				this.lvwRoles.Name = "lvwRoles";
				this.lvwRoles.Scrollable = false;
				this.lvwRoles.Size = new System.Drawing.Size(208, 351);
				this.lvwRoles.TabIndex = 0;
				this.lvwRoles.UseCompatibleStateImageBehavior = false;
				this.lvwRoles.View = System.Windows.Forms.View.Details;
				this.lvwRoles.SelectedIndexChanged += new System.EventHandler(this.lvwRoles_SelectedIndexChanged);
				// 
				// ColumnHeader1
				// 
				this.ColumnHeader1.Text = "Role Name";
				this.ColumnHeader1.Width = 186;
				// 
				// picRoleImage
				// 
				this.picRoleImage.Image = global::Jinisys.Hotel.Security.Properties.Resources.Cashier;
				this.picRoleImage.Location = new System.Drawing.Point(467, 24);
				this.picRoleImage.Name = "picRoleImage";
				this.picRoleImage.Size = new System.Drawing.Size(34, 33);
				this.picRoleImage.TabIndex = 67;
				this.picRoleImage.TabStop = false;
				// 
				// RolesUI
				// 
				this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
				this.CancelButton = this.btnClose;
				this.ClientSize = new System.Drawing.Size(544, 414);
				this.Controls.Add(this.picRoleImage);
				this.Controls.Add(this.lvwRoles);
				this.Controls.Add(this.txtRoleName);
				this.Controls.Add(this.Label1);
				this.Controls.Add(this.Label2);
				this.Controls.Add(this.txtDescription);
				this.Controls.Add(this.gbxCommands);
				this.Name = "RolesUI";
				this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
				this.Text = "Roles";
				this.Load += new System.EventHandler(this.RolesUI_Load);
				this.gbxCommands.ResumeLayout(false);
				((System.ComponentModel.ISupportInitialize)(this.picRoleImage)).EndInit();
				this.ResumeLayout(false);
				this.PerformLayout();

			}
			
			#endregion
			
			#region "Variables and Constants"
			private MySqlConnection localConnection;
			private Role oRoles = new Role();
			private RolesFacade oRolesFacade;
			private string mode = "";
		#endregion
			
			#region "Constructor"
			public RolesUI(MySqlConnection connection)
			{
				InitializeComponent();
				localConnection = connection;
			}
			#endregion
			
			#region "Events"
			private void btnNew_Click(System.Object sender, System.EventArgs e)
			{
				NewRoles();
			}
			
			private void btnSave_Click(System.Object sender, System.EventArgs e)
			{
				SaveOrUpdateRoles();
			}
			
			private void btnCancel_Click(System.Object sender, System.EventArgs e)
			{
				CancelTransaction();
			}
			
			private void btnDelete_Click(System.Object sender, System.EventArgs e)
			{
				DeleteRoles();
			}
			
			private void RolesUI_Load(System.Object sender, System.EventArgs e)
			{
                this.ButtonState(true);
				LoadData();
			}
			private void lvwRoles_SelectedIndexChanged(System.Object sender, System.EventArgs e)
			{
				BindRowToControls();
			}
			#endregion
			
			#region "Methods"

            private ControlListener lControlListener = new ControlListener();
			private void LoadData()
			{
                this.lControlListener.StopListen(this);
				oRolesFacade = new RolesFacade(localConnection);
				oRoles = oRolesFacade.GetActiveRoles();
				int i;
				this.lvwRoles.Items.Clear();
				for (i = 0; i <= oRoles.Tables["Role"].Rows.Count - 1; i++)
				{
					ListViewItem lst = new ListViewItem(oRoles.Tables["Role"].Rows[i]["RoleName"].ToString());
					this.lvwRoles.Items.Add(lst);
				}
				
				if ( oRoles != null )
				{
					DatasetBinder datasetBinder = new DatasetBinder();
					Control tmpFrm = this;
                    ArrayList col = new ArrayList();
					object tmpRole = (object)oRoles;

					datasetBinder.BindControls(tmpFrm , ref tmpRole, col);
				}
                this.lControlListener.Listen(this);
			}
			private void SaveOrUpdateRoles()
			{
				if (this.Text.IndexOf("*") > 0)
				{
					UpdateRoles();
				}
				else
				{
					SaveRoles();
				}
				this.ClearBinding();
				this.LoadData();
				this.ButtonState(true);
			}
			private void NewRoles()
			{
                this.BindingContext[oRoles.Tables["Role"]].SuspendBinding();
				mode = "Add";
				this.Text = "Roles";
				this.ClearTextBox();
				this.ButtonState(false);
			}
			private void SaveRoles()
			{
				oRolesFacade = new RolesFacade(localConnection);
				InitializeHotelObj();
				if (ValidInput())
				{
					if (oRolesFacade.SaveRoles(oRoles))
					{
						
					}
				}
				
			}
			private void UpdateRoles()
			{
				oRolesFacade = new RolesFacade(localConnection);
				InitializeHotelObj();
				if (ValidInput())
				{
					if (oRolesFacade.UpdateRoles(oRoles))
					{
						
					}
				}
				
			}
			private void DeleteRoles()
			{
				oRolesFacade = new RolesFacade(localConnection);
				InitializeHotelObj();
				if (MessageBox.Show("Delete Roles '" + this.txtRoleName.Text + "'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					if (oRolesFacade.DeleteRoles(oRoles))
					{
						//MsgBox("Deleted!")
					}
				}
				this.ClearBinding();
				this.LoadData();
				this.ButtonState(true);
			}
			private void CancelTransaction()
			{
                this.BindingContext[oRoles.Tables["Role"]].ResumeBinding();
				this.Text = "Roles";
				this.ButtonState(true);
			}
			private void BindRowToControls()
			{
				try
				{
                    this.lControlListener.StopListen(this);
                    this.BindingContext[oRoles.Tables["Role"]].Position = Find(this.lvwRoles.SelectedItems[0].Text);
					this.Text = "Roles*";
					//this.ButtonState(false);
                    this.lControlListener.Listen(this);
				}
				catch (Exception)
				{
					
				}
			}
			//Find index of selected item
			private int Find(string key)
			{
				DataRow drRole;
				int i = 0;
                foreach (DataRow tempLoopVar_drRole in oRoles.Tables["Role"].Rows)
				{
					drRole = tempLoopVar_drRole;
					if (drRole["RoleName"].ToString() == key)
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
			private void InitializeHotelObj()
			{
				oRoles.RoleName = this.txtRoleName.Text;
				oRoles.Description = this.txtDescription.Text;
			}
			private void ClearTextBox()
			{
				Control ctr;
				foreach (Control tempLoopVar_ctr in this.Controls)
				{
					ctr = tempLoopVar_ctr;
					if (ctr is TextBox)
					{
						ctr.Text = "";
					}
				}
			}
			private bool ValidInput()
			{
				Control ctr;
				foreach (Control tempLoopVar_ctr in this.Controls)
				{
					ctr = tempLoopVar_ctr;
					if (ctr is TextBox)
					{
						if (ctr.Text == "")
						{
                            MessageBox.Show("Data not saved! \nPlease fill in all required data!","Notice",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
							return false;
						}
					}
				}
				return true;
			}
			//Control Button State
			private void ButtonState(bool state)
			{
				RolesUI with_1 = this;
				with_1.btnNew.Enabled = state;
				with_1.btnDelete.Enabled = state;
				with_1.btnSave.Enabled = ! state;
				with_1.btnCancel.Enabled = ! state;
			}
			private void ClearBinding()
			{
				Control ctr;
				foreach (Control tempLoopVar_ctr in this.Controls)
				{
					ctr = tempLoopVar_ctr;
					if (ctr is TextBox)
					{
						((TextBox) ctr).DataBindings.Remove(((TextBox) ctr).DataBindings["Text"]);
					}
				}
			}
			#endregion

            private void btnClose_Click(object sender, EventArgs e)
            {
                this.Close();
            }

			private void txtRoleName_TextChanged(object sender, EventArgs e)
			{
				switch (txtRoleName.Text)
				{ 
					case "ADMINISTRATOR":

						this.picRoleImage.Image = global::Jinisys.Hotel.Security.Properties.Resources.Administrator;
						break;
					case "FRONTDESK":
						this.picRoleImage.Image = global::Jinisys.Hotel.Security.Properties.Resources.FrontDesk;
						break;
					case "CASHIER":
						this.picRoleImage.Image = global::Jinisys.Hotel.Security.Properties.Resources.Cashier;
						break;
					case "SALES":
						this.picRoleImage.Image = global::Jinisys.Hotel.Security.Properties.Resources.Sales;
						break;
					case "GUEST":
						this.picRoleImage.Image = global::Jinisys.Hotel.Security.Properties.Resources.User;
						break;
					case "ACCOUNTING":
						this.picRoleImage.Image = global::Jinisys.Hotel.Security.Properties.Resources.Accouting;
						break;
					case "MAINTENANCE":
						this.picRoleImage.Image = global::Jinisys.Hotel.Security.Properties.Resources.Engineering;
						break;

					case "HOUSEKEEPING":
						this.picRoleImage.Image = global::Jinisys.Hotel.Security.Properties.Resources.Housekeeping;
						break;

					default:
						this.picRoleImage.Image = global::Jinisys.Hotel.Security.Properties.Resources.User;
						break;
				}

			}
			
			
		}
	}
}
