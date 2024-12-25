using System;
using System.Collections.Generic;

namespace ETicaret.Models;

public partial class Sepet
{
    public int SepetId { get; set; }

    public int KullaniciId { get; set; }

    public DateTime? OlusturmaTarihi { get; set; }

    public virtual Kullanicilar Kullanici { get; set; } = null!;

    public virtual ICollection<SepetDetaylari> SepetDetaylaris { get; set; } = new List<SepetDetaylari>();
}
