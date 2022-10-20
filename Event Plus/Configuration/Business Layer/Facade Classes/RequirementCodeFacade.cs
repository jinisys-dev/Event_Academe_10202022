using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using Jinisys.Hotel.ConfigurationHotel.DataAccessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

//added by Genny - Apr. 25, 2008
//used for the Sales Module
namespace Jinisys.Hotel.ConfigurationHotel.BusinessLayer
{
    public class RequirementCodeFacade
    {
        private RequirementCodeDAO lRequirementCodeDAO;
        public RequirementCodeFacade()
        { }

        #region Requirement Header

        public void insertRequirementCode(RequirementCode pRequirementCode, ref GenericList<RequirementCode> pRequirementCodeList)
        {
            string _requirementID = "";

            lRequirementCodeDAO = new RequirementCodeDAO();
            _requirementID = lRequirementCodeDAO.insertRequirementCode(pRequirementCode);

            pRequirementCode.Requirement_Code = _requirementID;
            pRequirementCodeList.Add(pRequirementCode);
        }

        public GenericList<RequirementCode> getRequirementCodes()
        {
            GenericList<RequirementCode> _requirementCodeList = new GenericList<RequirementCode>();
            lRequirementCodeDAO = new RequirementCodeDAO();
            DataTable _dataTable = lRequirementCodeDAO.getRequirements();
            foreach (DataRow _dataRow in _dataTable.Rows)
            {
                RequirementCode _oRequirementCode = new RequirementCode();
                _oRequirementCode.Requirement_Code = _dataRow["requirementID"].ToString();
                _oRequirementCode.Description = _dataRow["requirementDescription"].ToString();
                _oRequirementCode.TransactionCode = _dataRow["transactionCode"].ToString();

                _requirementCodeList.Add(_oRequirementCode);
            }

            return _requirementCodeList;
        }

        public void deleteRequirement(string pRequirementID, ref GenericList<RequirementCode> pRequirementCodeList)
        {
            try
            {
                lRequirementCodeDAO = new RequirementCodeDAO();
                lRequirementCodeDAO.deleteRequirement(pRequirementID);

                foreach (RequirementCode _oRequirementCode in pRequirementCodeList)
                {
                    if (_oRequirementCode.Requirement_Code == pRequirementID)
                    {
                        pRequirementCodeList.Remove(_oRequirementCode);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateRequirement(RequirementCode pRequirementCode, GenericList<RequirementCode> pRequirementCodeList)
        {
            lRequirementCodeDAO = new RequirementCodeDAO();
            lRequirementCodeDAO.updateRequirement(pRequirementCode);

            foreach (RequirementCode _oRequirementCode in pRequirementCodeList)
            {
                if (_oRequirementCode.Requirement_Code==pRequirementCode.Requirement_Code)
                {
                    _oRequirementCode.Requirement_Code = pRequirementCode.Requirement_Code;
                    _oRequirementCode.Description = pRequirementCode.Description;
                    _oRequirementCode.TransactionCode = pRequirementCode.TransactionCode;

                    break;
                }
            }
        }

        #endregion


        #region Requirement Details

        public GenericList<RequirementCode> getDetailsForRequirements(string pRequirementCode)
        {
            GenericList<RequirementCode> _requirementCodeDetailsList = new GenericList<RequirementCode>();
            lRequirementCodeDAO = new RequirementCodeDAO();
            DataTable _dataTable = lRequirementCodeDAO.getDetailsForRequirements(pRequirementCode);
            foreach (DataRow _dataRow in _dataTable.Rows)
            {
                RequirementCode _oRequirementCodeDetails = new RequirementCode();
                _oRequirementCodeDetails.Description = _dataRow["description"].ToString();

                _requirementCodeDetailsList.Add(_oRequirementCodeDetails);
            }
            return _requirementCodeDetailsList;
        }

        public void insertRequirementDetail(RequirementCode poRequirementCodeDetail)
        {
            lRequirementCodeDAO = new RequirementCodeDAO();
            lRequirementCodeDAO.insertRequirementDetails(poRequirementCodeDetail);
        }

        public void deleteRequirementDetail(string pRequirementID)
        {
            lRequirementCodeDAO = new RequirementCodeDAO();
            lRequirementCodeDAO.deleteRequirementDetails(pRequirementID);
        }

        #endregion
    }
}
