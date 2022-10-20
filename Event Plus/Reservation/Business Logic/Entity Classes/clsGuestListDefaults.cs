using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Jinisys.Hotel.Reservation.BusinessLayer
{
	public class clsGuestListDefaults
	{
		private string mTableLineID;
		public string TableLineID
		{
			set { this.mTableLineID = value; }
			get { return this.TableLineID; }
		}

		private string mFolioStatusSelected;
		public string FolioStatusSelected
		{
			set { this.mFolioStatusSelected = value; }
			get { return this.mFolioStatusSelected; }
		}

		private string mFolioTypeSelected;
		public string FolioTypeSelected
		{
			set { this.mFolioTypeSelected = value; }
			get { return this.mFolioTypeSelected; }
		}


		private ArrayList mAvailableFolioTypes;
		public ArrayList AvailableFolioTypes
		{
			set { this.mAvailableFolioTypes = value; }
			get { return this.mAvailableFolioTypes; }
		}

		public void setAvailableFolioTypes(string pFolioTypes)
		{
			this.mAvailableFolioTypes = new ArrayList();

			string[] folioTypes = pFolioTypes.Split(',');
			foreach (string str in folioTypes)
			{
				this.mAvailableFolioTypes.Add(str.TrimEnd());
			}

		}

	}
}
