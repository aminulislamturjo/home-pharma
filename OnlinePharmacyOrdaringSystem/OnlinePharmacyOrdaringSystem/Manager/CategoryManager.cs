using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlinePharmacyOrdaringSystem.Gateway;
using OnlinePharmacyOrdaringSystem.Models;

namespace OnlinePharmacyOrdaringSystem.Manager
{
    public class CategoryManager
    {
        CategoryGateway aCategoryGateway = new CategoryGateway();
        public List<Category> GetAllCategories()
        {
            return aCategoryGateway.GetAllCategories();
        } 
    }
}