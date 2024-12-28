using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var calisan = await _context.Calisan
                .Include(c => c.Salon)  // Salon bilgisini de dahil ediyoruz
                .ToListAsync();
            return View("~/Views/Home/CalisanApi/Calisan.cshtml", calisan);  // View'da çalışanları listeleyeceğiz
        }

        public IActionResult Create()
        {
            // Salon listesini dropdown için SelectList olarak ayarla
            ViewBag.Salons = new SelectList(_context.Salon, "salonid", "salonadı");
            return View("~/Views/Home/CalisanApi/Create.cshtml");
        }


        // POST: Çalışan Ekleme
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("salonid,adsoyad,uzmanlıkalanı,uygunluksaatleri")] Calisan calisan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var yeniCalisan = new Calisan
                    {
                        adsoyad = calisan.adsoyad,
                        salonid = calisan.salonid,
                        uzmanlıkalanı = calisan.uzmanlıkalanı,
                        uygunluksaatleri = calisan.uygunluksaatleri
                    };

                    // Yeni çalışanı veritabanına ekle
                    _context.Calisan.Add(yeniCalisan);
                    await _context.SaveChangesAsync();

                    // Başarıyla işlem tamamlandıysa yönlendirme yap
                    return RedirectToAction("Calisan");
                }

                // Model geçerli değilse, salonlar listesi yeniden oluşturulup view'a dönülür
                ViewBag.salon = new SelectList(_context.Salon, "salonid", "salonadı", calisan.salonid);
                return View("~/Views/Home/CalisanApi/Create.cshtml", calisan);
            }
            catch (Exception ex)
            {
                // Hata meydana gelirse, hatayı loglar ve kullanıcıya uygun bir mesaj gösterir
                // Örneğin, bir log sistemi ile hata kaydedebilirsiniz.
                // Loglama işlemi örneği (yazılımınıza uygun şekilde kullanabilirsiniz)


                // Hata mesajı eklenir ve kullanıcıya bildirilir
                ModelState.AddModelError(string.Empty, "Bir hata oluştu. Lütfen tekrar deneyin.");

                // View'a geri dönülür ve kullanıcıya hata mesajı gösterilir
                ViewBag.salon = new SelectList(_context.Salon, "salonid", "salonadı", calisan.salonid);
                return View("~/Views/Home/CalisanApi/Create.cshtml", calisan);
            }
        }

        // GET: Çalışan Silme
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calisan = await _context.Calisan
                .Include(c => c.Salon)  // Salon bilgisini dahil et
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
                return NotFound();
            }

            var calisan = await _context.Calisan
                .Include(c => c.Salon)  // Salon bilgisini dahil et
                .FirstOrDefaultAsync(m => m.Calisanid == id);
            if (calisan == null)
            {
                return NotFound();
            }

            ViewBag.Salons = new SelectList(_context.Salon, "salonid", "salonadı", calisan.salonid);  // Salon seçimini yapabilmek için
            return View("~/Views/Home/CalisanApi/Edit.cshtml", calisan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Calisanid,salonid,adsoyad,uzmanlıkalanı,uygunluksaatleri")] Calisan calisan)
        {
            if (id != calisan.Calisanid)
            {
                return NotFound();
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
            return View(calisan);
        }

        private bool CalisanExists(int calisanid)
        {
            return _context.Calisan.Any(e => e.Calisanid == calisanid);
        }
    }
}