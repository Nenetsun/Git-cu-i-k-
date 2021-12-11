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
    }
}