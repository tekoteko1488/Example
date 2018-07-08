using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Models.FolderInfoAboutSub;
using WebApplication.Models.FolderForRefill;
using WebApplication.Models.FolderViewingAccountHistory;
using WebApplication.Models.FolderForTransferMoney;

namespace WebApplication.Controllers
{
    public class InfoSubController : Controller
    {
        InfoSubRepository infoSubRepository = new InfoSubRepository();

        Repository repository = new Repository();

        public ActionResult Index()
        {
            return View("Authorization");
        }

        public ActionResult CheckPassportData(long? PassportData)
        {
            List<MobileNomerForInfoSub> list = new List<MobileNomerForInfoSub>();

            if (PassportData != null)
            {
                if (infoSubRepository.Authorization(PassportData.ToString()) == "0")
                {
                    list = infoSubRepository.SelectContractNumberForInfoAboutSub(PassportData.Value);

                    if (HttpContext.Request.IsAjaxRequest())
                    {
                        DataOpen.PassportData = PassportData.Value;
                        return Json(new SelectList(list, "Id_MobileNumber", "MobileNumber"), JsonRequestBehavior.AllowGet);
                    }
                    else return HttpNotFound();
                }
                else return HttpNotFound();
            }
            else return HttpNotFound();
        }

        public ActionResult NameOfServiceList(int Id_MobileNumber)
        {
            List<ModelForReviewServiceConnectedService> list =
                repository.SelectServiceWhichUserHave(Id_MobileNumber);
            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            return View(list);
        }


        // Пополнение счёта, при нажатии на кнопку "Пополнить"
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Refill")]
        public ActionResult Refill(int? Id_MobileNumber)
        {
            if (ModelState.IsValid)
            {
                if (Id_MobileNumber == null)
                    return RedirectToAction("Index", "InfoSub");
                else
                {
                    DataForRefill.Id_MobileNumber = Id_MobileNumber.Value;
                    return RedirectToAction("Index", "Refill");
                }
            }
            else return HttpNotFound();
        }

        [HttpPost]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "ChangeTarif")]
        public ActionResult ChangeTarif(int? Id_MobileNumber)
        {
            if (Id_MobileNumber == null)
                return RedirectToAction("Index", "InfoSub");
            else
            {
                DataOpen.Id_MobileNumber = Id_MobileNumber.Value;
                return RedirectToAction("Index", "InfoSubChangeTarif");
            }
        }

        [HttpPost]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "PaymentForBills")]
        public ActionResult PaymentForBills(int? Id_MobileNumber)
        {
            if (Id_MobileNumber == null)
                return RedirectToAction("Index", "InfoSub");
            else
            {
                DataOpen.Id_MobileNumber = Id_MobileNumber.Value;
                return RedirectToAction("Index", "PaymentForBills");
            }
        }

        // При нажатии на кнопку "Сменить услуги", происходит переброс на view
        [MultiButton(MatchFormKey = "action", MatchFormValue = "ChangeService")]
        public ActionResult ChangeService(int? Id_MobileNumber)
        {
            if (Id_MobileNumber == null)
                return RedirectToAction("Index", "InfoSub");
            else
                return RedirectToAction("Index", "InfoSubChangeService");
        }

        [HttpPost]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "TransferMoney")]
        public ActionResult TransferMoney(int? Id_MobileNumber)
        {
            if(Id_MobileNumber == null)
                return RedirectToAction("Index", "InfoSub");
            else
            {
                DataForTransferMoney.Id_MobileNumber = Id_MobileNumber.Value;
                return RedirectToAction("Index", "TransferMoney");
            }
        }

        [HttpPost]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "ViewingAccountHistory")]
        public ActionResult ViewingAccountHistory(int? Id_MobileNumber)
        {
            if (Id_MobileNumber == null)
                return RedirectToAction("Index", "InfoSub");
            else
            {
                DataOpen.Id_MobileNumber = Id_MobileNumber.Value;
                DataForViewingAccountHistory.Id_MobileNumber = Id_MobileNumber.Value;
                return RedirectToAction("Index", "ViewingAccountHistory");
            }
        }
        
        public ActionResult InfoSubList(int Id_MobileNumber, long PassportData)
        {
            List<InfoAboutSubModel> infolist = infoSubRepository.InfoAboutSub(PassportData, Id_MobileNumber);
            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(infolist, JsonRequestBehavior.AllowGet);
            }
            return View(infolist);
        }
    }
}