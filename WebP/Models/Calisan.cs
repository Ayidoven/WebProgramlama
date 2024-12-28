using System;
using System.Collections.Generic;

namespace WebP.Models
{
    public partial class Calisan
    {
        public int Calisanid { get; set; } // Çalışan ID'si
        public int salonid { get; set; }   // Salon ID'si (Salonla ilişki)
        public string adsoyad { get; set; } = null!; // Çalışanın adı soyadı
        public string? uzmanlıkalanı { get; set; }  // Çalışanın uzmanlık alanı (isteğe bağlı)
        public string? uygunluksaatleri { get; set; } // Çalışanın uygunluk saatleri (isteğe bağlı)

        // Çalışanın sahip olduğu randevular
        public virtual ICollection<Randevu> Randevu { get; set; } = new List<Randevu>();

        // Çalışanın bağlı olduğu salon
        public virtual Salon Salon { get; set; } = null!;
    }
}
