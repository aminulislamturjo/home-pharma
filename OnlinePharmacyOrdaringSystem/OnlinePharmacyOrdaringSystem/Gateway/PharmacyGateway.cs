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
    public class PharmacyGateway
    {
        string connectionString =
                WebConfigurationManager.ConnectionStrings["PharmacyDBConnection"].ConnectionString;
        public int Save(Pharmacy pharmacy)
        {

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "INSERT INTO Pharmacy VALUES(@pharmacyName, @owner, @address, @email, @contactNo, @latitude, @longitude, @description, @date, @pharmUserId)";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();

            command.Parameters.Add("pharmacyName", SqlDbType.VarChar);
            command.Parameters["pharmacyName"].Value = pharmacy.PharmacyName;
            command.Parameters.Add("owner", SqlDbType.VarChar);
            command.Parameters["owner"].Value = pharmacy.Owner;
            command.Parameters.Add("address", SqlDbType.VarChar);
            command.Parameters["address"].Value = pharmacy.Address;
            command.Parameters.Add("email", SqlDbType.VarChar);
            command.Parameters["email"].Value = pharmacy.Email;
            command.Parameters.Add("contactNo", SqlDbType.VarChar);
            command.Parameters["contactNo"].Value = pharmacy.ContactNo;
            command.Parameters.Add("latitude", SqlDbType.VarChar);
            command.Parameters["latitude"].Value = pharmacy.Latitude;
            command.Parameters.Add("longitude", SqlDbType.VarChar);
            command.Parameters["longitude"].Value = pharmacy.Longitude;
            command.Parameters.Add("description", SqlDbType.VarChar);
            command.Parameters["description"].Value = pharmacy.Description;
            command.Parameters.Add("date", SqlDbType.Date);
            command.Parameters["date"].Value = pharmacy.Date;

            command.Parameters.Add("pharmUserId", SqlDbType.Int);
            command.Parameters["pharmUserId"].Value = pharmacy.PharmUserId;

            connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowAffected;
        }


        public int DeletePharmacy(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "DELETE FROM Pharmacy WHERE PharmUserId = @pharmUserId ";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();


            command.Parameters.Add("pharmUserId", SqlDbType.Int);
            command.Parameters["pharmUserId"].Value = id;

            connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowAffected;
        }

        //public List<Pharmacy> GetAllPharmacies()
        //{
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    string query = "SELECT * FROM Pharmacy";
        //    SqlCommand command = new SqlCommand(query, connection);
        //    connection.Open();

        //    SqlDataReader reader = command.ExecuteReader();
        //    List<Pharmacy> pharmacies = new List<Pharmacy>();
        //    while (reader.Read())
        //    {
        //        Pharmacy aPharmacy = new Pharmacy();
        //        aPharmacy.Id = (int)reader["Id"];
        //        aPharmacy.PharmacyName = reader["PharmacyName"].ToString();
        //        aPharmacy.Latitude = reader["Latitude"].ToString();
        //        aPharmacy.Longitude = reader["Longitude"].ToString();
        //        aPharmacy.Description = reader["Description"].ToString();

        //        pharmacies.Add(aPharmacy);
        //    }

        //    reader.Close();
        //    connection.Close();
        //    return pharmacies;
        //}

        public List<Pharmacy> GetAllPharmacies()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Pharmacy";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            List<Pharmacy> pharmacies = new List<Pharmacy>();
            while (reader.Read())
            {
                Pharmacy aPharmacy = new Pharmacy();
                aPharmacy.Id = (int)reader["Id"];
                aPharmacy.PharmacyName = reader["PharmacyName"].ToString();
                aPharmacy.Owner = reader["Owner"].ToString();
                aPharmacy.Address = reader["Address"].ToString();
                aPharmacy.Email = reader["Email"].ToString();
                aPharmacy.ContactNo = reader["ContactNo"].ToString();
                aPharmacy.Latitude = reader["Latitude"].ToString();
                aPharmacy.Longitude = reader["Longitude"].ToString();
                aPharmacy.Description = reader["Description"].ToString();
                //aPharmacy.Date = Convert.ToDateTime(reader["Date"].ToString());
                aPharmacy.PharmUserId = (int)reader["PharmUserId"];

                pharmacies.Add(aPharmacy);
            }

            reader.Close();
            connection.Close();
            return pharmacies;
        }

        public int UpdatePharmacy(Pharmacy pharmacy)
        {

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "UPDATE Pharmacy SET PharmacyName = @pharmacyName, Owner = @owner, Address = @address,  Email = @email, ContactNo = @contactNo, Description = @description WHERE PharmUserId = @pharmUserId";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();

            command.Parameters.Add("pharmacyName", SqlDbType.VarChar);
            command.Parameters["pharmacyName"].Value = pharmacy.PharmacyName;

            command.Parameters.Add("owner", SqlDbType.VarChar);
            command.Parameters["owner"].Value = pharmacy.Owner;

            command.Parameters.Add("address", SqlDbType.VarChar);
            command.Parameters["address"].Value = pharmacy.Address;

            command.Parameters.Add("email", SqlDbType.VarChar);
            command.Parameters["email"].Value = pharmacy.Email;

            command.Parameters.Add("contactNo", SqlDbType.VarChar);
            command.Parameters["contactNo"].Value = pharmacy.ContactNo;

            command.Parameters.Add("description", SqlDbType.VarChar);
            command.Parameters["description"].Value = pharmacy.Description;

            command.Parameters.Add("pharmUserId", SqlDbType.Int);
            command.Parameters["pharmUserId"].Value = pharmacy.PharmUserId;

            connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowAffected;
        }

      
        

        public bool IsExist(Pharmacy pharmacy)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Pharmacy WHERE PharmacyName = @pharmacyName OR Email = @email";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();
            command.Parameters.Add("pharmacyName", SqlDbType.VarChar);
            command.Parameters["pharmacyName"].Value = pharmacy.PharmacyName;
            command.Parameters.Add("email", SqlDbType.VarChar);
            command.Parameters["email"].Value = pharmacy.Email;

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            bool hasRow = false;
            if (reader.HasRows)
            {
                hasRow = true;
            }

            reader.Close();

            connection.Close();
            return hasRow;
        }
    }
}