using System;
using System.Collections;
using System.Text;
using System.Data;

using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.AccountingInterface.SAP_Interface
{
    public class Template
    {

        public Template()
        {
        }

        private int mID;
        public int ID
        {
            set { this.mID = value; }
            get { return this.mID; }
        }

        private string mName;
        public string Name
        {
            set { this.mName = value; }
            get { return this.mName; }
        }

        private string mDescription;
        public string Description
        {
            set { this.mDescription = value; }
            get { return this.mDescription; }
        }

        private string mOutputExtension;
        public string OutputExtension
        {
            set { this.mOutputExtension = value; }
            get { return this.mOutputExtension; }
        }

        private bool mGenerate;
        public bool Generate
        {
            set { this.mGenerate = value; }
            get { return this.mGenerate; }
        }

        private string mCreatedBy;
        public string CreatedBy
        {
            set { this.mCreatedBy = value; }
            get { return this.mCreatedBy; }
        }


        private DateTime mCreatedDate;
        public DateTime CreatedDate
        {
            set { this.mCreatedDate = value; }
            get { return this.mCreatedDate; }
        }

        private string mUpdatedBy;
        public string UpdatedBy
        {
            set { this.mUpdatedBy = value; }
            get { return this.mUpdatedBy; }
        }


        private DateTime mUpdatedDate;
        public DateTime UpdatedDate
        {
            set { this.mUpdatedDate = value; }
            get { return this.mUpdatedDate; }
        }

        private ArrayList mFields = new ArrayList();
        public ArrayList Fields
        {
            set { this.mFields = value; }
            get { return this.mFields; }
        }


        public static Template[] getAllTemplates()
        {
            DataTable tblTemplates = TemplateDAO.getAllTemplates(GlobalVariables.gPersistentConnection);

            Template[] oTemplates = new Template[tblTemplates.Rows.Count];

            int i = 0;
            foreach (DataRow row in tblTemplates.Rows)
            {
                oTemplates[i] = new Template();

                oTemplates[i].CreatedBy = row["CreatedBy"].ToString();
                oTemplates[i].CreatedDate = DateTime.Parse( row["CreatedDate"].ToString() );
                oTemplates[i].Description = row["Description"].ToString();
                oTemplates[i].Generate = row["Generate"].ToString() == "1" ? true : false;
                oTemplates[i].ID = int.Parse( row["ID"].ToString() );
                oTemplates[i].Name = row["Name"].ToString();
                oTemplates[i].OutputExtension = row["OutputExtension"].ToString();
                oTemplates[i].UpdatedBy = row["UpdatedBy"].ToString();
                oTemplates[i].UpdatedDate = DateTime.Parse( row["UpdatedDate"].ToString() );

                //oTemplates[i].Fields = row["CreatedBy"].ToString();
                DataTable tblFields = TemplateDAO.getTemplateFields(oTemplates[i].ID, GlobalVariables.gPersistentConnection);
                if (tblFields != null)
                {
                    foreach (DataRow fRow in tblFields.Rows)
                    {
                        TemplateField oField = new TemplateField();
                        oField.CreatedBy = fRow["CreatedBy"].ToString();
                        oField.CreatedDate = DateTime.Parse( fRow["CreatedDate"].ToString() );
                        oField.Description = fRow["Description"].ToString();
                        oField.Field_In_Folio = fRow["Field_In_Folio"].ToString();
                        oField.ID = int.Parse( fRow["ID"].ToString() );
                        oField.Name = fRow["Name"].ToString();
                        oField.StatusFlag = fRow["StatusFlag"].ToString();
                        oField.TemplateID = oTemplates[i].ID;
                        oField.UpdatedBy = fRow["UpdatedBy"].ToString();
                        oField.UpdatedDate = DateTime.Parse( fRow["UpdatedDate"].ToString() );


                        oTemplates[i].Fields.Add(oField);
                    }

                }

                i++;
            }



            return oTemplates;
        }


    }
}
