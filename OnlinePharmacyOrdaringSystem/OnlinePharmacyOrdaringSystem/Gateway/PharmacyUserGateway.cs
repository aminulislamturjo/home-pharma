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
    public class PharmacyUserGateway
    {
        string connectionString =
                WebConfigurationManager.ConnectionStrings["PharmacyDBConnection"].ConnectionString;

        public int Save(PharmacyUser pharmacyUser)
        {

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "INSERT INTO PharmacyUserTbl VALUES(@userName, @email, @password)";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();

            command.Parameters.Add("userName", SqlDbType.VarChar);
            command.Parameters["userName"].Value = pharmacyUser.Username;
          
            command.Parameters.Add("email", SqlDbType.VarChar);
            command.Parameters["email"].Value = pharmacyUser.Email;

            command.Parameters.Add("password", SqlDbType.VarChar);
            command.Parameters["password"].Value = pharmacyUser.Password;

            


            connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowAffected;
        }


        public List<PharmacyUser> GetAllPharmacyUsers()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM PharmacyUserTbl";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            List<PharmacyUser> pharmacyUsers = new List<PharmacyUser>();
            while (reader.Read())
            {
                PharmacyUser aPharmacyUser = new PharmacyUser();
                aPharmacyUser.PharmacyUserID = (int)reader["PharmacyUserID"];
                aPharmacyUser.Username = reader["Username"].ToString();
                aPharmacyUser.Email = reader["Email"].ToString();
                aPharmacyUser.Password = reader["Password"].ToString();
                

                pharmacyUsers.Add(aPharmacyUser);
            }

            reader.Close();
            connection.Close();
            return pharmacyUsers;
        }

        public int UpdateUser(PharmacyUser pharmacyUser)
        {

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "UPDATE PharmacyUserTbl SET Username = @userName, Email = @email, Password = @password WHERE PharmacyUserID = @pharmacyUserID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();

            command.Parameters.Add("userName", SqlDbType.VarChar);
            command.Parameters["userName"].Value = pharmacyUser.Username;

            command.Parameters.Add("email", SqlDbType.VarChar);
            command.Parameters["email"].Value = pharmacyUser.Email;

            command.Parameters.Add("password", SqlDbType.VarChar);
            command.Parameters["password"].Value = pharmacyUser.Password;

            command.Parameters.Add("pharmacyUserID", SqlDbType.Int);
            command.Parameters["pharmacyUserID"].Value = pharmacyUser.PharmacyUserID;


            connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowAffected;
        }


        //public bool IsExist(PharmacyUser pharmacyUser)
        //{
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    string query = "SELECT * FROM PharmacyUserTbl WHERE Username = @userName OR Email = @email";

        //    SqlCommand command = new SqlCommand(query, connection);

        //    command.Parameters.Clear();
        //    command.Parameters.Add("userName", SqlDbType.VarChar);
        //    command.Parameters["userName"].Value = pharmacyUser.Username;

        //    command.Parameters.Add("email", SqlDbType.VarChar);
        //    command.Parameters["email"].Value = pharmacyUser.Email;

        //    connection.Open();

        //    SqlDataReader reader = command.ExecuteReader();

        //    bool hasRow = false;
        //    if (reader.HasRows)
        //    {
        //        hasRow = true;
        //    }

        //    reader.Close();

        //    connection.Close();
        //    return hasRow;
        //}

    }
}