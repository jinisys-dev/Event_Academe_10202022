
using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;

using MySql.Data.MySqlClient;
using System.Collections.Specialized;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Accounts.BusinessLayer;
using Jinisys.Hotel.Services.BusinessLayer;
using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.NightAudit.DataAccessLayer;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.Reports.BusinessLayer;
using Jinisys.Hotel.Reports.DataAccessLayer;
using Jinisys.Hotel.Reports.Presentation;
using Jinisys.Hotel.Cashier.BusinessLayer;
using SAP_SDK_MLine;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using Integrations;
using Integrations.Global;

using Jinisys.Hotel.AccountingInterface.SAP_Interface;
using Integrations.BusinessObjects.Facade_Layer;


namespace Jinisys.Hotel.NightAudit.BusinessLayer
{
    public class PostRoomChargesFacade
    {
        
        public PostRoomChargesFacade()
        {
        }

        Sequence loSequence = new Sequence();


        // a public property for No of Guest Posted
        private int mNoOfGuestPosted = 0;
        public int noOfGuestPosted
        {
            get { return mNoOfGuestPosted; }
            set { mNoOfGuestPosted = value; }
        }



        public bool initializePostRoomCharges()
        {
            
            AuditFacade oAuditFacade = new AuditFacade(GlobalVariables.gPersistentConnection);
            DateTime incrementedDate = DateTime.Parse(GlobalVariables.gAuditDate);
            Audit audit = oAuditFacade.getCurrentAudit(GlobalVariables.gAuditDate);


            if (GlobalVariables.gAuditDate == audit.gAuditDate)
            {

                this.PostRoomCharges(DateTime.Parse(string.Format("{0:yyyy-MM-dd}", DateTime.Parse(GlobalVariables.gAuditDate))));

                //generateReports();
            }
            else
            {
                return false;
            }

            return true;
        }

        public bool initializePostRoomCharges(string folioID)
        {

            AuditFacade oAuditFacade = new AuditFacade(GlobalVariables.gPersistentConnection);
            DateTime incrementedDate = DateTime.Parse(GlobalVariables.gAuditDate);
            Audit audit = oAuditFacade.getCurrentAudit(GlobalVariables.gAuditDate);
            Folio _oFolio = new Folio();
            FolioFacade _oFolioFacade = new FolioFacade();
            _oFolio = _oFolioFacade.GetFolio(folioID);

            if (GlobalVariables.gAuditDate == audit.gAuditDate)
            {
                if (_oFolio.FolioType != "GROUP")
                {
                    if (!(this.PostRoomCharges(DateTime.Parse(string.Format("{0:yyyy-MM-dd}", DateTime.Parse(GlobalVariables.gAuditDate))), folioID)))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!(this.PostGroupCharges(DateTime.Parse(string.Format("{0:yyyy-MM-dd}", DateTime.Parse(GlobalVariables.gAuditDate))), folioID)))
                    {
                        return false;
                    }
                }

                //generateReports();
            }
            else
            {
                return false;
            }

            return true;
        }

        public bool PostFolioTransactions()
        {
            oPostRoomChargesDAO = new PostRoomChargesDAO();
            oPostRoomChargesDAO.PostFolioTransactions(GlobalVariables.gAuditDate);

            return true;
        }

        public bool IncrementgAuditDate()
        {

            AuditFacade oAuditFacade = new AuditFacade(GlobalVariables.gPersistentConnection);

           
            DateTime incrementedDate = DateTime.Parse(GlobalVariables.gAuditDate);
            Audit audit = oAuditFacade.getCurrentAudit(GlobalVariables.gAuditDate);

            //UPDATE CURRENT gAuditDate
            incrementedDate = DateTime.Parse(Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gAuditDate).AddDays(1);
            audit.gAuditDate = string.Format("{0:yyyy-MM-dd}", incrementedDate);
            audit.ShiftCode = Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gShiftCode;
            audit.Meridian = "AM";
            audit.TriggeredBy = GlobalVariables.gLoggedOnUser;

            if (oAuditFacade.SetToProcessed(audit))
            {
                GlobalVariables.gAuditDate = string.Format("{0:yyyy-MM-dd}", incrementedDate);
            }

            return true;
        }

       
        #region " VARIABLES "

        private PostRoomChargesDAO oPostRoomChargesDAO;
        //private FolioTransactionFacade FolioTransactionFacade;

        private HouseKeepingJobFacade oHouseKeepingJobFacade;

        private FolioTransactions oFolioTransCollection;
        private FolioTransaction oFolioTransaction;
        private TransactionCode roomChargeTranCode;


        private Company oCompany;
        private Folio oFolio;
        private CompanyFacade oCompanyFacade;
        private FolioFacade oFolioFacade;

        #endregion
        
        //>>for posting of room charges during night audit
        public bool PostRoomCharges(DateTime postingDate)
        {
            int roomCount = 0;

            oPostRoomChargesDAO = new PostRoomChargesDAO();

            // >> GET "ROOM CHARGE" TRANSACTION CODE AND INFO
            roomChargeTranCode = new TransactionCode();
            roomChargeTranCode = oPostRoomChargesDAO.GetRoomChargeTranCode();

            // >> GET ROOMS TO BE POSTED
            DataTable roomsToCharge = new DataTable();
            roomsToCharge = oPostRoomChargesDAO.GetRoomsToCharge(postingDate);

            if (roomsToCharge.Rows.Count > 0)
            {
                roomCount = roomsToCharge.Rows.Count;

                DataRow dtRow;
                foreach (DataRow tempLoopVar_dtRow in roomsToCharge.Rows)
                {
                    dtRow = tempLoopVar_dtRow;

                    string _folioId = "";
                    _folioId = dtRow["EventId"].ToString();

                    oFolioTransaction = new FolioTransaction();
                    oFolio = GetFolioInfo(dtRow["EventId"].ToString());

                    string _roomId = "";
                    _roomId = dtRow["RoomId"].ToString();
                    decimal _roomRate = 0;
                    _roomRate = decimal.Parse(dtRow["RoomRate"].ToString());
                    long _referenceNo = 0;
                    _referenceNo = loSequence.GetSequenceLongId("seq_autopost");

                    AssignFolioTransValues(oFolioTransaction, oFolio, _roomId, _roomRate, roomChargeTranCode, _referenceNo);

                    //' Apply Folio Privilege here''
                    ApplyPrivileges(oFolioTransaction);

                    //'ApplyFolioPackage HERE''
                    ApplyPackage(oFolioTransaction, System.Convert.ToDecimal(dtRow["RoomRate"]), roomChargeTranCode);

                    //'Apply Folio Routing HERE for those folios that are not GROUP
                    ApplyRouting(oFolioTransaction, oFolio);

                    // > saves in database
                    if (oFolioTransCollection.Count > 0)
                    {
                        AppendFolioTransaction(oFolioTransCollection);
                    }
                    else
                    {
                        AppendFolioTransaction(oFolioTransaction);
                    }

                    oPostRoomChargesDAO.SetRoomAsCharged(dtRow["roomid"].ToString(), postingDate);

                    // >> INSERT RECURRING CHARGES
                    RecurringCharge mRecurringCharge;
                    foreach (RecurringCharge tempLoopVar_mRecurringCharge in oFolio.RecurringCharges)
                    {
                        mRecurringCharge = tempLoopVar_mRecurringCharge;

                        bool _isFound = false;
                        DataTable _oChargedRecurring = new DataTable();
                        _oChargedRecurring = oPostRoomChargesDAO.getChargedRecurringCharges(_folioId, postingDate, mRecurringCharge.TransactionCode);
                        foreach (DataRow _dtRow in _oChargedRecurring.Rows)
                        {
                            if (_dtRow["folioID"].ToString() == _folioId &&
                                _dtRow["hotelID"].ToString() == GlobalVariables.gHotelId.ToString() &&
                                _dtRow["transactionCode"].ToString() == mRecurringCharge.TransactionCode &&
                                _dtRow["memo"].ToString() == mRecurringCharge.Memo)
                            {
                                _isFound = _isFound || true;
                                break;
                            }
                        }

                        //check whether foliotype is group
                        //and whether package is already posted
                        bool _isFromPackagePosted = false;
                        if (oFolio.FolioType != "GROUP")
                        {
                            //    _isFromPackagePosted = oPostRoomChargesDAO.isFromPackageAndIsPosted(_folioId, mRecurringCharge.TransactionCode, mRecurringCharge.Memo, string.Format("{0:yyyy-MM-dd}", postingDate));
                            //}

                            //if (_isFound == false && _isFromPackagePosted == false)
                            //{
                            //>> commented next line and changed date to audit date to trap error of getting recurring charges for the day
                            //if (DateTime.Now.Date >= mRecurringCharge.FromDate && DateTime.Now.Date <= mRecurringCharge.ToDate)
                            if (DateTime.Parse(GlobalVariables.gAuditDate) >= mRecurringCharge.FromDate && DateTime.Parse(GlobalVariables.gAuditDate) <= mRecurringCharge.ToDate)
                            {
                                oFolioTransCollection.Clear();
                                oFolioTransaction = new FolioTransaction();

                                TransactionCode _oTransactionCode = GetTranCode(mRecurringCharge.TransactionCode);
                                _referenceNo = loSequence.GetSequenceLongId("seq_autopost");

                                AssignFolioTransValues(oFolioTransaction, oFolio, "", System.Convert.ToDecimal(mRecurringCharge.Amount), _oTransactionCode, _referenceNo);
                                oFolioTransaction.SummaryFlag = mRecurringCharge.SummaryFlag;
                                oFolioTransaction.PackageName = mRecurringCharge.PackageID.ToString();
                                oFolioTransaction.Memo = mRecurringCharge.Memo + _roomId;
                                oFolioTransaction.TransactionSource = "AUTO";
                                oFolioTransaction.SubAccount = mRecurringCharge.SubAccount;

                                //if (oFolio.FolioType == "GROUP")
                                //{
                                //    EventPackageDetailFacade _oPackageFacade = new EventPackageDetailFacade();
                                //    oFolioTransaction.SubAccount = _oPackageFacade.getSubAccountForPackage(_oTransactionCode.Memo, mRecurringCharge.PackageID.ToString());
                                //}

                                //' Apply Folio Privilege here''
                                ApplyPrivileges(oFolioTransaction);

                                //'ApplyFolioPackage HERE''
                                ApplyPackage(oFolioTransaction, System.Convert.ToDecimal(mRecurringCharge.Amount), _oTransactionCode);

                                //'Apply Folio Routing HERE ''
                                ApplyRouting(oFolioTransaction, oFolio);

                                // > saves in database
                                if (oFolioTransCollection.Count > 0)
                                {
                                    AppendFolioTransaction(oFolioTransCollection);
                                }
                                else
                                {
                                    AppendFolioTransaction(oFolioTransaction);
                                }
                            }
                        }
                        //else
                        //{
                        //}
                    }

                    ////if group, update package and set it to posted
                    //if (oFolio.FolioType == "GROUP")
                    //{
                    //    EventFacade _oEventFacade = new EventFacade();
                    //    _oEventFacade.updateGroupPackage(_folioId);
                    //}

                    //// post GROUP RECURRING CHARGES HERE
                    PostGroupCharges(postingDate, oFolio.FolioID);
                }
                //insertGroupRecurringCharges();
            }

			// SELECT OCCUPIED ROOMS that are FOR-TRANSFER on NEXT AUDITDATE
			// and SET those ROOMS' status to VACANT-DIRTY
			try
			{
				DataTable _oRoomsToBeTransferred = oPostRoomChargesDAO.getRoomsToBeTransferred();

				foreach (DataRow _dRow in _oRoomsToBeTransferred.Rows)
				{
					string _roomId = _dRow["roomId"].ToString();

					RoomFacade _oRoomFacade = new RoomFacade();
					MySqlTransaction _oTrans = GlobalVariables.gPersistentConnection.BeginTransaction();

					_oRoomFacade.setRoomCleaningStatus(_roomId, "DIRTY", ref _oTrans);
					_oRoomFacade.setRoomStatus(_roomId, "VACANT",ref _oTrans);

					_oTrans.Commit();
				}

			}
			catch 
			{
			}

			// select Rooms Transfer Destination and set its Rooms' Status to OCCUPIED
			try
			{
				DataTable _oRoomsToBeTransferred = oPostRoomChargesDAO.getRoomsDestinationForTransfer();

				foreach (DataRow _dRow in _oRoomsToBeTransferred.Rows)
				{
					string _roomId = _dRow["roomId"].ToString();

					MySqlTransaction _oTrans = GlobalVariables.gPersistentConnection.BeginTransaction();

					RoomFacade _oRoomFacade = new RoomFacade();
					_oRoomFacade.setRoomStatus(_roomId, "OCCUPIED",ref _oTrans);

					_oTrans.Commit();
				}

			}
			catch
			{
			}



            // >> Set OCCUPIED ROOMS DIRTY
            if (roomCount > 0)
            {
                oHouseKeepingJobFacade = new HouseKeepingJobFacade();
                oHouseKeepingJobFacade.SetOccupiedRoomsDirty();
            }

            this.mNoOfGuestPosted = roomCount;
            //MessageBox.Show( roomCount + "'    Inhouse Guest Posted..", "Folio Plus", MessageBoxButtons.OK,MessageBoxIcon.Information );
            return true;
        }

        //>>for posting of folio that is only within one day
        public bool PostRoomCharges(DateTime pPostingDate, string pFolioID)
        {
            int _roomCount = 0;

            oPostRoomChargesDAO = new PostRoomChargesDAO();

            // >> GET "ROOM CHARGE" TRANSACTION CODE AND INFO
            roomChargeTranCode = new TransactionCode();
            roomChargeTranCode = oPostRoomChargesDAO.GetRoomChargeTranCode();

            // >> GET ROOMS TO BE POSTED
            DataTable roomsToCharge = new DataTable();
            roomsToCharge = oPostRoomChargesDAO.GetRoomsToCharge(pPostingDate, pFolioID);

            if (roomsToCharge.Rows.Count > 0)
            {
                _roomCount = roomsToCharge.Rows.Count;

                DataRow dtRow;
                foreach (DataRow tempLoopVar_dtRow in roomsToCharge.Rows)
                {
                    dtRow = tempLoopVar_dtRow;
                    oFolioTransaction = new FolioTransaction();
                    oFolioTransCollection = new FolioTransactions();

                    oFolio = GetFolioInfo(dtRow["EventId"].ToString());
                    long _referenceNo = loSequence.GetSequenceLongId("seq_autopost");

                    AssignFolioTransValues(oFolioTransaction, oFolio, dtRow["RoomId"].ToString(), System.Convert.ToDecimal(dtRow["RoomRate"]), roomChargeTranCode, _referenceNo);

                    //'ApplyFolioPackage HERE''
                    ApplyPackage(oFolioTransaction, System.Convert.ToDecimal(dtRow["RoomRate"]), roomChargeTranCode);

                    //' Apply Folio Privilege here''
                    ApplyPrivileges(oFolioTransaction);

                    // > saves in database
                    if (oFolioTransCollection.Count > 0)
                    {
                        AppendFolioTransaction(oFolioTransCollection);
                    }
                    else
                    {
                        AppendFolioTransaction(oFolioTransaction);
                    }

                    oPostRoomChargesDAO.SetRoomAsCharged(dtRow["roomid"].ToString(), pPostingDate);

                    // >> INSERT RECURRING CHARGES
                    RecurringCharge mRecurringCharge;
                    foreach (RecurringCharge tempLoopVar_mRecurringCharge in oFolio.RecurringCharges)
                    {
                        mRecurringCharge = tempLoopVar_mRecurringCharge;

                        bool _isFound = false;
                        DataTable _oChargedRecurring = new DataTable();
                        _oChargedRecurring = oPostRoomChargesDAO.getChargedRecurringCharges(pFolioID, pPostingDate, mRecurringCharge.TransactionCode);
                        foreach (DataRow _dtRow in _oChargedRecurring.Rows)
                        {
                            if (_dtRow["folioID"].ToString() == mRecurringCharge.FolioID &&
                                _dtRow["hotelID"].ToString() == GlobalVariables.gHotelId.ToString() &&
                                _dtRow["transactionCode"].ToString() == mRecurringCharge.TransactionCode)
                            {
                                _isFound = true;
                            }
                        }

                        //check whether foliotype is group
                        //and whether package is already posted
                        bool _isFromPackagePosted = false;
                        _isFromPackagePosted = oPostRoomChargesDAO.isFromPackageAndIsPosted(pFolioID, mRecurringCharge.TransactionCode, mRecurringCharge.Memo, string.Format("{0:yyyy-MM-dd}", pPostingDate));

                        if (_isFound == false && _isFromPackagePosted == false)
                        {
                            //>> commented next line and changed date to audit date to trap error of getting recurring charges for the day
                            //if (DateTime.Now.Date >= mRecurringCharge.FromDate && DateTime.Now.Date <= mRecurringCharge.ToDate)
                            if (DateTime.Parse(GlobalVariables.gAuditDate) >= mRecurringCharge.FromDate && DateTime.Parse(GlobalVariables.gAuditDate) <= mRecurringCharge.ToDate)
                            {
                                oFolioTransCollection.Clear();
                                oFolioTransaction = new FolioTransaction();
                                oFolioTransCollection = new FolioTransactions();

                                TransactionCode _oTransactionCode = GetTranCode(mRecurringCharge.TransactionCode);
                                _oTransactionCode.Memo = mRecurringCharge.Memo;
                                _referenceNo = loSequence.GetSequenceLongId("seq_autopost");

                                AssignFolioTransValues(oFolioTransaction, oFolio, "", System.Convert.ToDecimal(mRecurringCharge.Amount), _oTransactionCode, _referenceNo);
                                oFolioTransaction.SummaryFlag = mRecurringCharge.SummaryFlag;
                                oFolioTransaction.PackageName = mRecurringCharge.PackageID.ToString();
                                oFolioTransaction.Memo = mRecurringCharge.Memo;
                                oFolioTransaction.TransactionSource = "AUTO";

                                //EventPackageDetailFacade _oPackageFacade = new EventPackageDetailFacade();
                                //oFolioTransaction.SubAccount = _oPackageFacade.getSubAccountForPackage(mRecurringCharge.Memo, mRecurringCharge.PackageID.ToString());
                                oFolioTransaction.SubAccount = mRecurringCharge.SubAccount;

                                //'ApplyFolioPackage HERE''
                                ApplyPackage(oFolioTransaction, System.Convert.ToDecimal(mRecurringCharge.Amount), _oTransactionCode);

                                //' Apply Folio Privilege here''
                                ApplyPrivileges(oFolioTransaction);

                                // > saves in database
                                if (oFolioTransCollection.Count > 0)
                                {
                                    AppendFolioTransaction(oFolioTransCollection);
                                }
                                else
                                {
                                    AppendFolioTransaction(oFolioTransaction);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                oFolioTransaction = new FolioTransaction();
                oFolio = GetFolioInfo(pFolioID);

                // >> INSERT RECURRING CHARGES
                RecurringCharge mRecurringCharge;
                foreach (RecurringCharge tempLoopVar_mRecurringCharge in oFolio.RecurringCharges)
                {
                    mRecurringCharge = tempLoopVar_mRecurringCharge;

                    //>> for checking whether certain charge has already been posted
                    bool _isFound = false;
                    DataTable _oChargedRecurring = new DataTable();
                    _oChargedRecurring = oPostRoomChargesDAO.getChargedRecurringCharges(pFolioID, pPostingDate, mRecurringCharge.TransactionCode);
                    foreach (DataRow _dtRow in _oChargedRecurring.Rows)
                    {
                        if (_dtRow["folioID"].ToString() == pFolioID &&
                            _dtRow["hotelID"].ToString() == GlobalVariables.gHotelId.ToString() &&
                            _dtRow["transactionCode"].ToString() == mRecurringCharge.TransactionCode)
                        {
                            _isFound = true;
                        }
                    }

                    //>> to check whether group packages are already posted
                    bool _isGroupPackagePosted = false;
                    EventFacade _oEventFacade = new EventFacade();
                    _isGroupPackagePosted = _oEventFacade.isGroupPackagePosted(pFolioID);

                    if (_isFound == false)
                    {
                        if (mRecurringCharge.PackageID == 0 || (mRecurringCharge.PackageID > 0 && _isGroupPackagePosted == false))
                        {
                            if (DateTime.Parse(GlobalVariables.gAuditDate) >= mRecurringCharge.FromDate && DateTime.Parse(GlobalVariables.gAuditDate) <= mRecurringCharge.ToDate)
                            {
                                oFolioTransaction = new FolioTransaction();
                                oFolioTransCollection = new FolioTransactions();
                                oFolioTransaction.SummaryFlag = mRecurringCharge.SummaryFlag;
                                oFolioTransaction.PackageName = mRecurringCharge.PackageID.ToString();

                                TransactionCode _oTransactionCode = GetTranCode(mRecurringCharge.TransactionCode);
                                _oTransactionCode.Memo = mRecurringCharge.Memo;
                                long _referenceNo = loSequence.GetSequenceLongId("seq_autopost");

                                AssignFolioTransValues(oFolioTransaction, oFolio, "", System.Convert.ToDecimal(mRecurringCharge.Amount), _oTransactionCode, _referenceNo);

                                //'ApplyFolioPackage HERE''
                                ApplyPackage(oFolioTransaction, System.Convert.ToDecimal(mRecurringCharge.Amount), _oTransactionCode);

                                //' Apply Folio Privilege here''
                                ApplyPrivileges(oFolioTransaction);

                                // > saves in database
                                if (oFolioTransCollection.Count > 0)
                                {
                                    AppendFolioTransaction(oFolioTransCollection);
                                }
                                else
                                {
                                    AppendFolioTransaction(oFolioTransaction);
                                }
                            }
                        }
                    }
                }

            }

            // >> Set OCCUPIED ROOMS DIRTY
            if (_roomCount > 0)
            {
                oHouseKeepingJobFacade = new HouseKeepingJobFacade();
                oHouseKeepingJobFacade.SetOccupiedRoomsDirty();
            }
            return true;
        }

        //for posting of group's charges
        public bool PostGroupCharges(DateTime pPostingDate, string pFolioID)
        {
            //int _roomCount = 0;
            //oPostRoomChargesDAO = new PostRoomChargesDAO();

            //// >> GET "ROOM CHARGE" TRANSACTION CODE AND INFO
            //roomChargeTranCode = new TransactionCode();
            //roomChargeTranCode = oPostRoomChargesDAO.GetRoomChargeTranCode();

            //// >> GET ROOMS TO BE POSTED
            //DataTable roomsToCharge = new DataTable();
            //roomsToCharge = oPostRoomChargesDAO.GetRoomsToCharge(pPostingDate, pFolioID);

            //if (roomsToCharge.Rows.Count > 0)
            //{
            //    _roomCount = roomsToCharge.Rows.Count;

            //    DataRow dtRow;
            //    foreach (DataRow tempLoopVar_dtRow in roomsToCharge.Rows)
            //    {
            //        dtRow = tempLoopVar_dtRow;
            //        oFolioTransaction = new FolioTransaction();
            //        oFolioTransCollection = new FolioTransactions();

            //        oFolio = GetFolioInfo(dtRow["EventId"].ToString());
            //        long _referenceNo = loSequence.GetSequenceLongId("seq_autopost");

            //        AssignFolioTransValues(oFolioTransaction, oFolio, dtRow["RoomId"].ToString(), System.Convert.ToDecimal(dtRow["RoomRate"]), roomChargeTranCode, _referenceNo);

            //        //'ApplyFolioPackage HERE''
            //        ApplyPackage(oFolioTransaction, System.Convert.ToDecimal(dtRow["RoomRate"]), roomChargeTranCode);

            //        //' Apply Folio Privilege here''
            //        ApplyPrivileges(oFolioTransaction);

            //        // > saves in database
            //        if (oFolioTransCollection.Count > 0)
            //        {
            //            AppendFolioTransaction(oFolioTransCollection);
            //        }
            //        else
            //        {
            //            AppendFolioTransaction(oFolioTransaction);
            //        }

            //        oPostRoomChargesDAO.SetRoomAsCharged(dtRow["roomid"].ToString(), pPostingDate);
            //    }
            //}
            oFolioTransaction = new FolioTransaction();
            oFolio = GetFolioInfo(pFolioID);

            // >> INSERT RECURRING CHARGES
            RecurringCharge mRecurringCharge;
            foreach (RecurringCharge tempLoopVar_mRecurringCharge in oFolio.RecurringCharges)
            {
                mRecurringCharge = tempLoopVar_mRecurringCharge;
                if (mRecurringCharge.TransactionCode != ConfigVariables.gRoomChargeTransactionCode && mRecurringCharge.Memo != "FOOD")
                {
                    mRecurringCharge.Memo = mRecurringCharge.QtyHrs + " " + mRecurringCharge.Memo;
                }
                bool _isFound = false;
                DataTable _oChargedRecurring = new DataTable();
                oPostRoomChargesDAO = new PostRoomChargesDAO();
                _oChargedRecurring = oPostRoomChargesDAO.getChargedRecurringCharges(pFolioID, pPostingDate, mRecurringCharge.TransactionCode);
                foreach (DataRow _dtRow in _oChargedRecurring.Rows)
                {
                    //Kevin L Oliveros
                    
                        decimal _amount = 0;
                        decimal.TryParse(_dtRow["amount"].ToString(), out _amount);
                        if (_dtRow["folioID"].ToString() == pFolioID &&
                            _dtRow["hotelID"].ToString() == GlobalVariables.gHotelId.ToString() &&
                            _dtRow["transactionCode"].ToString() == mRecurringCharge.TransactionCode &&
                            _dtRow["memo"].ToString() == mRecurringCharge.Memo &&
                            _amount == (mRecurringCharge.BaseAmount * mRecurringCharge.QtyHrs)
                            // to allow posting of event charges with same amount but with different room
                            // changed spGetChargedRecurringCharges, please see comment
                            // Clark 08.11.2011
                            && _dtRow["roomID"].ToString() == mRecurringCharge.RoomID
                            )
                        {
                            _isFound = true;
                        }
                   
                }

                if (_isFound == false)
                {
                    // changed the AuditDate to pPostingDate to allow posting of charges of previous dates
                    // also include the Date property of the conditions
                    // Clark 08.10.2011

                    //>> commented next line and changed date to audit date to trap error of getting recurring charges for the day
                    //if (DateTime.Now.Date >= mRecurringCharge.FromDate && DateTime.Now.Date <= mRecurringCharge.ToDate)
                    if (pPostingDate.Date >= mRecurringCharge.FromDate.Date && pPostingDate.Date <= mRecurringCharge.ToDate.Date && mRecurringCharge.TransactionCode != ConfigVariables.gContingencyCode)
                    {
                        oFolioTransaction = new FolioTransaction();
                        oFolioTransCollection = new FolioTransactions();
                        oFolioTransaction.SummaryFlag = mRecurringCharge.SummaryFlag;
                        oFolioTransaction.PackageName = mRecurringCharge.PackageID.ToString();
                        oFolioTransaction.RoomID = mRecurringCharge.RoomID;
                        oFolioTransaction.Discount = mRecurringCharge.Discount;
                        oFolioTransaction.BaseAmount = mRecurringCharge.BaseAmount;
                        oFolioTransaction.GovernmentTax = mRecurringCharge.Tax;
                        EventPackageDetailFacade _oPackageFacade = new EventPackageDetailFacade();

                        TransactionCode _oTransactionCode = GetTranCode(mRecurringCharge.TransactionCode);
                        _oTransactionCode.Memo = mRecurringCharge.Memo;
                        long _referenceNo = loSequence.GetSequenceLongId("seq_autopost");

                        AssignFolioTransValues(oFolioTransaction, oFolio, "", System.Convert.ToDecimal(mRecurringCharge.Amount), _oTransactionCode, _referenceNo);
                        //oFolioTransaction.SubAccount = _oPackageFacade.getSubAccountForPackage(_oTransactionCode.Memo, mRecurringCharge.PackageID.ToString());
                        oFolioTransaction.SubAccount = mRecurringCharge.SubAccount;
                        oFolioTransaction.TransactionSource = "AUTO";

                        // to allow previous date posting
                        // Clark 08.11.2011
                        oFolioTransaction.TransactionDate = pPostingDate;

                        //'ApplyFolioPackage HERE''
                        ApplyPackage(oFolioTransaction, System.Convert.ToDecimal(mRecurringCharge.Amount), _oTransactionCode);

                        //' Apply Folio Privilege here''
                        ApplyPrivileges(oFolioTransaction);

                        //for picc by jlo
                        if (ConfigVariables.gIsEMMOnly == "true")
                        {
                            oFolioTransaction.BaseAmount = mRecurringCharge.BaseAmount * mRecurringCharge.QtyHrs;
                            oFolioTransaction.Discount = oFolioTransaction.BaseAmount * mRecurringCharge.Discount / 100;
                            oFolioTransaction.GovernmentTax = (oFolioTransaction.BaseAmount - oFolioTransaction.Discount) * (mRecurringCharge.Tax / 100);
                            oFolioTransaction.NetBaseAmount = oFolioTransaction.BaseAmount - oFolioTransaction.Discount + oFolioTransaction.GovernmentTax;
                        }

                        // > saves in database
                        if (oFolioTransCollection.Count > 0)
                        {
                            AppendFolioTransaction(oFolioTransCollection);
                        }
                        else
                        {
                            AppendFolioTransaction(oFolioTransaction);
                        }
                    }
                }

            }

            //// >> Set OCCUPIED ROOMS DIRTY
            //if (_roomCount > 0)
            //{
            //    oHouseKeepingJobFacade = new HouseKeepingJobFacade();
            //    oHouseKeepingJobFacade.SetOccupiedRoomsDirty();
            //}

            //post to sap
            // postToSAP(pFolioID); -- method transfer to a new button btnPostToAccounting

            return true;
        }

        private string arrayToString(double[] pArray)
        {
            string _str = "{";
            foreach (double item in pArray)
            {
                _str = _str + item.ToString() + ",";
            }

            if (_str != "")
            {
                _str = _str.Substring(0, _str.Length - 1);
            }

            _str = _str + "}";

            return _str;
        }


        private string arrayToString(int[] pArray)
        {
            string _str = "{";
            foreach (int item in pArray)
            {
                _str = _str + item.ToString() + ",";
            }

            if (_str != "")
            {
                _str = _str.Substring(0, _str.Length - 1);
            }

            _str = _str + "}";

            return _str;
        }

        private string arrayToString(string[] pArray)
        {
            string _str = "{";
            foreach (string item in pArray)
            {
                _str = _str + item + ",";
            }

            if (_str != "")
            {
                _str = _str.Substring(0, _str.Length - 1);
            }

            _str = _str + "}";

            return _str;
        }

        public void postToSAP(string pFolioId)
        {
            Folio _oFolio = new Folio();
            FolioFacade _oFolioFacade = new FolioFacade();
            _oFolio = _oFolioFacade.GetFolio(pFolioId);

            bool isCompany = true;
            Company _company = new Company();
            Guest _guest = new Guest();
            string _tempHolderGuest = "";

            if (_oFolio.CompanyID.StartsWith("G-"))
            {
                isCompany = true;
                CompanyFacade _oCompanyFacade = new CompanyFacade();
                _company = _oCompanyFacade.getCompanyAccount(_oFolio.CompanyID);
            }
            else
            {
                isCompany = false;
                GuestFacade _oGuestFacade = new GuestFacade();
                _guest = _oGuestFacade.getGuestRecord(_oFolio.CompanyID);
            }

            PostRoomChargesDAO _postRoomChargesDAO = new PostRoomChargesDAO();
            DataTable _dt = _postRoomChargesDAO.getNonAuditCharges(pFolioId);
            
            string[] _description = new string[_dt.Rows.Count];
            double[] _amount = new double[_dt.Rows.Count];
            int[] _taxPercent = new int[_dt.Rows.Count];
            double[] _discountPercent = new double[_dt.Rows.Count];

            int _rows = 0;
            foreach (DataRow _dRow in _dt.Rows)
            {
                _description[_rows] = _dRow["memo"].ToString();
                double.TryParse(_dRow["netAmount"].ToString(),out _amount[_rows]);
                double _net = 0;
                double _tax = 0;
                double.TryParse(_dRow["netAmount"].ToString(), out _net);
                double.TryParse(_dRow["governmentTax"].ToString(), out _tax);
                double _test = _tax / (_net - _tax);
                _taxPercent[_rows] = Convert.ToInt32(_test);
                double _base = 0;
                double _discount = 0;
                double.TryParse(_dRow["baseAmount"].ToString(), out _base);
                double.TryParse(_dRow["discount"].ToString(), out _discount);
                _discountPercent[_rows] = _discount / _base;
                _rows++;

            }

            if (ConfigVariables.gSAPServer != "")
            {
                try
                {

                    //SAPIntegration.SAPCompany _oCompany = new SAPIntegration.SAPCompany();


                    SAPCompany _oCompany = new SAPCompany();

                    if(GlobalVariables.goIsConnectedToBackOffice == false)
                    {

                        MessageBox.Show("Unable to connect to SAP Server!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    
                    }
                  
                    string _str = "";
                    if (_oFolio.CompanyID.StartsWith("G-"))
                    {
                        _str = _company.CompanyName;
                    }
                    else
                    {
                        _str = _guest.AccountName;
                    }

                    try
                    {
                        _oCompany.addClient(_oFolio.CompanyID, _str);
                    }
                    catch
                    {
        
                    }
                 
                    DataTable _ARInvoice = _oCompany.getARInvoiceFormat(SAPVariables.INVOICETYPE.SERVICE);

          
                    //foreach (DataRow _row in _dt.Rows)
                    //{
                    //    DataRow _rowAR = _ARInvoice.NewRow();
                    //    _rowAR["ITEMCODE"] = "SD001";
                    //    _rowAR["ITEMNAME"] = "TESTING";
                    //    _rowAR["QUANTITY"] = "345";
                    //    _rowAR["UNITPRICE"] = "0";
                    //    _rowAR["DISCOUNTPERCENT"] = "0";
                    //    _rowAR["WAREHOUSECODE"] = "01";
                    //    _rowAR["LINETOTAL"] = "5656";
                    //    _rowAR["SERIALNUMBERS"] = "SD001";   
                    //    _ARInvoice.Rows.Add(_rowAR);
                    //}

                    GLaccountDAO oGLaccountsDAO = new GLaccountDAO();
                    ArrayList _ArrayFolioLGLMapping = Folio_GLAccountMapping.getTransactionCodeMapping("200002021",GlobalVariables.gPersistentConnection);

                    DataTable tempTable = GLaccountDAO.getAllGLaccounts(GlobalVariables.gHotelId, GlobalVariables.gPersistentConnection);


                    double _totalAmount = 0;
                    foreach (DataRow _row in _dt.Rows)
                    {
                        if (!_row["memo"].ToString().Contains("PAYMENTS"))
                        {
                            DataRow _rowAR = _ARInvoice.NewRow();
                            //_rowAR["SERVICEDESCRIPTION"] = _row["memo"];///_row["transactionCode"]                              
                            //_rowAR["GLACCOUNT"] = "_SYS00000000167";//"200002021";
                            //_rowAR["DISCOUNTPERCENT"] = 0;
                            //_rowAR["AMOUNT"] = _row["grossAmount"];
                            _totalAmount += double.Parse(_row["grossAmount"].ToString());
                            //_ARInvoice.Rows.Add(_rowAR);

                        }
                    }

                    SAPFacade _oSapFacade = new SAPFacade();
                    DataTable _dtGLAccountsmapping = _oSapFacade.getGLAccountsMapping();
                    DataView _dtViewMapping = _dtGLAccountsmapping.DefaultView;
                    _dtViewMapping.RowFilter = "FolioTransactionFieldName = 'TOTAL CHARGES POST TO SAP'";


                    if (_totalAmount > 0)
                    {
                        DataRow _rowA = _ARInvoice.NewRow();
                        _rowA["SERVICEDESCRIPTION"] = "TOTAL CHARGES FROM EVENT PLUS " + DateTime.Now;///_row["transactionCode"]                              
                        _rowA["GLACCOUNT"] = _dtViewMapping.ToTable().Rows[0]["GLAccountCode"].ToString();//"_SYS00000000014";//"_SYS00000000167";//"200002021";
                        _rowA["DISCOUNTPERCENT"] = 0;
                        _rowA["AMOUNT"] = _totalAmount.ToString();
                        _ARInvoice.Rows.Add(_rowA);
                    }

                    try
                    {
                        if (_oCompany.addARInvoice(_ARInvoice, SAPVariables.INVOICETYPE.SERVICE, _oFolio.CompanyID, DateTime.Now, "POSTED FROM EVENT PLUS " + DateTime.Now, _oFolio.FolioID
                                             , _oFolio.CreateTime, _oFolio.ReferenceNo, _oFolio.FromDate, _oFolio.Todate, _oFolio.GroupName, getRoomsForIntegration("ROOMID", pFolioId), getRoomsForIntegration("VENUE", pFolioId)))
                        {
                            //MessageBox.Show("An error occured in Posting to AR Invoice please check the data posted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                           // return;
                            _postRoomChargesDAO.postFolioTransactions(pFolioId);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("An error occurred during inserting charges to SAP!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }



                    //_oCompany.postARInvoice(pFolioId,
                                            
                    //addon _integration;
                    ////Jinisys.Hotel.SAPCompany _SAPsCompany = new S 
                    //if (ConfigVariables.gSAPDBUsername != "" && ConfigVariables.gSAPDBPassword != "" && ConfigVariables.gSAPCompanyDB != "" && ConfigVariables.gSAPUsername != "" && ConfigVariables.gSAPPassword != "")
                    //{
                    //    _integration = new addon(ConfigVariables.gSAPServer, ConfigVariables.gSAPDBUsername, ConfigVariables.gSAPDBPassword, ConfigVariables.gSAPCompanyDB, ConfigVariables.gSAPUsername, ConfigVariables.gSAPPassword);
                    //}
                    //else
                    //{
                    //    _integration = new addon(ConfigVariables.gSAPServer);
                    //}
                    //string _error = "";

                    //try
                    //{
                    //    string _cardCode = "";
                    //    if (isCompany)
                    //    {
                    //        _error = "Integration.eventPlusToSAPB1_BP(" + _company.CompanyName + ");";
                    //        //MessageBox.Show("BEFORE : " + _error, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        _cardCode = _integration.eventPlusToSAPB1_BP(_company.CompanyName);
                    //        //MessageBox.Show("AFTER : " + _error, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    }
                    //    else
                    //    {
                    //        _error = "Integration.eventPlusToSAPB1_BP(" + _guest.LastName + ", " + _guest.FirstName + ");";
                    //        //MessageBox.Show("BEFORE : " + _error, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        _cardCode = _integration.eventPlusToSAPB1_BP(_guest.LastName + ", " + _guest.FirstName);
                    //        //MessageBox.Show("AFTER : " + _error, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    }
                    //    if (_cardCode != "")
                    //    {
                    //        _error = "Inegration.eventPlusToSAPB1_SOMLine(" + _cardCode + ", " + _oFolio.CreateTime + ", " + _oFolio.ReferenceNo + ", " + _oFolio.FromDate + ", " + _oFolio.Todate + ", " + _oFolio.FolioID + ", " + _oFolio.GroupName + ", " + _oFolio.CompanyID + ", " + getRoomsForIntegration("ROOMID", pFolioId) + ", " + getRoomsForIntegration("VENUE", pFolioId) + ", " + arrayToString(_description) + "," + arrayToString(_amount) + "," + arrayToString(_taxPercent) + "," + arrayToString(_discountPercent) + ")";
                    //        //MessageBox.Show("BEFORE : " + _error, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        //if (!_integration.eventPlusToSAPB1_SO(_cardCode, DateTime.Parse(txtCreateTime.Text), txtReferenceNo.Text, loFolio.FromDate, loFolio.Todate, txtFolioID.Text, txtGroupName.Text, txtcompanyid.Text, getRoomsForIntegration(0), getRoomsForIntegration(2), double.Parse(txtContractAmount.Value.ToString())))
                    //        if (!_integration.eventPlusToSABB1_SOMLine(_cardCode, _oFolio.CreateTime, _oFolio.ReferenceNo, _oFolio.FromDate, _oFolio.Todate, _oFolio.FolioID, _oFolio.GroupName, _oFolio.CompanyID, getRoomsForIntegration("ROOMID", pFolioId), getRoomsForIntegration("VENUE", pFolioId), _description, _amount, _taxPercent, _discountPercent))
                    //        {
                    //            MessageBox.Show("Sales Order for SAP integration failed. Please check settings for integration.", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        }
                    //        else
                    //        {

                    //            _postRoomChargesDAO.postFolioTransactions(pFolioId);
                    //        }
                    //        //MessageBox.Show("AFTER : " + _error, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("SAP Integration did not return a cardcode value.", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    }
                    //    _integration.Dispose();
                    //}
                    //catch (Exception ex)
                    //{
                    //    _integration.Dispose();
                    //    MessageBox.Show("There was a problem with SAP integration\r\nMethod: " + _error + "\r\nError: " + ex.Message, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to connect to SAP Server for integration.\r\n Please check the server IP settigns in Event Plus.\r\nError: " + ex.Message, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string getRoomsForIntegration(string pColumn, string pFolioId)
        {
            ScheduleFacade _oScheduleFacade = new ScheduleFacade();
            System.Collections.Generic.IList<Schedule> _schedules = _oScheduleFacade.getFolioScheduleList(pFolioId);
            
            string _rooms = "";
            string _str = "";
            for (int i = 0; i < _schedules.Count; i++)
            {
                if (pColumn == "ROOMID")
                {
                    _str = _schedules[i].RoomID;
                }
                else
                {
                    _str = _schedules[i].Venue;
                }
                if (!_rooms.Contains(_str))
                {
                    _rooms = _rooms + _str + "/";
                }
            }
            if (_rooms != "")
            {
                _rooms = _rooms.Substring(0, _rooms.Length - 1);
            }
            return _rooms;
        }

        private bool insertGroupRecurringCharges()
        {
            //FolioTransactions folioTransCollection = new FolioTransactions();

            //oPostRoomChargesDAO = new PostRoomChargesDAO();
            //DataTable dtRecurringCharges = new DataTable();
            //dtRecurringCharges = oPostRoomChargesDAO.getGroupRecurringCharges();

            //foreach (DataRow dRow in dtRecurringCharges.Rows)
            //{
            //    FolioTransaction mFolioTransaction = new FolioTransaction();

            //    Folio companyFolio = new Folio();
            //    companyFolio.FolioID = dRow["FolioId"].ToString();
            //    companyFolio.AccountID = dRow["CompanyID"].ToString();

            //    TransactionCode transactionCode = new TransactionCode();
            //    transactionCode = GetTranCode(dRow["TransactionCode"].ToString());
            //    mFolioTransaction.TransactionSource = "AUTO-POST";

            //    AssignFolioTransValues(mFolioTransaction, companyFolio, "", decimal.Parse(dRow["Amount"].ToString()), transactionCode);

            //    folioTransCollection.Add(mFolioTransaction);
            //}
            //// > saves in database
            //if (folioTransCollection.Count > 0)
            //{
            //    AppendFolioTransaction(folioTransCollection);
            //}


            return true;
        }

        private Folio GetFolioInfo(string folioId)
        {
            try
            {
                oFolio = new Folio();
                oFolioFacade = new FolioFacade();
                oFolio = oFolioFacade.GetGuestFolioInfo(folioId);

                switch (oFolio.FolioType)
                {
                    case "DEPENDENT":

                        oCompany = new Company();
                        oCompanyFacade = new CompanyFacade();
                        oCompany = oCompanyFacade.getCompanyInfo(oFolio.MasterFolio);

						if (oCompany != null)
						{
							oFolio.CompanyID = oCompany.CompanyId;
						}

                        break;
                }

                return oFolio;

            }
            catch (Exception)
            {
                //msgBox(ex.Message)
            }
            return null;
        }

        private ArrayList GetShareFolio(Folio a_Folio)
        {
            try
            {

                ArrayList oFolios = new ArrayList();
                ArrayList folioIds = new ArrayList();
                oPostRoomChargesDAO = new PostRoomChargesDAO();
                folioIds = oPostRoomChargesDAO.getShareFolioIds(a_Folio.FolioID);

                for (int i = 0; i < folioIds.Count; i++)
                {
                    Folio mFolio = new Folio();
                    oFolioFacade = new FolioFacade();
                    mFolio = oFolioFacade.GetGuestFolioInfo(folioIds[i].ToString());

                    if (mFolio != null)
                    {
                        oFolios.Add(mFolio);
                    }
                }

                return oFolios;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


		private void AssignFolioTransValues(FolioTransaction poFolioTransaction, Folio oGuestFolio, string pRoomNo, decimal pAmount, TransactionCode poTransactionCode, long pReferenceNo)
        {
			// set mealAmount if ROOM CHARGE
			decimal _mealAmount = 0;
			// to get Folio Information(esp No. Of Pax, VatExempt)
			oFolioFacade = new FolioFacade();
			oFolio = oFolioFacade.GetFolio(oGuestFolio.FolioID);

			if (poTransactionCode.TranCode == "1000")
			{

				// get Schedule Info(esp rate type and breakfast component
				ScheduleFacade oScheduleFacade = new ScheduleFacade();
				Schedule oSched = oScheduleFacade.GetSchedule(oFolio.FolioID);

				RateTypeFacade oRateTypeFacade = new RateTypeFacade();
				RateType oMyRate = oRateTypeFacade.getRateType(oSched.RoomType, oSched.RateType);

				if (oMyRate != null)
				{
					if (oSched.BreakFast == "Y")
					{
						_mealAmount = oMyRate.BreakfastAmount;

						// multiply by number of Pax
						if (oFolio.NoofAdults > 1)
						{

							_mealAmount = _mealAmount * oFolio.NoofAdults;

						}
					}
				}

                //check whether meal amount < rate amount
                if (_mealAmount >= pAmount)
                {
                    _mealAmount = 0;
                }
			}
			// end mealAmount

			bool _inclusiveGovTax = true;
			bool _inclusiveLocalTax = true;
			bool _inclusiveServiceCharge = true;

			decimal _govtTaxPercent = 0;
			decimal _localTaxPercent = 0;
			decimal _serviceChargePercent = 0;

			decimal _govtTaxAmount = 0;
			decimal _localTaxAmount = 0;
			decimal _serviceChargeAmount = 0;

			poFolioTransaction.HotelID = GlobalVariables.gHotelId;
			poFolioTransaction.TransactionDate = DateTime.Parse(GlobalVariables.gAuditDate);
			poFolioTransaction.FolioID = oGuestFolio.FolioID;
			poFolioTransaction.SubFolio = "A";
            if (oGuestFolio.AccountID != null && oGuestFolio.AccountID!="")
            {
                poFolioTransaction.AccountID = oGuestFolio.AccountID;
            }
            else
            {
                poFolioTransaction.AccountID = oGuestFolio.CompanyID;
            }

			poFolioTransaction.TransactionCode = poTransactionCode.TranCode;
			poFolioTransaction.ReferenceNo = pReferenceNo.ToString();
			poFolioTransaction.TransactionSource = poTransactionCode.DefaultTransactionSource;
			poFolioTransaction.Memo = poTransactionCode.Memo + pRoomNo;

			poFolioTransaction.AcctSide = poTransactionCode.AcctSide;
			poFolioTransaction.CurrencyCode = "PHP";
			poFolioTransaction.ConversionRate = 1;
			poFolioTransaction.CurrencyAmount = pAmount;

			poFolioTransaction.Discount = 0;

			// BaseAmount = Currency Amount * Exchange Rate
			decimal _baseAmount = poFolioTransaction.CurrencyAmount * poFolioTransaction.ConversionRate;

			poFolioTransaction.BaseAmount = _baseAmount;
			poFolioTransaction.GrossAmount = pAmount;


			// deduct discount b4 applying Tax & Service Charge
			_baseAmount = _baseAmount - poFolioTransaction.Discount;


			_inclusiveGovTax = poTransactionCode.GovtTaxInclusive == 1 ? true : false;
			_inclusiveLocalTax = poTransactionCode.LocalTaxInclusive == 1 ? true : false;
			_inclusiveServiceCharge = poTransactionCode.ServiceChargeInclusive == 1 ? true : false;

			_govtTaxPercent = poTransactionCode.GovtTax / 100;
			_localTaxPercent = poTransactionCode.LocalTax / 100;
			_serviceChargePercent = poTransactionCode.ServiceCharge / 100;


			//>> get Total Inclusive Charges
			decimal _totalInclusive = 0;
			if (_inclusiveGovTax)
			{
				_totalInclusive += _govtTaxPercent;
			}

			if (_inclusiveLocalTax)
			{
				_totalInclusive += _localTaxPercent;
			}

			if (_inclusiveServiceCharge)
			{
				_totalInclusive += _serviceChargePercent;
			}
			//>> end get Total Inclusive Charges

			decimal _amountAfterDeductInclusiveCharges = _baseAmount / (1 + _totalInclusive);

			//>> compute Government Tax
			if (_govtTaxPercent > 0)
			{
				if (_inclusiveGovTax)
				{
					_govtTaxAmount = _amountAfterDeductInclusiveCharges * _govtTaxPercent;
				}
				else
				{
					_govtTaxAmount = _baseAmount * _govtTaxPercent;
				}
			}
			//>> end compute Government Tax

			//>> compute Local Tax
			if (_localTaxPercent > 0)
			{
				if (_inclusiveLocalTax)
				{
					_localTaxAmount = _amountAfterDeductInclusiveCharges * _localTaxPercent;
				}
				else
				{
					_localTaxAmount = _baseAmount * _localTaxPercent;
				}
			}
			//>> end compute Local Tax


			//>> compute Service Charge
			if (_serviceChargePercent > 0)
			{
				if (_inclusiveServiceCharge)
				{
					_serviceChargeAmount = _amountAfterDeductInclusiveCharges * _serviceChargePercent;
				}
				else
				{
					_serviceChargeAmount = _baseAmount * _serviceChargePercent;
				}
			}
			//>> end compute Service Charge


			poFolioTransaction.NetAmount = poFolioTransaction.GrossAmount - poFolioTransaction.Discount; //System.Convert.ToDouble(poFolioTransaction.BaseAmount - poFolioTransaction.Discount);

			poFolioTransaction.NetBaseAmount = poFolioTransaction.BaseAmount - poFolioTransaction.Discount;

			poFolioTransaction.NetBaseAmount = _amountAfterDeductInclusiveCharges;
			poFolioTransaction.GovernmentTax = _govtTaxAmount;
			poFolioTransaction.LocalTax = _localTaxAmount;
			poFolioTransaction.ServiceCharge = _serviceChargeAmount;

			poFolioTransaction.GovernmentTaxInclusive = _inclusiveGovTax == true ? 1 : 0;
			poFolioTransaction.LocalTaxInclusive = _inclusiveLocalTax == true ? 1 : 0;
			poFolioTransaction.ServiceChargeInclusive = _inclusiveServiceCharge == true ? 1 : 0;


			poFolioTransaction.MealAmount = _mealAmount;
			poFolioTransaction.NetBaseAmount -= poFolioTransaction.MealAmount;

			poFolioTransaction.RouteSequence = "";
			poFolioTransaction.SourceFolio = "";
			poFolioTransaction.SourceSubFolio = "";
			poFolioTransaction.TerminalID = GlobalVariables.gTerminalID.ToString();
			poFolioTransaction.CreatedBy = GlobalVariables.gLoggedOnUser;

			// new, Jrom, April 26, 2008
			// Golden prince requirement

			poFolioTransaction.CreditCardNo = "";
			poFolioTransaction.ChequeNo = "";
			poFolioTransaction.AccountName = "";
			poFolioTransaction.BankName = "";
			poFolioTransaction.ChequeDate = "1900-01-01";
			poFolioTransaction.FOCGrantedBy = "";

			poFolioTransaction.CreditCardType = "";
			poFolioTransaction.ApprovalSlip = "";
			poFolioTransaction.SubAccount = "";
			poFolioTransaction.CreditCardExpiry = "1900-01-01";
        }

        // >> APPLY PACKAGE
        private FolioPackage oPackage;
        private void ApplyPackage(FolioTransaction poFolioTransaction, decimal Amount, TransactionCode poTransactionCode)
        {
            try
            {
				bool _inclusiveGovTax = true;
				bool _inclusiveLocalTax = true;
				bool _inclusiveServiceCharge = true;


                oFolioFacade = new FolioFacade();
                oPackage = new FolioPackage();
                oPackage = oFolioFacade.GetFolioTransPackage(poFolioTransaction.FolioID, poFolioTransaction.TransactionCode);

                //check if transaction to be discounted has high discount than the package
                if (hasHighDiscount(poFolioTransaction.TransactionCode, "PACKAGE", oFolio) == false)
                {
                    return;
                }

                if (oPackage != null)
                {

					//FolioTransaction _oFolioTransaction = poFolioTransaction;
					//_oFolioTransaction.BaseAmount = decimal.Parse(this.txtBaseAmount.Text);

					if (oPackage.Basis == "A")
					{
						poFolioTransaction.Discount += oPackage.AmountOff;
					}
					else
					{
						poFolioTransaction.Discount += poFolioTransaction.NetAmount * (oPackage.PercentOff / 100);
					}

					//_oFolioTransaction.BaseAmount = _oFolioTransaction.BaseAmount - _oFolioTransaction.Discount;


					//_oFolioTransaction.GovernmentTax = decimal.Parse(this.txtGovTax.Text);
					//if (System.Convert.ToDouble(_oFolioTransaction.GovernmentTax) > 0.0)
					//{
					//    _oFolioTransaction.GovernmentTax = ComputeTaxSrvCharge(_oFolioTransaction.BaseAmount, _oFolioTransaction.GovernmentTax, _oFolioTransaction.GovernmentTaxInclusive);
					//}

					//_oFolioTransaction.LocalTax = decimal.Parse(this.txtLocalTax.Text);
					//if (System.Convert.ToDouble(_oFolioTransaction.LocalTax) > 0.0)
					//{
					//    _oFolioTransaction.LocalTax = ComputeTaxSrvCharge((_oFolioTransaction.BaseAmount - _oFolioTransaction.GovernmentTax), _oFolioTransaction.LocalTax, _oFolioTransaction.LocalTaxInclusive);
					//}

					//_oFolioTransaction.ServiceCharge = decimal.Parse(this.txtServiceCharge.Text);
					//if (System.Convert.ToDouble(_oFolioTransaction.ServiceCharge) > 0.0)
					//{
					//    _oFolioTransaction.ServiceCharge = ComputeTaxSrvCharge((_oFolioTransaction.BaseAmount - _oFolioTransaction.GovernmentTax - _oFolioTransaction.LocalTax), _oFolioTransaction.ServiceCharge, _oFolioTransaction.ServiceChargeInclusive);
					//}

					////with_1.NetBaseAmount = with_1.BaseAmount - with_1.GovernmentTax - with_1.LocalTax - with_1.ServiceCharge;
					//_oFolioTransaction.NetBaseAmount = _oFolioTransaction.BaseAmount - _oFolioTransaction.GovernmentTax - _oFolioTransaction.LocalTax - _oFolioTransaction.ServiceCharge - _oFolioTransaction.Discount;

					//string _strTransactionCode = poFolioTransaction.TransactionCode;
					//TransactionCode _oTranCode;
					//TransactionCodeFacade _oTranCode = oTransactionCodeFacade.getTransactionCode(_strTransactionCode);


					// BaseAmount = Currency Amount * Exchange Rate
					decimal _baseAmount = poFolioTransaction.BaseAmount;

					poFolioTransaction.BaseAmount = _baseAmount;
					poFolioTransaction.GrossAmount = poFolioTransaction.GrossAmount;


					// deduct discount b4 applying Tax & Service Charge
					_baseAmount = _baseAmount - poFolioTransaction.Discount;

					// compute Government Tax here (Inclusive or Exclusive)
					// if has SubAccount use SubAccount settings for Govt Tax
					// else use TransactionCode settings for Govt Tax

					if (poTransactionCode.GovtTax > 0)
						{
							decimal _govTaxPercent = poTransactionCode.GovtTax;

							decimal _govTaxAmount = ComputeTaxSrvCharge(_baseAmount, _govTaxPercent, poTransactionCode.GovtTaxInclusive);
							poFolioTransaction.GovernmentTax = _govTaxAmount;

							if (poTransactionCode.GovtTaxInclusive == 0)
							{
								//poFolioTransaction.GrossAmount += _govTaxAmount;

								_inclusiveGovTax = false;
							}
						}
						else
						{
							poFolioTransaction.GovernmentTax = 0;
						}

					


					// compute Local Tax here (Inclusive or Exclusive)
					// if has SubAccount use SubAccount settings for Govt Tax
					// else use TransactionCode settings for Local Tax

						if (poTransactionCode.LocalTax > 0)
						{
							decimal _localTaxPercent = (decimal)poTransactionCode.LocalTax;

							decimal _localTaxAmount = ComputeTaxSrvCharge(_baseAmount, _localTaxPercent, poTransactionCode.LocalTaxInclusive);
							poFolioTransaction.LocalTax = _localTaxAmount;

							if (poTransactionCode.LocalTaxInclusive == 0)
							{
								//poFolioTransaction.GrossAmount += _localTaxAmount;

								_inclusiveLocalTax = false;
							}
						}
						else
						{
							poFolioTransaction.LocalTax = 0;
						}

					



					// compute Local Tax here (Inclusive or Exclusive)
					// if has SubAccount use SubAccount settings for Govt Tax
					// else use TransactionCode settings for Local Tax
						_baseAmount = _baseAmount - poFolioTransaction.GovernmentTax - poFolioTransaction.LocalTax;


						if (poTransactionCode.ServiceCharge > 0)
						{
							if (poTransactionCode.ServiceChargeInclusive == 0)
							{
								// SUBTRACT GovtTax and LocalTax before applying Service Charge
								_baseAmount = poFolioTransaction.BaseAmount;

								_inclusiveServiceCharge = false;
							}

							decimal _serviceChargePercent = (decimal)poTransactionCode.ServiceCharge;

							decimal _serviceChargeAmount = ComputeTaxSrvCharge(_baseAmount, _serviceChargePercent, poTransactionCode.ServiceChargeInclusive);
							poFolioTransaction.ServiceCharge = _serviceChargeAmount;

							// add service charge to Gross Amount if exclusive
							if (poTransactionCode.ServiceChargeInclusive == 0)
							{
								//poFolioTransaction.GrossAmount += _serviceChargeAmount;

								_inclusiveServiceCharge = false;
							}
						}
						else
						{
							poFolioTransaction.ServiceCharge = 0;
						}




						poFolioTransaction.NetAmount = poFolioTransaction.GrossAmount - poFolioTransaction.Discount; //System.Convert.ToDouble(poFolioTransaction.BaseAmount - poFolioTransaction.Discount);

						poFolioTransaction.NetBaseAmount = poFolioTransaction.BaseAmount - poFolioTransaction.Discount - poFolioTransaction.MealAmount;

					if (_inclusiveGovTax)
					{
						poFolioTransaction.NetBaseAmount -= poFolioTransaction.GovernmentTax;
					}
					if (_inclusiveLocalTax)
					{
						poFolioTransaction.NetBaseAmount -= poFolioTransaction.LocalTax;
					}

					if (_inclusiveServiceCharge)
					{
						poFolioTransaction.NetBaseAmount -= poFolioTransaction.ServiceCharge;
					}

					//poFolioTrans.RouteSequence = "";
					//poFolioTrans.SourceFolio = "";
					//poFolioTrans.SourceSubFolio = "";
					//poFolioTrans.TerminalID = GlobalVariables.gTerminalID.ToString();
					//poFolioTrans.CreatedBy = GlobalVariables.gLoggedOnUser;

					//// new, Jrom, April 26, 2008
					//// Golden prince requirement

					//poFolioTrans.CreditCardNo = this.txtPayment_CardNo.Text;
					//poFolioTrans.ChequeNo = this.txtPayment_Cheque.Text;
					//poFolioTrans.AccountName = this.txtPayment_Account.Text;
					//poFolioTrans.BankName = this.txtPayment_Bank.Text;
					//poFolioTrans.ChequeDate = string.Format("{0:yyyy-MM-dd}", this.dtpPayment_Date.Value);
					//poFolioTransaction.FOCGrantedBy = this.txtGrantedBy.Text;

					//poFolioTransaction.CreditCardType = this.txtCardType.Text;
					//poFolioTransaction.ApprovalSlip = this.txtCardApproval.Text;
					//poFolioTransaction.SubAccount = this.cboSubAccount.Text;
					//poFolioTransaction.CreditCardExpiry = string.Format("{0:yyyy-MM-dd}", this.dtpCardExpires.Value);
			

                }
            }
            catch (Exception)
            {
                MessageBox.Show("No Package was applied..");
            }
        }

        private FolioRoutingCollection oFolioRoutingCollection;
        private void ApplyRouting(FolioTransaction oFTrans, Folio oFolio)
        {
            oFolioTransCollection = new FolioTransactions();
            if (oFolio.FolioType != "GROUP")//apply routing if foliotype is not equal to GROUP
            {
                //oFolioRoutingCollection = new FolioRoutingCollection();
                oFolioRoutingCollection = oFolioFacade.GetFolioTransRouting(oFTrans.FolioID, oFTrans.TransactionCode);

                if (oFolioRoutingCollection.Count == 0)
                    return;


                //oFTrans.TransactionSource = "AUTO-POST";
                // >> this is used in Routing
                //double originalAmountForRouting = poFolioTransaction.BaseAmount;
                decimal originalAmountForRouting = oFTrans.NetAmount;

                string _tempChargeType = "P"; // P=Percent ; A=Amount
                decimal _tempTotalAmountInRouting = 0;
                decimal _tempTotalPercentInRouting = 0;
                foreach (FolioRouting _oRouting in oFolioRoutingCollection)
                {
                    if (_oRouting.PercentCharged > 0)
                    {
                        _tempTotalPercentInRouting += _oRouting.PercentCharged;
                    }
                    else if (_oRouting.AmountCharged > 0)
                    {
                        _tempTotalAmountInRouting += _oRouting.AmountCharged;
                    }

                    _tempChargeType = _oRouting.Basis;

                }

                // check if Routing has a total Percentage of 100
                // if not then charge the remaining Percent to subFolio A
                if (_tempChargeType == "P")
                {
                    if (_tempTotalPercentInRouting < 100)
                    {
                        // we use 1 here since oRouting.PercentCharge will be multiplied by 100
                        oFolioRoutingCollection.Item(0).PercentCharged = (1 - _tempTotalPercentInRouting);
                    }
                }

                // check if Routing has a total Amount equal to NetAmount
                // if not then charge the remaining amount to subFolio A
                if (_tempChargeType == "A")
                {

                    if (_tempTotalPercentInRouting < originalAmountForRouting)
                    {
                        oFolioRoutingCollection.Item(0).AmountCharged = (originalAmountForRouting - _tempTotalAmountInRouting);
                    }
                }


                foreach (FolioRouting _oRouting in oFolioRoutingCollection)
                {

                    if (_oRouting.PercentCharged > 0 || _oRouting.AmountCharged > 0)
                    {

                        FolioTransaction oFolioTrans = new FolioTransaction();

                        oFolioTrans.HotelID = oFTrans.HotelID;
                        oFolioTrans.FolioID = oFolio.FolioID;
                        if (oFolio.AccountID != null)
                        {
                            oFolioTrans.AccountID = oFolio.AccountID;
                        }
                        else
                        {
                            oFolioTrans.AccountID = oFolio.CompanyID;
                        }
                        oFolioTrans.TransactionDate = oFTrans.TransactionDate;
                        oFolioTrans.PostingDate = oFTrans.PostingDate;
                        oFolioTrans.TransactionCode = oFTrans.TransactionCode;
                        oFolioTrans.ReferenceNo = oFTrans.ReferenceNo;
                        oFolioTrans.TransactionSource = oFTrans.TransactionSource;
                        oFolioTrans.Memo = oFTrans.Memo;
                        oFolioTrans.AcctSide = oFTrans.AcctSide;
                        oFolioTrans.CurrencyCode = oFTrans.CurrencyCode;
                        oFolioTrans.ConversionRate = oFTrans.ConversionRate;
                        oFolioTrans.CurrencyAmount = oFTrans.CurrencyAmount;
                        oFolioTrans.BaseAmount = oFTrans.BaseAmount;
                        oFolioTrans.GrossAmount = oFTrans.GrossAmount;
                        oFolioTrans.MealAmount = oFTrans.MealAmount;
                        oFolioTrans.Discount = oFTrans.Discount;

                        oFolioTrans.GovernmentTax = oFTrans.GovernmentTax;
                        oFolioTrans.GovernmentTaxInclusive = oFTrans.GovernmentTaxInclusive;

                        oFolioTrans.LocalTax = oFTrans.LocalTax;
                        oFolioTrans.LocalTaxInclusive = oFTrans.LocalTaxInclusive;

                        oFolioTrans.ServiceCharge = oFTrans.ServiceCharge;
                        oFolioTrans.ServiceChargeInclusive = oFTrans.ServiceChargeInclusive;


                        oFolioTrans.NetBaseAmount = oFTrans.NetBaseAmount;
                        oFolioTrans.NetAmount = oFTrans.NetAmount;

                        oFolioTrans.TerminalID = oFTrans.TerminalID;
                        oFolioTrans.CreatedBy = oFTrans.CreatedBy;


                        oFolioTrans.SubFolio = _oRouting.SubFolio;
                        if (_oRouting.PercentCharged > 0)
                        {
                            oFolioTrans.Discount = oFolioTrans.Discount * (_oRouting.PercentCharged / 100);

                            oFolioTrans.CurrencyAmount = oFolioTrans.CurrencyAmount * (_oRouting.PercentCharged / 100);
                            oFolioTrans.BaseAmount = oFolioTrans.BaseAmount * (_oRouting.PercentCharged / 100);

                            oFolioTrans.GovernmentTax = oFolioTrans.GovernmentTax * (_oRouting.PercentCharged / 100);
                            oFolioTrans.LocalTax = oFolioTrans.LocalTax * (_oRouting.PercentCharged / 100);
                            oFolioTrans.ServiceCharge = oFolioTrans.ServiceCharge * (_oRouting.PercentCharged / 100);

                            oFolioTrans.NetBaseAmount = oFolioTrans.NetBaseAmount * (_oRouting.PercentCharged / 100);
                            oFolioTrans.NetAmount = oFolioTrans.NetAmount * (_oRouting.PercentCharged / 100);
                            oFolioTrans.GrossAmount = oFolioTrans.GrossAmount * (_oRouting.PercentCharged / 100);
                            oFolioTrans.MealAmount = oFolioTrans.MealAmount * (_oRouting.PercentCharged / 100);
                        }
                        else
                        {
                            // checks if amount is > originalAmountForRouting 
                            if (originalAmountForRouting > _oRouting.AmountCharged)
                            {
                                originalAmountForRouting -= _oRouting.AmountCharged;
                            }
                            else
                            {
                                _oRouting.AmountCharged = originalAmountForRouting;
                                originalAmountForRouting = 0;
                            }

                            // Discount = 0 since we won't be able to determine how much discount to Route
                            // to destination folio.
                            oFolioTrans.Discount = 0;

                            oFolioTrans.CurrencyAmount = _oRouting.AmountCharged;
                            oFolioTrans.BaseAmount = _oRouting.AmountCharged;
                            oFolioTrans.GovernmentTax = ComputeTaxSrvCharge(_oRouting.AmountCharged, roomChargeTranCode.GovtTax, roomChargeTranCode.GovtTaxInclusive);
                            oFolioTrans.LocalTax = ComputeTaxSrvCharge(_oRouting.AmountCharged, roomChargeTranCode.LocalTax, roomChargeTranCode.LocalTaxInclusive);
                            oFolioTrans.ServiceCharge = ComputeTaxSrvCharge(_oRouting.AmountCharged, roomChargeTranCode.ServiceCharge, roomChargeTranCode.ServiceChargeInclusive);
                            oFolioTrans.NetBaseAmount = _oRouting.AmountCharged - (oFolioTrans.GovernmentTax + oFolioTrans.LocalTax + oFolioTrans.ServiceCharge);


                            oFolioTrans.GrossAmount = oFolioTrans.BaseAmount;
                            oFolioTrans.NetAmount = oFolioTrans.BaseAmount;


                        }


                        // KUNG NAA CYA MASTER FOLIO(DEPENDENT CYA) DERITSO SA 
                        // IYA MASTER FOLIO ANG TRANSACTION SA 
                        // SUB-FOLIO B., IF INDEPENDENT THEN NAA CYA 
                        // SUB-FOLIO B TRANS, IYAHA GHAPON ANG
                        // TRANSACTION PERO, SA SUB-FOLIO B.
                        oFolioTrans.SubFolio = _oRouting.SubFolio;
                        if (oFolioTrans.SubFolio == "B")
                        {
                            //revised: jrom
                            // desc  : dli man cya makita sa folio transactions if ideritso 
                            //         ang iya transaction sa iya master folio,
                            //         ang tendency i-double charge na hinuon nila..
                            //         ila manualon ug insert para makita b4 i-checkout ...

                            //oFolioTrans.AccountID = (oFolio.CompanyID == "" || oFolio.CompanyID == "0") ? oFolio.AccountID : oFolio.CompanyID;
                            //oFolioTrans.FolioID = (oFolio.MasterFolio == "" || oFolio.CompanyID == "0") ? oFolio.FolioID : oFolio.MasterFolio;

                            oFolioTrans.AccountID = oFolio.AccountID;
                            oFolio.FolioID = oFolio.FolioID;
                            oFolioTrans.SubFolio = "B";

                            //oFolioTrans.SubFolio = (oFolio.MasterFolio == "" || oFolio.CompanyID == "0") ? "B" : "A";
                            //oFolioTrans.SourceFolio = oFolio.FolioID;
                            //oFolioTrans.SourceSubFolio = "A";
                            oFolioTrans.Discount = oFolioTrans.Discount;
                        }
                        else
                        {
                            oFolioTrans.AccountID = oFolio.AccountID;
                            if (oFolio.MasterFolio != "")
                            {
                                oFolioTrans.Discount = 0;
                            }
                            else
                            {
                                oFolioTrans.Discount = oFolioTrans.Discount;
                            }
                        }

                        oFolioTrans.ChequeDate = "1900-01-01";
                        oFolioTrans.CreditCardExpiry = "1900-01-01";


                        oFolioTransCollection.Add(oFolioTrans);
                    }
                }
            }
        }

        private bool hasHighDiscount(string pTransactionCode, string discountType, Folio _poFolio)
        {
            decimal _discount = 0;
            bool _isPresent = false;
            string _discType = "";

            foreach (Privilege _oPrivilege in _poFolio.Privileges)
            {
                if (_oPrivilege.TransactionCode == pTransactionCode)
                {
                    if (_oPrivilege.Basis == "P") // for percent
                    {
                        _discount = _oPrivilege.Percentoff;
                        _discType = "PRIVILEGE";
                    }
                    else
                    {
                        _discount = _oPrivilege.AmountOff;
                        _discType = "PRIVILEGE";
                    }

                    _isPresent = true;
                    break;
                }
            }

            foreach (FolioPackage _oPackage in _poFolio.Package)
            {
                if (_oPackage.TransactionCode == pTransactionCode)
                {
                    if (_oPackage.Basis == "P" && _discount < _oPackage.PercentOff) // for percent
                    {
                        _discount = _oPackage.PercentOff;
                        _discType = "PACKAGE";
                    }
                    else if (_oPackage.Basis == "A" && _discount < _oPackage.AmountOff)
                    {
                        _discount = _oPackage.AmountOff;
                        _discType = "PACKAGE";
                    }
                    else if (_oPackage.Basis == "P" && _discount >= _oPackage.PercentOff)
                    {
                        _discType = "PRIVILEGE";
                    }
                    else if (_oPackage.Basis == "A" && _discount >= _oPackage.AmountOff)
                    {
                        _discType = "PRIVILEGE";
                    }

                    break;
                }
            }

            if (_discType == "PRIVILEGE" && discountType == "PRIVILEGE")
            {
                return true;
            }
            else if (_discType == "PRIVILEGE" && discountType == "PACKAGE")
            {
                return false;
            }
            else if (_discType == "PACKAGE" && discountType == "PACKAGE")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void  ApplyPrivileges(FolioTransaction oFolioTrans)
        {
            try
            {
                oFolioFacade = new FolioFacade();

				//if (oFolioTransCollection == null || oFolioTransCollection.Count == 0)
				//{
				//    oFolioTransCollection = new FolioTransactions();

				//    oFolioTransCollection.Add(oFolioTrans);
				//}

				TransactionCode _oTransactionCode = GetTranCode(oFolioTrans.TransactionCode);

				//FolioTransaction fTrans;
				//foreach (FolioTransaction tempLoopVar_fTrans in oFolioTransCollection)
				//{

                //check if transaction to be discounted has high discount than the package
                if (hasHighDiscount(oFolioTransaction.TransactionCode, "PRIVILEGE", oFolio) == false)
                {
                    return;
                }

				FolioTransaction fTrans = oFolioTrans;
                    //fTrans.TransactionSource = "AUTO-POST";
                    DataRow dtPrivileges = oFolioFacade.GetFolioTransPrivilege(ref fTrans);

                    if (dtPrivileges != null)
                    {
                        decimal disc = 0;
                        if ((string)dtPrivileges["Basis"] == "A")
                        {
                            disc = System.Convert.ToDecimal(dtPrivileges["AmountOff"]);
                        }
                        else
                        {
                            disc = fTrans.NetAmount * System.Convert.ToDecimal(dtPrivileges["PercentOff"].ToString());
							disc = (disc / 100);
                        }

						fTrans.Discount += disc;
						fTrans.NetAmount -= disc;


						fTrans.GovernmentTax = _oTransactionCode.GovtTax;
                        if (fTrans.GovernmentTax > 0)
                        {
							fTrans.GovernmentTax = ComputeTaxSrvCharge(fTrans.NetAmount, fTrans.GovernmentTax, _oTransactionCode.GovtTaxInclusive);
                        }

						fTrans.LocalTax = _oTransactionCode.LocalTax;
                        if (fTrans.LocalTax > 0)
                        {
							fTrans.LocalTax = ComputeTaxSrvCharge((fTrans.NetAmount - fTrans.GovernmentTax), fTrans.LocalTax, _oTransactionCode.LocalTaxInclusive);
                        }

						fTrans.ServiceCharge = _oTransactionCode.ServiceCharge;
                        if (fTrans.ServiceCharge > 0)
                        {
							fTrans.ServiceCharge = ComputeTaxSrvCharge((fTrans.NetAmount - fTrans.GovernmentTax - fTrans.LocalTax), fTrans.ServiceCharge, _oTransactionCode.ServiceChargeInclusive);
                        }

						fTrans.NetBaseAmount = fTrans.NetAmount - fTrans.GovernmentTax - fTrans.LocalTax - fTrans.ServiceCharge - fTrans.MealAmount;

                    }
                //}

            }
            catch
            {
                //MessageBox.Show("No Privilege was applied..");
            }
        }

		private decimal ComputeTaxSrvCharge(decimal pBaseAmount, decimal pTaxPercent, int isInclusive)
		{
			decimal _taxAmount;

			if (isInclusive == 1)
			{
				_taxAmount = pBaseAmount - (pBaseAmount / (1 + (pTaxPercent / 100)));
			}
			else
			{
				_taxAmount = pBaseAmount * (pTaxPercent / 100);
			}

			return _taxAmount;
		}

        private FolioTransactionFacade oFolioTransactionFacade;
        private void AppendFolioTransaction(FolioTransaction oFolioTrans)
        {
            MySqlTransaction myTransaction = GlobalVariables.gPersistentConnection.BeginTransaction();

            
            oFolioTransactionFacade = new FolioTransactionFacade();

            if (oFolioTransactionFacade.InsertFolioTransaction(oFolioTrans, ref myTransaction))
            {
                myTransaction.Commit();
            }
            else
            {
                myTransaction.Rollback();
            }

        }

        private void AppendFolioTransaction(FolioTransactions oFolioTransCollection)
        {
            FolioTransaction folioTrans;
            foreach (FolioTransaction tempLoopVar_folioTrans in oFolioTransCollection)
            {
                folioTrans = tempLoopVar_folioTrans;
                AppendFolioTransaction(folioTrans);
            }
        }

        public TransactionCode GetTranCode(string a_TranCode)
        {
            TransactionCodeFacade tranCodeFacade = new TransactionCodeFacade();
            return tranCodeFacade.getTransactionCode(a_TranCode);
        }



        private ReportViewer reportViewerUI;
        private ReportFacade oReportFacade;
        ProgressForm progress = new ProgressForm();
        // reports
        public void generateReports()
        {
            oReportFacade = new ReportFacade();
            Type reportType = oReportFacade.GetType();


			AuditFacade _oAuditFacade = new AuditFacade(GlobalVariables.gPersistentConnection);
			DayEndProcessConfig _oDayEndProcessConfig = _oAuditFacade.getDayEndProcessConfig();

			string[] _report = _oDayEndProcessConfig.ReportsToGenerate.Split(',');
			foreach (string strReport in _report)
			{
				string _reportName = strReport.Trim();

				object[] param = new object[1];
				param[0] = GlobalVariables.gAuditDate;

				ReportDocument rptDocument = new ReportDocument();

				if (_reportName != "")
				{

					switch (_reportName)
					{
						case "getInHouseGuests":
							try
							{
								rptDocument = (ReportDocument)reportType.GetMethod(_reportName).Invoke(oReportFacade, null);
                                showReport(rptDocument);
                            }
							catch (Exception ex)
							{
								MessageBox.Show(_reportName + "(): failed.\r\nError message: " + ex.Message, "Print Report Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							}

							break;

						case "getExpectedArrivalReport":
						case "getExpectedDepartureReport":

							param[0] = string.Format("{0:yyyy-MM-dd}", DateTime.Parse(GlobalVariables.gAuditDate).AddDays(1));

							try
							{
								rptDocument = (ReportDocument)reportType.GetMethod(_reportName).Invoke(oReportFacade, param);
                                showReport(rptDocument);
                            }
							catch (Exception ex)
							{
								MessageBox.Show(_reportName + "(): failed.\r\nError message: " + ex.Message, "Print Report Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							}

							break;

						case "getGuestLedger":
							//object[] param = new object[1];
							param[0] = DateTime.Parse(GlobalVariables.gAuditDate + " 11:59:59");
							try
							{
								rptDocument = (ReportDocument)reportType.GetMethod(_reportName).Invoke(oReportFacade, param);
                                showReport(rptDocument);
                            }
							catch (Exception ex)
							{
								MessageBox.Show(_reportName + "(): failed.\r\nError message: " + ex.Message, "Print Report Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							}

							break;

						case "getRoomAvailability":
						case "getRoomTransferReport":
						case "getDailyTransactions":
						case "getSalesReport":
						case "getTransactionRegisterReport":
						case "getCityLedger":
						case "getCityTransferTransactions":

							try
							{
								rptDocument = (ReportDocument)reportType.GetMethod(_reportName).Invoke(oReportFacade, null);
                                showReport(rptDocument);
                            }
							catch (Exception ex)
							{
								MessageBox.Show(_reportName + "(): failed.\r\nError message: " + ex.Message, "Print Report Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							}

							break;

						case "getAllCashierShiftTransaction":

							object[] paramCST = new object[2];
							paramCST[0] = GlobalVariables.gAuditDate;
							paramCST[1] = "ALL";
							try
							{
								rptDocument = (ReportDocument)reportType.GetMethod("getAllCashierShiftTransaction").Invoke(oReportFacade, paramCST);
                                showReport(rptDocument);
                            }
							catch (Exception ex)
							{
								MessageBox.Show(_reportName + "(): failed.\r\nError message: " + ex.Message, "Print Report Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							}

							break;

						case "getHousekeepingJobs":
						case "getRoomOccupancy":
							try
							{
								param[0] = DateTime.Parse( GlobalVariables.gAuditDate );

								rptDocument = (ReportDocument)reportType.GetMethod(_reportName).Invoke(oReportFacade, param);
                                showReport(rptDocument);
                            }
							catch (Exception ex)
							{
								MessageBox.Show(_reportName + "(): failed.\r\nError message: " + ex.Message, "Print Report Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							}

							break;

                        case "getRoomingList":
                            try
                            {
                                FolioFacade _oFolioFacade = new FolioFacade();
                                DataTable _dt = _oFolioFacade.getCheckedInGroups(GlobalVariables.gAuditDate);
                                foreach (DataRow dRow in _dt.Rows)
                                {
                                    param[0] = dRow["folioid"];

                                    rptDocument = (ReportDocument)reportType.GetMethod(_reportName).Invoke(oReportFacade, param);
                                    showReport(rptDocument);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(_reportName + "(): failed.\r\nError message: " + ex.Message, "Print Report Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            break;

						default:
							try
							{
								rptDocument = (ReportDocument)reportType.GetMethod(_reportName).Invoke(oReportFacade, param);
                                showReport(rptDocument);
                            }
							catch (Exception ex)
							{
								MessageBox.Show(_reportName + "(): failed.\r\nError message: " + ex.Message, "Print Report Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							}

							break;
					}
				}

			}

			//try
			//{
			//    object[] param = new object[1];
			//    param[0] = GlobalVariables.gAuditDate;


			//    showReport(reportType.GetMethod("getActualArrivalReport").Invoke(oReportFacade, param));
			//}
			//catch (Exception ex)
			//{
			//    MessageBox.Show("getActualArrivalReport: " + ex.Message, "Print Report Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			//}

			//try
			//{
			//    object[] param = new object[1];
			//    param[0] = GlobalVariables.gAuditDate;

			//    showReport(reportType.GetMethod("getActualDepartureReport").Invoke(oReportFacade, param));
			//}
			//catch (Exception ex)
			//{
			//    MessageBox.Show("getActualDepartureReport: " + ex.Message, "Print Report Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			//}

			//try
			//{
			//    showReport(reportType.GetMethod("getInHouseGuests").Invoke(oReportFacade, null));
			//}
			//catch (Exception ex)
			//{
			//    MessageBox.Show("getInHouseGuests: " + ex.Message, "Print Report Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			//}

			//try
			//{
			//    object[] param = new object[1];
			//    param[0] = string.Format("{0:yyyy-MM-dd}",DateTime.Parse(GlobalVariables.gAuditDate).AddDays(1));

			//    showReport(reportType.GetMethod("getExpectedArrivalReport").Invoke(oReportFacade, param));
                
			//}
			//catch (Exception ex)
			//{
			//    MessageBox.Show("getExpectedArrivalReport: " + ex.Message, "Print Report Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			//}

			//try
			//{
			//    object[] param = new object[1];
			//    param[0] = string.Format("{0:yyyy-MM-dd}",DateTime.Parse(GlobalVariables.gAuditDate).AddDays(1));

			//    showReport(reportType.GetMethod("getExpectedDepartureReport").Invoke(oReportFacade, param));
			//}
			//catch (Exception ex)
			//{
			//    MessageBox.Show("getExpectedDepartureReport: " + ex.Message, "Print Report Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			//}

			//try
			//{
			//    object[] param = new object[1];
			//    param[0] = GlobalVariables.gAuditDate;

			//    showReport(reportType.GetMethod("getCancelledReservation").Invoke(oReportFacade, param));

			//}
			//catch (Exception ex)
			//{
			//    MessageBox.Show("getCancelledReservation: " + ex.Message, "Print Report Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			//}

			//try
			//{
			//    object[] param = new object[1];
			//    param[0] = DateTime.Now;

			//    showReport(reportType.GetMethod("getGuestLedger").Invoke(oReportFacade, param));

			//}
			//catch (Exception ex)
			//{
			//    MessageBox.Show("getGuestLedger: " + ex.Message, "Print Report Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			//}

			//try
			//{
			//    showReport(reportType.GetMethod("getRoomAvailability").Invoke(oReportFacade, null));
			//}
			//catch (Exception ex)
			//{
			//    MessageBox.Show("getRoomAvailability: " + ex.Message, "Print Report Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			//}

			//try
			//{
			//    showReport(reportType.GetMethod("getRoomTransferReport").Invoke(oReportFacade, null));
			//}
			//catch (Exception ex)
			//{
			//    MessageBox.Show("getRoomTransferReport: " + ex.Message, "Print Report Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			//}

			//try
			//{
			//    showReport(reportType.GetMethod("getRoomOccupancy").Invoke(oReportFacade, null));
			//}
			//catch (Exception ex)
			//{
			//    MessageBox.Show("getRoomOccupancy: " + ex.Message, "Print Report Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			//}

			//try
			//{
			//    showReport(reportType.GetMethod("getDailyTransactions").Invoke(oReportFacade, null));
			//}
			//catch (Exception ex)
			//{
			//    MessageBox.Show("getDailyTransactions: " + ex.Message, "Print Report Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			//}

            //curProgress++;
            //progress.updateProgress(curProgress);
            // -------------------------------

			//try
			//{
			//    showReport(reportType.GetMethod("getSalesReport").Invoke(oReportFacade, null));
			//}
			//catch (Exception ex)
			//{
			//    MessageBox.Show("getSalesReport: " + ex.Message, "Print Report Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			//}

            //curProgress++;
            //progress.updateProgress(curProgress);
            // -------------------------------

			//try
			//{
			//    object[] param = new object[1];
			//    param[0] = DateTime.Parse(Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gAuditDate);

			//    showReport(reportType.GetMethod("getSalesSummary").Invoke(oReportFacade, param));
			//}
			//catch (Exception ex)
			//{
			//    MessageBox.Show("getSalesSummary: " + ex.Message, "Print Report Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			//}

            //curProgress++;
            //progress.updateProgress(curProgress);
            // -------------------------------

			//try
			//{
			//    showReport(reportType.GetMethod("getTransactionRegisterReport").Invoke(oReportFacade, null));
			//}
			//catch (Exception ex)
			//{
			//    MessageBox.Show("getTransactionRegisterReport: " + ex.Message, "Print Report Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			//}

            //curProgress++;
            //progress.updateProgress(curProgress);
            // -------------------------------

			//try
			//{
			//    showReport(reportType.GetMethod("getCityLedger").Invoke(oReportFacade, null));
			//}
			//catch (Exception ex)
			//{
			//    MessageBox.Show("getCityLedger: " + ex.Message, "Print Report Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			//}

            //curProgress++;
            //progress.updateProgress(curProgress);
            // -------------------------------

			//try
			//{
			//    showReport(reportType.GetMethod("getCityTransferTransactions").Invoke(oReportFacade, null));
			//}
			//catch (Exception ex)
			//{
			//    MessageBox.Show("getCityLedger: " + ex.Message, "Print Report Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			//}

            
            //curProgress++;
            //progress.updateProgress(curProgress);
            // -------------------------------

			//try
			//{
			//    object[] param = new object[2];
			//    param[0] = Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gAuditDate;
			//    param[1] = "ALL";

			//    showReport(reportType.GetMethod("getAllCashierShiftTransaction").Invoke(oReportFacade, param));
			//}
			//catch (Exception ex)
			//{
			//    MessageBox.Show("getCityLedger: " + ex.Message, "Print Report Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			//}

            //curProgress++;
            //progress.updateProgress(curProgress);
            

            // --------------- export reports for accounting ---------------------
            string dumpAccountingLogs = ConfigVariables.gDumpAccountingLogs;
            if (dumpAccountingLogs == "YES")
            {
                exportReports();
            }

            //curProgress++;
            //progress.updateProgress(curProgress);
            

            //progress.Close();
        }

        public void showReport(object reportDoc)
        {
            reportViewerUI = new ReportViewer();
            oReportFacade = new ReportFacade();

            reportViewerUI.rptViewer.ReportSource = reportDoc;
            
            reportViewerUI.MdiParent = (Form)GlobalVariables.gMDI;
            reportViewerUI.Show();
        }

        public void exportReports()
        {
            exportTransactionCodes();
            exportInhouseGuests();
            exportDailyTransactions();
            exportRestaurantLedger();
        }

        public bool exportTransactionCodes()
        {
            try
            {
                string csvTransactionCodes = "";

                TransactionCodeFacade transactionCodeFacade = new TransactionCodeFacade();

                TransactionCode transactionCodes = new TransactionCode();
                transactionCodes = (TransactionCode)transactionCodeFacade.loadObject();

                DataTable dtTransactionCodes = new DataTable("Transaction Codes");
                dtTransactionCodes = transactionCodes.Tables[0];

                foreach (DataRow dtRow in dtTransactionCodes.Rows)
                {
                    csvTransactionCodes += dtRow["TranCode"].ToString() + "," +
                                            dtRow["Memo"].ToString() + "," +
                                            dtRow["acctSide"].ToString() + "," +
                                            dtRow["debitSide"].ToString() + "," +
                                            dtRow["creditSide"].ToString() + ",";
                    csvTransactionCodes += "\r\n";
                }

                string _dumpLogsForAccounting = ConfigVariables.gDumpAccountingLogs;
                if (_dumpLogsForAccounting == "YES")
                {
                    // gets the path where the file is to dumped
                    string fileName = ConfigVariables.gDumpPath;
                    int fileSize = int.Parse(ConfigVariables.gDumpFileSize);

                    fileName += "FDCodes";
                    fileName += string.Format("{0:yyyyMMdd}", DateTime.Parse(GlobalVariables.gAuditDate)) + ".txt";

                    StreamWriter strWriter = new StreamWriter(@fileName, true, System.Text.Encoding.UTF8, fileSize);
                    strWriter.Write(csvTransactionCodes);

                    strWriter.Flush();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Export Transaction Codes error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
        }

        public bool exportInhouseGuests()
        {
            try
            {
                string csvInHouseGuests = "";

                ReportDAO rptDAO = new ReportDAO();
                DataTable dtInHouseGuests = new DataTable("InHouseGuests");
                dtInHouseGuests = rptDAO.getInHouseGuests();

                foreach (DataRow dtRow in dtInHouseGuests.Rows)
                {
                    csvInHouseGuests += dtRow["AccountId"].ToString() + "," +
                                            dtRow["GuestName"].ToString() + "," +
                                            dtRow["Address1"].ToString() + "," +
                                            dtRow["TelephoneNo"].ToString() + "," +
                                            dtRow["Citizenship"].ToString() + ",";
                    csvInHouseGuests += "\r\n";
                }

                // gets the path where the file is to dumped
                string fileName = ConfigVariables.gDumpPath;
                int fileSize = int.Parse(ConfigVariables.gDumpFileSize);

                fileName += "Guests";
                fileName += string.Format("{0:yyyyMMdd}", DateTime.Parse(GlobalVariables.gAuditDate)) + ".txt";

                StreamWriter strWriter = new StreamWriter(@fileName, true, System.Text.Encoding.UTF8, fileSize);
                strWriter.Write(csvInHouseGuests);

                strWriter.Flush();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Export Inhouse Guests error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
        }

        public bool exportDailyTransactions()
        {
            try
            {
                string csvDailyTransactions = "";

                ReportDAO rptDAO = new ReportDAO();
                DataTable dtDailyTransactions = new DataTable("DailyTransactions");
                dtDailyTransactions = rptDAO.getParamTransactionRegisterReport(GlobalVariables.gAuditDate, GlobalVariables.gAuditDate);

                foreach (DataRow dtRow in dtDailyTransactions.Rows)
                {
                    csvDailyTransactions += dtRow["FolioId"].ToString() + "," +
                                            dtRow["PostingDate"].ToString() + "," +
                                            dtRow["ReferenceNo"].ToString() + "," +
                                            dtRow["Memo"].ToString() + "," +
                                            dtRow["AccountId"].ToString() + "," +
                                            dtRow["RoomId"].ToString() + "," +
                                            dtRow["RoomType"].ToString() + "," +
                                            dtRow["Debit"].ToString() + "," +
                                            dtRow["Credit"].ToString() + "," +
                                            dtRow["TransactionCode"].ToString() + ","
                                            ;
                    csvDailyTransactions += "\r\n";
                }

                // gets the path where the file is to dumped
                string fileName = ConfigVariables.gDumpPath;
                int fileSize = int.Parse(ConfigVariables.gDumpFileSize);

                fileName += "FD";
                fileName += string.Format("{0:yyyyMMdd}", DateTime.Parse(GlobalVariables.gAuditDate)) + ".txt";

                StreamWriter strWriter = new StreamWriter(@fileName, true, System.Text.Encoding.UTF8, fileSize);
                strWriter.Write(csvDailyTransactions);

                strWriter.Flush();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Export Daily Transactions error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
        }

        public bool exportRestaurantLedger()
        {
            try
            {
                string csvRestaurantLedger = "";

                ReportDAO rptDAO = new ReportDAO();
                DataTable dtRestaurantLedger = new DataTable("RestaurantLedger");
                dtRestaurantLedger = rptDAO.getRestaurantLeger(GlobalVariables.gAuditDate);

                foreach (DataRow dtRow in dtRestaurantLedger.Rows)
                {
                    csvRestaurantLedger += dtRow["id"].ToString() + "," +
                                            dtRow["date"].ToString() + "," +
                                            dtRow["refNo"].ToString() + "," +
                                            dtRow["Memo"].ToString() + "," +
                                            dtRow["debit"].ToString() + "," +
                                            dtRow["credit"].ToString() + ","
                                            ;
                    csvRestaurantLedger += "\r\n";
                }

                // gets the path where the file is to dumped
                string fileName = ConfigVariables.gDumpPath;
                int fileSize = int.Parse(ConfigVariables.gDumpFileSize);

                fileName += "RS";
                fileName += string.Format("{0:yyyyMMdd}", DateTime.Parse(GlobalVariables.gAuditDate)) + ".txt";

                StreamWriter strWriter = new StreamWriter(@fileName, true, System.Text.Encoding.UTF8, fileSize);
                strWriter.Write(csvRestaurantLedger);

                strWriter.Flush();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Export Restaurant Ledger error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
        }

    }
}