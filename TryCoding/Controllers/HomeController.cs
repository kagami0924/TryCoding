﻿using System;
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