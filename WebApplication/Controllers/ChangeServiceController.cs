using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Models.FolderInfoAboutSub;

namespace WebApplication.Controllers
{
    public class InfoSubChangeServiceController : Controller
    {
        InfoSubRepository infoSubRepository = new InfoSubRepository();

        // GET: ChangeService
        public ActionResult Index()
        {
            return View("SelectService");
        }

        //Добавляет пользователю услугу (срабатывает при нажатии кнопки "Добавить услугу")
        [HttpPost]
        [MultiButton(MatchFormKey = "service", MatchFormValue = "AddService")]
        public ActionResult AddService(int DoNotTheConnectedServices)
        {
            infoSubRepository.AddService(DoNotTheConnectedServices);
            return RedirectToAction("Index", "InfoSubChangeService");
        }

        //Убирает пользователю услугу (срабатывает при нажатии кнопки "Убрать услугу")
        [HttpPost]
        [MultiButton(MatchFormKey = "service", MatchFormValue = "DeleteService")]
        public ActionResult DeleteService(int ConnectedServices)
        {
            infoSubRepository.DeleteService(ConnectedServices);
            return RedirectToAction("Index", "InfoSubChangeService");
        }

        //Достаёт описание услуги
        public ActionResult SelectDescriptionOfServiceList(int Id_Service)
        {
            List<SelectDescriptionOfServiceMODEL> infolist = infoSubRepository.SelectDescriptionOfService(Id_Service);
            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(infolist, JsonRequestBehavior.AllowGet);
            }
            return View(infolist);
        }

        //Функция, достающая подключённые услуги
        public ActionResult ServiceWhichUserHaveList()
        {
            List<ServiceForProcedure> list = infoSubRepository.SelectServiceWhichUserHave(DataForInfoAboutSub.ContractNumber);
            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(new SelectList(list, "Id_Service", "NameOfService"), JsonRequestBehavior.AllowGet);
            }
            return View(list);
        }

        //Функция, достающая не подключённые услуги в формате выпадающего списка
        public ActionResult ServiceWhichUserDoNotHaveList()
        {
            List<ServiceForProcedure> list = infoSubRepository.ServiceWhichUserDoNotHaveList(DataForInfoAboutSub.ContractNumber);
            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(new SelectList(list, "Id_Service", "NameOfService"), JsonRequestBehavior.AllowGet);
            }
            return View(list);
        }
    }
}