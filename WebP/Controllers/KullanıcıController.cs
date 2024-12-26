using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebP.Data;
using WebP.Models;

namespace WebP.Controllers
{
    public class KullanıcıController : Controller
    {
        private readonly AppDbContext _context;

        public KullanıcıController(AppDbContext context)
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
        public IActionResult Kayıt([Bind("AdSoyad,Email,Sifre")] Kullanıcı kullanıcı)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kullanıcı); // Kullanıcı verisini veritabanına ekle
                _context.SaveChanges(); // Değişiklikleri kaydet
                return RedirectToAction("Success"); // Başarı sayfasına yönlendir
            }

            return View(kullanıcı); // Formda hata varsa tekrar formu göster
        }

        // Kayıt Başarılı Sayfası
        public IActionResult Başarılı()
        {
            return View();
        }
    }
}
