using System;
using System.Collections.Generic;

namespace WebP.Models;

public partial class Randevu
{
    public int Randevuid { get; set; }

    public int Calisanid { get; set; }

    public int Hizmetid { get; set; }

    public DateTime Tarih { get; set; }

    public string? Kullaniciadi { get; set; }

    public string? Durum { get; set; }

    public virtual Hizmet Hizmet { get; set; } = null!;

    public virtual Calisan Calisan { get; set; } = null!;
}
