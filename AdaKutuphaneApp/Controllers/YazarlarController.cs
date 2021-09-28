using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdaKutuphaneApp.Models.Entity;


namespace AdaKutuphaneApp.Controllers
{
    public class YazarlarController : Controller
    {
        // GET: Yazarlar
        AdaKutuphaneEntities1 db = new AdaKutuphaneEntities1();
        public ActionResult Index()
        {
            var yazarlar = db.tblYazarlar.ToList();
            return View(yazarlar);
        }

        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YazarEkle(tblYazarlar y)
        {
            db.tblYazarlar.Add(y);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YazarSil(int id)
        {
            var yazar = db.tblYazarlar.Find(id);
            db.tblYazarlar.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult YazarGetir(int id)
        {
            var yazar = db.tblYazarlar.Find(id);
            return View("YazarGetir", yazar);
        }

        public ActionResult YazarGuncelle(tblYazarlar y)
        {
            var yazar = db.tblYazarlar.Find(y.ID);
            yazar.AD = y.AD;
            yazar.SOYAD = y.SOYAD;
            yazar.DETAY = y.DETAY;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}