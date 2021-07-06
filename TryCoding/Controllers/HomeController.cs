using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TryCoding.Controllers {
    public class HomeController : Controller {

        public ActionResult Index() {
            return View();
        }

        public ActionResult LogIn() {

            HttpCookie cookie = Request.Cookies.Get("User");

            if (cookie != null)
            {

                var email = cookie.Values["UserEmail"].ToString();
                ViewBag.UserEmail = email;

                var PWD = cookie.Values["UserPWD"].ToString();
                ViewBag.UserPWD = PWD;
            }

            return View();
        }

        public ActionResult SignUp() {

            return View();
        }

        public ActionResult Contact() {

            return View();
        }
    }
}