using System;
using System.Collections.Generic;

namespace ETicaret.Models;

public partial class Adresler
{
    public int AdresId { get; set; }

    public int KullaniciId { get; set; }

    public string? Adres { get; set; }

    public string Sehir { get; set; } = null!;

    public string Ilce { get; set; } = null!;

    public string? PostaKodu { get; set; }

    public DateTime? KayitTarihi { get; set; }

    public virtual Kullanicilar Kullanici { get; set; } = null!;
}
