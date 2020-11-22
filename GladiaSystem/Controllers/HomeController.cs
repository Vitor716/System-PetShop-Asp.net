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
            if (ModelState.IsValid)
            {
                queries.RegisterAdm(adm);
                TempData["Success"] = "Feito! 😄";
            }
            else
            {
                ViewData["Error"] = "Opss, algo deu errado 😢.";
            }
            return RedirectToAction("Adm");
        }
    
        public ActionResult Agenda()
        {
            var agenda = new Agenda();
            return View(agenda);
        }

        [HttpPost]
        public ActionResult CreateAgenda(Agenda agenda)
        {
            bool agendaValid = ModelState.IsValid && (DateTime.Now < agenda.Day);
            if ( agendaValid )
            {
                queries.RegisterAgenda(agenda);
                TempData["Success"] = "Agendamento feito! 😄";
            }
            else
            {
                TempData["Error"] = "Opss, algo deu errado 😢";
            }
            return RedirectToAction("Agenda");
        }

        public ActionResult POS()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove("access");
            Session.Abandon();
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
            //bool userUnic = CheckUserUnic();
            if (ModelState.IsValid)
            {
                queries.RegisterEmployee(employee);
                TempData["Success"] = "Feito! 😄";
            }
            else
            {
                ViewData["Error"] = "Opss, algo deu errado 😢.";
            }
            return RedirectToAction("Employee");
        }

        public ActionResult Pet()
        {
            Pet pet = new Pet();
            return View(pet);
        }

        [HttpPost]
        public ActionResult RegisterPet(Pet pet)
        {
            if (ModelState.IsValid)
            {

            }
            else
            {

            }
            return RedirectToAction("Pet");
        }

        public ActionResult Category()
        {
            Category category = new Category();
            return View(category);
        }

        [HttpPost]
        public ActionResult RegisterCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                queries.RegisterCategory(category);
                TempData["Success"] = "Feito! 😄";
                return RedirectToAction("Category");
            }
            else
            {
                ViewData["Error"] = "Opss, algo deu errado 😢.";
                return View(category);
            }
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