using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlinePharmacyOrdaringSystem.Manager;
using OnlinePharmacyOrdaringSystem.Models;

namespace OnlinePharmacyOrdaringSystem.Controllers
{
    public class PharmacyController : Controller
    {
        PharmacyManager aPharmacyManager = new PharmacyManager();

        
        // GET: /Pharmacy/
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Pharmacy pharmacy)
        {
            ViewBag.Message = aPharmacyManager.Save(pharmacy);
            return View();
        }


        public ActionResult EditPharmacy(int id)
        {
            //PharmacyUserManager aPharmUser = new PharmacyUserManager();
            return View(aPharmacyManager.GetAllPharmacies().Find(smodel => smodel.PharmUserId == id));
        }

        [HttpPost]
        public ActionResult EditPharmacy(int id, Pharmacy pharmacy)
        {
            PharmacyManager aPharmacy = new PharmacyManager();
            aPharmacy.UpdatePharmacy(pharmacy);

            //return View();
            return RedirectToAction("AfterLogin", "PharmacyUser");


            //return RedirectToAction("AfterLogin");
            //try
            //{
            //    PharmacyUserManager aPharmUser = new PharmacyUserManager();
            //    aPharmUser.UpdateUser(pharmacyUser);
            //    return RedirectToAction("AfterLogin");
            //}
            //catch
            //{
            //    return View();
            //}
        }



        public ActionResult DeletePharmacy(int id)
        {
            aPharmacyManager.DeletePharmacy(id);
            return View("Save");
        }

        //public ActionResult RemovePharmacy(int id)
        //{
        //    var pharm = aPharmacyManager.GetAllPharmacies().Where(r => r.PharmUserId == id).First();
        //    aPharmacyManager.GetAllPharmacies().Remove(pharm);
            
        //    var pharm2 = aPharmacyManager.GetAllPharmacies().ToList();
        //    //return View(pharm2);
        //    return View("Save");
        //}


	}
}