using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebP.Data;
using WebP.Models;

namespace WebP.Controllers
{
    // "Home/Index" gibi sayfalarda yönlendirme yapılacak bir controller
    public class CalisanApiController : Controller
    {
        private readonly AppDbContext _context;

        public CalisanApiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Çalışanlar (Listeleme)
        public async Task<IActionResult> Calisan()
        {
            var calisan = await _context.Calisan.ToListAsync();
            return View("~/Views/Home/CalisanApi/Calisan.cshtml", calisan);  // View'da çalışanları listeleyeceğiz
        }

        // GET: Çalışan Ekleme
        public IActionResult Create()
        {
            return View("~/Views/Home/CalisanApi/Create.cshtml");  // Create.cshtml sayfasını döndür
        }

        // POST: Çalışan Ekleme
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Calisanid,AdSoyad,UzmanlikAlani,UygunlukSaatleri")] Calisan calisan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calisan); // Çalışan objesini veritabanına ekle
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Calisan));  // Ekleme işleminden sonra listeye yönlendir
            }
            return View("~/Views/Home/CalisanApi/Create.cshtml", calisan);
        }

        // GET: Çalışan Silme
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calisan = await _context.Calisan
                .FirstOrDefaultAsync(m => m.Calisanid == id);
            if (calisan == null)
            {
                return NotFound();
            }

            return View("~/Views/Home/CalisanApi/Delete.cshtml", calisan);
        }

        // POST: Çalışan Silme
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calisan = await _context.Calisan.FindAsync(id);
            _context.Calisan.Remove(calisan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Calisan));
        }

        // GET: Çalışan Güncelleme
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();  // Eğer ID yoksa hata döndür
            }

            var calisan = await _context.Calisan.FindAsync(id);
            if (calisan == null)
            {
                return NotFound();  // Çalışan bulunamazsa hata döndür
            }
            return View("~/Views/Home/CalisanApi/Edit.cshtml", calisan);  // Çalışanın bilgilerini güncelleme formuna gönder
        }

        // POST: Çalışan Güncelleme
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Calisanid,AdSoyad,UzmanlikAlani,UygunlukSaatleri")] Calisan calisan)
        {
            if (id != calisan.Calisanid)
            {
                return NotFound();  // ID uyumsuzsa hata döndür
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calisan);  // Çalışanı güncelle
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalisanExists(calisan.Calisanid))  // Çalışan yoksa hata döndür
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Calisan));  // Güncelleme işleminden sonra listeye yönlendir
            }
            return View("~/Views/Home/CalisanApi/Edit.cshtml", calisan);  // Formda hata varsa tekrar formu render et
        }

        private bool CalisanExists(int id)
        {
            return _context.Calisan.Any(e => e.Calisanid == id);  // Çalışan var mı kontrol et
        }
    }
}
