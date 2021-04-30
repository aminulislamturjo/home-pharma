using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlinePharmacyOrdaringSystem.Gateway;
using OnlinePharmacyOrdaringSystem.Models;

namespace OnlinePharmacyOrdaringSystem.Manager
{
    public class PharmacyManager
    {
        PharmacyGateway aPharmacyGateway = new PharmacyGateway();

        public string Save(Pharmacy pharmacy)
        {
            if (aPharmacyGateway.IsExist(pharmacy))
            {
                return "Pharmacy already exists. Add new.";
            }
            else
            {
                int rowAffected = aPharmacyGateway.Save(pharmacy);
                if (rowAffected > 0)
                {
                    return "Pharmacy saved successfully.";
                }
                else
                {
                    return "Save failed.";
                }
            }
        }

        public List<Pharmacy> GetAllPharmacies()
        {
            return aPharmacyGateway.GetAllPharmacies();
        }

        public int UpdatePharmacy(Pharmacy pharmacy)
        {
            return aPharmacyGateway.UpdatePharmacy(pharmacy);
        }

        public int DeletePharmacy(int id)
        {
            return aPharmacyGateway.DeletePharmacy(id);
        }
    }
}