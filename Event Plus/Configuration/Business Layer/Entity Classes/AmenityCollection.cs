
using System.Diagnostics;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.ConfigurationHotel.BusinessLayer
{
	public class AmenityCollection : CollectionBase
	{

        public AmenityCollection()
		{
		}

		public bool Add(Amenity oAmenity)
		{
            try
            {
                this.List.Add(oAmenity);
                return true;
            }
            catch
            {
                return false;
            }
		}

		public Amenity Item(int index)
		{
			return (Amenity)this.List[index];
		}

        public int count()
        {
            return this.count();
        }
	}
}
