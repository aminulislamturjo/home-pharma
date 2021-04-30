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
    public class MedicineGateway
    {
        string connectionString =
                WebConfigurationManager.ConnectionStrings["PharmacyDBConnection"].ConnectionString;
        //public int Save(Medicine medicine, HttpPostedFileBase imageId)
        //{
        //    //medicine.Image = new byte[imageId.ContentLength];
        //    //imageId.InputStream.Read(medicine.Image, 0, imageId.ContentLength);

        //    SqlConnection connection = new SqlConnection(connectionString);

        //    string query = "INSERT INTO Medicine VALUES(@name, @quantity, @categoryId, @price, @image)";
        //    SqlCommand command = new SqlCommand(query, connection);

        //    command.Parameters.Clear();
        //    command.Parameters.Add("name", SqlDbType.VarChar);
        //    command.Parameters["name"].Value = medicine.Name;
        //    command.Parameters.Add("quantity", SqlDbType.Int);
        //    command.Parameters["quantity"].Value = medicine.Quantity;
        //    command.Parameters.Add("categoryId", SqlDbType.Int);
        //    command.Parameters["categoryId"].Value = medicine.CategoryId;
        //    command.Parameters.Add("price", SqlDbType.Float);
        //    command.Parameters["price"].Value = medicine.Price;
        //    command.Parameters.Add("image", SqlDbType.VarBinary);
        //    command.Parameters["image"].Value = medicine.ImageId;
        //    connection.Open();

        //    int rowAffected = command.ExecuteNonQuery();
        //    connection.Close();
        //    return rowAffected;
        //}


        public List<Category> GetAllCategories()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Category";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            List<Category> categories = new List<Category>();

            while (reader.Read())
            {
                Category aCategory = new Category
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString()
                };
                categories.Add(aCategory);
            }

            reader.Close();
            connection.Close();

            return categories;
        }


        public bool IsExist(Medicine medicine)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Medicine WHERE Name = @name";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();
            command.Parameters.Add("name", SqlDbType.VarChar);
            command.Parameters["name"].Value = medicine.Name;

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


        public List<Medicine> GetAllMedicines()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Medicine";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            List<Medicine> medicines = new List<Medicine>();
            while (reader.Read())
            {
                Medicine aMedicine = new Medicine();
                aMedicine.Id = (int)reader["Id"];
                aMedicine.Name = reader["Name"].ToString();
                aMedicine.Quantity = (int)reader["Quantity"];
                aMedicine.CategoryId = (int)reader["CategoryId"];
                aMedicine.Price = Convert.ToDouble(reader["Price"]);
             
                

                medicines.Add(aMedicine);
            }

            reader.Close();
            connection.Close();
            return medicines;
        }


        public List<Medicine> GetAllTablets()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Medicine WHERE CategoryId = 1";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            List<Medicine> tablets = new List<Medicine>();
            while (reader.Read())
            {
                Medicine aMedicine = new Medicine();
                aMedicine.Id = (int)reader["Id"];
                aMedicine.Name = reader["Name"].ToString();
                aMedicine.Quantity = (int)reader["Quantity"];
                aMedicine.CategoryId = (int)reader["CategoryId"];
                aMedicine.Price = Convert.ToDouble(reader["Price"]);

                aMedicine.Image = (string) reader["Image"];
            

                tablets.Add(aMedicine);
            }

            reader.Close();
            connection.Close();
            return tablets;
        }


        public List<Medicine> GetAllCapsule()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Medicine WHERE CategoryId = 2";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            List<Medicine> capsule = new List<Medicine>();
            while (reader.Read())
            {
                Medicine aMedicine = new Medicine();
                aMedicine.Id = (int)reader["Id"];
                aMedicine.Name = reader["Name"].ToString();
                aMedicine.Quantity = (int)reader["Quantity"];
                aMedicine.CategoryId = (int)reader["CategoryId"];
                aMedicine.Price = Convert.ToDouble(reader["Price"]);

                aMedicine.Image = (string)reader["Image"];
        


                capsule.Add(aMedicine);
            }

            reader.Close();
            connection.Close();
            return capsule;
        }

        public List<Medicine> GetAllSyrup()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Medicine WHERE CategoryId = 3";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            List<Medicine> syrup = new List<Medicine>();
            while (reader.Read())
            {
                Medicine aMedicine = new Medicine();
                aMedicine.Id = (int)reader["Id"];
                aMedicine.Name = reader["Name"].ToString();
                aMedicine.Quantity = (int)reader["Quantity"];
                aMedicine.CategoryId = (int)reader["CategoryId"];
                aMedicine.Price = Convert.ToDouble(reader["Price"]);

                aMedicine.Image = (string)reader["Image"];
           



                syrup.Add(aMedicine);
            }

            reader.Close();
            connection.Close();
            return syrup;
        }


        public int UpdateQuantity(Medicine medicine)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "UPDATE Medicine SET Quantity = Quantity + @quantity WHERE Name = @name";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();

            command.Parameters.AddWithValue("quantity", medicine.Quantity);
            command.Parameters.AddWithValue("name", medicine.Name);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;

        }


        public int IncrementQuantity(Medicine medicine)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "UPDATE Medicine SET Quantity = Quantity + 1 WHERE Id = @id";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();

            command.Parameters.AddWithValue("quantity", medicine.Quantity);
            command.Parameters.AddWithValue("id", medicine.Id);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }



        public int DecrementQuantity(Medicine medicine)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "UPDATE Medicine SET Quantity = Quantity - 1 WHERE Id = @id";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();

            command.Parameters.AddWithValue("quantity", medicine.Quantity);
            command.Parameters.AddWithValue("id", medicine.Id);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }
    }
}