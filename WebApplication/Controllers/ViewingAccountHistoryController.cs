using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Models.FolderViewingAccountHistory;

namespace WebApplication.Controllers
{
    public class ViewingAccountHistoryController : Controller
    {
        ViewingAccountHistoryRepository ViewingAccountHistoryRepository = new ViewingAccountHistoryRepository();

        public ActionResult Index()
        {
            return View("ViewingAccountHistory");
        }

        public ActionResult AccountHistoryReplenishment()
        {
            List<ModelForAccountHistory> list = ViewingAccountHistoryRepository
                .GetListHistory(DataForViewingAccountHistory.Id_MobileNumber, "dbo.AccountOverviewReplenishment");

            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            return View(list);
        }

        public ActionResult AccountHistoryWithdrawal()
        {
            List<ModelForAccountHistory> list = ViewingAccountHistoryRepository
                .GetListHistory(DataForViewingAccountHistory.Id_MobileNumber, "dbo.AccountOverviewWithdrawal");

            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            return View(list);
        }

        public ActionResult AccountHistoryBankCard()
        {
            List<ModelForOverviewBankCard> list = ViewingAccountHistoryRepository.
                GetListHistoryBankCard(DataForViewingAccountHistory.Id_MobileNumber);

            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            return View(list);
        }

        public ActionResult AccountHistoryMobileNumberAddressee()
        {
            List<ModelForOverviewTransferMonetToMobileNumber> list = ViewingAccountHistoryRepository.
                GetListHistoryMobileNumberAddressee(DataForViewingAccountHistory.Id_MobileNumber);

            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            return View(list);
        }

        public ActionResult AccountHistoryPaymentForTheApartment()
        {
            List<ModelForAccountHistory> list = ViewingAccountHistoryRepository.
                GetListHistoryPayment(DataOpen.PassportData, "dbo.AccountHistoryPaymentForTheApartment");

            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            return View(list);
        }

        public ActionResult AccountHistoryPaymentElectricity()
        {
            List<ModelForAccountHistory> list = ViewingAccountHistoryRepository.
                GetListHistoryPayment(DataOpen.PassportData, "dbo.AccountHistoryPaymentForElectricity");

            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            return View(list);
        }

        public ActionResult AccountHistoryPaymentTelephone()
        {
            List<ModelForAccountHistory> list = ViewingAccountHistoryRepository.
                GetListHistoryPayment(DataOpen.PassportData, "dbo.AccountHistoryPaymentForTheTelephone");

            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            return View(list);
        }

        public ActionResult AccountHistoryPaymentInternet()
        {
            List<ModelForAccountHistory> list = ViewingAccountHistoryRepository.
                GetListHistoryPayment(DataOpen.PassportData, "dbo.AccountHistoryPaymentForInternet");

            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            return View(list);
        }
    }
}