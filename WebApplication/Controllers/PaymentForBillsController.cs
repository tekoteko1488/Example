using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Models.FolderForPayment;

namespace WebApplication.Controllers
{
    public class PaymentForBillsController : Controller
    {
        PaymentRepository PaymentRepository = new PaymentRepository();

        public ActionResult Index()
        {
            return View("PaymentForBills");
        }

        public ActionResult Apartment()
        {
            return PartialView("PaymentForApartment");
        }

        public ActionResult Electricity()
        {
            return PartialView("PaymentForElectricity");
        }

        public ActionResult Telephone()
        {
            return PartialView("PaymentForTelephone");
        }

        public ActionResult Internet()
        {
            return PartialView("PaymentForInternet");
        }

        [HttpPost]
        public ActionResult ElectricityPay(ModelForPayment ob)
        {
            ViewBag.Result = PaymentRepository.Pay(DataOpen.PassportData, ob.Payment, DataOpen.Id_MobileNumber, "dbo.ElectricityPay");
            return PartialView("SuccessPay");
        }

        [HttpPost]
        public ActionResult ApartmentPay(ModelForPayment ob)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Result = PaymentRepository.Pay(DataOpen.PassportData, ob.Payment, DataOpen.Id_MobileNumber, "dbo.ApartmentPay");
                return PartialView("SuccessPay");
            }
            else return HttpNotFound();

        }

        [HttpPost]
        public ActionResult TelephonePay(ModelForPayment ob)
        {
            ViewBag.Result = PaymentRepository.Pay(DataOpen.PassportData, ob.Payment, DataOpen.Id_MobileNumber, "dbo.TelephonePay");
            return PartialView("SuccessPay");
        }

        [HttpPost]
        public ActionResult InternetPay(ModelForPayment ob)
        {
            ViewBag.Result = PaymentRepository.Pay(DataOpen.PassportData, ob.Payment, DataOpen.Id_MobileNumber, "dbo.InternetPay");
            return PartialView("SuccessPay");
        }
    }
}