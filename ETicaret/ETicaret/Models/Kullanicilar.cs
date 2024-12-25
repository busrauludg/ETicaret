using System;
using System.Collections.Generic;

namespace ETicaret.Models;

public partial class Kullanicilar
{
    public int KullaniciId { get; set; }

    public string? Ad { get; set; }

    public string? Soyad { get; set; }

    public string Email { get; set; } = null!;

    public string SifreHash { get; set; } = null!;

    public DateOnly? DogumTarihi { get; set; }

    public DateTime? KayitTarihi { get; set; }

    public int? RolId { get; set; }

    public virtual ICollection<Adresler> Adreslers { get; set; } = new List<Adresler>();

    public virtual ICollection<GeriBildirimler> GeriBildirimlers { get; set; } = new List<GeriBildirimler>();

    public virtual ICollection<IndirimKullanimi> IndirimKullanimis { get; set; } = new List<IndirimKullanimi>();

    public virtual ICollection<OdemeYontemleri> OdemeYontemleris { get; set; } = new List<OdemeYontemleri>();

    public virtual ICollection<Raporlar> Raporlars { get; set; } = new List<Raporlar>();

    public virtual ICollection<Sepet> Sepets { get; set; } = new List<Sepet>();

    public virtual ICollection<Siparisler> Siparislers { get; set; } = new List<Siparisler>();

    public virtual ICollection<Yorumlar> Yorumlars { get; set; } = new List<Yorumlar>();
}
