using GladiaSystem.Database;
using GladiaSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Collections.ObjectModel;


namespace GladiaSystem.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            User user = new User();
            return View(user);
        }

        Queries queries = new Queries();

        [HttpPost]
        public ActionResult LoginUser(User user)
        {
            string acessLevel = queries.Login(user);

            if( acessLevel == "0")
            {
                //pdv e iniciar sessao com access level 0 e tirar seta 
                Session["access"] = "0";
                return RedirectToAction("Pos", "Home");
            }
            else if( acessLevel == "1")
            {
                Session["access"] = "1";
                return RedirectToAction("Home", "Home");
                //home e iniciar sessao com access level 1
            }
            else
            {
                return Redirect("Login");
                //Recarrega a página ou tela de erro
            }
        }

    }
}