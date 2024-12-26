using System;
using System.Collections.Generic;

namespace Web_Programlama.Models;

public partial class Randevu
{
    public int Randevuid { get; set; }

    public int Çalışanid { get; set; }

    public int Hizmetid { get; set; }

    public DateTime Tarih { get; set; }

    public string? Kullanıcıadı { get; set; }

    public string? Durum { get; set; }

    public virtual Hizmet Hizmet { get; set; } = null!;

    public virtual Çalışan Çalışan { get; set; } = null!;
}
