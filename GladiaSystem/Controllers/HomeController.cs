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
            ViewBag.AllAgenda = ShowAgenda.ListAgenda();
            BigAgenda bigAgenda = new BigAgenda();
            return View(bigAgenda);
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

        List<int> IDs = new List<int>();
        List<string> Name = new List<string>();
        List<string> Price = new List<string>();
        List<string> Quant = new List<string>();

        [HttpPost]
        public ActionResult ProductGet(Product product)
        {
            product = queries.GetProduct(product.Name);


            IDs.Add(product.ID);
            Name.Add(product.Name);
            Price.Add(product.Price);
            Quant.Add(product.Quant);

            ViewBag.IDs = IDs;
            ViewBag.Name = Name;
            ViewBag.Price = Price;
            ViewBag.Quant = Quant;

            return View("POS");
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
            }
            else
            {
                ViewData["Error"] = "Opss, algo deu errado 😢.";
            }
                return RedirectToAction("Category");
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

            queries.RegisterProd(product, imagePath);
            TempData["Success"] = "Feito! 😄";
            ViewBag.ListCategory = queries.ListCategory();
            return RedirectToAction("Product");
        }


        public ActionResult ChangePassword()
        {
            string session = (string)Session["userID"];
            ViewBag.Img = queries.GetUserImages(session);
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
            string session = (string)Session["userID"];
            ViewBag.Img = queries.GetUserImages(session);
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

        [HttpPost]
        public ActionResult ChangePhoto(User user)
        {
            WebImage photo = null;
            var newFileName = "";
            var imagePath = "";
            string sessionID = (string)Session["userID"];

            photo = WebImage.GetImageFromRequest();
            if (photo != null)
            {
                newFileName = Guid.NewGuid().ToString() + "_" +
                Path.GetFileName(photo.FileName);
                imagePath = @"/" + newFileName;

                photo.Save(@"~/Images" + imagePath);
                imagePath = photo.FileName;
            }

            queries.ChangePhoto(imagePath,sessionID);
            TempData["Success"] = "Feito! 😄";
            return RedirectToAction("DeleteAccount");
        }

        [HttpPost]
        public ActionResult ChangePhotoName(User user)
        {
            WebImage photo = null;
            var newFileName = "";
            var imagePath = "";
            string sessionID = (string)Session["userID"];

            photo = WebImage.GetImageFromRequest();
            if (photo != null)
            {
                newFileName = Guid.NewGuid().ToString() + "_" +
                Path.GetFileName(photo.FileName);
                imagePath = @"/" + newFileName;

                photo.Save(@"~/Images" + imagePath);
                imagePath = photo.FileName;
            }

            queries.ChangePhoto(imagePath, sessionID);
            TempData["Success"] = "Feito! 😄";
            return RedirectToAction("ChangeName");
        }

        [HttpPost]
        public ActionResult ChangePhotoPassword(User user)
        {
            WebImage photo = null;
            var newFileName = "";
            var imagePath = "";
            string sessionID = (string)Session["userID"];

            photo = WebImage.GetImageFromRequest();
            if (photo != null)
            {
                newFileName = Guid.NewGuid().ToString() + "_" +
                Path.GetFileName(photo.FileName);
                imagePath = @"/" + newFileName;

                photo.Save(@"~/Images" + imagePath);
                imagePath = photo.FileName;
            }

            queries.ChangePhoto(imagePath, sessionID);
            TempData["Success"] = "Feito! 😄";
            return RedirectToAction("ChangePassword");
        }

        [HttpPost]
        public ActionResult ChangePhotoDelete(User user)
        {
            WebImage photo = null;
            var newFileName = "";
            var imagePath = "";
            string sessionID = (string)Session["userID"];

            photo = WebImage.GetImageFromRequest();
            if (photo != null)
            {
                newFileName = Guid.NewGuid().ToString() + "_" +
                Path.GetFileName(photo.FileName);
                imagePath = @"/" + newFileName;

                photo.Save(@"~/Images" + imagePath);
                imagePath = photo.FileName;
            }

            queries.ChangePhoto(imagePath, sessionID);
            TempData["Success"] = "Feito! 😄";
            return RedirectToAction("DeleteAccount");
        }

        public ActionResult DeleteAccount()
        {
            string session = (string)Session["userID"];
            ViewBag.Img = queries.GetUserImages(session);
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