using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Models.FolderForNewSub;

namespace WebApplication.Controllers
{
    public class NewSubController : Controller
    {
        DataContext db = new DataContext();

        NewSubRepository NewSubRepository = new NewSubRepository();

        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult RegistrationNewSub(ModelForNewSub ob)
        {
            if (ModelState.IsValid)
            {
                NewSubRepository.AddNewSub(ob);
                DataForNewSub.PassportData = ob.PassportData;
                ViewBag.Surname = ob.Surname;
                ViewBag.Name = ob.Name;
                ViewBag.Patronymic = ob.Patronymic;
                if (ob.Sex == 'М')
                    ViewBag.Sex = "зарегистрирован";
                else if (ob.Sex == 'Ж')
                    ViewBag.Sex = "зарегистрирована";

                return View("NumberOfMobilePhone");
            }
            else return HttpNotFound();
        }

        public ActionResult CheckPassportData(string PassportData)
        {
            if (HttpContext.Request.IsAjaxRequest())
            {
                string veracity = NewSubRepository.CheckPassportData(PassportData);

                //если 0, то такие паспортные данные есть в бд, если 1, тогда значит их нет
                if (veracity == "0")
                {
                    ViewBag.Condition = "Данные паспортные данные существуют в БД. " +
                        "Попробуйте найти данного пользователя через вкладку 'Информация об абоненте' ";
                    return PartialView("CheckPassportData");
                }
                else
                    return PartialView("_Empty");
            }
            else
                return HttpNotFound();
        }

        public ActionResult AliasNumberPartialView()
        {
            return PartialView("AliasNumber");
        }

        public ActionResult AlienNumberPartialView()
        {
            return PartialView("AlienNumber");
        }

        [HttpPost]
        public ActionResult ConnectMobileNumber(int Id_MobileNumber)
        {            
            ViewBag.ContractNumber = NewSubRepository.CreateContactNumberAndConnectMobileNumber(DataForNewSub.PassportData, Id_MobileNumber);
            return PartialView("ConnectTarifAndService");
        }

        [HttpPost]
        public ActionResult ConnectAlienMobileNumber(AlienMobileNumberModel ob)
        {
            ViewBag.ContractNumber = NewSubRepository.
                CreateContactNumberAndConnectAlienMobileNumber(DataForNewSub.PassportData, ob.AlienMobileNumber);
            return PartialView("ConnectTarifAndService");
        }

        public ActionResult PrestigeList()
        {
            List<PrestigeOfNumber> list = NewSubRepository.SelectPrestige();

            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(new SelectList(list, "PrestigeCodeOfMobileNumber", "NameOfPrestige"), JsonRequestBehavior.AllowGet);
            }
            return View(list);
        }

        public ActionResult MobileNumberList(byte PrestigeOfNumber)
        {
            List<PhoneNumber> list = NewSubRepository.SelectMobileNumberOfThePrestige(PrestigeOfNumber);
            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(new SelectList(list, "Id_MobileNumber", "MobileNumber"), JsonRequestBehavior.AllowGet);
            }
            return View(list);
        }

        public ActionResult RegionList()
        {
            List<Region> list = NewSubRepository.SelectRegion();

            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(new SelectList(list, "id_Region", "NameOfRegion"), JsonRequestBehavior.AllowGet);
            }
            return View(list);
        }

        public ActionResult SelectCityOfTheRegion(byte id_Region)
        {
            List<City> list = NewSubRepository.SelectCityOfTheRegion(id_Region);

            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(new SelectList(list, "Id_City", "NameOfCity"), JsonRequestBehavior.AllowGet);
            }
            return View(list);
        }

        public ActionResult SelectDistrictOfTheCity(Int16 Id_City)
        {
            List<District> list = NewSubRepository.SelectDistrictOfTheCity(Id_City);

            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(new SelectList(list, "Id_District", "NameOfDistrict"), JsonRequestBehavior.AllowGet);
            }
            return View(list);
        }

        public ActionResult SelectStreetOfTheDistrict(Int32 Id_District)
        {
            List<Street> list = NewSubRepository.SelectStreetOfTheDistrict(Id_District);

            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(new SelectList(list, "Id_Street", "NameOfStreet"), JsonRequestBehavior.AllowGet);
            }
            return View(list);
        }

        public ActionResult SelectRepublic()
        {
            List<Republic> list = NewSubRepository.SelectRepublic();

            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(new SelectList(list, "Id_Republic", "NameOfRepublic"), JsonRequestBehavior.AllowGet);
            }
            return View(list);
        }

        public ActionResult SelectCityOfTheRepublic(byte Id_Republic)
        {
            List<City> list = NewSubRepository.SelectCityOfTheRepublic(Id_Republic);

            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(new SelectList(list, "Id_City", "NameOfCity"), JsonRequestBehavior.AllowGet);
            }
            return View(list);
        }
    }
}