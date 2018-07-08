using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Models.FolderForChangeTarif;

namespace WebApplication.Controllers
{
    public class InfoSubChangeTarifController : Controller
    {
        ChangeTarifRepository ChangeTarifRepository = new ChangeTarifRepository();

        public ActionResult Index()
        {
            return View("SelectTarif");
        }

        [HttpPost]
        public ActionResult UpdateTheTarif(short Id_Tarif)
        {
            ChangeTarifRepository.UpdateTarif(DataOpen.Id_MobileNumber, Id_Tarif);
            return RedirectToAction("Index", "InfoSubChangeTarif");
        }

        //Функция для отображения тарифов не подключённых у пользователя(при нажатии на кнопку "Сменить тариф")
        public ActionResult ChangeTarifJSON()
        {
            List<Tarif> list = ChangeTarifRepository.SelectTarifs(DataOpen.Id_MobileNumber);
            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(new SelectList(list, "Id_Tarif", "NameOfTarif"), JsonRequestBehavior.AllowGet);
            }
            return View(list);
        }

        //Используется JSON запросом, чтобы достать описание тарифа
        public ActionResult DescriptionOfTarif(short Id_Tarif)
        {
            TarifDescriptionModel ob = ChangeTarifRepository.ProcedureDescriptionOfTarif(Id_Tarif);

            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(ob, JsonRequestBehavior.AllowGet);
            }
            return View(ob);
        }
    }
}