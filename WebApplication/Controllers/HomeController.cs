using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Data.Entity;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        //DataContext db = new DataContext();

        //ServiceRepository serviceRepository = new ServiceRepository();

        //static int Id_Sub;
        //static int ContractNumber;

        public ActionResult Index()
        {
            return View("Main");
        }

        //        [HttpGet]
        //        public ActionResult RegistrationNewSub()
        //        {
        //            return View("Index");
        //        }

        //        [HttpPost]
        //        public ActionResult RegistrationNewSub(Subscriber_s_personal_data ob)
        //        {
        //            ob.DateOfRegistration = DateTime.Now;

        //            db.Subscriber_s_personal_data.Add(ob);

        //            db.SaveChanges();

        //            List<Subscriber_s_personal_data> list = db.Subscriber_s_personal_data.
        //                Where(model => model.PassportData == ob.PassportData).ToList(); // 

        //            Id_Sub = list[0].Id_Sub;

        //            ViewBag.List = list;

        //            return View("NumberOfMobilePhone");
        //        }

        //        [HttpPost]
        //        public ActionResult SubscriberBase(PhoneNumber obPhoneNumber)
        //        {
        //            SubscriberBaseRepository ob = new SubscriberBaseRepository();
        //            ContractNumber = ob.AddContract(Id_Sub, obPhoneNumber.Id_MobileNumber);
        //            ViewBag.Check = ContractNumber;
        //            return View("SelectTarif");
        //        }

        //        [HttpPost]
        //        public ActionResult SelectTarif(Tarif obTarif)
        //        {
        //            TarifRepository obTarifRepository = new TarifRepository();
        //            obTarifRepository.SelectTarif(obTarif.Id_Tarif, ContractNumber);
        //            ViewBag.Check1 = obTarif.Id_Tarif;
        //            ViewBag.Check2 = ContractNumber;
        //            return View("SelectService");
        //        }

        //        [HttpPost]
        //        public ActionResult SelectService(ServiceForProcedure obService)
        //        {
        //            serviceRepository.ConnectServices(ContractNumber, obService.Id_Service);

        //            return View("Thanks");
        //        }

        //        public ActionResult PriceDescriptionList(string Id_Service)
        //        {
        //            short id_Service = Convert.ToInt16(Id_Service);

        //            List<Service> pricedescriptions = db.Services.Where(model => model.Id_Service == id_Service).ToList();

        //            if (HttpContext.Request.IsAjaxRequest())
        //            {
        //                return Json(pricedescriptions, JsonRequestBehavior.AllowGet);
        //            }
        //            return View(pricedescriptions);
        //        }

        //        public ActionResult ServiceList()
        //        {          
        //            List<ServiceForProcedure> services = serviceRepository.OutputOfServicesThatAreNotConnectedToTheUser(ContractNumber);

        //            if (HttpContext.Request.IsAjaxRequest())
        //            {
        //                return Json(new SelectList(services, "Id_Service", "NameOfService"), JsonRequestBehavior.AllowGet);
        //            }
        //            return View(services);
        //        }

        //        public ActionResult TarifList()
        //        {
        //            List<Tarif> tarifs = db.Tarifs.ToList();

        //            if (HttpContext.Request.IsAjaxRequest())
        //            {
        //                return Json(new SelectList(tarifs, "Id_Tarif", "NameOfTarif"), JsonRequestBehavior.AllowGet);
        //            }
        //            return View(tarifs);
        //        }

        //        public ActionResult PrestigeList()
        //        {
        //            List<PrestigeOfNumber> prestiges = db.PrestigeOfNumbers.ToList();

        //            if (HttpContext.Request.IsAjaxRequest())
        //            {
        //                return Json(new SelectList(prestiges, "PrestigeCodeOfMobileNumber", "NameOfPrestige"), JsonRequestBehavior.AllowGet);
        //            }
        //            return View(prestiges);
        //        }

        //        public ActionResult MobileNumberList(string PrestigeOfNumber)
        //        {
        //            int prestigeOfNumbeR = Convert.ToInt32(PrestigeOfNumber);
        //            List<PhoneNumber> mobilenumbers = db.PhoneNumbers.
        //                Where(model=>model.PrestigeCodeOfMobileNumber == prestigeOfNumbeR && model.StatusCodeOfMobileNumber == 1).ToList();
        //            if (HttpContext.Request.IsAjaxRequest())
        //            {
        //                return Json(new SelectList(mobilenumbers, "Id_MobileNumber", "MobileNumber"), JsonRequestBehavior.AllowGet);
        //            }
        //            return View(mobilenumbers);
        //        }

        //        public ActionResult RegionList()
        //        {
        //            List<Region> regions = db.Regions.ToList();

        //            if (HttpContext.Request.IsAjaxRequest())
        //            {
        //                return Json(new SelectList(regions, "id_Region", "NameOfRegion"), JsonRequestBehavior.AllowGet);
        //            }
        //            return View(regions);
        //        }

        //        public ActionResult CityList(string id_Region)
        //        {
        //            byte? id_RegioN = Convert.ToByte(id_Region);
        //            List<City> cities = db.Cities.Where(t => t.Id_Region == id_RegioN).ToList();

        //            if (HttpContext.Request.IsAjaxRequest())
        //            {
        //                return Json(new SelectList(cities, "id_City", "NameOfCity"),JsonRequestBehavior.AllowGet);
        //            }
        //            return View(cities);
        //        }

        //        public ActionResult DistrictList(string id_City)
        //        {
        //            byte? id_CitY = Convert.ToByte(id_City);
        //            List<District> districts = new List<District>();

        //            foreach (City l1 in db.Cities.Where(t=>t.Id_City==id_CitY).Include(t => t.Districts))
        //            {
        //                foreach(District l2 in l1.Districts)
        //                {
        //                    districts.Add(l2);
        //                }
        //            }
        //            if (HttpContext.Request.IsAjaxRequest())
        //            {
        //                return Json(new SelectList(districts, "id_District", "NameOfDistrict"), JsonRequestBehavior.AllowGet);
        //            }
        //            return View(districts);
        //        }

        //        public ActionResult StreetList(string id_District)
        //        {
        //            byte? id_DistricT = Convert.ToByte(id_District);
        //            List<Street> streets = new List<Street>();

        //            foreach(District l1 in db.Districts.Where(t => t.Id_District == id_DistricT).Include(t => t.Streets))
        //            {
        //                foreach(Street l2 in l1.Streets)
        //                {
        //                    streets.Add(l2);
        //                }
        //            }
        //            if (HttpContext.Request.IsAjaxRequest())
        //            {
        //                return Json(new SelectList(streets, "id_Street", "NameOfStreet"), JsonRequestBehavior.AllowGet);
        //            }
        //            return View(streets);
        //        }

        //        public ActionResult RepublicList()
        //        {
        //            IQueryable republics = db.Republics;

        //            if (HttpContext.Request.IsAjaxRequest())
        //            {
        //                return Json(new SelectList(republics, "id_Republic", "NameOfRepublic"), JsonRequestBehavior.AllowGet);
        //            }
        //            return View(republics);
        //        }

        //        public ActionResult USSRCityList(string Id_RepublicOfBirth)
        //        {
        //            byte? id_RepubliC = Convert.ToByte(Id_RepublicOfBirth);
        //            IQueryable USSRCities = db.Cities.Where(t => t.Id_Republic == id_RepubliC);

        //            if (HttpContext.Request.IsAjaxRequest())
        //            {
        //                return Json(new SelectList(USSRCities, "id_City", "NameOfCity"), JsonRequestBehavior.AllowGet);
        //            }
        //            return View(USSRCities);
        //        }
    }
}