using GladiaSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using GladiaSystem.Database;
using System.Collections.ObjectModel;

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

        Queries queries = new Queries();

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Adm()
        {
            User adm = new User();
            return View(adm);
        }

        [HttpPost]
        public ActionResult CadAdm(User adm)
        {
            queries.RegisterAdm(adm);
            return Redirect("Adm");
        }

        public ActionResult Agenda()
        {
            var agenda = new Agenda();
            return View(agenda);
        }

        [HttpPost]
        public ActionResult CreateAgenda(Agenda agenda)
        {
            queries.RegisterAgenda(agenda);
            return Redirect("Agenda");
        }

        public ActionResult POS()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove("access");
            return RedirectToAction("Login", "Login");
        }

        public ActionResult Employee()
        {
            User employee = new User();
            return View(employee);
        }

        [HttpPost]
        public ActionResult CadEmployee(User employee)
        {
            queries.RegisterEmployee(employee);
            return Redirect("Employee");
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

        [HttpPost]
        public ActionResult CadCategory(Category category)
        {
            queries.RegisterCategory(category);
            return Redirect("Category");
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