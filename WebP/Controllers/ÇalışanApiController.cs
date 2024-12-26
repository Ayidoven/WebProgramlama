using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Programlama.Data;
using Web_Programlama.Models;

namespace Web_Programlama.Controllers
{
    // "Home/Index" gibi sayfalarda yönlendirme yapılacak bir controller
    public class ÇalışanApiController : Controller
    {
        private readonly AppDbContext _context;

        public ÇalışanApiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Çalışanlar (Listeleme)
        public async Task<IActionResult> Çalışan()
        {
            var çalışan = await _context.Çalışan.ToListAsync();
            return View("~/Views/Home/ÇalışanApi/Çalışan.cshtml",çalışan);  // View'da çalışanları listeleyeceğiz
        }

        // GET: Çalışan Ekleme
        public IActionResult Create()
        {
            return View("~/Views/Home/ÇalışanApi/Create.cshtml");  // Create.cshtml sayfasını döndür
        }

        // POST: Çalışan Ekleme
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id","AdSoyad,UzmanlıkAlanı,UygunlukSaatleri")] Çalışan çalışan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(çalışan); // Çalışan objesini veritabanına ekle
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Çalışan));  // Ekleme işleminden sonra listeye yönlendir
            }
            return View("~/Views/Home/ÇalışanApi/Create.cshtml", çalışan);  
        }

       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();  
            }

            var çalışan = await _context.Çalışan
                .FirstOrDefaultAsync(m => m.Çalışanid == id); 
            if (çalışan == null)
            {
                return NotFound(); 
            }

            return View("~/Views/Home/ÇalışanApi/Delete.cshtml", çalışan);  
        }

        // POST: Çalışan Silme
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var çalışan = await _context.Çalışan.FindAsync(id);
            _context.Çalışan.Remove(çalışan);  
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Çalışan));  
        }

        // GET: Çalışan Güncelleme
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();  // Eğer ID yoksa hata döndür
            }

            var çalışan = await _context.Çalışan.FindAsync(id);
            if (çalışan == null)
            {
                return NotFound();  // Çalışan bulunamazsa hata döndür
            }
            return View("~/Views/Home/ÇalışanApi/Edit.cshtml", çalışan);  // Çalışanın bilgilerini güncelleme formuna gönder
        }

        // POST: Çalışan Güncelleme
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ÇalışanId,AdSoyad,UzmanlıkAlanı,UygunlukSaatleri")] Çalışan çalışan)
        {
            if (id != çalışan.Çalışanid)
            {
                return NotFound();  // ID uyumsuzsa hata döndür
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(çalışan);  // Çalışanı güncelle
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ÇalışanExists(çalışan.Çalışanid))  // Çalışan yoksa hata döndür
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Çalışan));  // Güncelleme işleminden sonra listeye yönlendir
            }
            return View("~/Views/Home/ÇalışanApi/Edit.cshtml", çalışan);  // Formda hata varsa tekrar formu render et
        }

        private bool ÇalışanExists(int id)
        {
            return _context.Çalışan.Any(e => e.Çalışanid == id);  // Çalışan var mı kontrol et
        }
    }
}
