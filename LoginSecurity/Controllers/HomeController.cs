using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaptchaMvc.HtmlHelpers;
using LoginSecurity.Models;
namespace LoginSecurity.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel ObjModel)
        {
            if(ModelState.IsValid)
            {
                //now check your capchat is valid or not
                if (!this.IsCaptchaValid(""))
                {
                    ViewBag.ErrMessage = "Captcha is not valid";
                    return View();
                }
                return RedirectToAction("Home");
                //end

            }
            else
            {
                return View();
            }
            
        }

        
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult CheckExistsOrNot(string Emailaddress)
        {
            // Assume these details coming from database  
            List<LoginViewModel> RegisterUsers = new List<LoginViewModel>()
            {
                new LoginViewModel
                {
                    Emailaddress="Surajghosi@gmail.com",Password="Suraj123"
                },
                new LoginViewModel
                {
                    Emailaddress="chirag@gmail.com",Password="Chirag123"
                }
            };
            //end

            // below we are checking email id exists or not
            var checkemailid = (from u in RegisterUsers
                               where u.Emailaddress.ToUpper() == Emailaddress.ToUpper()
                               select new { Emailaddress }).FirstOrDefault();
            //end

            //now we set status and return base of checkemailid result

            bool status;
            if (checkemailid == null)
            {
                status = false;
            }
            else { status = true; }


            return Json(status);
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
    }
}