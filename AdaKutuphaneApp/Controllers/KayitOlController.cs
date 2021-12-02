using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdaKutuphaneApp.Models.Entity;

namespace AdaKutuphaneApp.Controllers
{
    public class KayitOlController : Controller
    {
        // GET: KayitOl
        AdaKutuphaneEntities1 db = new AdaKutuphaneEntities1();
        [HttpGet]
        public ActionResult Kayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kayit(tblUyeler u)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            db.tblUyeler.Add(u);
            db.SaveChanges();
            return View();
            
        }
    }
}