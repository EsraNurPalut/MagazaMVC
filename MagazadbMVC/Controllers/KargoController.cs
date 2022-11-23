using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagazadbMVC.Models;
namespace MagazadbMVC.Controllers
{
    public class KargoController : Controller
    {
        
       Magaza1Entities db = new Magaza1Entities();

        public ActionResult Index()
        {
            return View(db.Kargoes.ToList());
        }

        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Kargo save)
        {
            try
            {
                using (Magaza1Entities db = new Magaza1Entities())
                {
                    db.Kargoes.Add(save);
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
        public ActionResult Duzenle(int kargono)
        {
            using (Magaza1Entities db = new Magaza1Entities())
            {
                return View(db.Kargoes.Where(x => x.KargoNo == kargono).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult Duzenle(int kargono, Kargo modify)
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
                return View(db.Kargoes.Where(x => x.KargoNo == id).FirstOrDefault());
            }
        }


        [HttpPost]
        public ActionResult Delete(int id, Kargo sil)
        {
            try
            {
                using (Magaza1Entities db = new Magaza1Entities())
                {
                    sil = db.Kargoes.Where(x => x.KargoNo == id).FirstOrDefault();
                    db.Kargoes.Remove(sil);
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