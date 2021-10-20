using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_flim.Areas.Admin.Models.Framework;
namespace Project_flim.Controllers
{
    public class HomeController : Controller
    {
        PhimEntities db = new PhimEntities();
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult PhimDanhMuc(int CategoryID)
        {
            DanhMuc obj = db.DanhMuc.First(x => x.ID == CategoryID);
            List<Phim> lst = db.Phim.Where(x => x.CategoryID == CategoryID && x.Active == true).Take(5).ToList();
            ViewBag.DanhMuc = obj;
            return PartialView(lst);
        }
        public ActionResult dangnhap()
        {
            return View();
        }
        public ActionResult dangky()
        {
            return View();
        }
        
    }
}