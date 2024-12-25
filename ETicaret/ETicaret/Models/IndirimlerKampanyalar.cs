using System;
using System.Collections.Generic;

namespace ETicaret.Models;

public partial class IndirimlerKampanyalar
{
    public int IndirimId { get; set; }

    public string IndirimKodu { get; set; } = null!;

    public decimal IndirimYuzdesi { get; set; }

    public DateTime BaslangicTarihi { get; set; }

    public DateTime BitisTarihi { get; set; }

    public decimal? MinSatisTutari { get; set; }

    public bool? Aktif { get; set; }

    public virtual ICollection<IndirimKullanimi> IndirimKullanimis { get; set; } = new List<IndirimKullanimi>();
}
