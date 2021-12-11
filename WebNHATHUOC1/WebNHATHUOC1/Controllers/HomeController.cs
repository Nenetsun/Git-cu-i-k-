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

        #region Đăng nhập
        public ActionResult FormDangnhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult loginNhanVien(string manv, string password)
        {
            bool flag = true;
            if (ModelState.IsValid)
            {
                Models.NHANVIEN nv = null;
                foreach (var a in db.NHANVIENs.Where(x => x.manv == manv))
                {
                    nv = a;
                    if (a.password.ToString().Trim() != password.Trim())
                        flag = false;
                    break;
                }
                if (nv != null && flag == true)
                {
                    Session["User"] = nv;
                    return RedirectToAction("Index");
                }
                else if (nv != null && flag == false)
                    ModelState.AddModelError("password", "Sai mật khẩu!");
                else if (nv == null)
                    ModelState.AddModelError("manv", "Sai tên đăng nhập!");
            }
            return View("FormDangnhap");
        }
        public ActionResult logout()
        {
            Session["User"] = null;
            return RedirectToAction("Index");
        }
        #endregion

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
                else if (nv.password != password1)
                    ModelState.AddModelError("password1", "Xác nhận sai mật khẩu!");
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