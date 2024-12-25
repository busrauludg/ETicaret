using System;
using System.Collections.Generic;

namespace ETicaret.Models;

public partial class Raporlar
{
    public int RaporId { get; set; }

    public string RaporTuru { get; set; } = null!;

    public DateTime? RaporTarihi { get; set; }

    public string RaporVerisi { get; set; } = null!;

    public int OlusturanId { get; set; }

    public virtual Kullanicilar Olusturan { get; set; } = null!;
}
