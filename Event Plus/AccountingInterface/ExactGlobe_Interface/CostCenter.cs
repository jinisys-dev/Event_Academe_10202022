using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Jinsiys.Hotel.AccountingInterface.ExactGlobe.BusinessLayer
{
	public class eCostCenter
	{
		public eCostCenter()
		{
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
