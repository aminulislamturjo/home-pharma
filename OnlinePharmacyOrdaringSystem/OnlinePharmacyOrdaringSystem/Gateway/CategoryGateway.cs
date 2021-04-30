using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using OnlinePharmacyOrdaringSystem.Models;

namespace OnlinePharmacyOrdaringSystem.Gateway
{
    public class CategoryGateway
    {
        string connectionString =
                WebConfigurationManager.ConnectionStrings["PharmacyDBConnection"].ConnectionString;
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
                Category aCategory = new Category();
                aCategory.Id = (int)reader["Id"];
                aCategory.Name = reader["Name"].ToString();

                categories.Add(aCategory);
            }

            reader.Close();
            connection.Close();
            return categories;
        }
    }
}