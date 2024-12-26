using System;
using System.Collections.Generic;

namespace Web_Programlama.Models;

public partial class Çalışan
{
    public int Çalışanid { get; set; }

    public int salonid { get; set; }

    public string adsoyad { get; set; } = null!;

    public string? uzmanlıkalanı { get; set; }

    public string? uygunluksaatleri { get; set; }

    public virtual ICollection<Randevu> Randevu { get; set; } = new List<Randevu>();

    public virtual Salon Salon { get; set; } = null!;
}
