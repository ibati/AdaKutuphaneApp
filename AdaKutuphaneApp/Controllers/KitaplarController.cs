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
        public ActionResult KitapEkle(tblKitaplar k)
        {
            var kategorisec = db.tblKategoriler.Where(kategori => kategori.ID == k.tblKategoriler.ID).FirstOrDefault();
            var yazarsec = db.tblYazarlar.Where(yazar => yazar.ID == k.tblYazarlar.ID).FirstOrDefault();
            k.tblKategoriler = kategorisec;
            k.tblYazarlar = yazarsec;
            db.tblKitaplar.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult KitapSil(int id)
        {
            var kitap = db.tblKitaplar.Find(id);
            db.tblKitaplar.Remove(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapGetir(int id)
        {
            var kitap = db.tblKitaplar.Find(id);
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
            return View("KitapGetir", kitap);
        }

        public ActionResult KitapGuncelle(tblKitaplar k)
        {
            var kategorisec = db.tblKategoriler.Where(kategori => kategori.ID == k.tblKategoriler.ID).FirstOrDefault();
            var yazarsec = db.tblYazarlar.Where(yazar => yazar.ID == k.tblYazarlar.ID).FirstOrDefault();
            var kitap = db.tblKitaplar.Find(k.ID);
            kitap.AD = k.AD;
            kitap.KATEGORI = kategorisec.ID;
            kitap.YAZAR = yazarsec.ID;
            kitap.BASIMYILI = k.BASIMYILI;
            kitap.SAYFASAYISI = k.SAYFASAYISI;
            kitap.YAYINEVİ = k.YAYINEVİ;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}