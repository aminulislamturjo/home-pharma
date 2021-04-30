using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlinePharmacyOrdaringSystem.Gateway;
using OnlinePharmacyOrdaringSystem.Models;

namespace OnlinePharmacyOrdaringSystem.Manager
{
    public class PharmacyUserManager
    {
        PharmacyUserGateway aPharmacyUserGateway = new PharmacyUserGateway();


        public string Save(PharmacyUser pharmacyUser)
        {
            int rowAffected = aPharmacyUserGateway.Save(pharmacyUser);
            if (rowAffected > 0)
            {
                return "Your account is registered successfully.";
            }
            else
            {
                return "Registration failed";
            }
        }


        public List<PharmacyUser> GetAllPharmacyUsers()
        {
            return aPharmacyUserGateway.GetAllPharmacyUsers();
        }

        public int UpdateUser(PharmacyUser pharmacyUser)
        {
            return aPharmacyUserGateway.UpdateUser(pharmacyUser);
        }

        //public string Save(PharmacyUser pharmacyUser)
        //{
        //    if (aPharmacyUserGateway.IsExist(pharmacyUser))
        //    {
        //        return "User already exists. Add new.";
        //    }
        //    else
        //    {
        //        int rowAffected = aPharmacyUserGateway.Save(pharmacyUser);
        //        if (rowAffected > 0)
        //        {
        //            return "User account saved successfully.";
        //        }
        //        else
        //        {
        //            return "Save failed.";
        //        }
        //    }
        //}
    }
}