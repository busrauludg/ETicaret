using System;
using System.Collections.Generic;

namespace ETicaret.Models;

public partial class StokHareketleri
{
    public int StokHareketId { get; set; }

    public int UrunId { get; set; }

    public string HareketTipi { get; set; } = null!;

    public int Miktar { get; set; }

    public decimal Fiyat { get; set; }

    public DateTime? Tarih { get; set; }

    public virtual Urunler Urun { get; set; } = null!;
}
