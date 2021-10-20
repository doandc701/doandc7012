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
    public class ListDVsController : Controller
    {
        private PhimEntities db = new PhimEntities();

        // GET: Admin/ListDVs
        public ActionResult Index(string SearchString)
        {
            var listDV = db.ListDV.Where(l => l.NameDV.Contains(SearchString)).ToList();
            return View(listDV);
        }

        // GET: Admin/ListDVs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListDV listDV = db.ListDV.Find(id);
            if (listDV == null)
            {
                return HttpNotFound();
            }
            return View(listDV);
        }

        // GET: Admin/ListDVs/Create
        public ActionResult Create()
        {
            ViewBag.PhimID = new SelectList(db.Phim, "ID", "Name");
            return View();
        }

        // POST: Admin/ListDVs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NameDV,ImageDV,PhimID,Date_of_birth,Job,Height,View,Related_movies,Story,NamePhim")] ListDV listDV)
        {
            if (ModelState.IsValid) //thành công
            {
                int number = db.ListDV.Count(x => x.ID == listDV.ID);
                if (number > 0)
                {
                    ModelState.AddModelError("ID", "Mã đã tồn tại");
                }
                else
                {

                    db.ListDV.Add(listDV);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.PhimID = new SelectList(db.Phim, "ID", "Name", listDV.PhimID);
            return View(listDV);
        }

        // GET: Admin/ListDVs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListDV listDV = db.ListDV.Find(id);
            if (listDV == null)
            {
                return HttpNotFound();
            }
            ViewBag.PhimID = new SelectList(db.Phim, "ID", "Name", listDV.PhimID);
            return View(listDV);
        }

        // POST: Admin/ListDVs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NameDV,ImageDV,PhimID,Date_of_birth,Job,Height,View,Related_movies,Story,NamePhim")] ListDV listDV)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listDV).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PhimID = new SelectList(db.Phim, "ID", "Name", listDV.PhimID);
            return View(listDV);
        }

        // GET: Admin/ListDVs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListDV listDV = db.ListDV.Find(id);
            if (listDV == null)
            {
                return HttpNotFound();
            }
            return View(listDV);
        }

        // POST: Admin/ListDVs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListDV listDV = db.ListDV.Find(id);
            db.ListDV.Remove(listDV);
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
