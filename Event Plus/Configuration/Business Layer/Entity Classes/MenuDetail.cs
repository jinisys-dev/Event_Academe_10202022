using System;
using System.Data;
namespace Jinisys.Hotel.Configuration.BusinessLayer
{
	
	public class MenuDetail
	{
		public MenuDetail()
		{
			
		}
		private string mMENU_ID;
		public string MENU_ID
		{
			get{return mMENU_ID;}
			set{mMENU_ID=value;}
		}
		private string mITEM_ID;
		public string ITEM_ID
		{
			get{return mITEM_ID;}
			set{mITEM_ID=value;}
		}
		private int mQUANTITY;
		public int QUANTITY
		{
			get{return mQUANTITY;}
			set{mQUANTITY=value;}
		}
	}
}
