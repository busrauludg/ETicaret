using System;
using System.Collections.Generic;

namespace ETicaret.Models;

public partial class Yorumlar
{
    public int YorumId { get; set; }

    public int UrunId { get; set; }

    public int KullaniciId { get; set; }

    public int Puan { get; set; }

    public string YorumMetni { get; set; } = null!;

    public DateTime? YorumTarihi { get; set; }

    public virtual Kullanicilar Kullanici { get; set; } = null!;

    public virtual Urunler Urun { get; set; } = null!;
}
