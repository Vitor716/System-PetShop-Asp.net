using GladiaSystem.Database;
using GladiaSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GladiaSystem.Controllers
{
    public class LoginController : Controller
    {

        Queries queries = new Queries();

        // GET: Login
        public ActionResult Login()
        {
            User user = new User();
            return View(user);
        }

        [HttpPost]
        public ActionResult CheckUser(User u)
        {
            queries.TestUser(u);
            return Redirect("");
        }
    }
}