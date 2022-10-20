using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Jinisys.Hotel.AccountingInterface.Peachtree_Interface
{
    public class TemplateFacade
    {
        private PTemplate initializeTemplate(string pTemplate)
        {
            PTemplate _PTemplate = new PTemplate();
            _PTemplate.Name = pTemplate;
            _PTemplate.Description = pTemplate;
            _PTemplate.OutputExtension = ".csv";
            return _PTemplate;
        }

        private PTemplateField initializeTemplateField(string pName, string pTemplate, string pDescription)
        {
            PTemplateField _PTemplateField = new PTemplateField();
            _PTemplateField.Name = pName;
            _PTemplateField.TemplateID = pTemplate;
            _PTemplateField.Description = pDescription;
            return _PTemplateField;
        }

        public void insertTemplates(DataTable pTemplateDataTable, string pTemplate)
        {
            PTemplateDAO _PTemplateDAO = new PTemplateDAO();
            try
            {
                //insert template
                _PTemplateDAO.insertTemplate(initializeTemplate(pTemplate));
                //insert template fields
                foreach (DataRow _row in pTemplateDataTable.Rows)
                {
                    _PTemplateDAO.insertTemplateFields(initializeTemplateField(_row["TemplateField"].ToString(), _row["Template"].ToString(), _row["TemplateField"].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
