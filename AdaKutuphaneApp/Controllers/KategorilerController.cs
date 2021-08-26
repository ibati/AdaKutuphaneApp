using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdaKutuphaneApp.Models.Entity;

namespace AdaKutuphaneApp.Controllers
{
    public class KategorilerController : Controller
    {
        // GET: Kategoriler
        AdaKutuphaneEntities1 db = new AdaKutuphaneEntities1();
        public ActionResult Index()
        {
            var kategoriler = db.tblKategoriler.ToList();
            return View(kategoriler);
        }

        public ActionResult KategoriEkle(tblKategoriler k)
        {
            db.tblKategoriler.Add(k);
            db.SaveChanges();
            return View();
        }
    }


}