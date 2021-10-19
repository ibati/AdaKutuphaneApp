using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdaKutuphaneApp.Models.Entity;

namespace AdaKutuphaneApp.Controllers
{
    public class HareketlerController : Controller
    {
        // GET: Hareketler
        AdaKutuphaneEntities1 db = new AdaKutuphaneEntities1();
        public ActionResult Index()
        {
            var hareketler = db.tblHareketler.ToList();
            return View(hareketler);
        }

        [HttpGet]
        public ActionResult OduncVer()
        {
            List<SelectListItem> uyelist = (from i in db.tblUyeler.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.AD,
                                                Value = i.ID.ToString()
                                            }).ToList();
            ViewBag.uyesec = uyelist;

            List<SelectListItem> kitaplist = (from i in db.tblKitaplar.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.AD,
                                                  Value = i.ID.ToString()
                                              }).ToList();
            ViewBag.kitapsec = kitaplist;

            List<SelectListItem> personellist = (from i in db.tblPersoneller.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = i.AD,
                                                     Value = i.ID.ToString()
                                                 }).ToList();
            ViewBag.personelsec = personellist;

            return View();
        }

        [HttpPost]
        public ActionResult OduncVer(tblHareketler h)
        {
            var uyesec = db.tblUyeler.Where(uye => uye.ID == h.tblUyeler.ID).FirstOrDefault();
            var kitapsec = db.tblKitaplar.Where(kitap => kitap.ID == h.tblKitaplar.ID).FirstOrDefault();
            var personelsec = db.tblPersoneller.Where(uye => uye.ID == h.tblPersoneller.ID).FirstOrDefault();
            h.tblUyeler = uyesec;
            h.tblKitaplar = kitapsec;
            h.tblPersoneller = personelsec;
            db.tblHareketler.Add(h);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult IadeAl(int id)
        {
            var iade = db.tblHareketler.Find(id);
            return View("IadeAl", iade);
        }

        public ActionResult IadeTamamla(tblHareketler t)
        {
            var iade = db.tblHareketler.Find(t.ID);
            iade.ISLEMDURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }


}