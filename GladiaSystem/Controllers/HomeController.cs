﻿using GladiaSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using GladiaSystem.Database;

namespace GladiaSystem.Controllers
{
    public class HomeController : Controller
    {
        [HandleError]
        // GET: Home
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Adm()
        {
            return View();
        }
        public ActionResult Agenda()
        {
            return View();
        }
        public ActionResult POS()
        {
            return View();
        }
        public ActionResult Employee()
        {
            return View();
        }
        public ActionResult Pet()
        {
            return View();
        }
        public ActionResult Category()
        {
            Category category = new Category();
            return View(category);
        }

        public ActionResult Teste(Category category)
        {
            return View(category);
        }

        [HttpPost]
        public ActionResult CadCategory(Category category)
        {
            Queries.
            return View(category);
        }

    
        public ActionResult Product()
        {
            return View();
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        public ActionResult ChangeName()
        {
            return View();
        }
        public ActionResult DeleteAccount()
        {
            return View();
        }
        public ActionResult Payment()
        {
            return View();
        }

        public ActionResult Receipt()
        {
            return View();
        }
        public ActionResult ProductList()
        {
            return View();
        }
    }
}