using System;
using System.Collections.Generic;
using System.Text;

namespace Jinsiys.Hotel.AccountingInterface.ExactGlobe.BusinessLayer
{
	public class eTransactionCodeMapping
	{
		public eTransactionCodeMapping()
		{
		}
		private string _FolioPlus_TranCode;
		public string pFolioPlus_TranCode
		{
			set
			{
				this._FolioPlus_TranCode = value;
			}
			get
			{
				return this._FolioPlus_TranCode;
			}
		}
		private string _Exact_GLAccountID;
		public string pExact_GLAccountID
		{
			set
			{
				this._Exact_GLAccountID = value;
			}
			get
			{
				return this._Exact_GLAccountID;
			}
		}
		private int _LineNo;
		public int pLineNo
		{
			set
			{
				this._LineNo = value;
			}
			get
			{
				return this._LineNo;
			}
		}
		private string _AmountColumnInFolioTrans;
		public string pAmountColumnInFolioTrans
		{
			set
			{
				this._AmountColumnInFolioTrans = value;
			}
			get
			{
				return this._AmountColumnInFolioTrans;
			}
		}
		private string _CostCenterCode;
		public string pCostCenterCode
		{
			set
			{
				this._CostCenterCode = value;
			}
			get
			{
				return this._CostCenterCode;
			}
		}
		private string _JournalEntryCode;
		public string pJournalEntryCode
		{
			set
			{
				this._JournalEntryCode = value;
			}
			get
			{
				return this._JournalEntryCode;
			}
		}
		private string _StatuFlag;
		public string pStatuFlag
		{
			set
			{
				this._StatuFlag = value;
			}
			get
			{
				return this._StatuFlag;
			}
		}
		private string _CreatedBy;
		public string pCreatedBy
		{
			set
			{
				this._CreatedBy = value;
			}
			get
			{
				return this._CreatedBy;
			}
		}
		private DateTime _CreatedDate;
		public DateTime pCreatedDate
		{
			set
			{
				this._CreatedDate = value;
			}
			get
			{
				return this._CreatedDate;
			}
		}
		private string _UpdatedBy;
		public string pUpdatedBy
		{
			set
			{
				this._UpdatedBy = value;
			}
			get
			{
				return this._UpdatedBy;
			}
		}
		private DateTime _UpdatedDate;
		public DateTime pUpdatedDate
		{
			set
			{
				this._UpdatedDate = value;
			}
			get
			{
				return this._UpdatedDate;
			}
		}
	}
}