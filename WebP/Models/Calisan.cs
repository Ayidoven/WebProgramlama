using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebP.Models
{
    [Table("Calisan")]
    public partial class Calisan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Calisanid { get; set; } // Çalışan ID'si
        public int salonid { get; set; }   // Salon ID'si (Salonla ilişki)
        public string adsoyad { get; set; } = null!; // Çalışanın adı soyadı
        public string? uzmanlıkalanı { get; set; }  // Çalışanın uzmanlık alanı (isteğe bağlı)
        public string? uygunluksaatleri { get; set; } // Çalışanın uygunluk saatleri (isteğe bağlı)

        // Çalışanın sahip olduğu randevular
        public virtual ICollection<Randevu> Randevu { get; set; } = new List<Randevu>();

        // Çalışanın bağlı olduğu salon
        public virtual Salon? Salon { get; set; } = null!;
    }
}
