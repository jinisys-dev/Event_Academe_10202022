using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Jinisys.Hotel.AccountingInterface.Presentation
{
	public partial class GLAccountsUI : Form
	{
		public GLAccountsUI()
		{
			InitializeComponent();
		}

		private void GLAccountsUI_Activated(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Maximized;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}