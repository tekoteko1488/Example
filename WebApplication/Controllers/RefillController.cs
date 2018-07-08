using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Models.FolderForRefill;

namespace WebApplication.Controllers
{
    public class RefillController : Controller
    {
        RefillRepository refillRepository = new RefillRepository();

        Repository Repository = new Repository();

        public ActionResult Index()
        {
            return View("Refill");
        }

        public ActionResult RefillBalance(ModelForRefill ob)
        {
            refillRepository.Refill(ob.Summa, DataForRefill.Id_MobileNumber);
            ViewBag.AmountOfReplenishment = ob.Summa;
            ViewBag.MobileNumber = Repository.SelectMobileNumber(DataForRefill.Id_MobileNumber);
            return PartialView("Thanks");
        }
    }
}