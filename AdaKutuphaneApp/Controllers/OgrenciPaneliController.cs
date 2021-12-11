using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdaKutuphaneApp.Models.Entity;


namespace AdaKutuphaneApp.Controllers
{
    public class OgrenciPaneliController : Controller
    {
        // GET: OgrenciPaneli
        AdaKutuphaneEntities1 db = new AdaKutuphaneEntities1();
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"];
            var bilgiler = db.tblUyeler.FirstOrDefault(x => x.MAIL == uyemail);
            return View(bilgiler);
        }
        [HttpPost]
        public ActionResult Index(tblUyeler p)
        {
            var kullanici = (string)Session["Mail"];
            var uye = db.tblUyeler.FirstOrDefault(x => x.MAIL == kullanici);
            uye.PAROLA = p.PAROLA;
            db.SaveChanges();
            return View();
        }
    }
}