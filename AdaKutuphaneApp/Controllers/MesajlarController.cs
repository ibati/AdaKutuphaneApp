using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdaKutuphaneApp.Controllers
{
    public class MesajlarController : Controller
    {
        // GET: Mesajalr
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult YeniMesaj()
        {
            return View();
        }
    }
}