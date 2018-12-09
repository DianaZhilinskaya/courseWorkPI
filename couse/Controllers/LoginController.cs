﻿using couse.mod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace couse.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherize(couse.mod.Autorization login_model)
        {
            using (StudentModel db = new StudentModel())
            {
                var userDetails = db.Autorization.Where(x => x.login_user == login_model.login_user && x.password_user == login_model.password_user).FirstOrDefault();
                if (userDetails == null)
                {
                   login_model.loginErrorMessage = "Wrong username or password.";
                    return View("Index", login_model);
                }
                else
                {
                    Session["login_user"] = userDetails.login_user;
                    return RedirectToAction("Index", "Home");
                }
            }
                return View();
        }
    }
}