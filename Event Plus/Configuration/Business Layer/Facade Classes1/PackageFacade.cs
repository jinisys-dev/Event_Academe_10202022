using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.Configuration.DataAccessLayer;

namespace Jinisys.Hotel.Configuration.BusinessLayer
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
        public DataTable loadPackageDetails(string packageId)
        {
            oPackageDAO = new PackageDAO();
            return oPackageDAO.loadPackageDetails(packageId);
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




    }
	
}
