using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.Reports.BusinessLayer;
using System.Reflection;
using System.Collections;
using System.Configuration;
namespace Jinisys.Housekeeping.Reports.Presentation
{
    public partial class HKReportViewerUI : Form
    {
        string reportName;
        ReportFacade oReportFacade;
        public HKReportViewerUI(string pReportName)
        {
            InitializeComponent();
            this.reportName = pReportName;
            oReportFacade = new ReportFacade();
        }

        private void ReportViewerUI_Load(object sender, EventArgs e)
        {
            this.showReport();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.showReport();
        }
        private void showReport()
        {
			this.lblTitle.Text = reportName;

            string fromDate = string.Format("{0:yyyy-MM-dd}", this.dtpFromDate.Value);
            string toDate = string.Format("{0:yyyy-MM-dd}", this.dtpToDate.Value);
            switch (reportName)
            {
                case "Housekeeping Report":
					this.crpViewer.ReportSource = oReportFacade.HK_GetHousekeepingReport(fromDate, toDate);
                    break;
                case "Housekeeping Report by Housekeepers":
					this.crpViewer.ReportSource = oReportFacade.HK_GetHousekeepingReportByHousekeepers(fromDate, toDate);
                    break;
                case "Housekeeper Summary":
					this.crpViewer.ReportSource = oReportFacade.HK_GetHousekeeperSummary(fromDate, toDate);
                    break;
                case "Minibar Sales":
					this.crpViewer.ReportSource = oReportFacade.HK_GetMinibarSalesReport(fromDate, toDate);
                    break;
                case "Minibar Sales By Housekeeper":
					this.crpViewer.ReportSource = oReportFacade.HK_GetMinibarSalesReportByHousekeeper(fromDate, toDate);
                    break;
                case "Minibar Sales By Room":
					this.crpViewer.ReportSource = oReportFacade.HK_GetMinibarSalesReportByRoom(fromDate, toDate);
                    break;
                case "Minibar Sales By Category":
					this.crpViewer.ReportSource = oReportFacade.HK_GetMinibarSalesReportByCategory(fromDate, toDate);
                    break;
                case "Items List":
                     type = new ItemsTypePanel();
					 DataTable cats = oReportFacade.HK_GetCategories();
                    type.DataSource = cats;
                    type.DisplayMember = "CategoryName";
                    type.ValueMember = "CategoryID";
                    type.Dock = DockStyle.Fill;
                    type.BringToFront();
                    type.btnViewClick += new ItemsTypePanel.btnViewEventHandler(btnViewClick);
                    this.groupBox1.Controls.Clear();
                    this.groupBox1.Controls.Add(type);
					this.crpViewer.ReportSource = oReportFacade.HK_GetMinibarItemsList(int.Parse(type.SelectedValue));

                    break;

                  
            }
           
            if (this.crpViewer.ReportSource != null)
            {
                this.crpViewer.Show();

            }
        }
        private ItemsTypePanel type = null;
        private void btnViewClick(Object sender, EventArgs e)
        {
			this.crpViewer.ReportSource = oReportFacade.HK_GetMinibarItemsList(int.Parse(type.SelectedValue));
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.crpViewer.PrintReport();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

		private void HKReportViewerUI_Activated(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Maximized;
		}

      
      
        //private Object CreateObject(String QualifiedName)
        //{
        //    Assembly new_assembly;
        //    String file_name =Application.StartupPath +  ConfigurationManager.AppSettings.Get("AssemblyPath");
        //    new_assembly = Assembly.LoadFrom(file_name);
        //    Type type;
        //    ConstructorInfo ci;
        //    try
        //    {
        //        type = new_assembly.GetType(QualifiedName);

        //        ci = type.GetConstructor(System.Type.EmptyTypes);
        //        Object obj = ci.Invoke(null);
        //        return obj;
        //    }
        //    catch (Exception ex)
        //    {
                
        //        MessageBox.Show("This Feature is not supported in this version!");
        //        return null;
        //    }
           
            
        //}
    }
}