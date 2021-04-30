using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using OnlinePharmacyOrdaringSystem.Models;

namespace OnlinePharmacyOrdaringSystem.Gateway
{
    public class OrderGateway
    {
        string connectionString =
                WebConfigurationManager.ConnectionStrings["PharmacyDBConnection"].ConnectionString;


        public List<Order> GetAllOrders()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM MedicineOrders";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            List<Order> orders = new List<Order>();
            while (reader.Read())
            {
                Order aOrder = new Order();
                aOrder.OrderId = (int)reader["OrderId"];
                aOrder.CustomerName = reader["CustomerName"].ToString();
                aOrder.CustomerAddress = reader["CustomerAddress"].ToString();
                aOrder.CustomerContact = reader["CustomerContact"].ToString();
                aOrder.MedicineName = reader["MedicineName"].ToString();
                aOrder.Quantity = (int)reader["Quantity"];
                aOrder.Category = reader["Category"].ToString();            
                aOrder.CustomerId = (int)reader["CustomerID"];
                aOrder.TotalBill = (int)reader["TotalBill"];
                
                orders.Add(aOrder);
            }

            reader.Close();
            connection.Close();
            return orders;
        }


        //public int AcceptOrder(ReceivedOrder receivedOrder)
        //{
        //    SqlConnection connection = new SqlConnection(connectionString);

        //    string query = "INSERT INTO ReceivedOrder(OrdersId) SELECT OrderId FROM MedicineOrders";
        //    SqlCommand command = new SqlCommand(query, connection);
        //    //command.Parameters.Clear();
        //    //command.Parameters.Add("ordersId", SqlDbType.Int);
        //    //command.Parameters["ordersId"].Value = receivedOrder.OrdersId;
            
        //    connection.Open();

        //    int rowAffected = command.ExecuteNonQuery();

        //    connection.Close();

        //    return rowAffected;
        //}

        //public int AcceptOrder(Order order)
        //{
        //    SqlConnection connection = new SqlConnection(connectionString);

        //    string query = "UPDATE MedicineOrders SET Accepted = @accepted ADD = 'True' WHERE OrderId = @orderId";
        //    SqlCommand command = new SqlCommand(query, connection);

        //    command.Parameters.Clear();

        //    command.Parameters.AddWithValue("accepted", order.Accepted);
        //    command.Parameters.AddWithValue("orderId", order.OrderId);


        //    connection.Open();

        //    int rowAffected = command.ExecuteNonQuery();

        //    connection.Close();

        //    return rowAffected;
        //}


        //public int AcceptOrder(Order order)
        //{
        //    SqlConnection connection = new SqlConnection(connectionString);

        //    string query = "UPDATE MedicineOrders SET Accepted = 'Order accepted' WHERE OrderId = @orderId";

        //    //string query = "UPDATE MedicineOrders SET Accepted = @accepted WHERE OrderId = @orderId";
        //    SqlCommand command = new SqlCommand(query, connection);

        //    command.Parameters.Clear();

        //    //command.Parameters.AddWithValue("accepted", order.Accepted);
        //    command.Parameters.AddWithValue("orderId", order.OrderId);


        //    connection.Open();

        //    int rowAffected = command.ExecuteNonQuery();

        //    connection.Close();

        //    return rowAffected;
        //}


        public int AcceptOrder(Order order)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string message = "Your order is accepted by " + order.PharmacyUserName;

            string query = "INSERT INTO NotificationTbl VALUES(@orderIDFK, @pharmUserID, GETDATE(), 'Accepted', @message)";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();
            command.Parameters.Add("orderIDFK", SqlDbType.Int);
            command.Parameters["orderIDFK"].Value = order.OrderId;
            command.Parameters.Add("pharmUserID", SqlDbType.Int);
            command.Parameters["pharmUserID"].Value = order.PharmUserId;
            command.Parameters.Add("message", SqlDbType.VarChar);
            command.Parameters["message"].Value = message;
            


            connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowAffected;
        }


        public int RejectOrder(Order order)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string message = "Your order is rejected by " + order.PharmacyUserName;


            string query = "INSERT INTO NotificationTbl VALUES(@orderIDFK, @pharmUserID, GETDATE(), 'Rejected', @message)";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();
            command.Parameters.Add("orderIDFK", SqlDbType.Int);
            command.Parameters["orderIDFK"].Value = order.OrderId;
            command.Parameters.Add("pharmUserID", SqlDbType.Int);
            command.Parameters["pharmUserID"].Value = order.PharmUserId;
            command.Parameters.Add("message", SqlDbType.VarChar);
            command.Parameters["message"].Value = message;


            connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowAffected;
        }


        public int DeliverOrder(Order order)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string message = "Your order is delivered by " + order.PharmacyUserName;


            string query = "INSERT INTO NotificationTbl VALUES(@orderIDFK, @pharmUserID, GETDATE(), 'Delivered', @message)";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();
            command.Parameters.Add("orderIDFK", SqlDbType.Int);
            command.Parameters["orderIDFK"].Value = order.OrderId;
            command.Parameters.Add("pharmUserID", SqlDbType.Int);
            command.Parameters["pharmUserID"].Value = order.PharmUserId;
            command.Parameters.Add("message", SqlDbType.VarChar);
            command.Parameters["message"].Value = message;


            connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowAffected;
        }

        //public int RejectOrder(Order order)
        //{
        //    SqlConnection connection = new SqlConnection(connectionString);

        //    string query = "UPDATE MedicineOrders SET Accepted = 'Order rejected' WHERE OrderId = @orderId";

        //    //string query = "UPDATE MedicineOrders SET Accepted = @accepted WHERE OrderId = @orderId";
        //    SqlCommand command = new SqlCommand(query, connection);

        //    command.Parameters.Clear();

        //    //command.Parameters.AddWithValue("accepted", order.Accepted);
        //    command.Parameters.AddWithValue("orderId", order.OrderId);


        //    connection.Open();

        //    int rowAffected = command.ExecuteNonQuery();

        //    connection.Close();

        //    return rowAffected;
        //}


        //public int DeliverOrder(Order order)
        //{
        //    SqlConnection connection = new SqlConnection(connectionString);

        //    string query = "UPDATE MedicineOrders SET Delivered = 'Order delivered' WHERE OrderId = @orderId";

        //    //string query = "UPDATE MedicineOrders SET Accepted = @accepted WHERE OrderId = @orderId";
        //    SqlCommand command = new SqlCommand(query, connection);

        //    command.Parameters.Clear();

        //    //command.Parameters.AddWithValue("accepted", order.Accepted);
        //    command.Parameters.AddWithValue("orderId", order.OrderId);


        //    connection.Open();

        //    int rowAffected = command.ExecuteNonQuery();

        //    connection.Close();

        //    return rowAffected;
        //}
    }
}