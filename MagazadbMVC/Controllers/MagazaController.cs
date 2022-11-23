using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagazadbMVC.Models;

namespace MagazadbMVC.Controllers
{
    public class MagazaController : Controller
    {
       
       Magaza1Entities db = new Magaza1Entities();

        public ActionResult Index()
        {
            return View(db.Magazas.ToList());
        }

        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Magaza save)
        {
            try
            {
                using (Magaza1Entities db = new Magaza1Entities())
                {
                    db.Magazas.Add(save);
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
        public ActionResult Duzenle(int magazano)
        {
            using (Magaza1Entities db = new Magaza1Entities())
            {
                return View(db.Magazas.Where(x => x.MagazaNo == magazano).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult Duzenle(int magazano, Magaza modify)
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
                return View(db.Magazas.Where(x => x.MagazaNo == id).FirstOrDefault());
            }
        }


        [HttpPost]
        public ActionResult Delete(int id, Magaza sil)
        {
            try
            {
                using (Magaza1Entities db = new Magaza1Entities())
                {
                    sil = db.Magazas.Where(x => x.MagazaNo == id).FirstOrDefault();
                    db.Magazas.Remove(sil);
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