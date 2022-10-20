using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.ConfigurationHotel.DataAccessLayer;
using System.Collections.Generic;

namespace Jinisys.Hotel.ConfigurationHotel.BusinessLayer
{

    public class PackageFacade
    {

        private PackageDAO oPackageDAO;
        public PackageFacade(){}

        public int insertObject(ref PackageHeader a_PackageHeader)
        {
            int rowsAffected = 0;
            oPackageDAO = new PackageDAO();
            rowsAffected = oPackageDAO.insertObject(a_PackageHeader);
            return rowsAffected;
        }
        public int updateObject(ref PackageHeader a_PackageHeader)
        {
            int rowsAffected = 0;
            oPackageDAO = new PackageDAO();
            rowsAffected = oPackageDAO.updateObject(ref a_PackageHeader);
            return rowsAffected;
        }
        public Hashtable getTransactionCodes()
        {
            oPackageDAO = new PackageDAO();
            return oPackageDAO.getTransactionCodes();
        }

        public object loadObject()
        {
            oPackageDAO = new PackageDAO();
            return oPackageDAO.loadObject();
        }

		public IList<PackageDetail> loadPackageDetails(string packageId)
		{
			IList<PackageDetail> _oPackageDetails = new List<PackageDetail>();

			oPackageDAO = new PackageDAO();
			DataTable _dtDetails = oPackageDAO.loadPackageDetails(packageId);

			foreach (DataRow _dRow in _dtDetails.Rows)
			{
				PackageDetail _newPackageDetail = new PackageDetail();
				_newPackageDetail.PackageID = _dRow["PackageID"].ToString();
				_newPackageDetail.TransactionCode = _dRow["TransactionCode"].ToString();
				_newPackageDetail.Memo = _dRow["Memo"].ToString();
				_newPackageDetail.Basis = _dRow["Basis"].ToString();
				_newPackageDetail.PercentOff = decimal.Parse( _dRow["PercentOff"].ToString() );
				_newPackageDetail.AmountOff = decimal.Parse( _dRow["AmountOff"].ToString() );

				_oPackageDetails.Add(_newPackageDetail);
			}

			return _oPackageDetails;
		}

        public int deletePackageDetails(string packageId, string trancode)
        {
            int rowsAffected = 0;
            oPackageDAO = new PackageDAO();
            rowsAffected = oPackageDAO.deletePackageDetail(packageId, trancode);
            return rowsAffected;
        }

        public int deleteObject(ref PackageHeader a_PackageHeader)
        {
            int rowsAffected = 0;
            oPackageDAO = new PackageDAO();
            rowsAffected = oPackageDAO.deleteObject(a_PackageHeader);
            return rowsAffected;
        }

        public IList<PackageHeader> getApplicablePackages()
        {
			oPackageDAO = new PackageDAO();
			IList<PackageHeader> _oPackages = new List<PackageHeader>();

			DataTable _dtPackages = oPackageDAO.getApplicablePackages();

			foreach (DataRow _dRow in _dtPackages.Rows)
			{
				PackageHeader _newPackage = new PackageHeader();
				_newPackage.PackageID = _dRow["PackageID"].ToString();
				_newPackage.Description = _dRow["Description"].ToString();
				_newPackage.FromDate = DateTime.Parse( _dRow["FromDate"].ToString() );
				_newPackage.ToDate = DateTime.Parse( _dRow["ToDate"].ToString() );
				_newPackage.DaysApplied = _dRow["DaysApplied"].ToString();

				_newPackage.PackageDetails = this.loadPackageDetails(_newPackage.PackageID);
				

				_oPackages.Add(_newPackage);
			}

			return _oPackages;
        }

        public IList<PackageHeader> getApplicablePackages(string pStartDate, string pEndDate)
        {
            oPackageDAO = new PackageDAO();
            IList<PackageHeader> _oPackages = new List<PackageHeader>();

            DataTable _dtPackages = oPackageDAO.getApplicablePackages(pStartDate, pEndDate);

            foreach (DataRow _dRow in _dtPackages.Rows)
            {
                PackageHeader _newPackage = new PackageHeader();
                _newPackage.PackageID = _dRow["PackageID"].ToString();
                _newPackage.Description = _dRow["Description"].ToString();
                _newPackage.FromDate = DateTime.Parse(_dRow["FromDate"].ToString());
                _newPackage.ToDate = DateTime.Parse(_dRow["ToDate"].ToString());
                _newPackage.DaysApplied = _dRow["DaysApplied"].ToString();

                _newPackage.PackageDetails = this.loadPackageDetails(_newPackage.PackageID);


                _oPackages.Add(_newPackage);
            }

            return _oPackages;
        }

	

    }
	
}
