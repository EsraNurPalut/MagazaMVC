using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagazadbMVC.Models;

namespace MagazadbMVC.Controllers
{
    public class PersonelController : Controller
    {
      
       Magaza1Entities db = new Magaza1Entities();

        public ActionResult Index()
        {
            return View(db.Personellers.ToList());
        }

        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Personeller save)
        {
            try
            {
                using (Magaza1Entities db = new Magaza1Entities())
                {
                    db.Personellers.Add(save);
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
        public ActionResult Duzenle(int personelno)
        {
            using (Magaza1Entities db = new Magaza1Entities())
            {
                return View(db.Personellers.Where(x => x.PersonelNo == personelno).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult Duzenle(int personelno, Personeller modify)
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
                return View(db.Personellers.Where(x => x.PersonelNo == id).FirstOrDefault());
            }
        }


        [HttpPost]
        public ActionResult Delete(int id, Personeller sil)
        {
            try
            {
                using (Magaza1Entities db = new Magaza1Entities())
                {
                    sil = db.Personellers.Where(x => x.PersonelNo == id).FirstOrDefault();
                    db.Personellers.Remove(sil);
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