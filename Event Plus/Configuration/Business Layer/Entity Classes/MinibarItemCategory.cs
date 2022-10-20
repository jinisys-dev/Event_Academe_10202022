using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Jinisys.Hotel.ConfigurationHotel.BusinessLayer
{
    class MinibarItemCategory : DataTable
    {
		public MinibarItemCategory(String name)
            : base(name)
        { }
        private int categoryId;
        public int CategoryID
        {
            get { return categoryId; }
            set { categoryId = value; }
        }
        private String categoryName;
        public String CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }
       
    }
}
