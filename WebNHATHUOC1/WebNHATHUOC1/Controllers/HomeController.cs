using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using WebNHATHUOC1.Models;
using WebNHATHUOC1.Controllers;

namespace WebNHATHUOC1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private QLNT db = new QLNT();
      
        public ActionResult Index()
        {
      
            return View();
        }
        public ActionResult Tienich()
        {

            return View();
        }
        public ActionResult Tuvan()
        {

            return View();
        }
        public ActionResult Hotro()
        {

            return View();
        }
        public ActionResult Khachhang()
        {

            return View();
        }
        public ActionResult Kinhnghiem()
        {

            return View();
        }

        #region Đăng ký
        [HttpGet]
        public ActionResult FormDangky()
        {
            ViewBag.DSCN = db.CHINHANHs.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult registerNhanvien(Models.NHANVIEN nv, string password1)
        {
            if(ModelState.IsValid)
            {
                Models.NHANVIEN check = db.NHANVIENs.Find(nv.manv);
                if (check != null)
                    ModelState.AddModelError("manv", "Đã tồn tại tên đăng nhập này!");
                /*else if (nv.password != password1)
                    ModelState.AddModelError("password1", "Xác nhận sai mật khẩu!");*/
                else if (db.CHINHANHs.Find(nv.macn) == null)
                    ModelState.AddModelError("macn", "Không có chi nhánh này!");
                else
                {
                    db.NHANVIENs.Add(nv);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.DSCN = db.CHINHANHs.ToList();
            return View("FormDangky");
        }
        #endregion
    }
}