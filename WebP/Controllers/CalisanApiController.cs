using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebP.Data;
using WebP.Models;

namespace WebP.Controllers
{
    [Route("CalisanApi/[action]/{id?}")]
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
        public async Task<IActionResult> Create([Bind("adsoyad,uzmanlıkalanı,uygunluksaatleri")] Calisan calisan)
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);  // Konsola yazdırabilirsiniz
                }
                return View("~/Views/Home/CalisanApi/Create.cshtml", calisan);
            }

            if (ModelState.IsValid)
            {
                _context.Add(calisan); // Çalışan objesini veritabanına ekle
                await _context.SaveChangesAsync();
                return RedirectToAction("Calisan");  // Listeleme sayfasına yönlendirme
                                                     // Ekleme işleminden sonra listeye yönlendir
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
                return RedirectToAction(nameof(Calisan));  // Listeleme sayfasına yönlendir
            }
            return View(calisan);  // Eğer hata varsa formu tekrar render et
        }

        private bool CalisanExists(int calisanid)
        {
            throw new NotImplementedException();
        }

    }
}