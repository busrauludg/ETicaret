using System;
using System.Collections.Generic;

namespace ETicaret.Models;

public partial class Siparisler
{
    public int SiparisId { get; set; }

    public int KullaniciId { get; set; }

    public DateTime? SiparisTarihi { get; set; }

    public decimal ToplamTutar { get; set; }

    public string SiparisDurumu { get; set; } = null!;

    public string? TeslimatAdresi { get; set; }

    public virtual ICollection<GeriBildirimler> GeriBildirimlers { get; set; } = new List<GeriBildirimler>();

    public virtual ICollection<IndirimKullanimi> IndirimKullanimis { get; set; } = new List<IndirimKullanimi>();

    public virtual ICollection<KargoDurumuDegisiklikleri> KargoDurumuDegisiklikleris { get; set; } = new List<KargoDurumuDegisiklikleri>();

    public virtual Kullanicilar Kullanici { get; set; } = null!;

    public virtual ICollection<SiparisDetaylari> SiparisDetaylaris { get; set; } = new List<SiparisDetaylari>();

    public virtual SiparisKargo? SiparisKargo { get; set; }
}
