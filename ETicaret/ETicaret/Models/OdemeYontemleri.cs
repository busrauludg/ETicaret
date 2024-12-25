using System;
using System.Collections.Generic;

namespace ETicaret.Models;

public partial class OdemeYontemleri
{
    public int OdemeYontemiId { get; set; }

    public int KullaniciId { get; set; }

    public string KartTuru { get; set; } = null!;

    public string KartNumarasi { get; set; } = null!;

    public DateOnly SonKullanmaTarihi { get; set; }

    public int Cvv { get; set; }

    public virtual Kullanicilar Kullanici { get; set; } = null!;
}
