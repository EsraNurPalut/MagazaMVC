using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagazadbMVC.Models;

namespace MagazadbMVC.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        Magaza1Entities db = new Magaza1Entities();

        public ActionResult Index()
        {
            return View(db.Musteris.ToList());
        }


        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Musteri save)
        {
            try
            {
                using (Magaza1Entities db = new Magaza1Entities())
                {
                    db.Musteris.Add(save);
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
        public ActionResult Duzenle(int musterino)
        {
            using (Magaza1Entities db = new Magaza1Entities())
            {
                return View(db.Musteris.Where(x => x.MusteriNo == musterino).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Duzenle(int musterino, Musteri modify)
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
                return View(db.Musteris.Where(x => x.MusteriNo == id).FirstOrDefault());
            }
        }


        [HttpPost]
        public ActionResult Delete(int id, Musteri sil)
        {
            try
            {
                using (Magaza1Entities db = new Magaza1Entities())
                {
                    sil = db.Musteris.Where(x => x.MusteriNo == id).FirstOrDefault();
                    db.Musteris.Remove(sil);
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