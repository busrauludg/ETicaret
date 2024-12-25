using System;
using System.Collections.Generic;

namespace ETicaret.Models;

public partial class IndirimKullanimi
{
    public int KullanimId { get; set; }

    public int KullaniciId { get; set; }

    public int IndirimId { get; set; }

    public int SiparisId { get; set; }

    public DateTime? KullanimTarihi { get; set; }

    public virtual IndirimlerKampanyalar Indirim { get; set; } = null!;

    public virtual Kullanicilar Kullanici { get; set; } = null!;

    public virtual Siparisler Siparis { get; set; } = null!;
}
