using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlinePharmacyOrdaringSystem.Models
{
    public class ReceivedOrder
    {
        public int ReceivedOrderId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerContact { get; set; }
        public string MedicineName { get; set; }
        public int Quantity { get; set; }
        public int OrdersId { get; set; }
    }
}