using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdaKutuphaneApp.Models.Entity;

namespace AdaKutuphaneApp.Controllers
{
    public class UyelerController : Controller
    {
        // GET: Uyeler
        AdaKutuphaneEntities1 db = new AdaKutuphaneEntities1();

        public ActionResult Index()
        {
            var uyeler = db.tblUyeler.ToList();
            return View(uyeler);
        }

        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UyeEkle(tblUyeler u)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            db.tblUyeler.Add(u);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UyeSil(int id)
        {
            var uye = db.tblUyeler.Find(id);
            db.tblUyeler.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UyeGetir(int id)
        {
            var uye = db.tblUyeler.Find(id);
            return View("UyeGetir", uye);
        }

        public ActionResult UyeGuncelle(tblUyeler u)
        {
            var uye = db.tblUyeler.Find(u.ID);
            uye.AD = u.AD;
            uye.SOYAD = u.SOYAD;
            uye.SOYAD = u.SOYAD;
            uye.MAIL = u.MAIL;
            uye.KULLANICIADI = u.KULLANICIADI;
            uye.PAROLA = u.PAROLA;
            uye.TELEFON = u.TELEFON;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult UyeKitapGecmis(int id)
        {
            var kitapgecmis = db.tblHareketler.Where(kitap => kitap.UYE == id).ToList();
            var uye = db.tblUyeler.Where(uyeid => uyeid.ID == id).Select(uyead => uyead.AD + " " + uyead.SOYAD).FirstOrDefault();
            ViewBag.uye = uye;
            return View(kitapgecmis);
        }
    }
}
