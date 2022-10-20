using System;
using System.Collections.Generic;
using System.Text;

namespace Jinisys.Hotel.Reservation.BusinessLayer
{
    public class MinibarSalesDetail
    {
        private int sales_id;
        public int Sales_Id
        {
            get { return sales_id; }
            set { sales_id = value; }
        }
        private string item_code;
        public string Item_Code
        {
            get { return item_code; }
            set { item_code = value; }
        }

        private string item_description;
        public string Item_Description
        {
            get { return item_description; }
            set { item_description = value; }
        }

        private int qty;
        public int Qty
        {
            get { return qty; }
            set { qty = value; }
        }
        private decimal unit_price;
        public decimal Unit_Price
        {
            get { return unit_price; }
            set { unit_price = value; }
        }

    }
}
