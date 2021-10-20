using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_flim.Areas.Admin.Models.Framework;

namespace Project_flim.Areas.Admin.Controllers
{
    public class PhimsController : Controller
    {
        private PhimEntities db = new PhimEntities();

        // GET: Admin/Phims
        public ActionResult Index(string SearchString)
        {
            var phim = db.Phim.Where(p => p.Name.Contains(SearchString)).ToList();
            return View(phim);
        }

        // GET: Admin/Phims/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phim phim = db.Phim.Find(id);
            if (phim == null)
            {
                return HttpNotFound();
            }
            return View(phim);
        }

        // GET: Admin/Phims/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.DanhMuc, "ID", "Name");
            return View();
        }

        // POST: Admin/Phims/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Alias,Time,CategoryID,Image,Detail,Active,ChiMuc,Video")] Phim phim)
        {
            if (ModelState.IsValid) //thành công
            {
                int number = db.Phim.Count(x => x.ID == phim.ID);
                if (number > 0)
                {
                    ModelState.AddModelError("ID", "Mã đã tồn tại");
                }
                else
                {

                    db.Phim.Add(phim);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.CategoryID = new SelectList(db.DanhMuc, "ID", "Name", phim.CategoryID);
            return View(phim);
        }

        // GET: Admin/Phims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phim phim = db.Phim.Find(id);
            if (phim == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.DanhMuc, "ID", "Name", phim.CategoryID);
            return View(phim);
        }

        // POST: Admin/Phims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Alias,Time,CategoryID,Image,Detail,Active,ChiMuc,Video")] Phim phim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.DanhMuc, "ID", "Name", phim.CategoryID);
            return View(phim);
        }

        // GET: Admin/Phims/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phim phim = db.Phim.Find(id);
            if (phim == null)
            {
                return HttpNotFound();
            }
            return View(phim);
        }

        // POST: Admin/Phims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Phim phim = db.Phim.Find(id);
            db.Phim.Remove(phim);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
