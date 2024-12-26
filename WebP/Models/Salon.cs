using System;
using System.Collections.Generic;

namespace Web_Programlama.Models;

public partial class Salon
{
    public int salonid { get; set; }

    public string salonadı { get; set; } = null!;

    public string? adres { get; set; }

    public string? çalışmasaatleri { get; set; }

    public string? telefon { get; set; }

    public virtual ICollection<Hizmet> Hizmet { get; set; } = new List<Hizmet>();

    public virtual ICollection<Çalışan> Çalışan { get; set; } = new List<Çalışan>();
}
