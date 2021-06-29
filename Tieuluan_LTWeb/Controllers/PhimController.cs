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
    public class PhimController : Controller
    {
        private WebPhim db = new WebPhim();

        // GET: Phim
        public ActionResult Index()
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }

            if (HttpContext.Session["admin"] == null)
            {
                return RedirectToAction("NoPermission","Home");
            }
            return View(db.Phims.ToList());
        }

        // GET: Phim/Details/5
        public ActionResult Details(int? id)
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }

            if (HttpContext.Session["admin"] == null)
            {
                return RedirectToAction("NoPermission", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phim phim = db.Phims.Find(id);
            if (phim == null)
            {
                return HttpNotFound();
            }
            return View(phim);
        }

        // GET: Phim/Create
        public ActionResult Create()
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }

            if (HttpContext.Session["admin"] == null)
            {
                return RedirectToAction("NoPermission", "Home");
            }
            return View();
        }

        // POST: Phim/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPhim,TenPhim,MoTa,Anh,Link,LuotXem")] Phim phim)
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }

            if (HttpContext.Session["admin"] == null)
            {
                return RedirectToAction("NoPermission", "Home");
            }
            if (ModelState.IsValid)
            {
                db.Phims.Add(phim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phim);
        }

        // GET: Phim/Edit/5
        public ActionResult Edit(int? id)
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }

            if (HttpContext.Session["admin"] == null)
            {
                return RedirectToAction("NoPermission", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phim phim = db.Phims.Find(id);
            if (phim == null)
            {
                return HttpNotFound();
            }
            return View(phim);
        }

        // POST: Phim/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPhim,TenPhim,MoTa,Anh,Link,LuotXem")] Phim phim)
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }

            if (HttpContext.Session["admin"] == null)
            {
                return RedirectToAction("NoPermission", "Home");
            }
            if (ModelState.IsValid)
            {
                db.Entry(phim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phim);
        }

        // GET: Phim/Delete/5
        public ActionResult Delete(int? id)
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }

            if (HttpContext.Session["admin"] == null)
            {
                return RedirectToAction("NoPermission", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phim phim = db.Phims.Find(id);
            if (phim == null)
            {
                return HttpNotFound();
            }
            return View(phim);
        }

        // POST: Phim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }

            if (HttpContext.Session["admin"] == null)
            {
                return RedirectToAction("NoPermission", "Home");
            }
            Phim phim = db.Phims.Find(id);
            db.Phims.Remove(phim);
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
