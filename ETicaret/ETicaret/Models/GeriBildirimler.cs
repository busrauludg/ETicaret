using System;
using System.Collections.Generic;

namespace ETicaret.Models;

public partial class GeriBildirimler
{
    public int GeriBildirimId { get; set; }

    public int SiparisId { get; set; }

    public int KullaniciId { get; set; }

    public string Konu { get; set; } = null!;

    public string Mesaj { get; set; } = null!;

    public string? Cevap { get; set; }

    public DateTime? CevapTarihi { get; set; }

    public string Durum { get; set; } = null!;

    public DateTime? Tarih { get; set; }

    public virtual Kullanicilar Kullanici { get; set; } = null!;

    public virtual Siparisler Siparis { get; set; } = null!;
}
