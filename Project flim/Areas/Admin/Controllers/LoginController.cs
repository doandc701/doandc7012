using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_flim.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Models.DTO.UserModel user)
        {

            if (ModelState.IsValid)
            {
                bool isLogin = Models.DAO.AccountDAO.checkLogin(user.UserName, user.Password);
                if (isLogin == true)
                {
                    // Lưu trạng thái đăng nhập của người dùng

                    Session["Username"] = user.UserName;

                    // Điều hướng đến trang chủ
                    return RedirectToAction("Index", "Homes");
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng");
                }
            }

            return View(user);
        }
        public ActionResult Logout()
        {
            Session.Remove("Username");
            return RedirectToAction("Index");
        }
    }
}