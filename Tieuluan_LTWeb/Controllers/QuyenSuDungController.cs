using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.Model;

namespace Tieuluan_LTWeb.Controllers
{
    public class QuyenSuDungController : Controller
    {
        private WebPhim db = new WebPhim();

        // GET: QuyenSuDung
        public ActionResult Index()
        {
            return View(db.QuyenSuDungs.ToList());
        }

        // GET: QuyenSuDung/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuyenSuDung quyenSuDung = db.QuyenSuDungs.Find(id);
            if (quyenSuDung == null)
            {
                return HttpNotFound();
            }
            return View(quyenSuDung);
        }

        // GET: QuyenSuDung/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuyenSuDung/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idQuyen,TenQuyen")] QuyenSuDung quyenSuDung)
        {
            if (ModelState.IsValid)
            {
                db.QuyenSuDungs.Add(quyenSuDung);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quyenSuDung);
        }

        // GET: QuyenSuDung/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuyenSuDung quyenSuDung = db.QuyenSuDungs.Find(id);
            if (quyenSuDung == null)
            {
                return HttpNotFound();
            }
            return View(quyenSuDung);
        }

        // POST: QuyenSuDung/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idQuyen,TenQuyen")] QuyenSuDung quyenSuDung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quyenSuDung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quyenSuDung);
        }

        // GET: QuyenSuDung/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuyenSuDung quyenSuDung = db.QuyenSuDungs.Find(id);
            if (quyenSuDung == null)
            {
                return HttpNotFound();
            }
            return View(quyenSuDung);
        }

        // POST: QuyenSuDung/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuyenSuDung quyenSuDung = db.QuyenSuDungs.Find(id);
            db.QuyenSuDungs.Remove(quyenSuDung);
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
