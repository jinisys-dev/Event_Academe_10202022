using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Integrations.BusinessObjects.Facade_Layer;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Integrations.Presentation
{
    public partial class GLMapping : Form
    {
        public GLMapping()
        {
            InitializeComponent();
        }

        private ComboBox cboTransactionCode;
        private ComboBox cboGLAccounts;
        private ComboBox cboGLAccountsName;

        SAPFacade loSAPFacade;
        SAPCompany loSAPCompany;
        DataTable lDtGLAccounts; 
        private void loadDropDowns()
        {
            TransactionCodeFacade oTransactionCodeFacade = new TransactionCodeFacade();
            DataSet odsTranCodes = (DataSet)oTransactionCodeFacade.loadObject();

            DataTable tempTable = odsTranCodes.Tables[0];

            this.cboTransactionCode.DisplayMember = "tranCode";
            this.cboTransactionCode.ValueMember = "tranCode";
            this.cboTransactionCode.DataSource = tempTable;

            lDtGLAccounts =loSAPCompany.getAllGLAccounts();
         
            this.cboGLAccounts.DisplayMember = "AcctCode";
            this.cboGLAccounts.ValueMember = "AcctCode";
            cboGLAccounts.DataSource = lDtGLAccounts;

            this.cboGLAccountsName.DisplayMember = "AcctName";
            this.cboGLAccountsName.ValueMember = "AcctCode";
            cboGLAccountsName.DataSource = lDtGLAccounts;

        }
        private void loadGrid()
        {
            try
            {
                grdGLAccounts.DataSource = loSAPFacade.getGLAccountsMapping();
            }
            catch
            {

            }
        }
        private void initialize()
        {
            loSAPFacade = new SAPFacade();
            cboTransactionCode = new ComboBox();
            cboGLAccounts = new ComboBox();
            cboGLAccountsName = new ComboBox();
            loSAPCompany = new SAPCompany();
            if (!GlobalVariables.goSAPCompany.Connected)
            {
                MessageBox.Show("Unable to connect to SAP");
                this.Close();
            }
            else
            {

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                loSAPFacade.saveTransactionMapping(grdGLAccounts);
                MessageBox.Show("Successfully updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                grdGLAccounts.Rows.Add();
            }
            catch
            {
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                grdGLAccounts.Rows.Remove(grdGLAccounts.Row) ;
            }
            catch
            {
            }
        }

        private void GLMapping_Load(object sender, EventArgs e)
        {
            initialize();
            loadGrid();
            loadDropDowns();
        }
        
        private void grdGLAccounts_BeforeEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            grdGLAccounts.Cols[0].Editor = cboTransactionCode;
            grdGLAccounts.Cols[2].Editor = cboGLAccounts;
            grdGLAccounts.Cols[3].Editor = cboGLAccountsName;
            
         
        }

        private void grdGLAccounts_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (e.Col == 0)
            {
                try
                {
              
                    TransactionCodeFacade _oTransactionCodeFacade = new TransactionCodeFacade();
                    grdGLAccounts.SetData(grdGLAccounts.Row, "FolioTransactionFieldName", _oTransactionCodeFacade.getTransactionCode(cboTransactionCode.Text).Memo);
                }
                catch
                {

                }
            }
            else if (e.Col == 2)
            {
                try
                {
                    //DataView _dtView = new DataView();
                    //_dtView = lDtGLAccounts.Clone().DefaultView;
                    //_dtView.RowFilter = "AcctCode ='" + grdGLAccounts.GetData(grdGLAccounts.Row, 2) + "'";
                    //grdGLAccounts.SetData(grdGLAccounts.Row, 3, _dtView.ToTable().Rows[0][1]);
                }
                catch
                {

                }

            }
            else if (e.Col == 3)
            {
                //DataView _dtView = new DataView();
                //_dtView = lDtGLAccounts.DefaultView;
                //_dtView.RowFilter = "AcctCode ='" + cboGLAccountsName.SelectedValue.ToString() + "'";

                try
                {
                    grdGLAccounts.SetData(grdGLAccounts.Row, 2, cboGLAccountsName.SelectedValue.ToString());
                    grdGLAccounts.SetData(grdGLAccounts.Row, 3, cboGLAccountsName.Text);

                }
                catch
                {
                }

            }
        }

   

      
    }
}