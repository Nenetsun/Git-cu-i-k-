using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebNHATHUOC1.Models;
using WebNHATHUOC1.Controllers;

namespace WebNHATHUOC1.Controllers
{
    public class HoaDonController : Controller
    {
        // GET: HoaDon
        private QLNT db = new QLNT();
        public ActionResult Index()
        {
            return View(db.HOADONs.ToList());
        }
        [HttpGet]
        public ActionResult chitietHD(string sohd)
        {
            Session["Mahd"] = sohd;
            return View(db.CHITIETHOADONs.Where(x => x.sohd == sohd));
        }
        public ActionResult FormDelHD(string sohd)
        {
            Session["Mahd"] = sohd;
            ViewBag.DSCTHD = db.CHITIETHOADONs.Where(x => x.sohd == sohd).ToList();
            return View(db.HOADONs.Find(sohd));
        }
        [HttpGet]
        public ActionResult xoaHD(string sohd)
        {
            if (ModelState.IsValid)
            {
                Models.HOADON a = db.HOADONs.Find(sohd);
                List<Models.CHITIETHOADON> cthd = db.CHITIETHOADONs.Where(x => x.sohd == sohd).ToList();
                foreach (var item in cthd)
                {
                    db.CHITIETHOADONs.Remove(item);
                }
                db.HOADONs.Remove(a);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index");
        }
        #region Xử lý CTHD
        public ActionResult delHD(string sohd, string mathuoc)
        {
            List<Models.CHITIETHOADON> tam = db.CHITIETHOADONs.Where(x => x.sohd == sohd && x.mathuoc == mathuoc).ToList();
            if (tam.Count > 0)
            {
                db.CHITIETHOADONs.Remove(tam[0]);
                Models.HOADON hd = db.HOADONs.Find(sohd);
                hd.thanhtien = hd.CHITIETHOADONs.Sum(x => x.soluong * x.dongia);
                db.SaveChanges();
                Session["Mahd"] = null;
                return RedirectToAction("Index");
            }
            return View("chitietHD");
        }
        public ActionResult FormAddHD()
        {
            ViewBag.DSThuoc = db.THUOCs.ToList();
            return View();
        }
        public ActionResult addCTHD(string sohd, string mathuoc, string soluong)
        {
            if (ModelState.IsValid)
            {
                if (db.CHITIETHOADONs.Where(x => x.sohd == sohd && x.mathuoc == mathuoc).ToList().Count < 1)
                {
                    Models.CHITIETHOADON a = new CHITIETHOADON();
                    a.sohd = sohd;
                    a.mathuoc = mathuoc;
                    a.donvitinh = db.THUOCs.Find(mathuoc).donvitinh;
                    a.dongia = db.THUOCs.Find(mathuoc).dongia;
                    a.soluong = Byte.Parse(soluong);
                    a.thanhtien = a.dongia * a.soluong;
                    db.CHITIETHOADONs.Add(a);
                    Models.HOADON hd = db.HOADONs.Find(a.sohd);
                    hd.thanhtien = hd.CHITIETHOADONs.Sum(x => x.soluong * x.dongia);
                    db.SaveChanges();
                    Session["Mahd"] = null;
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("mathuoc", "Thuốc đã có trong hóa đơn!");
                    ViewBag.DSThuoc = db.THUOCs.ToList();
                    return View("FormAddHD");
                }
            }
            ViewBag.DSThuoc = db.THUOCs.ToList();
            return View("FormAddHD");
        }
        [HttpGet]
        public ActionResult FormEditHD(string sohd, string mathuoc)
        {
            return View(db.CHITIETHOADONs.Where(x => x.sohd == sohd && x.mathuoc == mathuoc).ToList()[0]);
        }
        [HttpPost]
        public ActionResult editHD(Models.CHITIETHOADON cthd)
        {
            if (ModelState.IsValid)
            {
                Models.CHITIETHOADON a = db.CHITIETHOADONs.Where(x => x.sohd == cthd.sohd && x.mathuoc == cthd.mathuoc).ToList()[0];
                if (a != null)
                {
                    a.donvitinh = cthd.donvitinh;
                    a.soluong = cthd.soluong;
                    a.dongia = cthd.dongia;
                    a.thanhtien = a.dongia * a.soluong;
                    Models.HOADON hd = db.HOADONs.Find(a.sohd);
                    hd.thanhtien = hd.CHITIETHOADONs.Sum(x => x.soluong * x.dongia);
                    db.SaveChanges();
                    Session["Mahd"] = null;
                    return RedirectToAction("Index");
                }
            }
            return View("FormEditHD", cthd);
        }
        #endregion

        #region Chọn thuốc
        public ActionResult FormChonThuoc(string id)
        {
            return View(db.THUOCs.ToList());
        }
        public ActionResult chonThuoc(string id)
        {
            List<Models.THUOC> ds = new List<Models.THUOC>();
            Models.THUOC a = db.THUOCs.Find(id);
            if (a != null)
            {
                if (ds.Find(x => x.mathuoc == a.mathuoc) == null)
                {
                    ds.Add(a);
                }
            }
            return PartialView(ds);
        }
        [HttpGet]
        public ActionResult delThuoc(string mathuoc)
        {
            if (ModelState.IsValid)
            {
                List<Models.CHITIETHOADON> ds = Session["DSCTHD"] as List<Models.CHITIETHOADON>;
                Models.CHITIETHOADON a = ds.Find(x => x.mathuoc == mathuoc);
                if (a != null)
                    ds.Remove(a);
                Session["DSCTHD"] = ds;
                return RedirectToAction("FormDonThuoc", ds);

            }
            ViewBag.DSKH = db.KHACHHANGs.ToList();
            return View("FormDonThuoc", Session["DSCTHD"] as List<Models.CHITIETHOADON>);
        }
        #endregion

        #region Lập đơn thuốc
        public ActionResult FormDonThuoc()
        {
            Session["Mahd"] = null;
            List<Models.CHITIETHOADON> ds = Session["DSCTHD"] as List<Models.CHITIETHOADON>;
            ViewBag.DSKH = db.KHACHHANGs.ToList();
            return View(ds);
        }

        [HttpPost]
        public ActionResult updateCTHD(string sohd, string mathuoc, string soluong)
        {
            List<Models.CHITIETHOADON> ds1 = Session["DSCTHD"] as List<Models.CHITIETHOADON>;
            Models.CHITIETHOADON a = new CHITIETHOADON();
            a.sohd = sohd;
            a.mathuoc = mathuoc;
            a.soluong = Byte.Parse(soluong==null?soluong:"1");
            a.donvitinh = db.THUOCs.Find(a.mathuoc).donvitinh;
            a.dongia = db.THUOCs.Find(a.mathuoc).dongia;
            a.thanhtien = a.dongia * a.soluong;
            Models.CHITIETHOADON b = ds1.Find(x => x.sohd == a.sohd);
            if (ds1.Count == 0)
            {
                ds1.Add(a);
                Session["Mahd"] = a.sohd;
            }
            else if (b != null && b.mathuoc != a.mathuoc)
            {
                ds1.Add(a);
            }
            //Lỗi ràng buộc
            else if (b != null && b.mathuoc == a.mathuoc)
            {
                ModelState.AddModelError("mathuoc", "Thuốc này đã có trong đơn!");
                return View("FormChonThuoc", db.THUOCs.ToList());
            }
            else if (b == null)
            {
                ModelState.AddModelError("sohd", "Số hóa đơn không đồng bộ!");
                return View("FormChonThuoc", db.THUOCs.ToList());
            }
            ViewBag.DSKH = db.KHACHHANGs.ToList();
            return View("FormDonThuoc", Session["DSCTHD"] as List<Models.CHITIETHOADON>);
        }
        [HttpPost]
        public ActionResult themHoaDon(string ngaylap, string sodt)
        {
            if (ModelState.IsValid && ngaylap != "")
            {
                List<Models.CHITIETHOADON> ds = Session["DSCTHD"] as List<Models.CHITIETHOADON>;
                decimal thanhtien = 0;
                if (ds.Count > 0)
                {
                    foreach (var item in ds)
                    {
                        db.CHITIETHOADONs.Add(item);
                        thanhtien += (decimal)item.thanhtien;
                    }
                    Models.HOADON hd = new HOADON();
                    Models.NHANVIEN nv = Session["User"] as Models.NHANVIEN;
                    hd.makh = sodt;
                    hd.manv = nv.manv;
                    hd.ngaylap = DateTime.Parse(ngaylap);
                    hd.sohd = ds[0].sohd;
                    hd.thanhtien = thanhtien;
                    db.HOADONs.Add(hd);
                    db.SaveChanges();
                    Session["DSCTHD"] = new List<Models.CHITIETHOADON>();
                    Session["Mahd"] = null;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("sohd", "Đơn thuốc rỗng!");
                }
            }
            else
            {
                ModelState.AddModelError("ngaylap", "Hãy nhập ngày lập!");
                if (sodt == "")
                    ModelState.AddModelError("makh", "Hãy nhập mã khách hàng!");
            }
            ViewBag.DSKH = db.KHACHHANGs.ToList();
            return View("FormDonThuoc", Session["DSCTHD"] as List<Models.CHITIETHOADON>);
        }

        #endregion
    }
}