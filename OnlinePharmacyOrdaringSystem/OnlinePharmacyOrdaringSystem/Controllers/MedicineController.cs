//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using OnlinePharmacyOrdaringSystem.Manager;
//using OnlinePharmacyOrdaringSystem.Models;

//namespace OnlinePharmacyOrdaringSystem.Controllers
//{
//    public class MedicineController : Controller
//    {

//        MedicineManager aMedicineManager = new MedicineManager();
//        CategoryManager aCategoryManager = new CategoryManager();

//        //public ActionResult SaveMedicine()
//        //{
//        //    ViewBag.Category = aCategoryManager.GetAllCategories();
//        //    return View();
//        //}

//        //[HttpPost]
//        //public ActionResult SaveMedicine(Medicine medicine, HttpPostedFileBase imageId)
//        //{
//        //    //medicine.ImageId = new byte[imageId.ContentLength];
//        //    //imageId.InputStream.Read(medicine.ImageId, 0, imageId.ContentLength);
//        //    ViewBag.Category = aCategoryManager.GetAllCategories();
//        //    ViewBag.Message = aMedicineManager.Save(medicine, imageId);
//        //    return View();
//        //}


//        //public ActionResult ShowMedicine()
//        //{
//        //    ViewBag.Category = aCategoryManager.GetAllCategories();

//        //    List<Medicine> medicines = aMedicineManager.GetAllMedicines();
//        //    ViewBag.medicines = aMedicineManager.GetAllMedicines();
//        //    ViewBag.tablets = aMedicineManager.GetAllTablets();
//        //    ViewBag.capsule = aMedicineManager.GetAllCapsule();
//        //    ViewBag.syrup = aMedicineManager.GetAllSyrup();
           
//        //    return View(medicines);
//        //}


//        //[HttpPost]
//        //public ActionResult IncrementQuantity(Medicine medicine)
//        //{
//        //    ViewBag.Category = aCategoryManager.GetAllCategories();
//        //    ViewBag.Message = aMedicineManager.IncrementMedicine(medicine);
//        //    return RedirectToAction("SaveMedicine");
//        //}


//        //[HttpPost]
//        //public ActionResult DecrementQuantity(Medicine medicine)
//        //{
//        //    ViewBag.Category = aCategoryManager.GetAllCategories();
//        //    ViewBag.Message = aMedicineManager.DecrementMedicine(medicine);
//        //    return RedirectToAction("SaveMedicine");
//        //}

//    }
//}