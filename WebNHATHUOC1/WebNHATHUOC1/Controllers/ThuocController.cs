using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebNHATHUOC1.Models;
using WebNHATHUOC1.Controllers;

namespace WebNHATHUOC1.Controllers
{
    public class ThuocController : Controller
    {
        // GET: Thuoc
        private QLNT db = new QLNT();
        public ActionResult Index()
        {
            return View(db.THUOCs.ToList());
        }
        public ActionResult FormAddThuoc()
        {
            ViewBag.DSNCC = db.NHACUNGCAPs.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult addThuoc(Models.THUOC thuoc)
        {
            if(ModelState.IsValid)
            {
                if(db.THUOCs.Find(thuoc.mathuoc) == null)
                {
                    db.THUOCs.Add(thuoc);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("mathuoc", "Thuốc đã có dữ liệu!");
                    ViewBag.DSNCC = db.NHACUNGCAPs.ToList();
                    return View("FormAddThuoc");
                }    
            }
            ViewBag.DSNCC = db.NHACUNGCAPs.ToList();
            return View("FormAddThuoc");
        }
        public ActionResult detailsThuoc(string mathuoc)
        {           
            return View(db.THUOCs.Find(mathuoc));
        }
        public ActionResult FormEditThuoc(string mathuoc)
        {
            ViewBag.DSNCC = db.NHACUNGCAPs.ToList();
            return View(db.THUOCs.Find(mathuoc));
        }
        [HttpPost]
        public ActionResult editThuoc(Models.THUOC thuoc)
        {
            Models.THUOC a = db.THUOCs.Find(thuoc.mathuoc);
            a.tenthuoc = thuoc.tenthuoc;
            a.mancc = thuoc.mancc;
            a.mota = thuoc.mota;
            a.hansd = thuoc.hansd;
            a.dongia = thuoc.dongia;
            a.donvitinh = thuoc.donvitinh;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult delThuoc(string mathuoc)
        {
            Models.THUOC a = db.THUOCs.Find(mathuoc);
            if(a != null)
            {
                db.THUOCs.Remove(a);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}