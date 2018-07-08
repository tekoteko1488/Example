using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using WebApplication.Models;
using WebApplication.Models.FeedBack;

namespace WebApplication.Controllers
{
    public class FeedbackController : Controller
    {
        DataContext db = new DataContext();
        // GET: Feedback
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]///ffgf
        public ActionResult Send(ForFeedback ob)
        {
            DateTime dateTime = DateTime.Now;

            db.Database.ExecuteSqlCommand("FeedbackProcedure @MessageSubject, @Body, @surname, @name, @patronymic, @datetimeofreceipt",
                new SqlParameter("@MessageSubject", ob.Subject),
                new SqlParameter("@Body", ob.Body),
                new SqlParameter("@surname", ob.Surname),
                new SqlParameter("@name", ob.Name),
                new SqlParameter("@patronymic", ob.Patronymic),
                new SqlParameter("@datetimeofreceipt", dateTime));

            return RedirectToAction("Index", "Feedback");
        }
    }
}