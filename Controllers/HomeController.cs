using AuthenticationTwoFactor.Models;
using AuthenticationTwoFactor.Repository;
using AuthenticationTwoFactor.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;

namespace AuthenticationTwoFactor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ViewResult Login(LoginModel loginDTO)
        {
            if (ModelState.IsValid)
            {
                LoginRepository db = new LoginRepository();

                UserLogged userLogged = db.LoginUser(loginDTO);
                
                if (userLogged.IsLogged)
                {
                    TwilioHelper twilio = new TwilioHelper();
                    twilio.SendSMSMessage(userLogged.MobilePhone, userLogged.SMSCode.ToString());
                    return View("AuthenticatorSMS", userLogged);
                }
            }

            return View("Index", loginDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ViewResult AuthenticatorSMS(UserLogged userLogged)
        {
            if (ModelState.IsValid)
            {

                if (userLogged.SMSCodeVerify.Equals(userLogged.SMSCode))
                {
                    ViewBag.Message = "Se verificó correctamente el SMS enviado. " + userLogged.SMSCode;
                    return View(userLogged);
                }
            }
            ViewBag.Message = "SMS ingresado es incorrecto. ";
            return View(userLogged);
        }
    }
}
