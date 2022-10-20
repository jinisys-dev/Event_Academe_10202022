using System;
using System.Collections.Generic;
using System.Text;

namespace Jinisys.Hotel.AccountingInterface.Peachtree_Interface
{
    public class PTemplateField
    {
        public PTemplateField()
        { }

        private int mID;
        public int ID
        {
            set { this.mID = value; }
            get { return this.mID; }
        }

        private string mTemplateID;
        public string TemplateID
        {
            set { this.mTemplateID = value; }
            get { return this.mTemplateID; }
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


        private string mField_In_Folio;
        public string Field_In_Folio
        {
            set { this.mField_In_Folio = value; }
            get { return this.mField_In_Folio; }
        }

        private string mStatusFlag;
        public string StatusFlag
        {
            set { this.mStatusFlag = value; }
            get { return this.mStatusFlag; }
        }

        private DateTime mCreatedDate;
        public DateTime CreatedDate
        {
            set { this.mCreatedDate = value; }
            get { return this.mCreatedDate; }
        }

        private string mCreatedBy;
        public string CreatedBy
        {
            set { this.mCreatedBy = value; }
            get { return this.mCreatedBy; }
        }

        private DateTime mUpdatedDate;
        public DateTime UpdatedDate
        {
            set { this.mUpdatedDate = value; }
            get { return this.mUpdatedDate; }
        }

        private string mUpdatedBy;
        public string UpdatedBy
        {
            set { this.mUpdatedBy = value; }
            get { return this.mUpdatedBy; }
        }

    }
}
