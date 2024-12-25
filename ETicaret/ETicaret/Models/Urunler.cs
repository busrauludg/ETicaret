using System;
using System.Collections.Generic;

namespace ETicaret.Models;

public partial class Urunler
{
    public int UrunId { get; set; }

    public string Ad { get; set; } = null!;

    public string? Aciklama { get; set; }

    public decimal Fiyat { get; set; }

    public int StokMiktari { get; set; }

    public int KategoriId { get; set; }

    public DateTime? EklemeTarihi { get; set; }

    public virtual Kategoriler Kategori { get; set; } = null!;

    public virtual ICollection<SepetDetaylari> SepetDetaylaris { get; set; } = new List<SepetDetaylari>();

    public virtual ICollection<SiparisDetaylari> SiparisDetaylaris { get; set; } = new List<SiparisDetaylari>();

    public virtual ICollection<StokHareketleri> StokHareketleris { get; set; } = new List<StokHareketleri>();

    public virtual ICollection<Yorumlar> Yorumlars { get; set; } = new List<Yorumlar>();
}
