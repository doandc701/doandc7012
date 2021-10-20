using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Project_flim.Areas.Admin.Models.Framework;

namespace Project_flim.Areas.Admin.Controllers
{
    public class HomesController : Controller
    {
        PhimEntities objModel = new PhimEntities();
        private bool checkLogin()
        {
            if (Session["Username"] == null || Session["Username"].ToString() == "")
            {
                return false;
            }
            return true;
        }
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (!checkLogin())
            {
                return RedirectToAction("Index", "Login");
            }
            
            return View();
        }

        public ActionResult Bieudo()
        {
            return View();
        }

        //Register
       
    }
}