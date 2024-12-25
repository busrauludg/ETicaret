using System;
using System.Collections.Generic;

namespace ETicaret.Models;

public partial class KargoFirmalari
{
    public int KargoFirmaId { get; set; }

    public string FirmaAdi { get; set; } = null!;

    public string? Telefon { get; set; }

    public string? WebSite { get; set; }

    public virtual ICollection<SiparisKargo> SiparisKargos { get; set; } = new List<SiparisKargo>();
}
