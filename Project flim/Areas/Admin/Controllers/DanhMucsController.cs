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
    public class DanhMucsController : Controller
    {
        private PhimEntities db = new PhimEntities();

        // GET: Admin/DanhMucs
        public ActionResult Index()
        {
            var danhMuc = db.DanhMuc.Include(d => d.DanhMuc2).OrderBy(d => d.Level).ToList();
            //var danhMuc = db.DanhMuc.Where(n => n.Name.Contains(SearchString)).ToList();
            return View(danhMuc);
        }

        // GET: Admin/DanhMucs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMuc danhMuc = db.DanhMuc.Find(id);
            if (danhMuc == null)
            {
                return HttpNotFound();
            }
            return View(danhMuc);
        }

        // GET: Admin/DanhMucs/Create
        public ActionResult Create()
        {
            ViewBag.ParentID = new SelectList(db.DanhMuc, "ID", "Name");
            return View();
        }

        // POST: Admin/DanhMucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Alias,ParentID,Order,Level,Active")] DanhMuc danhMuc)
        {
            if (ModelState.IsValid) //thành công
            {
                int number = db.DanhMuc.Count(x => x.ID == danhMuc.ID);
                if (number > 0)
                {
                    ModelState.AddModelError("ID", "Mã đã tồn tại");
                }
                else
                {
                    db.DanhMuc.Add(danhMuc);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                   
                }
            }
            // thất bại
            ViewBag.ParentID = new SelectList(db.DanhMuc, "ID", "Name", danhMuc.ParentID);
            return View(danhMuc);
        }

        // GET: Admin/DanhMucs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMuc danhMuc = db.DanhMuc.Find(id);
            if (danhMuc == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentID = new SelectList(db.DanhMuc, "ID", "Name", danhMuc.ParentID);
            return View(danhMuc);
        }

        // POST: Admin/DanhMucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Alias,ParentID,Order,Level,Active")] DanhMuc danhMuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhMuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParentID = new SelectList(db.DanhMuc, "ID", "Name", danhMuc.ParentID);
            return View(danhMuc);
        }

        // GET: Admin/DanhMucs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMuc danhMuc = db.DanhMuc.Find(id);
            if (danhMuc == null)
            {
                return HttpNotFound();
            }
            return View(danhMuc);
        }

        // POST: Admin/DanhMucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DanhMuc danhMuc = db.DanhMuc.Find(id);
            db.DanhMuc.Remove(danhMuc);
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
