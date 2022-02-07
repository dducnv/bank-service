using bank_client.Models;
using bank_client.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace bank_client.Controllers
{
    public class AccountController : Controller
    {
        static ServiceReference1.Bank_ServiceClient serviceClient = new ServiceReference1.Bank_ServiceClient();
        // GET: Login
        public ActionResult Login()
        {

            var sessionUser = (AccountDto)Session[AccountStore.USER_SESSION];
            if(sessionUser != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "PhoneNumber,Password")] Login login)
        {
            if (ModelState.IsValid)
            {
                LoginDto loginDto = new LoginDto()
                {
                    PhoneNumber = login.PhoneNumber,
                    Password = login.Password
                };
                var result =  serviceClient.Login(loginDto);
                if (result != null)
                {
                    Session.Add(AccountStore.USER_SESSION,result);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", result.ToString());
                    return RedirectToAction("Login", "Account");
                }
                
                
            }
            return View(login);
        }
        public ActionResult Register()
        {
            var sessionUser = (AccountDto)Session[AccountStore.USER_SESSION];

            if (sessionUser != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register([Bind(Include = "FistName,LastName,Password,PasswordConfirm,PhoneNumber,Address,Email,IndetityNumber,Birthday")] Account account)
        {

            if (ModelState.IsValid)
            {
                AccountDto accountDto = new AccountDto() {
                            FistName = account.FistName,
                            LastName = account.LastName,
                            Password = account.Password,
                            PasswordConfirm = account.PasswordConfirm,
                            PhoneNumber = account.PhoneNumber,
                            Email = account.Email,
                            IndetityNumber = account.IndetityNumber,
                            Birthday = account.Birthday,
                            Address = account.Address,
            };
                
                var result = await serviceClient.RegisterAsync(accountDto);
                if(result == "success")
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("", result);
                    return RedirectToAction("Register");
                }
                       
            }

            return View(account);
        }
        public ActionResult Logout()
        {
            Session[AccountStore.USER_SESSION] = null;
            return RedirectToAction("Login");
        }
       
    }
}