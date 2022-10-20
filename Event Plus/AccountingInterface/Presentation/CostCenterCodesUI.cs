using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Jinisys.Hotel.AccountingInterface.Presentation
{
	public partial class CostCenterCodesUI : Form
	{
		public CostCenterCodesUI()
		{
			InitializeComponent();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void CostCenterCodesUI_Activated(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}