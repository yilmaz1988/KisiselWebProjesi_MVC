using KisiselWebProjesi_MVC.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KisiselWebProjesi_MVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var deger = c.Anasayfas.ToList();
            return View(deger);
        }
        public ActionResult AnasayfaGetir(int id)
        {
            var getir = c.Anasayfas.Find(id);
            return View("AnasayfaGetir", getir);
        }
        public ActionResult AnasayfaGuncelle(Anasayfa x)
        {
            var anasayfa = c.Anasayfas.Find(x.id);
            anasayfa.isim = x.isim;
            anasayfa.profil = x.profil;
            anasayfa.unvan = x.unvan;
            anasayfa.aciklama = x.aciklama;
            anasayfa.iletisim = x.iletisim;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ikonListesi()
        {
            var deger = c.ikonlars.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniIkon()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniIkon(ikonlar p)
        {
            c.ikonlars.Add(p);
            c.SaveChanges();
            return RedirectToAction("ikonListesi");
        }
        public ActionResult ikonGetir(int id)
        {
            var ikon = c.ikonlars.Find(id);
            return View("ikonGetir", ikon);
        }
        public ActionResult ikonGuncelle(ikonlar x)
        {
            var ikon = c.ikonlars.Find(x.id);
            ikon.ikon = x.ikon;
            ikon.link = x.link;
            c.SaveChanges();
            return RedirectToAction("ikonListesi");
        }
        public ActionResult ikonSil(int id)
        {
            var sil = c.ikonlars.Find(id);
            c.ikonlars.Remove(sil);
            c.SaveChanges();
            return RedirectToAction("ikonListesi");
        }
    }
}
