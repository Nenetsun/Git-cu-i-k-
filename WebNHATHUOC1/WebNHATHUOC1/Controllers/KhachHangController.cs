using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebNHATHUOC1.Models;
using WebNHATHUOC1.Controllers;

namespace WebNHATHUOC1.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: KhachHang
        QLNT db = new QLNT();
        public ActionResult Index()
        {
            return View(db.KHACHHANGs.ToList());
        }
        public ActionResult FormThemKH()
        {
            return View();
        }
        [HttpPost]
        public ActionResult themKH(Models.KHACHHANG kh)
        {
            if(ModelState.IsValid)
            {
                if(db.KHACHHANGs.Find(kh.sodt) == null)
                {
                    db.KHACHHANGs.Add(kh);
                    db.SaveChanges();
                    RedirectToAction("Index", "KhachHang");
                }
                else
                {
                    ModelState.AddModelError("sodt", "Đã có khách hàng này!");
                }    
            }
            return View("FormThemKH");
        }
        public ActionResult detailsKH(string sodt)
        {
            ViewBag.DSHD = db.HOADONs.Where(x => x.makh == sodt).ToList();
            return View(db.KHACHHANGs.Find(sodt));
        }
        public ActionResult FormDelKH(string sodt)
        {
            ViewBag.DSHD = db.HOADONs.Where(x => x.makh == sodt).ToList();
            return View(db.KHACHHANGs.Find(sodt));
        }
        [HttpGet]
        public ActionResult delKH(string sodt)
        {
            Models.KHACHHANG a = db.KHACHHANGs.Find(sodt);
            if(a != null)
            {
                List<Models.HOADON> lstHD = db.HOADONs.Where(x => x.makh == sodt).ToList();
                foreach(var hd in lstHD)
                {
                    List<Models.CHITIETHOADON> lstCTHD = db.CHITIETHOADONs.Where(x => x.sohd == hd.sohd).ToList();
                    foreach (var cthd in lstCTHD)
                        db.CHITIETHOADONs.Remove(cthd);
                }    
                db.KHACHHANGs.Remove(a);
                db.SaveChanges();
            }    
            return RedirectToAction("Index");
        }
        public ActionResult FormEditKH(string sodt)
        {
            return View(db.KHACHHANGs.Find(sodt));
        }
        [HttpPost]
        public ActionResult editKH(Models.KHACHHANG kh)
        {
            if(ModelState.IsValid)
            {
                Models.KHACHHANG a = db.KHACHHANGs.Find(kh.sodt);
                a.tenkh = kh.tenkh;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("FormEditKH",db.KHACHHANGs.Find(kh.sodt));
        }
    }
}