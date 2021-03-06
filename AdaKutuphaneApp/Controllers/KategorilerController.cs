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
            var kategoriler = db.tblKategoriler.Where(x=>x.DURUM == true).ToList();
            return View(kategoriler);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(tblKategoriler k)
        {
            db.tblKategoriler.Add(k);
            db.SaveChanges();
            return View();
        }

        public  ActionResult KategoriSil(int id)
        {
            var kategori = db.tblKategoriler.Find(id);
            // db.tblKategoriler.Remove(kategori); // Silme yerine pasif etme getirdik
            kategori.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.tblKategoriler.Find(id);
            return View("KategoriGetir", kategori);
        }

        public ActionResult KategoriGuncelle(tblKategoriler k)
        {
            var kategori = db.tblKategoriler.Find(k.ID);
            kategori.AD = k.AD;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }


}