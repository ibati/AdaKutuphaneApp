using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdaKutuphaneApp.Models.Entity;

namespace AdaKutuphaneApp.Controllers
{
    public class VitrinController : Controller
    {
        // GET: Vitrin
        AdaKutuphaneEntities1 db = new AdaKutuphaneEntities1();
        public ActionResult Index()
        {
            var kitaplar = db.tblKitaplar.ToList();

            return View(kitaplar);
        }
    }
}