using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_flim.Areas.Admin.Models.Framework;
namespace Project_flim.Controllers
{
    public class XemPhimController : Controller
    {
        PhimEntities db = new PhimEntities();
        // GET: XemPhim
        public ActionResult XemPhim(int ID)
        {
            Phim lst = db.Phim.Find(ID);
            return View(lst);
        }
    }
}