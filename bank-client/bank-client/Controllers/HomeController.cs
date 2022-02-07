using bank_client.Models;
using bank_client.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bank_client.Controllers
{
    public class HomeController : Controller
    {
        static ServiceReference1.Bank_ServiceClient serviceClient = new ServiceReference1.Bank_ServiceClient();

        public ActionResult Index()
        {
            var sessionUser = (AccountDto)Session[AccountStore.USER_SESSION];

            if (sessionUser != null)
            {
                /*var otp = serviceClient.SendOtp("+840383665477");
                ViewBag.OTP = otp;*/
                var getInfo = serviceClient.GetInfoAccount(sessionUser.AccountNumber, sessionUser.PhoneNumber);
                return View(getInfo);
            }

            return RedirectToAction("Login", "Account");

        }

        public ActionResult About()
        {

            var sessionUser = (AccountDto)Session[AccountStore.USER_SESSION];

            if (sessionUser != null)
            {
                var getInfo = serviceClient.GetInfoAccount(sessionUser.AccountNumber, sessionUser.PhoneNumber);
                return View(getInfo);
            }

            return RedirectToAction("Login", "Account");
        }

        public ActionResult Contact()
        {
            var sessionUser = (AccountDto)Session[AccountStore.USER_SESSION];

            if (sessionUser != null)
            {
                return View(sessionUser);
            }

            return RedirectToAction("Login", "Account");
        }
        // Chưa có gì
        public ActionResult Blog()
        {
            var sessionUser = (AccountDto)Session[AccountStore.USER_SESSION];

            if (sessionUser != null)
            {
                return View(sessionUser);
            }

            return RedirectToAction("Login", "Account");
        }
        // Lịch Sử Giao Dịch
        public ActionResult Transactionhistory()
        {

            var sessionUser = (AccountDto)Session[AccountStore.USER_SESSION];

            if (sessionUser != null)
            {
                var transactionHistory = serviceClient.transactionHistory(sessionUser.AccountNumber);
                return View(transactionHistory);
            }

            return RedirectToAction("Login", "Account");
        }
        // Chuyển Tiền
        public ActionResult Transfers()
        {
            var sessionUser = (AccountDto)Session[AccountStore.USER_SESSION];

            if (sessionUser != null)
            {
                var getInfo = (AccountDto)serviceClient.GetInfoAccount(sessionUser.AccountNumber, sessionUser.PhoneNumber);
                MultiModel multiModel = new MultiModel() { 
                             accountDto = getInfo
                };
                
                return View(multiModel);
            }

            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Transfers([Bind(Include = "AccountNumberReceiver,FullName,Amount,Message,Password")] TransferDto account,int Otp)
        {
            var sessionUser = (AccountDto)Session[AccountStore.USER_SESSION];
                TransferDto transfers = new TransferDto()
                {
                    AccountNumberReceiver =  account.AccountNumberReceiver,
                    AccountNumberSender = sessionUser.AccountNumber,
                    FullName = account.FullName,
                    Amount = account.Amount,
                    Message = account.Message,
                    Password = account.Password
                };
                serviceClient.Transfers(transfers, Otp);
                return RedirectToAction("Index", "Home");
           
        }
        //Thanh toán và nạp tiền
        public ActionResult Payment()
        {
            var sessionUser = (AccountDto)Session[AccountStore.USER_SESSION];

            if (sessionUser != null)
            {
                return View(sessionUser);
            }

            return RedirectToAction("Login", "Account");
        }
        public ActionResult GetOTP()
        {
            var sessionUser = (AccountDto)Session[AccountStore.USER_SESSION];
            var getInfo = (AccountDto)serviceClient.GetInfoAccount(sessionUser.AccountNumber, sessionUser.PhoneNumber);
            if (sessionUser != null && getInfo !=null)
            {
                serviceClient.SendOtp("+840383665477");
            }

            return RedirectToAction("Login", "Account");
        }

    }
}