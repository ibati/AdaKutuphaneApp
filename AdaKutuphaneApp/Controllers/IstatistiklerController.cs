using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdaKutuphaneApp.Models.Entity;

namespace AdaKutuphaneApp.Controllers
{
    public class IstatistiklerController : Controller
    {
        // GET: Istatistikler
        AdaKutuphaneEntities1 db = new AdaKutuphaneEntities1();
        public ActionResult Index()
        {
            var uyesayisi = db.tblUyeler.Count();
            var kitapsayisi = db.tblKitaplar.Count();
            var oduncsayisi = db.tblKitaplar.Where(x => x.DURUM == false).Count();
            var kasa = db.tblCezalar.Sum(x => x.CEZA);
            ViewBag.uyesayisi = uyesayisi;
            ViewBag.kitapsayisi = kitapsayisi;
            ViewBag.oduncsayisi = oduncsayisi;
            ViewBag.kasa = kasa;

            var kategorisayisi = db.tblKategoriler.Count();
            var enfazlakitapyazar = db.EnFazlaKitapYazar().FirstOrDefault();
            var eniyiyayinevi = db.tblKitaplar.GroupBy(x => x.YAYINEVİ).OrderByDescending(y => y.Count()).Select(z => new { z.Key }).FirstOrDefault();


            ViewBag.kategorisayisi = kategorisayisi;
            ViewBag.enfazlakitapyazar = enfazlakitapyazar;
            ViewBag.eniyiyayinevi = eniyiyayinevi;

            return View();
        }

        public ActionResult Galeri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResimYukle(HttpPostedFileBase dosya)
        {
            if (dosya.ContentLength > 0)
            {
                string dosyayolu = Path.Combine(Server.MapPath("~/Uploads/"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyayolu);
            }
            return RedirectToAction("Galeri");
        }


    }
}