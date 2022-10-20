using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using Jinisys.Hotel.Reservation.DataAccessLayer;

namespace Jinisys.Hotel.Reservation.BusinessLayer
{
	public class EndorsementFacade
	{

		public EndorsementFacade()
		{ 
		}

		private EndorsementDAO lEndorsementDAO;
		public DataTable  getAllEndorsements()
		{
			lEndorsementDAO = new EndorsementDAO();
			return lEndorsementDAO.getAllEndorsements();
		}


		public Endorsement getEndorsementById(int pEndorsementId)
		{
			DataTable _tempData = this.getAllEndorsements();
			DataView _tempView = _tempData.DefaultView;

			_tempView.RowStateFilter = DataViewRowState.OriginalRows;
			_tempView.RowFilter = "id = " + pEndorsementId ;

			if (_tempView.Count > 0)
			{
				Endorsement _oEndorsement = new Endorsement();

				_oEndorsement.Id = int.Parse( _tempView[0]["id"].ToString() );
				_oEndorsement.LogDate = DateTime.Parse( _tempView[0]["logDate"].ToString() );
				_oEndorsement.TerminalNo = int.Parse( _tempView[0]["TerminalNo"].ToString() );
				_oEndorsement.ShiftCode = int.Parse( _tempView[0]["shiftCode"].ToString() );
				_oEndorsement.LoggedUser = _tempView[0]["loggedUser"].ToString();
				_oEndorsement.EndorsementDescription = _tempView[0]["endorsementDescription"].ToString();
				_oEndorsement.StatusFlag = _tempView[0]["statusFlag"].ToString();
				_oEndorsement.EndorsementRemarks = _tempView[0]["endorsementRemarks"].ToString();
				_oEndorsement.AcknowledgedBy = _tempView[0]["acknowledgedBy"].ToString();
				_oEndorsement.AcknowledgeAtTerminal = int.Parse( _tempView[0]["acknowledgeAtTerminal"].ToString() );
				_oEndorsement.AcknowledgeAtShiftCode = int.Parse( _tempView[0]["acknowledgeAtShiftCode"].ToString() );
				
				_oEndorsement.CreatedBy = _tempView[0]["createdBy"].ToString();
				_oEndorsement.CreateTime = DateTime.Parse( _tempView[0]["createTime"].ToString() );
				_oEndorsement.UpdatedBy = _tempView[0]["updatedBy"].ToString();
				_oEndorsement.UpdateTime = DateTime.Parse( _tempView[0]["updateTime"].ToString() );
				_oEndorsement.HotelId = int.Parse( _tempView[0]["hotelId"].ToString() );


				return _oEndorsement;
			}
			else
			{
				return null;
			}
		}


		public int updateEndorsement(Endorsement pEndorsement)
		{
			lEndorsementDAO = new EndorsementDAO();
			return lEndorsementDAO.updateEndorsement(pEndorsement);
		}


		public int acknowledgeEndorsement(Endorsement pEndorsement)
		{
			lEndorsementDAO = new EndorsementDAO();
			return lEndorsementDAO.acknowledgeEndorsement(pEndorsement);
		}


		public int insertNewEndorsement(Endorsement pEndorsement)
		{
			lEndorsementDAO = new EndorsementDAO();
			return lEndorsementDAO.insertEndorsement(pEndorsement);
			
		}


	}
}
