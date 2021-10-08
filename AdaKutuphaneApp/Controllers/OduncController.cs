using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdaKutuphaneApp.Models.Entity;

namespace AdaKutuphaneApp.Controllers
{
    public class OduncController : Controller
    {
        // GET: Odunc
        AdaKutuphaneEntities1 db = new AdaKutuphaneEntities1();
        public ActionResult Index()
        {
            var hareketler = db.tblHareketler.ToList();
            return View(hareketler);
        }

        [HttpGet]
        public ActionResult OduncVer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OduncVer(tblHareketler h)
        {
            db.tblHareketler.Add(h);
            db.SaveChanges();
            return View();        
        }


    }
}