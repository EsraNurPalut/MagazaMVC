using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagazadbMVC.Models;

namespace MagazadbMVC.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun

        Magaza1Entities db = new Magaza1Entities();

        public ActionResult Index()
        {
            return View(db.Urunlers.ToList());
        }

        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Urunler save)
        {
            try
            {
                using (Magaza1Entities db = new Magaza1Entities())
                {
                    db.Urunlers.Add(save);
                    db.SaveChanges();
                }
                return RedirectToAction("Index"); //ekleme yapınca ındex sayfasına direk gitsin
            }
            catch
            {
                return View();
            }

        }

        [HttpGet]
        public ActionResult Duzenle(int urunno)
        {
            using (Magaza1Entities db = new Magaza1Entities())
            {
                return View(db.Urunlers.Where(x => x.UrunNo == urunno).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult Duzenle(int urunno, Urunler modify)
        {
            try
            {
                using (Magaza1Entities db = new Magaza1Entities())
                {
                    db.Entry(modify).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (Magaza1Entities db = new Magaza1Entities())
            {
                return View(db.Urunlers.Where(x => x.UrunNo == id).FirstOrDefault());
            }
        }


        [HttpPost]
        public ActionResult Delete(int id, Urunler sil)
        {
            try
            {
                using (Magaza1Entities db = new Magaza1Entities())
                {
                    sil = db.Urunlers.Where(x => x.UrunNo == id).FirstOrDefault();
                    db.Urunlers.Remove(sil);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}