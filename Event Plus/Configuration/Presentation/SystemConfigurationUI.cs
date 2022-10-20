using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.BusinessSharedClasses;

using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;

namespace Jinisys.Hotel.ConfigurationHotel.Presentation
{
	public partial class SystemConfigurationUI : Jinisys.Hotel.UIFramework.Maintenance2UI
	{
		public SystemConfigurationUI()
		{
			InitializeComponent();
		}

		private void SystemConfigurationUI_Load(object sender, EventArgs e)
		{
			loadData();
		}

		SystemConfigurationFacade loSystemConfigurationFacade;
		private void loadData()
		{
			loSystemConfigurationFacade = new SystemConfigurationFacade();

			IList<SystemConfiguration> _SystemConfigList = loSystemConfigurationFacade.getSystemConfiguration();


			this.grdSystemConfig.Rows.Count = _SystemConfigList.Count + 1;
			int i = 1;
			foreach (SystemConfiguration _oSystemConfig in _SystemConfigList)
			{
				this.grdSystemConfig.SetData(i, 0, i);
				this.grdSystemConfig.SetData(i, 1, _oSystemConfig.Key);
				this.grdSystemConfig.SetData(i, 2, _oSystemConfig.Value);
				this.grdSystemConfig.SetData(i, 3, _oSystemConfig.Description);

				this.grdSystemConfig.SetData(i, 4, _oSystemConfig.Updated_Date);
				this.grdSystemConfig.SetData(i, 5, _oSystemConfig.Updated_By);

				i++;
			}

		}


		private void SystemConfigurationUI_Activated(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Maximized;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void grdSystemConfig_RowColChange(object sender, EventArgs e)
		{
			if (grdSystemConfig.Col == 2 || grdSystemConfig.Col == 3)
			{
				this.grdSystemConfig.StartEditing(this.grdSystemConfig.Row, this.grdSystemConfig.Col); 
			}

		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			loSystemConfigurationFacade = new SystemConfigurationFacade();

			IList<SystemConfiguration> _SystemConfigList = new List<SystemConfiguration>();


			for (int i = 1; i < this.grdSystemConfig.Rows.Count; i++)
			{
				SystemConfiguration _newSystemConfig = new SystemConfiguration();

                _newSystemConfig.Key = GlobalFunctions.addSlashes(this.grdSystemConfig.GetDataDisplay(i, 1));
				_newSystemConfig.Value = GlobalFunctions.addSlashes(this.grdSystemConfig.GetDataDisplay(i, 2));
                _newSystemConfig.Description = GlobalFunctions.addSlashes(this.grdSystemConfig.GetDataDisplay(i, 3));
				

				_SystemConfigList.Add(_newSystemConfig);
			}

			try
			{
				loSystemConfigurationFacade.updateSystemConfiguration(_SystemConfigList);

				MessageBox.Show("Transaction successful.\r\n\r\nSystem configuration updated.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);


			}
			catch(Exception ex)
			{
				MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}


	}
}

