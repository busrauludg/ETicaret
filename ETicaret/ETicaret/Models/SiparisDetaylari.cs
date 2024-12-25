using System;
using System.Collections.Generic;

namespace ETicaret.Models;

public partial class SiparisDetaylari
{
    public int SiparisDetayId { get; set; }

    public int SiparisId { get; set; }

    public int UrunId { get; set; }

    public int Miktar { get; set; }

    public decimal BirimFiyat { get; set; }

    public virtual Siparisler Siparis { get; set; } = null!;

    public virtual Urunler Urun { get; set; } = null!;
}
