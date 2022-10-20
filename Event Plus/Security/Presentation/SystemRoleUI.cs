using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.Security.BusinessLayer;

using Jinisys.Hotel.BusinessSharedClasses;
using System.Reflection;
using System.Collections.Generic;

namespace Jinisys.Hotel.Security
{
	namespace Presentation
	{
		public class SystemRoleUI : Jinisys.Hotel.UIFramework.Maintenance2UI
		{


			#region " Windows Form Designer generated code "

			public SystemRoleUI()
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
			internal System.Windows.Forms.Button btnSave;
			private C1.Win.C1FlexGrid.C1FlexGrid grdMenus;
			internal ComboBox cboRoleName;
			public TextBox txtDescription;
			public Label Label2;
			public Label Label1;
			private TabControl tabRole;
			private TabPage tabSystemMenus;
			private TabPage tabSystemForms;
			private C1.Win.C1FlexGrid.C1FlexGrid grdForms;
			private TabPage tabPrivileges;
			private C1.Win.C1FlexGrid.C1FlexGrid grdRolePrivileges;
			internal Button btnClose;
			[System.Diagnostics.DebuggerStepThrough()]
			private void InitializeComponent()
			{
				System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemRoleUI));
				this.btnSave = new System.Windows.Forms.Button();
				this.btnClose = new System.Windows.Forms.Button();
				this.grdMenus = new C1.Win.C1FlexGrid.C1FlexGrid();
				this.cboRoleName = new System.Windows.Forms.ComboBox();
				this.txtDescription = new System.Windows.Forms.TextBox();
				this.Label2 = new System.Windows.Forms.Label();
				this.Label1 = new System.Windows.Forms.Label();
				this.tabRole = new System.Windows.Forms.TabControl();
				this.tabSystemMenus = new System.Windows.Forms.TabPage();
				this.tabSystemForms = new System.Windows.Forms.TabPage();
				this.grdForms = new C1.Win.C1FlexGrid.C1FlexGrid();
				this.tabPrivileges = new System.Windows.Forms.TabPage();
				this.grdRolePrivileges = new C1.Win.C1FlexGrid.C1FlexGrid();
				((System.ComponentModel.ISupportInitialize)(this.grdMenus)).BeginInit();
				this.tabRole.SuspendLayout();
				this.tabSystemMenus.SuspendLayout();
				this.tabSystemForms.SuspendLayout();
				((System.ComponentModel.ISupportInitialize)(this.grdForms)).BeginInit();
				this.tabPrivileges.SuspendLayout();
				((System.ComponentModel.ISupportInitialize)(this.grdRolePrivileges)).BeginInit();
				this.SuspendLayout();
				// 
				// btnSave
				// 
				this.btnSave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.btnSave.Location = new System.Drawing.Point(465, 55);
				this.btnSave.Name = "btnSave";
				this.btnSave.Size = new System.Drawing.Size(66, 31);
				this.btnSave.TabIndex = 73;
				this.btnSave.Text = "&Save";
				this.btnSave.Click += new System.EventHandler(this.btnUpdate_Click);
				// 
				// btnClose
				// 
				this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
				this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.btnClose.Location = new System.Drawing.Point(537, 55);
				this.btnClose.Name = "btnClose";
				this.btnClose.Size = new System.Drawing.Size(66, 31);
				this.btnClose.TabIndex = 191;
				this.btnClose.Text = "C&lose";
				this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
				// 
				// grdMenus
				// 
				this.grdMenus.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
				this.grdMenus.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor;
				this.grdMenus.ColumnInfo = resources.GetString("grdMenus.ColumnInfo");
				this.grdMenus.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.grdMenus.Location = new System.Drawing.Point(7, 12);
				this.grdMenus.Name = "grdMenus";
				this.grdMenus.Rows.DefaultSize = 17;
				this.grdMenus.Size = new System.Drawing.Size(580, 445);
				this.grdMenus.StyleInfo = resources.GetString("grdMenus.StyleInfo");
				this.grdMenus.TabIndex = 198;
				this.grdMenus.SelChange += new System.EventHandler(this.grdMenus_SelChange);
				// 
				// cboRoleName
				// 
				this.cboRoleName.BackColor = System.Drawing.SystemColors.Info;
				this.cboRoleName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
				this.cboRoleName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.cboRoleName.Location = new System.Drawing.Point(95, 26);
				this.cboRoleName.Name = "cboRoleName";
				this.cboRoleName.Size = new System.Drawing.Size(210, 22);
				this.cboRoleName.TabIndex = 195;
				this.cboRoleName.SelectedIndexChanged += new System.EventHandler(this.cboRoleName_SelectedIndexChanged);
				// 
				// txtDescription
				// 
				this.txtDescription.BackColor = System.Drawing.Color.White;
				this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
				this.txtDescription.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.txtDescription.Location = new System.Drawing.Point(95, 56);
				this.txtDescription.MaxLength = 30;
				this.txtDescription.Multiline = true;
				this.txtDescription.Name = "txtDescription";
				this.txtDescription.ReadOnly = true;
				this.txtDescription.Size = new System.Drawing.Size(276, 23);
				this.txtDescription.TabIndex = 193;
				// 
				// Label2
				// 
				this.Label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.Label2.Location = new System.Drawing.Point(26, 59);
				this.Label2.Name = "Label2";
				this.Label2.Size = new System.Drawing.Size(63, 17);
				this.Label2.TabIndex = 194;
				this.Label2.Text = "Description";
				// 
				// Label1
				// 
				this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.Label1.Location = new System.Drawing.Point(26, 30);
				this.Label1.Name = "Label1";
				this.Label1.Size = new System.Drawing.Size(63, 17);
				this.Label1.TabIndex = 192;
				this.Label1.Text = "Role Name";
				// 
				// tabRole
				// 
				this.tabRole.Controls.Add(this.tabSystemMenus);
				this.tabRole.Controls.Add(this.tabSystemForms);
				this.tabRole.Controls.Add(this.tabPrivileges);
				this.tabRole.Location = new System.Drawing.Point(12, 92);
				this.tabRole.Name = "tabRole";
				this.tabRole.SelectedIndex = 0;
				this.tabRole.Size = new System.Drawing.Size(601, 490);
				this.tabRole.TabIndex = 199;
				// 
				// tabSystemMenus
				// 
				this.tabSystemMenus.Controls.Add(this.grdMenus);
				this.tabSystemMenus.Location = new System.Drawing.Point(4, 23);
				this.tabSystemMenus.Name = "tabSystemMenus";
				this.tabSystemMenus.Padding = new System.Windows.Forms.Padding(3);
				this.tabSystemMenus.Size = new System.Drawing.Size(593, 463);
				this.tabSystemMenus.TabIndex = 0;
				this.tabSystemMenus.Text = "System Menus     ";
				this.tabSystemMenus.UseVisualStyleBackColor = true;
				// 
				// tabSystemForms
				// 
				this.tabSystemForms.Controls.Add(this.grdForms);
				this.tabSystemForms.Location = new System.Drawing.Point(4, 22);
				this.tabSystemForms.Name = "tabSystemForms";
				this.tabSystemForms.Padding = new System.Windows.Forms.Padding(3);
				this.tabSystemForms.Size = new System.Drawing.Size(593, 464);
				this.tabSystemForms.TabIndex = 1;
				this.tabSystemForms.Text = "System Forms     ";
				this.tabSystemForms.UseVisualStyleBackColor = true;
				// 
				// grdForms
				// 
				this.grdForms.AllowEditing = false;
				this.grdForms.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
				this.grdForms.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor;
				this.grdForms.ColumnInfo = resources.GetString("grdForms.ColumnInfo");
				this.grdForms.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.grdForms.Location = new System.Drawing.Point(6, 15);
				this.grdForms.Name = "grdForms";
				this.grdForms.Rows.DefaultSize = 17;
				this.grdForms.Size = new System.Drawing.Size(580, 442);
				this.grdForms.StyleInfo = resources.GetString("grdForms.StyleInfo");
				this.grdForms.TabIndex = 199;
				this.grdForms.SelChange += new System.EventHandler(this.grdForms_SelChange);
				// 
				// tabPrivileges
				// 
				this.tabPrivileges.Controls.Add(this.grdRolePrivileges);
				this.tabPrivileges.Location = new System.Drawing.Point(4, 22);
				this.tabPrivileges.Name = "tabPrivileges";
				this.tabPrivileges.Padding = new System.Windows.Forms.Padding(3);
				this.tabPrivileges.Size = new System.Drawing.Size(593, 464);
				this.tabPrivileges.TabIndex = 2;
				this.tabPrivileges.Text = "Role Privileges     ";
				this.tabPrivileges.UseVisualStyleBackColor = true;
				// 
				// grdRolePrivileges
				// 
				this.grdRolePrivileges.AllowEditing = false;
				this.grdRolePrivileges.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
				this.grdRolePrivileges.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor;
				this.grdRolePrivileges.ColumnInfo = "3,0,0,0,0,85,Columns:0{Width:26;Caption:\"No.\";}\t1{Width:459;Caption:\"Description\"" +
					";}\t2{Width:75;Caption:\"Allowed\";DataType:System.Boolean;TextAlignFixed:CenterCen" +
					"ter;ImageAlign:CenterCenter;}\t";
				this.grdRolePrivileges.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.grdRolePrivileges.Location = new System.Drawing.Point(6, 15);
				this.grdRolePrivileges.Name = "grdRolePrivileges";
				this.grdRolePrivileges.Rows.DefaultSize = 17;
				this.grdRolePrivileges.Size = new System.Drawing.Size(580, 442);
				this.grdRolePrivileges.StyleInfo = resources.GetString("grdRolePrivileges.StyleInfo");
				this.grdRolePrivileges.TabIndex = 200;
				this.grdRolePrivileges.SelChange += new System.EventHandler(this.grdRolePrivileges_SelChange);
				// 
				// SystemRoleUI
				// 
				this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
				this.CancelButton = this.btnClose;
				this.ClientSize = new System.Drawing.Size(628, 601);
				this.Controls.Add(this.tabRole);
				this.Controls.Add(this.cboRoleName);
				this.Controls.Add(this.txtDescription);
				this.Controls.Add(this.Label2);
				this.Controls.Add(this.Label1);
				this.Controls.Add(this.btnClose);
				this.Controls.Add(this.btnSave);
				this.Font = new System.Drawing.Font("Arial", 8.25F);
				this.MinimizeBox = false;
				this.Name = "SystemRoleUI";
				this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
				this.Text = "System Menu Role";
				this.Shown += new System.EventHandler(this.SystemRoleUI_Shown);
				this.Load += new System.EventHandler(this.SystemRoleUI_Load);
				((System.ComponentModel.ISupportInitialize)(this.grdMenus)).EndInit();
				this.tabRole.ResumeLayout(false);
				this.tabSystemMenus.ResumeLayout(false);
				this.tabSystemForms.ResumeLayout(false);
				((System.ComponentModel.ISupportInitialize)(this.grdForms)).EndInit();
				this.tabPrivileges.ResumeLayout(false);
				((System.ComponentModel.ISupportInitialize)(this.grdRolePrivileges)).EndInit();
				this.ResumeLayout(false);
				this.PerformLayout();

			}

			#endregion

			#region "Variables and Constants"
			private MySqlConnection localConnection;
			private SystemRoleFacade oSystemRoleFacade;
			private Hashtable hash;
			private int index = 0;
			#endregion

			public SystemRoleUI(MySqlConnection connection)
			{
				InitializeComponent();
				localConnection = connection;
			}

			private void SystemRoleUI_Load(System.Object sender, System.EventArgs e)
			{
				LoadData();
			}

			DataTable tableRoles = null;
			private void LoadData()
			{
				loadMenus();
				loadAllUINames();
				loadSystemPrivileges();

				oSystemRoleFacade = new SystemRoleFacade();
				tableRoles = oSystemRoleFacade.GetRoles();

				this.cboRoleName.DataSource = tableRoles;
				this.cboRoleName.DisplayMember = "RoleName";

				this.cboRoleName.MaxDropDownItems = tableRoles.Rows.Count;


				//bgLoadUI.RunWorkerAsync();
			}

			private void loadMenus()
			{
				Form frm = this.MdiParent;
				MenuStrip mainMenu = frm.MainMenuStrip;


				this.grdMenus.Rows.Count = 1;
				int i = 1;

				foreach (ToolStripMenuItem mnu in mainMenu.Items)
				{
					if (mnu.Text != "")
					{
						this.grdMenus.Rows.Count += 1;
						this.grdMenus.SetData(i, 0, mnu.Text.Replace("&", ""));
						this.grdMenus.Rows[i].Style = this.grdMenus.Styles["mainMenu"];
						i++;

						if (mnu.HasDropDownItems)
						{
							foreach (ToolStripItem subMenu in mnu.DropDownItems)
							{
								if (subMenu.Text != "")
								{
									this.grdMenus.Rows.Count += 1;
									this.grdMenus.SetData(i, 1, subMenu.Text.Replace("&", ""));
									i++;

									if (subMenu.GetType() != typeof(ToolStripSeparator))
									{
										ToolStripMenuItem _temp = (ToolStripMenuItem)subMenu;
										if (_temp.HasDropDownItems)
										{
											foreach (ToolStripItem subSubMenu in _temp.DropDownItems)
											{
												if (subSubMenu.Text != "")
												{
													this.grdMenus.Rows.Count += 1;
													this.grdMenus.SetData(i, 2, subSubMenu.Text.Replace("&", ""));
													i++;
												} // endif
											}// end foreach

										}//endif

									}// endif

								}// endif 

							}// end foreach

						}//end if

					}//end if

				}//end foreach
			}

			private void loadSystemPrivileges()
			{
				RolesFacade oRoleFacade = new RolesFacade(GlobalVariables.gPersistentConnection);

				DataTable _dtTemp = oRoleFacade.getSystemPrivileges();

				this.grdRolePrivileges.Rows.Count = _dtTemp.Rows.Count + 1;
				int i = 1;
				foreach (DataRow _dRow in _dtTemp.Rows)
				{
					this.grdRolePrivileges.SetData(i, 0, i);
					this.grdRolePrivileges.SetData(i, 1, _dRow["privilegeDescription"].ToString());
					i++;
				}

			}

			private void btnUpdate_Click(System.Object sender, System.EventArgs e)
			{
				this.Cursor = Cursors.WaitCursor;
				try
				{

					RoleMenuCollection oRoleMenuCollection = new RoleMenuCollection();
					IList<RoleUIPrivilege> oRoleUIPrivileges = new List<RoleUIPrivilege>();


					oSystemRoleFacade = new SystemRoleFacade();

					Role _oRole = new Role();
					_oRole.RoleName = this.cboRoleName.Text;
					
					_oRole.RoleMenuCollection = assignRoleMenu();
					_oRole.RoleUIPrivileges = assignRoleUIPrivilege();
					_oRole.Privileges = assignRoleSystemPrivileges();

					if (oSystemRoleFacade.UpdateRoles(_oRole))
					{
						MessageBox.Show("Update successful.\r\n\r\nChanges will take effect on next log-on.", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}

				catch (Exception ex)
				{
					MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					this.Cursor = Cursors.Default;
				}

			}

			private RoleMenuCollection assignRoleMenu()
			{

				RoleMenuCollection oRoleMenuCollection = new RoleMenuCollection();

				for (int _row = 1; _row < this.grdMenus.Rows.Count; _row++)
				{

					for (int _col = 0; _col < this.grdMenus.Cols.Count - 1; _col++)
					{
						string _str = this.grdMenus.GetDataDisplay(_row, _col);
						bool _enable = (bool)this.grdMenus.GetData(_row, 3);

						if (_str != "")
						{
							RoleMenu _newRoleMenu = new RoleMenu();

							_newRoleMenu.RoleName = this.cboRoleName.Text;
							_newRoleMenu.Menu = _str;
							_newRoleMenu.IsEnable = _enable;

							oRoleMenuCollection.Add(_newRoleMenu);

						}// endif

					}// end inner for

				}// end for

				return oRoleMenuCollection;

			}


			private IList<RoleUIPrivilege> assignRoleUIPrivilege()
			{

				IList<RoleUIPrivilege> _oRoleUIPrivileges = new List<RoleUIPrivilege>();

				for (int _row = 1; _row < this.grdForms.Rows.Count; _row++)
				{
					object obj = this.grdForms.GetData(_row, 3);
					string _strVisible = "";
					try {
						_strVisible = obj.ToString();
					}
					catch {
						_strVisible = "False";
					}

					int _isVisible = _strVisible == "True" ? 1 : 0;
					string _strModule = "";
					string _strFormName = "";
					string _strButton = "";

					//if (_isVisible == 1)
					//{

						_strModule = this.grdForms.GetDataDisplay(_row, 0);
						if (_strModule == "")
						{
							try
							{
								_strModule = this.grdForms.GetDataDisplay(_row, 4).ToString();
							}
							catch { }
						}


						_strFormName = this.grdForms.GetDataDisplay(_row, 1);
						if (_strFormName == "")
						{
							try
							{
								_strFormName = this.grdForms.GetDataDisplay(_row, 5).ToString();
							}
							catch { }
						}

						_strButton = this.grdForms.GetDataDisplay(_row,2);
					//}

					RoleUIPrivilege _newRolePrivilege = new RoleUIPrivilege();
					_newRolePrivilege.RoleName = this.cboRoleName.Text;
					_newRolePrivilege.Module = _strModule;
					_newRolePrivilege.FormName = _strFormName;
					_newRolePrivilege.ButtonName = _strButton;
					_newRolePrivilege.IsVisible = _isVisible;

					if (_strFormName != "")
					{
						_oRoleUIPrivileges.Add(_newRolePrivilege);
					}


				}// end for


				return _oRoleUIPrivileges;

			}

			private IList<Role_Privilege> assignRoleSystemPrivileges()
			{

				IList<Role_Privilege> _oRolePrivileges = new List<Role_Privilege>();

				for (int _row = 1; _row < this.grdRolePrivileges.Rows.Count; _row++)
				{
					object obj = this.grdRolePrivileges.GetDataDisplay(_row, 2);
					string _strAllowed = "";
					try
					{
						_strAllowed = obj.ToString();
					}
					catch
					{
						_strAllowed = "False";
					}

					int _isAllowed = _strAllowed == "True" ? 1 : 0;


					string _description = this.grdRolePrivileges.GetDataDisplay(_row, 1);

					Role_Privilege _newRolePrivilege = new Role_Privilege();
					_newRolePrivilege.RoleName = this.cboRoleName.Text;
					_newRolePrivilege.Privilege = _description;
					_newRolePrivilege.Allowed = _isAllowed;
					
					
					_oRolePrivileges.Add(_newRolePrivilege);


				}// end for


				return _oRolePrivileges;

			}

			private string GetRoleDescription(string pRoleName)
			{
				if (tableRoles != null)
				{
					foreach (DataRow _dRow in tableRoles.Rows)
					{
						if (_dRow["RoleName"].ToString() == pRoleName)
						{
							return _dRow["Description"].ToString();
						}
					}
				}
				return "";
			}

			private void btnClose_Click(object sender, EventArgs e)
			{
				this.Close();
			}

			private void cboRoleName_SelectedIndexChanged(object sender, EventArgs e)
			{
				this.MdiParent.Cursor = Cursors.WaitCursor;

				oSystemRoleFacade = new SystemRoleFacade();

				DataTable tableMenus;
				DataTable tableUIPrivileges;
				DataTable tableSystemPrivileges;

				string _roleName = this.cboRoleName.Text;

				tableMenus = oSystemRoleFacade.GetMenus(_roleName);
				tableUIPrivileges = oSystemRoleFacade.getRoleUIPrivileges(_roleName);
				tableSystemPrivileges = oSystemRoleFacade.getRoleSystemPrivileges(_roleName);

				this.txtDescription.Text = GetRoleDescription(this.cboRoleName.Text);

				// initialize to uncheck
				for (int _row = 1; _row < this.grdMenus.Rows.Count; _row++)
				{
					this.grdMenus.SetData(_row, 3, false);
				}


				for (int _row = 1; _row < this.grdMenus.Rows.Count; _row++)
				{
					for (int _col = 0; _col < this.grdMenus.Cols.Count - 1; _col++)
					{
						foreach (DataRow dRow in tableMenus.Rows)
						{
							string _str = this.grdMenus.GetDataDisplay(_row, _col);

							string _menuName = dRow["Menu"].ToString();
							string _enable = dRow["Enable"].ToString();

							if (_str == _menuName && _enable == "1")
							{
								this.grdMenus.SetData(_row, 3, true);
								break;

							}// end if

						}// end inner for

					}// end for

				}//end for


				// ------------------- UI PRIVILEGES
				// initialize to uncheck
				for (int _row = 1; _row < this.grdForms.Rows.Count; _row++)
				{
					this.grdForms.SetData(_row, 3, false);
				}


				foreach (DataRow dRow in tableUIPrivileges.Rows)
				{
					int isVisible = int.Parse(dRow["isVisible"].ToString());

					if (isVisible == 1)
					{
						string _module = dRow["module"].ToString();
						string _formName = dRow["formName"].ToString();
						string _buttonName = dRow["buttonName"].ToString();

						for (int _row = 1; _row < this.grdForms.Rows.Count; _row++)
						{

							string _strModule = "";
							string _strFormName = "";
							string _strButton = "";

							_strModule = this.grdForms.GetDataDisplay(_row, 0);
							if (_strModule == "")
							{
								try
								{
									_strModule = this.grdForms.GetDataDisplay(_row, 4).ToString();
								}
								catch { }
							}

							_strFormName = this.grdForms.GetDataDisplay(_row, 1);
							if (_strFormName == "")
							{
								try
								{
									_strFormName = this.grdForms.GetDataDisplay(_row, 5).ToString();
								}
								catch { }
							}

							_strButton = this.grdForms.GetDataDisplay(_row, 2);


							if (_strModule.ToUpper() == _module.ToUpper() &&
								_strFormName.ToUpper() == _formName.ToUpper() &&
								_strButton.ToUpper() == _buttonName.ToUpper())
							{
								this.grdForms.SetData(_row, 3, true);
								break;
							}

						}// end inner for
					}

				}//end for


				//>> load Role System Privileges

				for (int i = 1; i < this.grdRolePrivileges.Rows.Count; i++)
				{
					this.grdRolePrivileges.SetData(i, 2, false);

					foreach (DataRow _dtRow in tableSystemPrivileges.Rows)
					{
						if (this.grdRolePrivileges.GetDataDisplay(i, 1).ToUpper() == _dtRow["privilegeDescription"].ToString().ToUpper())
						{
							if (_dtRow["isAllowed"].ToString() == "1")
							{
								this.grdRolePrivileges.SetData(i, 2, true);
							}
						}
					}
				}

				this.MdiParent.Cursor = Cursors.Default;
			}

			private void grdMenus_SelChange(object sender, EventArgs e)
			{
				if (this.grdMenus.Col > 2)
				{
					this.grdMenus.AllowEditing = true;
				}
				else
				{
					this.grdMenus.AllowEditing = false;
				}
			}


			private void loadAllUINames()
			{

				string[] DLLs = {  "AccountingInterface.dll",
									"Accounts.dll",
									"Cashier.dll",
									"ConfigurationHotel.dll",
									"NightAudit.dll",
									"Reports.dll",
									"Reservation.dll",
									"Security.dll",
									"Services.dll",
									"Utilities.dll"
								};


				this.grdForms.Rows.Count = 1;
				int i = 1;

				foreach (string _moduleName in DLLs)
				{
					
					Assembly new_assembly;
					Type[] types;
					new_assembly = Assembly.LoadFrom(Application.StartupPath + @"//" + _moduleName);

					types = new_assembly.GetTypes();

					string _namespace = new_assembly.GetName(true).Name;

					this.grdForms.Rows.Count += 1;

					this.grdForms.SetData(i, 4, _namespace);
					this.grdForms.SetData(i, 0, _namespace);
					this.grdForms.Rows[i].Style = this.grdForms.Styles["mainMenu"];
					i++;

					foreach (Type type in types)
					{
						if (!type.IsAbstract)
						{
							if (type.BaseType == typeof(Form))
							{

								this.grdForms.Rows.Count += 1;

								this.grdForms.SetData(i, 4, _namespace);
								this.grdForms.SetData(i, 1, type.Name);
								i++;

								
								ConstructorInfo cInfo = type.GetConstructor(System.Type.EmptyTypes);
								try
								{
									Form frm = (Form)cInfo.Invoke(null);

									loadFormButton((Control)frm, ref i, type.Name, _namespace);

								}
								catch { }

							}
							else
							{
								try
								{
									if (type.BaseType.BaseType == typeof(Form))
									{
										this.grdForms.Rows.Count += 1;

										this.grdForms.SetData(i, 4, _namespace);
										this.grdForms.SetData(i, 1, type.Name);
										i++;


										ConstructorInfo cInfo = type.GetConstructor(System.Type.EmptyTypes);
										try
										{
											Form frm = (Form)cInfo.Invoke(null);

											loadFormButton((Control)frm, ref i, type.Name, _namespace);

										}
										catch { }

									}
								}
								catch { }
							}

						}
					}

				}//end foreach

			}//end loadAllUINames

			private void loadFormButton(Control pControl, ref int i, string pFormName, string pModuleName)
			{
				//int i = this.grdForms.Rows.Count;

				foreach (Control _ctrl in pControl.Controls)
				{
					if (_ctrl is Button)
					{
						
						this.grdForms.Rows.Count += 1;

						this.grdForms.SetData(i, 4, pModuleName);
						this.grdForms.SetData(i, 5, pFormName);

						this.grdForms.SetData(i, 2, _ctrl.Name);
						i++;
					}
					else if (_ctrl is Panel || _ctrl is GroupBox || _ctrl is TabControl)
					{
						loadFormButton(_ctrl, ref i, pFormName, pModuleName);
					}
				}
			}

			private void grdForms_SelChange(object sender, EventArgs e)
			{
				if (this.grdForms.Col > 2)
				{
					this.grdForms.AllowEditing = true;
				}
				else
				{
					this.grdForms.AllowEditing = false;
				}
			}

			private void SystemRoleUI_Shown(object sender, EventArgs e)
			{
				cboRoleName_SelectedIndexChanged(this, new EventArgs());

			}

			private void grdRolePrivileges_SelChange(object sender, EventArgs e)
			{
				if (this.grdRolePrivileges.Col > 1)
				{
					this.grdRolePrivileges.AllowEditing = true;
				}
				else
				{
					this.grdRolePrivileges.AllowEditing = false;
				}
			}



		}
	}
}
