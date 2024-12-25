using System;
using System.Collections.Generic;

namespace ETicaret.Models;

public partial class SiparisKargo
{
    public int SiparisId { get; set; }

    public int KargoFirmaId { get; set; }

    public string TakipNumarasi { get; set; } = null!;

    public string KargoDurumu { get; set; } = null!;

    public DateTime? KargoTeslimTarihi { get; set; }

    public virtual KargoFirmalari KargoFirma { get; set; } = null!;

    public virtual Siparisler Siparis { get; set; } = null!;
}
