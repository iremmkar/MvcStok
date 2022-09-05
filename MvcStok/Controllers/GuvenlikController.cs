using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.Web.Security;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class GuvenlikController : Controller
    {
        // GET: Guvenlik
        StokDbEntities db = new StokDbEntities();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(Kullanici t)
        {
            var bilgiler = db.Kullanici.FirstOrDefault(x => x.KULLANICIADI == t.KULLANICIADI && x.SIFRE == t.SIFRE);
            if(bilgiler != null)
            {
               // FormsAuthentication.SetAuthCookie(bilgiler.KULLANICIADI, false);
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return View();
            }

            
        }


    }

}