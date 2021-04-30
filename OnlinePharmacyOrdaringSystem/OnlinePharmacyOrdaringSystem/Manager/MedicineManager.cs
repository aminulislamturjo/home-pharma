using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlinePharmacyOrdaringSystem.Gateway;
using OnlinePharmacyOrdaringSystem.Models;

namespace OnlinePharmacyOrdaringSystem.Manager
{
    public class MedicineManager
    {
        MedicineGateway aMedicineGateway = new MedicineGateway();
        
        //public string Save(Medicine medicine, HttpPostedFileBase imageId)
        //{
        //    if (aMedicineGateway.IsExist(medicine))
        //    {
        //        //return "Medicine already exists. Add new.";

        //        int rowAffected1 = aMedicineGateway.UpdateQuantity(medicine);
        //        if (rowAffected1 > 0)
        //        {
        //            return "Save successful";
        //        }
        //        else
        //        {
        //            return "Save failed";
        //        }

        //    }
        //    else
        //    {
        //        int rowAffected = aMedicineGateway.Save(medicine, imageId);
        //        if (rowAffected > 0)
        //        {
        //            return "Save successful";
        //        }
        //        else
        //        {
        //            return "Save failed";
        //        }
        //    }
        //}

        public List<Category> GetAllCategories()
        {
            return aMedicineGateway.GetAllCategories();
        }

        public List<Medicine> GetAllMedicines()
        {
            return aMedicineGateway.GetAllMedicines();
        }

        public List<Medicine> GetAllTablets()
        {
            return aMedicineGateway.GetAllTablets();
        }

        public List<Medicine> GetAllCapsule()
        {
            return aMedicineGateway.GetAllCapsule();
        }

        public List<Medicine> GetAllSyrup()
        {
            return aMedicineGateway.GetAllSyrup();
        }

        public int IncrementMedicine(Medicine medicine)
        {
            return aMedicineGateway.IncrementQuantity(medicine);
        }

        public int DecrementMedicine(Medicine medicine)
        {
            return aMedicineGateway.DecrementQuantity(medicine);
        }
    }
}