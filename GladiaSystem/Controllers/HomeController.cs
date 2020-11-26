using GladiaSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using GladiaSystem.Database;
using System.Collections.ObjectModel;
using System.Web.UI.WebControls;
using System.Web.Helpers;
using System.IO;

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
            WebImage photo = null;
            var newFileName = "";
            var imagePath = "";

            photo = WebImage.GetImageFromRequest();
            if (photo != null)
            {
                newFileName = Guid.NewGuid().ToString() + "_" +
                Path.GetFileName(photo.FileName);
                imagePath = @"/" + newFileName;

                photo.Save(@"~/Images" + imagePath);
                imagePath = photo.FileName;
            }

            queries.RegisterAdm(adm, imagePath);
            TempData["Success"] = "Feito! 😄";
            return RedirectToAction("Adm");
        }

        public ActionResult Agenda()
        {
            var ShowAgenda = new Queries();
            var AllAgenda = ShowAgenda.ListAgenda();
            return View(AllAgenda);
        }

        public ActionResult DeleteAgenda(int codAgenda)
        {
            Console.WriteLine(codAgenda);
            queries.DeleteItemAgenda(codAgenda);
            return RedirectToAction("Agenda");
        }

        public PartialViewResult CreateAgenda()
        {
            return PartialView();
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
            string session = (string)Session["userID"];
            ViewBag.Img = queries.GetUserImages(session);
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
            WebImage photo = null;
            var newFileName = "";
            var imagePath = "";

            photo = WebImage.GetImageFromRequest();
            if (photo != null)
            {
                newFileName = Guid.NewGuid().ToString() + "_" +
                Path.GetFileName(photo.FileName);
                imagePath = @"/" + newFileName;
                
                photo.Save(@"~/Images" + imagePath);
                imagePath = photo.FileName;
            }

            queries.RegisterEmployee(employee, imagePath);
            TempData["Success"] = "Feito! 😄";
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
            queries.RegisterPet(pet);
            TempData["Success"] = "Feito! 😄";
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
            Queries queries = new Queries();
            if (ModelState.IsValid && !queries.CategoryExists(category))
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
            Product product = new Product();

            ViewBag.ListCategory = queries.ListCategory();

            return View(product);
        }

        [HttpPost]
        public ActionResult RegisterProd(Product product)
        {
            queries.RegisterProd(product);
            TempData["Success"] = "Feito! 😄";
            return RedirectToAction("Product");
        }


        public ActionResult ChangePassword()
        {
            User changePassword = new User();
            return View(changePassword);
        }

        [HttpPost]
        public ActionResult ChangePass(User changePassword)
        {
            if(changePassword.password == changePassword.confPassword)
            {
                string session = (string)Session["userID"];
                queries.ChangePass(changePassword.password, session);
            }
            return RedirectToAction("ChangePassword", "Home");
        }

        public ActionResult ChangeName()
        {
            User changeName = new User();
            return View(changeName);
        }

        [HttpPost]
        public ActionResult ChangeNam(User changeName)
        {
            if (changeName.name == changeName.confName )
            {
                string session = (string)Session["userID"];
                queries.ChangeName(changeName.name, session);
            }
            return RedirectToAction("Login", "Login");
        }

        public ActionResult DeleteAccount()
        {
            return View();
        }

        public ActionResult Delete()
        {
            string deleteID = (string)Session["userID"];
            queries.DeleteAccount(deleteID);
            return RedirectToAction("Login" , "Login");
        }


        public ActionResult Payment()
        {
            string session = (string)Session["userID"];
            ViewBag.Img = queries.GetUserImages(session);
            return View();
        }

        public ActionResult Receipt()
        {
            string session = (string)Session["userID"];
            ViewBag.Img = queries.GetUserImages(session);
            return View();
        }

        public ActionResult ProductList()
        {
            return View();
        }
    }
}