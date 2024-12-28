using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebP.Models
{
    [Table("Salon")]
    public partial class Salon
    {
        public int salonid { get; set; }  // Salon ID'si
        public string salonadı { get; set; } = null!;  // Salon adı
        public string? adres { get; set; } // Salonun adresi (isteğe bağlı)
        public string? Çalışmasaatleri { get; set; } // Salonun çalışma saatleri (isteğe bağlı)
        public string? telefon { get; set; } // Salonun telefonu (isteğe bağlı)

        // Salona ait hizmetler
        public virtual ICollection<Hizmet> Hizmet { get; set; } = new List<Hizmet>();

        // Salona ait çalışanlar
        public virtual ICollection<Calisan> Calisan { get; set; } = new List<Calisan>();
    }
}
