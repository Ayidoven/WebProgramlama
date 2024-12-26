using System;
using System.Collections.Generic;

namespace Web_Programlama.Models;

public partial class Hizmet
{
    public int Hizmetid { get; set; }

    public int Salonid { get; set; }

    public string Hizmetadı { get; set; } = null!;

    public int Süre { get; set; }

    public decimal Ücret { get; set; }

    public virtual ICollection<Randevu> Randevu { get; set; } = new List<Randevu>();

    public virtual Salon Salon { get; set; } = null!;
}
