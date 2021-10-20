using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_flim.Areas.Admin.Models.Framework;
namespace Project_flim.Controllers
{
    public class DetailController : Controller
    {
        PhimEntities db = new PhimEntities();
        
        
        // GET: ctphim
        
       [ChildActionOnly]
        public ActionResult ImageDV(int PhimID)
        {
            List<ListDV> obj = db.ListDV.Where(x => x.PhimID == PhimID).Take(3).ToList();
            return PartialView(obj);
        }

        public ActionResult Chitietphim(int ID)
        {

            Phim lst = db.Phim.Find(ID);
            return View(lst);
        }
        public ActionResult DienVien(int ID)
        {
            ListDV dv = db.ListDV.Find(ID);
            return View(dv);
        }

    }
}