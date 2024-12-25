using System;
using System.Collections.Generic;

namespace ETicaret.Models;

public partial class KargoDurumuDegisiklikleri
{
    public int DegisiklikId { get; set; }

    public int SiparisId { get; set; }

    public string KargoDurumu { get; set; } = null!;

    public DateTime? DegisiklikTarihi { get; set; }

    public virtual Siparisler Siparis { get; set; } = null!;
}
