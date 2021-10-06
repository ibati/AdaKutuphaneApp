using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdaKutuphaneApp.Models.Entity;

namespace AdaKutuphaneApp.Controllers
{
    public class PersonellerController : Controller
    {
        // GET: Personeller
        AdaKutuphaneEntities1 db = new AdaKutuphaneEntities1();
        public ActionResult Index()
        {
            var personeller = db.tblPersoneller.ToList();
            return View(personeller);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(tblPersoneller p)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }
            db.tblPersoneller.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelSil(int id)
        {
            var personel = db.tblPersoneller.Find(id);
            db.tblPersoneller.Remove(personel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            var personel = db.tblPersoneller.Find(id);
            return View("PersonelGetir", personel);
        }

        public ActionResult PersonelGuncelle(tblPersoneller p)
        {
            var personel = db.tblPersoneller.Find(p.ID);
            personel.AD = p.AD;
            personel.SOYAD = p.SOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}