using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Jinisys.Hotel.ConfigurationHotel.BusinessLayer
{
    public class MinibarItem : DataTable
    {
		public MinibarItem(String table)
            : base(table)
        { }
        private string itemCode;
        public string ItemCode
        {
			get { return itemCode; }
			set { itemCode = value; }
        }
        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private decimal unitPrice;
        public decimal UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }
        private int categoryId;
        public int CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }
    }
}
