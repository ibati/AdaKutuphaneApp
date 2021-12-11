using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdaKutuphaneApp.Models.Entity;
using System.Web.Security;

namespace AdaKutuphaneApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        AdaKutuphaneEntities1 db = new AdaKutuphaneEntities1();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(tblUyeler p)
        {
            var uyebilgisi = db.tblUyeler.FirstOrDefault(x => x.MAIL == p.MAIL && x.PAROLA == p.PAROLA);
            if (uyebilgisi != null)
            {
                FormsAuthentication.SetAuthCookie(uyebilgisi.MAIL, false);  
                Session["Mail"] = uyebilgisi.MAIL.ToString();
                // Değiştirdik, alttakiler iptal
                //TempData["Ad"] = uyebilgisi.AD.ToString();
                //TempData["Soyad"] = uyebilgisi.SOYAD.ToString();
                //TempData["Kullanici"] = uyebilgisi.KULLANICIADI.ToString();
                //TempData["Sifre"] = uyebilgisi.PAROLA.ToString();
                return RedirectToAction("Index", "OgrenciPaneli");
            }
            else
            {
                return View();
            }

        }

    }
}