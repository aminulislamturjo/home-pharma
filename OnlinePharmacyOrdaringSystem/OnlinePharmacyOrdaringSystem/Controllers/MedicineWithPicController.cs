using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlinePharmacyOrdaringSystem.Manager;
using OnlinePharmacyOrdaringSystem.Models;

namespace OnlinePharmacyOrdaringSystem.Controllers
{
	public class MedicineWithPicController : Controller
	{
		MedicineWithPicDBEntities db = new MedicineWithPicDBEntities();
		CategoryManager aCategoryManager = new CategoryManager();
		MedicineManager aMedicineManager = new MedicineManager();

	
		// GET: /MedicineWithPic/
		public ActionResult AddNewMedicine()
		{
			ViewBag.Category = aCategoryManager.GetAllCategories();
			List<Medicine> medicines = aMedicineManager.GetAllMedicines();
			ViewBag.medicines = aMedicineManager.GetAllMedicines();
			ViewBag.tablets = aMedicineManager.GetAllTablets();
			ViewBag.capsule = aMedicineManager.GetAllCapsule();
			ViewBag.syrup = aMedicineManager.GetAllSyrup();
			return View(medicines);
		}

		public ActionResult SaveData(Medicine medicine)
		{
			ViewBag.Category = aCategoryManager.GetAllCategories();

			if (medicine.Name != null && medicine.Quantity != null && medicine.Price != null && medicine.CategoryId != null &&
				medicine.ImageId != null)
			{
				string fileName = Path.GetFileNameWithoutExtension(medicine.ImageId.FileName);
				string extension = Path.GetExtension(medicine.ImageId.FileName);
				fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
				medicine.Image = fileName;
				medicine.ImageId.SaveAs(Path.Combine(Server.MapPath("~/AppFile/Images"), fileName));
				db.Medicines.Add(medicine);
				db.SaveChanges();
			}
			var result = "Successfully Added";
			return Json(result, JsonRequestBehavior.AllowGet);
		}



	


		[HttpPost]
		public ActionResult IncrementQuantity(Medicine medicine)
		{
			ViewBag.Category = aCategoryManager.GetAllCategories();
			ViewBag.Message = aMedicineManager.IncrementMedicine(medicine);
			return RedirectToAction("AddNewMedicine");
		}


		[HttpPost]
		public ActionResult DecrementQuantity(Medicine medicine)
		{
			ViewBag.Category = aCategoryManager.GetAllCategories();
			ViewBag.Message = aMedicineManager.DecrementMedicine(medicine);
			return RedirectToAction("AddNewMedicine");
		}


	}
}