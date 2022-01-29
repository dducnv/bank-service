using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bank_client.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        // Chưa có gì
        public ActionResult Blog()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        // Lịch Sử Giao Dịch
        public ActionResult Transactionhistory()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        // Chuyển Tiền
        public ActionResult Transfers()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //Thanh toán và nạp tiền
        public ActionResult Payment()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}