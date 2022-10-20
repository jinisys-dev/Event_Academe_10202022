using System;
using System.Collections.Generic;
using System.Text;

namespace Jinisys.Hotel.Reservation.BusinessLayer
{
    public class MinibarSale
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string housekeeper_id;
        public string HouseKeeper_ID
        {
            get { return housekeeper_id; }
            set { housekeeper_id = value; }
        }

        private string housekeeper_name;
        public string HouseKeeper_Name
        {
            get { return housekeeper_name; }
            set { housekeeper_name = value; }
        }

        private string room_id;
        public string Room_Id
        {
            get { return room_id; }
            set{room_id =value;}
        }
        private DateTime salesdate;
        public DateTime SalesDate
        {
            get { return salesdate; }
            set { salesdate = value; }
        }
        private decimal amount;
        public decimal Amount
        {
            get { return amount; }
        
        }
        private int total_qty;
        public int Total_Qty
        {
            get { return total_qty; }
          
        }
        public IList<MinibarSalesDetail> Details = new List<MinibarSalesDetail>();
        public void ComputeTotalAmount()
        {
            amount = 0;
            total_qty = 0;
            if (Details.Count == 0) return;
            for (int i = 0;i<Details.Count;i++)
            {
                amount += Details[i].Qty * Details[i].Unit_Price;
                total_qty += Details[i].Qty;
            }
        }
        

    }
}
