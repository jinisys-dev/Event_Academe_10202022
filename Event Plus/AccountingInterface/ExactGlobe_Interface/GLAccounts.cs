using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Jinsiys.Hotel.AccountingInterface.ExactGlobe.BusinessLayer
{

    //prefix `e` represents Entity

	public class eGLaccounts
	{
		public eGLaccounts()
		{
		}
		private string _AccountID;
		public string pAccountID
		{
			set
			{
				this._AccountID = value;
			}
			get
			{
				return this._AccountID;
			}
		}
		private string _Description;
		public string pDescription
		{
			set
			{
				this._Description = value;
			}
			get
			{
				return this._Description;
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
		private string _AccountNature;
		public string pAccountNature
		{
			set
			{
				this._AccountNature = value;
			}
			get
			{
				return this._AccountNature;
			}
		}
		private string _StatusFlag;
		public string pStatusFlag
		{
			set
			{
				this._StatusFlag = value;
			}
			get
			{
				return this._StatusFlag;
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
	}
}
