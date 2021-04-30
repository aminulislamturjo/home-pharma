using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using OnlinePharmacyOrdaringSystem.Manager;
using OnlinePharmacyOrdaringSystem.Models;

namespace OnlinePharmacyOrdaringSystem.Controllers
{
	public class OrderController : Controller
	{

		OrderManager aOrderManager = new OrderManager();
		////
		//// GET: /Order/
		//public ActionResult Index()
		//{
		//    return View();
		//}


		public ActionResult ShowOrder(Order aOrder)
		{
			List<Order> orders = aOrderManager.GetAllOrders();
			return View(orders);
		}

		public ActionResult OrderInfo(int id)
		{
			List<Order> orderInfo = aOrderManager.GetAllOrders().Where(x => x.OrderId == id).ToList();
			return View(orderInfo);
		}

		public ActionResult UploadImage()
		{
			MedicineImgOrder aImgOrder = new MedicineImgOrder();
			return View(aImgOrder);
		}

		public ActionResult ShowPrescription()
		{
			
			ImageEntities dbImageEntities = new ImageEntities();
			var item = (from d in dbImageEntities.MedicineImageOrders
						select d).ToList();

			return View(item);
		}

		[HttpPost]
		public ActionResult AcceptOrder(Order order)
		{

			ViewBag.Message = aOrderManager.AcceptOrder(order);
			return RedirectToAction("ShowOrder");
		}

		[HttpPost]
		public ActionResult RejectOrder(Order order)
		{

			ViewBag.Message = aOrderManager.RejectOrder(order);
			return RedirectToAction("ShowOrder");
		}

		[HttpPost]
		public ActionResult DeliverOrder(Order order)
		{

			ViewBag.Message = aOrderManager.DeliverOrder(order);
			return RedirectToAction("ShowOrder");
		}
	}
}