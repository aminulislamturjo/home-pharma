using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlinePharmacyOrdaringSystem.Manager;
using OnlinePharmacyOrdaringSystem.Models;

namespace OnlinePharmacyOrdaringSystem.Controllers
{
	public class PharmacyUserController : Controller
	{

		PharmacyUserManager aPharmacyUserManager = new PharmacyUserManager();


		//
		// GET: /PharmacyUser/
		//public ActionResult Index()
		//{
		//    return View();
		//}

		public ActionResult SavePharmacyUser()
		{
			return View();
		}

		[HttpPost]
		public ActionResult SavePharmacyUser(PharmacyUser pharmacyUser)
		{
			ViewBag.Message = aPharmacyUserManager.Save(pharmacyUser);
			return View();
		}

		public JsonResult CheckValidUser(PharmacyUser pharmacyUser)
		{
			string result = "Fail";
			var DataItem = aPharmacyUserManager.GetAllPharmacyUsers().SingleOrDefault(x => x.Email == pharmacyUser.Email && x.Password == pharmacyUser.Password);
			if (DataItem != null)
			{
				Session["PharmacyUserID"] = DataItem.PharmacyUserID.ToString();
				Session["PharmacyUsername"] = DataItem.Username.ToString();
				result = "Success";
			}
			return Json(result, JsonRequestBehavior.AllowGet);
		}

		public ActionResult AfterLogin()
		{
			if (Session["PharmacyUserID"] != null)
			{
				return View();
			}
			else
			{
				return RedirectToAction("SavePharmacyUser");
			}
		}


		//public ActionResult Edit()
		//{
		//    string username = User.Identity.Name;

		//    // Fetch the userprofile
		//    UserProfile user = db.UserProfiles.FirstOrDefault(u => u.UserName.Equals(username));

		//    // Construct the viewmodel
		//    UserProfileEdit model = new UserProfileEdit();
		//    model.FirstName = user.FirstName;
		//    model.LastName = user.LastName;
		//    model.Email = user.Email;

		//    return View(model);
		//}


		//public ActionResult Edit(PharmacyUser pharmacyUser)
		//{
		//    var userDetails = aPharmacyUserManager.GetAllPharmacyUsers().SingleOrDefault(e => e.PharmacyUserID == pharmacyUser.PharmacyUserID);
		//    return View(userDetails);
		//}


		public ActionResult Edit(int id)
		{
			PharmacyUserManager aPharmUser = new PharmacyUserManager();
			return View(aPharmUser.GetAllPharmacyUsers().Find(smodel => smodel.PharmacyUserID == id));
		}

		[HttpPost]
		public ActionResult Edit(int id, PharmacyUser pharmacyUser)
		{
			PharmacyUserManager aPharmUser = new PharmacyUserManager();
			aPharmUser.UpdateUser(pharmacyUser);
			return RedirectToAction("AfterLogin");
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
	
		public ActionResult Logout()
		{
			Session.Clear();
			Session.Abandon();
			return RedirectToAction("SavePharmacyUser");
		}

	}
}