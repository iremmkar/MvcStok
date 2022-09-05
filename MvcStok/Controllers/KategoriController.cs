using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        StokDbEntities db = new StokDbEntities();
       
        public ActionResult Index()
        {
            var degerler = db.Kategori.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }


        [HttpPost]
        public ActionResult YeniKategori(Kategori p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.Kategori.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult SIL(int id)
        {
            var kategori = db.Kategori.Find(id);
            db.Kategori.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.Kategori.Find(id);
            return View("KategoriGetir", ktgr);
        }
        public ActionResult Guncelle(Kategori p1)
        {
            var ktg = db.Kategori.Find(p1.KATEGORIID);
            ktg.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}