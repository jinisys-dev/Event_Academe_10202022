using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Jinisys.Hotel.AccountingInterface.BusinessLayer;

namespace Jinisys.Hotel.AccountingInterface.Presentation
{
	public partial class TranCode_GLAccountSetup : Form
	{
		private ExactFacade loExactFacade;
		public TranCode_GLAccountSetup()
		{
			InitializeComponent();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void TranCode_GLAccountSetup_Load(object sender, EventArgs e)
		{
			loadData();
		}

		private void loadData()
		{
			loExactFacade = new ExactFacade();

			DataSet objDataSet = loExactFacade.getTransactionCodesWithGLAccounts();

			//this.gridAccounts.DataSource = objDataSet;
			this.dataGridView1.DataSource = objDataSet;

		}

        private void btnNew_Click(object sender, EventArgs e)
        {

        }
	}
}