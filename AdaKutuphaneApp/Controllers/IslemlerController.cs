using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdaKutuphaneApp.Models.Entity;
namespace AdaKutuphaneApp.Controllers
{
    public class IslemlerController : Controller
    {
        // GET: Islemler
        AdaKutuphaneEntities1 db = new AdaKutuphaneEntities1();
        public ActionResult Index()
        {
            var hareketler = db.tblHareketler.Where(x => x.ISLEMDURUM == true).ToList();
            return View(hareketler);
        }
    }
}