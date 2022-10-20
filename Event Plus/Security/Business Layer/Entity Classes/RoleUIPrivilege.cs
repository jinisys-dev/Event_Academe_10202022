using System;
using System.Collections.Generic;
using System.Text;

namespace Jinisys.Hotel.Security.BusinessLayer
{
	public class RoleUIPrivilege
	{
		public RoleUIPrivilege()
		{ 
		}


		private string mRoleName;
			public string RoleName
			{
				set
				{
					this.mRoleName = value;
				}
				get
				{
					return this.mRoleName.ToUpper();
				}
			}

		private string mModule;
		public string Module
		{
			set
			{
				this.mModule = value;
			}
			get
			{
				return this.mModule.ToUpper();
			}
		}

		private string mFormName;
		public string FormName
		{
			set
			{
				this.mFormName = value;
			}
			get
			{
				return this.mFormName.ToUpper();
			}
		}

		private string mButtonName;
		public string ButtonName
		{
			set
			{
				this.mButtonName = value;
			}
			get
			{
				return this.mButtonName.ToUpper();
			}
		}

		private int mIsVisible;
		public int IsVisible
		{
			set
			{
				this.mIsVisible = value;
			}
			get
			{
				return this.mIsVisible;
			}
		}

		private string mStatusFlag;
		public string StatusFlag
		{
			set
			{
				this.mStatusFlag = value;
			}
			get
			{
				return this.mStatusFlag.ToUpper();
			}
		}

	}
}
