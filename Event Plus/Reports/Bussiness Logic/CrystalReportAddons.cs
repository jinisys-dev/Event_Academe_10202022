using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.IO;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.Reports.BusinessLayer
{
    public class CrystalReportAddons
    {

        public static DataTable reportHeader()
        {
            string org;
            string address1;
            string address2;
            string contact;
            string website;

            org = ConfigVariables.gReportOrganization;
            address1 = ConfigVariables.gReportAddress1;
            address2 = ConfigVariables.gReportAddress2;
            contact = ConfigVariables.gReportContactNo;
            website = ConfigVariables.gReportWebsite;

            DataTable dtTable = new DataTable("Images");
            dtTable.Columns.Add("Img",typeof(byte[]));
            dtTable.Columns.Add("Organization",typeof(string));
            dtTable.Columns.Add("Address1",typeof(string));
            dtTable.Columns.Add("Address2",typeof(string));
            dtTable.Columns.Add("ContactNo",typeof(string));
            dtTable.Columns.Add("Website", typeof(string));

            DataRow dRow = dtTable.NewRow();
            
            dRow["Img"] = GlobalVariables.gReportImage;//File.ReadAllBytes(imgPath);
            dRow["Organization"] = org;
            dRow["Address1"] = address1;
            dRow["Address2"] = address2;
            dRow["ContactNo"] = contact;
            dRow["Website"] = website;

            dtTable.Rows.Add(dRow);

            //DataSet imgDataset = new DataSet("ImgDataSet");
            //imgDataset.Tables.Add(dtTable);
            //imgDataset.WriteXmlSchema(System.IO.Directory.GetCurrentDirectory() + "Images.xsd");

            return dtTable;
        }

    }


    
}
