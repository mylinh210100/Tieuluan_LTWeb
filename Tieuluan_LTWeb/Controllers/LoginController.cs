using DataIO.EF;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tieuluan_LTWeb.Models;

namespace Tieuluan_LTWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLogin taiKhoan)
        {
            if (ModelState.IsValid)
            {
                var model = new UserCode();
                int rs = model.Dangnhap(taiKhoan.Username, taiKhoan.Pass);
                if (rs == 1)
                {
                    var user = model.GetByName(taiKhoan.Username);
                    var sessionlogin = new SessionLogin();
                    sessionlogin.name = user.TenTaiKhoan;
                    Session["login"] = sessionlogin;
                    return Redirect("/");
                }
                else if (rs == 0)
                {
                    ModelState.AddModelError("", "this account is not exist");
                }
                else if (rs == -1)
                {
                    ModelState.AddModelError("", "your password is incorrect!");
                }
            }
            return View(taiKhoan);
        }


        public ActionResult Logout()
        {
            Session.Clear();
            return Redirect("/");
        }
    }
}