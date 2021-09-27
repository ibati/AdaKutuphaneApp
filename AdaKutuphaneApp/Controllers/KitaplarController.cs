using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdaKutuphaneApp.Models.Entity;

namespace AdaKutuphaneApp.Controllers
{
    public class KitaplarController : Controller
    {
        // GET: Kitap
        AdaKutuphaneEntities1 db = new AdaKutuphaneEntities1();
        public ActionResult Index()
        {
            var kitaplar = db.tblKitaplar.ToList();

            return View(kitaplar);
        }

        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> kategorilist = (from i in db.tblKategoriler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.kategorisec = kategorilist;

            List<SelectListItem> yazarlist = (from i in db.tblYazarlar.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = i.AD + ' ' + i.SOYAD,
                                                    Value = i.ID.ToString()
                                                }).ToList();
            ViewBag.yazarsec = yazarlist;
            return View();

        }

        [HttpPost]
        public ActionResult KitapEkle(tblKitaplar kitap)
        {
            var kategorisec = db.tblKategoriler.Where(kategori => kategori.ID == kitap.tblKategoriler.ID).FirstOrDefault();
            var yazarsec = db.tblYazarlar.Where(yazar => yazar.ID == kitap.tblYazarlar.ID).FirstOrDefault();
            kitap.tblKategoriler = kategorisec;
            kitap.tblYazarlar = yazarsec;
            db.tblKitaplar.Add(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}