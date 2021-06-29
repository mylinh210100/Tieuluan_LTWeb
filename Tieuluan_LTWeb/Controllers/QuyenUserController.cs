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
    public class QuyenUserController : Controller
    {
        private WebPhim db = new WebPhim();

        // GET: QuyenUser
        public ActionResult Index()
        {
            var quyenUsers = db.QuyenUsers.Include(q => q.QuyenSuDung).Include(q => q.TaiKhoan);
            return View(quyenUsers.ToList());
        }

        // GET: QuyenUser/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuyenUser quyenUser = db.QuyenUsers.Find(id);
            if (quyenUser == null)
            {
                return HttpNotFound();
            }
            return View(quyenUser);
        }

        // GET: QuyenUser/Create
        public ActionResult Create()
        {
            ViewBag.idQuyen = new SelectList(db.QuyenSuDungs, "idQuyen", "TenQuyen");
            ViewBag.TenTaiKhoan = new SelectList(db.TaiKhoans, "TenTaiKhoan", "PassWord");
            return View();
        }

        // POST: QuyenUser/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idQuyen,TenTaiKhoan,note")] QuyenUser quyenUser)
        {
            if (ModelState.IsValid)
            {
                db.QuyenUsers.Add(quyenUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idQuyen = new SelectList(db.QuyenSuDungs, "idQuyen", "TenQuyen", quyenUser.idQuyen);
            ViewBag.TenTaiKhoan = new SelectList(db.TaiKhoans, "TenTaiKhoan", "PassWord", quyenUser.TenTaiKhoan);
            return View(quyenUser);
        }

        // GET: QuyenUser/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuyenUser quyenUser = db.QuyenUsers.Find(id);
            if (quyenUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.idQuyen = new SelectList(db.QuyenSuDungs, "idQuyen", "TenQuyen", quyenUser.idQuyen);
            ViewBag.TenTaiKhoan = new SelectList(db.TaiKhoans, "TenTaiKhoan", "PassWord", quyenUser.TenTaiKhoan);
            return View(quyenUser);
        }

        // POST: QuyenUser/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idQuyen,TenTaiKhoan,note")] QuyenUser quyenUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quyenUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idQuyen = new SelectList(db.QuyenSuDungs, "idQuyen", "TenQuyen", quyenUser.idQuyen);
            ViewBag.TenTaiKhoan = new SelectList(db.TaiKhoans, "TenTaiKhoan", "PassWord", quyenUser.TenTaiKhoan);
            return View(quyenUser);
        }

        // GET: QuyenUser/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuyenUser quyenUser = db.QuyenUsers.Find(id);
            if (quyenUser == null)
            {
                return HttpNotFound();
            }
            return View(quyenUser);
        }

        // POST: QuyenUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuyenUser quyenUser = db.QuyenUsers.Find(id);
            db.QuyenUsers.Remove(quyenUser);
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
