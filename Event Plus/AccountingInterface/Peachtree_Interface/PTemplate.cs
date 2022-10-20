using System;
using System.Collections;
using System.Text;
using System.Data;

using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.AccountingInterface.Peachtree_Interface
{
    public class PTemplate
    {
        #region getters and setters
        public PTemplate()
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
        #endregion getters and setters

        public static PTemplate[] getAllPTemplates()
        {
            DataTable tblPTemplates = PTemplateDAO.getAllPTemplates();

            PTemplate[] oTemplates = new PTemplate[tblPTemplates.Rows.Count];

            int i = 0;
            foreach (DataRow row in tblPTemplates.Rows)
            {
                oTemplates[i] = new PTemplate();

                oTemplates[i].CreatedBy = row["CreatedBy"].ToString();
                oTemplates[i].CreatedDate = DateTime.Parse(row["CreatedDate"].ToString());
                oTemplates[i].Description = row["Description"].ToString();
                oTemplates[i].Generate = row["Generate"].ToString() == "1" ? true : false;
                oTemplates[i].ID = int.Parse( row["ID"].ToString() );
                oTemplates[i].Name = row["Name"].ToString();
                oTemplates[i].OutputExtension = row["OutputExtension"].ToString();
                oTemplates[i].UpdatedBy = row["UpdatedBy"].ToString();
                oTemplates[i].UpdatedDate = DateTime.Parse( row["UpdatedDate"].ToString() );

                //oTemplates[i].Fields = row["CreatedBy"].ToString();
                DataTable tblPFields = PTemplateDAO.getPTemplateFields(oTemplates[i].Name);
                if (tblPFields != null)
                {
                    foreach (DataRow fRow in tblPFields.Rows)
                    {
                        PTemplateField oField = new PTemplateField();
                        oField.CreatedBy = fRow["CreatedBy"].ToString();
                        oField.CreatedDate = DateTime.Parse( fRow["CreatedDate"].ToString() );
                        oField.Description = fRow["Description"].ToString();
                        oField.ID = int.Parse( fRow["ID"].ToString() );
                        oField.Name = fRow["Name"].ToString();
                        oField.StatusFlag = fRow["StatusFlag"].ToString();
                        oField.TemplateID = oTemplates[i].Name;
                        oField.UpdatedBy = fRow["UpdatedBy"].ToString();
                        oField.UpdatedDate = DateTime.Parse( fRow["UpdatedDate"].ToString() );
                        oTemplates[i].Fields.Add(oField);
                    }
                }

                i++;
            }

            return oTemplates;
        }

        public DataTable getAllTemplates()
        {
            PTemplateDAO _PTEmplateDAO = new PTemplateDAO();
            try
            {
                DataTable _dataTable = _PTEmplateDAO.getAllTemplates();
                return _dataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getTemplateFields(int pTemplateID)
        {
            PTemplateDAO _pTEmplateDAO = new PTemplateDAO();
            try
            {
                DataTable _dataTable = _pTEmplateDAO.getTemplateFields(pTemplateID);
                return _dataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateTemplates(int pTemplateID, string pStatus)
        {
            PTemplateDAO _PTemplateDAO = new PTemplateDAO();
            try
            {
                if (pStatus == "ACTIVE")
                {
                    _PTemplateDAO.updateTemplates(pTemplateID, 1);
                }
                else
                {
                    _PTemplateDAO.updateTemplates(pTemplateID, 0);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateFieldTemplates(int pTemplateID, string pStatus)
        {
            PTemplateDAO _PTemplateDAO = new PTemplateDAO();
            try
            {
                _PTemplateDAO.updateFieldTemplates(pTemplateID, pStatus);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void insertTemplate(PTemplate poPTemplate)
        {
            PTemplateDAO _PTemplateDAO = new PTemplateDAO();
            try
            {
                _PTemplateDAO.insertTemplate(poPTemplate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
