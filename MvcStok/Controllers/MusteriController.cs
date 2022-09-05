using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        StokDbEntities db = new StokDbEntities();

        
        [Authorize]
        public ActionResult Index()
        {
            var degerler = db.Musteri.ToList();

            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(Musteri p1) 
            {
                db.Musteri.Add(p1);
                db.SaveChanges();
                return View();
            }
        public ActionResult SIL(int id)
        {
            var musteri = db.Musteri.Find(id);
            db.Musteri.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.Musteri.Find(id);
            return View("MusteriGetir", mus);
        }
        public ActionResult Guncelle(Musteri p1)
        {
            var musteri = db.Musteri.Find(p1.MUSTERIID);
            musteri.ISIM = p1.ISIM;
            musteri.SOYISIM = p1.SOYISIM;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}