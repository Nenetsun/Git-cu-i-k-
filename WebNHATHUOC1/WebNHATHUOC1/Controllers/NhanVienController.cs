using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebNHATHUOC1.Models;
using WebNHATHUOC1.Controllers;

namespace WebNHATHUOC1.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: NhanVien
        QLNT db = new QLNT();
        #region Quản lý nhân viên
        public ActionResult Index()
        {
            return View(db.NHANVIENs.ToList());
        }
        public ActionResult detailsNV(string manv)
        {
            ViewBag.DSHD = db.HOADONs.Where(x => x.manv == manv);
            return View(db.NHANVIENs.Find(manv));
        }
        public ActionResult FormDelNV(string manv)
        {
            ViewBag.DSHD = db.HOADONs.Where(x => x.manv == manv);
            return View(db.NHANVIENs.Find(manv));
        }
        [HttpGet]
        public ActionResult delNV(string manv)
        {
            Models.NHANVIEN a = db.NHANVIENs.Find(manv);
            if (a != null)
            {
                List<Models.HOADON> lstHD = db.HOADONs.Where(x => x.manv == manv).ToList();
                foreach (var hd in lstHD)
                {
                    List<Models.CHITIETHOADON> lstCTHD = db.CHITIETHOADONs.Where(x => x.sohd == hd.sohd).ToList();
                    foreach (var cthd in lstCTHD)
                        db.CHITIETHOADONs.Remove(cthd);
                }
                db.NHANVIENs.Remove(a);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult FormEditNV(string manv)
        {
            ViewBag.DSCN = db.CHINHANHs.ToList();
            return View(db.NHANVIENs.Find(manv));
        }
        [HttpPost]
        public ActionResult editNV(Models.NHANVIEN nv, string password1, string password2)
        {
            if (nv != null)
            {
                Models.NHANVIEN a = db.NHANVIENs.Find(nv.manv);
                a.tennv = nv.tennv;
                a.socm = nv.socm;
                a.sodt = nv.sodt;
                a.macn = nv.macn;
                a.diachi = nv.diachi;
                if(password1 != "" && password2 != "")
                {
                    if (password2 != password1)
                    {
                        ModelState.AddModelError("password2", "Xác nhận sai mật khẩu!");
                        return View("FormEditNV");
                    }
                    else
                        a.password = password1;
                }
                else if(password1 != "" && password2 == "") 
                {
                    ModelState.AddModelError("password2", "Xác nhận sai mật khẩu!");
                    return View("FormEditNV");
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DSCN = db.CHINHANHs.ToList();
            return View("FormEditNV", db.NHANVIENs.Find(nv.macn));
        }
        #endregion
    }
}