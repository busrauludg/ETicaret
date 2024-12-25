using System;
using System.Collections.Generic;

namespace ETicaret.Models;

public partial class SepetDetaylari
{
    public int SepetDetayId { get; set; }

    public int SepetId { get; set; }

    public int UrunId { get; set; }

    public int Miktar { get; set; }

    public decimal BirimFiyat { get; set; }

    public virtual Sepet Sepet { get; set; } = null!;

    public virtual Urunler Urun { get; set; } = null!;
}
