using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlinePharmacyOrdaringSystem.Gateway;
using OnlinePharmacyOrdaringSystem.Models;

namespace OnlinePharmacyOrdaringSystem.Manager
{
    public class OrderManager
    {
        private OrderGateway aOrderGateway = new OrderGateway();

        public List<Order> GetAllOrders()
        {
            return aOrderGateway.GetAllOrders();
        }


        //public string AcceptOrder(ReceivedOrder receivedOrder)
        //{
        //    int rowAffected = aOrderGateway.AcceptOrder(receivedOrder);
        //    if (rowAffected > 0)
        //    {
        //        return "Order accepted";
        //    }
        //    else
        //    {
        //        return "Order acceptacne failed";
        //    }
        //}



        public string AcceptOrder(Order order)
        {
            int rowAffected = aOrderGateway.AcceptOrder(order);
            if (rowAffected > 0)
            {
                return "Order accepted";
            }
            else
            {
                return "Order acceptacne failed";
            }
        }

        public string RejectOrder(Order order)
        {
            int rowAffected = aOrderGateway.RejectOrder(order);
            if (rowAffected > 0)
            {
                return "Order rejected";
            }
            else
            {
                return "Order reject failed";
            }
        }

        public string DeliverOrder(Order order)
        {
            int rowAffected = aOrderGateway.DeliverOrder(order);
            if (rowAffected > 0)
            {
                return "Order delivered";
            }
            else
            {
                return "Order not delivered";
            }
        }
    }
}