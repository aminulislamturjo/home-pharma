using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace OnlinePharmacyOrdaringSystem.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int PharmUserId { get; set; }
        public string PharmacyUserName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerContact { get; set; }
        public string MedicineName { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
        public int TotalBill { get; set; }
        public string Accepted { get; set; }
        public string Rejected { get; set; }
        public string Delivered { get; set; }

        public DateTime Date { get; set; }

    }
}