using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        StokDbEntities db = new StokDbEntities();
        public ActionResult Index()
        {
            var degerler = db.Urunler.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.Kategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }
                                             ).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(Urunler p1)
        {
            var ktg = db.Kategori.Where(m => m.KATEGORIID == p1.Kategori.KATEGORIID).FirstOrDefault();
            p1.Kategori = ktg;

            db.Urunler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var urun = db.Urunler.Find(id);
            db.Urunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.Urunler.Find(id);

            List<SelectListItem> degerler = (from i in db.Kategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }
                                 ).ToList();
            ViewBag.dgr = degerler;
            

            return View("UrunGetir", urun);
        }

        public ActionResult Guncelle(Urunler p)
        {
            var urun = db.Urunler.Find(p.URUNID);
            urun.URUNAD = p.URUNAD;
            //urun.URUNKATEGORI = p.URUNKATEGORI;

            

            urun.FIYAT = p.FIYAT;
            urun.MARKA = p.MARKA;
            urun.STOK = p.STOK;

            var ktg = db.Kategori.Where(m => m.KATEGORIID == p.Kategori.KATEGORIID).FirstOrDefault();
            //urun.URUNKATEGORI = ktg.KATEGORIID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}