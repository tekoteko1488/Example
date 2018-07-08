using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Models.FolderForTransferMoney;

namespace WebApplication.Controllers
{
    public class TransferMoneyController : Controller
    {
        TransferMoneyRepository TransferMoneyRepository = new TransferMoneyRepository();

        Repository Repository = new Repository();

        // GET: TransferMoney
        public ActionResult Index()
        {
            return View("TransferMoney");
        }

        public ActionResult PartialForBankCard()
        {
            return PartialView("TransferMoneyToBankCard");
        }

        public ActionResult PartialForMobileNumber()
        {
            return PartialView("TransferMoneyToMobileNumber");
        }

        [HttpPost]
        public ActionResult ResultOfTransferMoneyToBankCard(ModelForTransferMoneyToBankCard ob)
        {
            if(ModelState.IsValid)
            {
                TransferMoneyRepository.ProcedureTransferMoneyToBankCard(DataForTransferMoney.Id_MobileNumber, ob.Sum, ob.BankCardAddressee);

                ViewBag.MobileNumber = Repository.SelectMobileNumber(DataForTransferMoney.Id_MobileNumber);

                ViewBag.Sum = ob.Sum;

                ViewBag.BankCard = ob.BankCardAddressee;

                return View("ThanksForTransferToBankCard");
            }
            else return View("ThanksForTransferToMobileNumber"); // ffffffffffffff

        }

        [HttpPost]
        public ActionResult ResultOfTransferMoneyToMobileNumber(ModelForTransferMoneyToMobileNumber ob)
        {
            if (ModelState.IsValid)
            {
                TransferMoneyRepository.TransferMoneytoMobileNumberProcedure
                    (DataForTransferMoney.Id_MobileNumber, ob.Sum, ob.MobileNumberAddressee);

                ViewBag.IdMobileNumber = Repository.SelectMobileNumber(DataForTransferMoney.Id_MobileNumber);

                ViewBag.MobileNumberAddressee = ob.MobileNumberAddressee;

                ViewBag.Sum = ob.Sum;

                return View("ThanksForTransferToMobileNumber");
            }
            else return View("ThanksForTransferToBankCard"); //jjjjjjjjjjj

        }
    }
}