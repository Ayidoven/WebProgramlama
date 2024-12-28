using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebP.Data;
using WebP.Models;

namespace WebP.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly AppDbContext _context;

        public KullaniciController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Kullanıcı Kayıt Sayfası
        public IActionResult Kayıt()
        {
            return View();
        }

        // POST: Kullanıcı Kayıt İşlemi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Kayıt([Bind("AdSoyad,Email,Sifre")] Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kullanici); // Kullanıcı verisini veritabanına ekle
                _context.SaveChanges(); // Değişiklikleri kaydet
                return RedirectToAction("Başarılı"); // Başarı sayfasına yönlendir
            }

            return View(kullanici); // Formda hata varsa tekrar formu göster
        }

        // Kayıt Başarılı Sayfası
        public IActionResult Başarılı()
        {
            return View("~/Views/Home/Index.cshtml");
        }
    }
}
