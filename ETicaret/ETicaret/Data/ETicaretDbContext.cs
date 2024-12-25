using System;
using System.Collections.Generic;
using ETicaret.Models;
using Microsoft.EntityFrameworkCore;

namespace ETicaret.Data;

public partial class ETicaretDbContext : DbContext
{
    public ETicaretDbContext()
    {
    }

    public ETicaretDbContext(DbContextOptions<ETicaretDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adresler> Adreslers { get; set; }

    public virtual DbSet<GeriBildirimler> GeriBildirimlers { get; set; }

    public virtual DbSet<IndirimKullanimi> IndirimKullanimis { get; set; }

    public virtual DbSet<IndirimlerKampanyalar> IndirimlerKampanyalars { get; set; }

    public virtual DbSet<KargoDurumuDegisiklikleri> KargoDurumuDegisiklikleris { get; set; }

    public virtual DbSet<KargoFirmalari> KargoFirmalaris { get; set; }

    public virtual DbSet<Kategoriler> Kategorilers { get; set; }

    public virtual DbSet<Kullanicilar> Kullanicilars { get; set; }

    public virtual DbSet<OdemeYontemleri> OdemeYontemleris { get; set; }

    public virtual DbSet<Raporlar> Raporlars { get; set; }

    public virtual DbSet<Sepet> Sepets { get; set; }

    public virtual DbSet<SepetDetaylari> SepetDetaylaris { get; set; }

    public virtual DbSet<SiparisDetaylari> SiparisDetaylaris { get; set; }

    public virtual DbSet<SiparisKargo> SiparisKargos { get; set; }

    public virtual DbSet<Siparisler> Siparislers { get; set; }

    public virtual DbSet<StokHareketleri> StokHareketleris { get; set; }

    public virtual DbSet<Urunler> Urunlers { get; set; }

    public virtual DbSet<Yorumlar> Yorumlars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Büşra\\Desktop\\Projee\\ETicaret\\ETicaret\\ETicaret\\Data\\ETicaret.mdf;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Turkish_CI_AS");

        modelBuilder.Entity<Adresler>(entity =>
        {
            entity.HasKey(e => e.AdresId).HasName("PK__Adresler__DA8DEA8C423DCD65");

            entity.ToTable("Adresler");

            entity.Property(e => e.Adres)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Ilce)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.KayitTarihi)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PostaKodu)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Sehir)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Kullanici).WithMany(p => p.Adreslers)
                .HasForeignKey(d => d.KullaniciId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Adresler__Kullan__75A278F5");
        });

        modelBuilder.Entity<GeriBildirimler>(entity =>
        {
            entity.HasKey(e => e.GeriBildirimId).HasName("PK__GeriBild__F72676AF48797ABD");

            entity.ToTable("GeriBildirimler");

            entity.Property(e => e.Cevap).HasColumnType("text");
            entity.Property(e => e.CevapTarihi).HasColumnType("datetime");
            entity.Property(e => e.Durum)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Konu)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Mesaj).HasColumnType("text");
            entity.Property(e => e.Tarih)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.GeriBildirimlers)
                .HasForeignKey(d => d.KullaniciId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GeriBildi__Kulla__05D8E0BE");

            entity.HasOne(d => d.Siparis).WithMany(p => p.GeriBildirimlers)
                .HasForeignKey(d => d.SiparisId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GeriBildi__Sipar__04E4BC85");
        });

        modelBuilder.Entity<IndirimKullanimi>(entity =>
        {
            entity.HasKey(e => e.KullanimId).HasName("PK__IndirimK__8B703BF6D1295108");

            entity.ToTable("IndirimKullanimi");

            entity.Property(e => e.KullanimTarihi)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Indirim).WithMany(p => p.IndirimKullanimis)
                .HasForeignKey(d => d.IndirimId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__IndirimKu__Indir__5CD6CB2B");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.IndirimKullanimis)
                .HasForeignKey(d => d.KullaniciId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__IndirimKu__Kulla__5BE2A6F2");

            entity.HasOne(d => d.Siparis).WithMany(p => p.IndirimKullanimis)
                .HasForeignKey(d => d.SiparisId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__IndirimKu__Sipar__5DCAEF64");
        });

        modelBuilder.Entity<IndirimlerKampanyalar>(entity =>
        {
            entity.HasKey(e => e.IndirimId).HasName("PK__Indiriml__A9F5A19BC4E7F25D");

            entity.ToTable("IndirimlerKampanyalar");

            entity.HasIndex(e => e.IndirimKodu, "UQ__Indiriml__6C363BA19D6B4E51").IsUnique();

            entity.Property(e => e.Aktif).HasDefaultValue(true);
            entity.Property(e => e.BaslangicTarihi).HasColumnType("datetime");
            entity.Property(e => e.BitisTarihi).HasColumnType("datetime");
            entity.Property(e => e.IndirimKodu)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IndirimYuzdesi).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.MinSatisTutari).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<KargoDurumuDegisiklikleri>(entity =>
        {
            entity.HasKey(e => e.DegisiklikId).HasName("PK__KargoDur__EC3655C2BCADC550");

            entity.ToTable("KargoDurumuDegisiklikleri");

            entity.Property(e => e.DegisiklikTarihi)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.KargoDurumu)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Siparis).WithMany(p => p.KargoDurumuDegisiklikleris)
                .HasForeignKey(d => d.SiparisId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__KargoDuru__Sipar__00200768");
        });

        modelBuilder.Entity<KargoFirmalari>(entity =>
        {
            entity.HasKey(e => e.KargoFirmaId).HasName("PK__KargoFir__E559C5410F9C269C");

            entity.ToTable("KargoFirmalari");

            entity.Property(e => e.FirmaAdi)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefon)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.WebSite)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Kategoriler>(entity =>
        {
            entity.HasKey(e => e.KategoriId).HasName("PK__Kategori__1782CC72439880CE");

            entity.ToTable("Kategoriler");

            entity.Property(e => e.Aciklama).HasColumnType("text");
            entity.Property(e => e.KategoriAdi)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Kullanicilar>(entity =>
        {
            entity.HasKey(e => e.KullaniciId).HasName("PK__Kullanic__E011F77BFEC798ED");

            entity.ToTable("Kullanicilar");

            entity.HasIndex(e => e.Email, "UQ__Kullanic__A9D10534EB6428C8").IsUnique();

            entity.Property(e => e.Ad)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.KayitTarihi)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SifreHash)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Soyad)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OdemeYontemleri>(entity =>
        {
            entity.HasKey(e => e.OdemeYontemiId).HasName("PK__OdemeYon__6AA8E53379379261");

            entity.ToTable("OdemeYontemleri");

            entity.Property(e => e.Cvv).HasColumnName("CVV");
            entity.Property(e => e.KartNumarasi)
                .HasMaxLength(19)
                .IsUnicode(false);
            entity.Property(e => e.KartTuru)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Kullanici).WithMany(p => p.OdemeYontemleris)
                .HasForeignKey(d => d.KullaniciId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OdemeYont__Kulla__60A75C0F");
        });

        modelBuilder.Entity<Raporlar>(entity =>
        {
            entity.HasKey(e => e.RaporId).HasName("PK__Raporlar__CFBFE48DB1438ECD");

            entity.ToTable("Raporlar");

            entity.Property(e => e.RaporTarihi)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.RaporTuru)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RaporVerisi).HasColumnType("text");

            entity.HasOne(d => d.Olusturan).WithMany(p => p.Raporlars)
                .HasForeignKey(d => d.OlusturanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Raporlar__Olustu__71D1E811");
        });

        modelBuilder.Entity<Sepet>(entity =>
        {
            entity.HasKey(e => e.SepetId).HasName("PK__Sepet__97CA09F3E67F93BE");

            entity.ToTable("Sepet");

            entity.Property(e => e.OlusturmaTarihi)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.Sepets)
                .HasForeignKey(d => d.KullaniciId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sepet__Kullanici__656C112C");
        });

        modelBuilder.Entity<SepetDetaylari>(entity =>
        {
            entity.HasKey(e => e.SepetDetayId).HasName("PK__SepetDet__1DBF796A43BCD548");

            entity.ToTable("SepetDetaylari");

            entity.Property(e => e.BirimFiyat).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Sepet).WithMany(p => p.SepetDetaylaris)
                .HasForeignKey(d => d.SepetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SepetDeta__Sepet__68487DD7");

            entity.HasOne(d => d.Urun).WithMany(p => p.SepetDetaylaris)
                .HasForeignKey(d => d.UrunId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SepetDeta__UrunI__693CA210");
        });

        modelBuilder.Entity<SiparisDetaylari>(entity =>
        {
            entity.HasKey(e => e.SiparisDetayId).HasName("PK__SiparisD__DA4BDFD2CBF0500B");

            entity.ToTable("SiparisDetaylari");

            entity.Property(e => e.BirimFiyat).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Siparis).WithMany(p => p.SiparisDetaylaris)
                .HasForeignKey(d => d.SiparisId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SiparisDe__Sipar__5165187F");

            entity.HasOne(d => d.Urun).WithMany(p => p.SiparisDetaylaris)
                .HasForeignKey(d => d.UrunId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SiparisDe__UrunI__52593CB8");
        });

        modelBuilder.Entity<SiparisKargo>(entity =>
        {
            entity.HasKey(e => e.SiparisId).HasName("PK__SiparisK__C3F03BFD444F398C");

            entity.ToTable("SiparisKargo");

            entity.Property(e => e.SiparisId).ValueGeneratedNever();
            entity.Property(e => e.KargoDurumu)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.KargoTeslimTarihi).HasColumnType("datetime");
            entity.Property(e => e.TakipNumarasi)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.KargoFirma).WithMany(p => p.SiparisKargos)
                .HasForeignKey(d => d.KargoFirmaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SiparisKa__Kargo__7C4F7684");

            entity.HasOne(d => d.Siparis).WithOne(p => p.SiparisKargo)
                .HasForeignKey<SiparisKargo>(d => d.SiparisId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SiparisKa__Sipar__7B5B524B");
        });

        modelBuilder.Entity<Siparisler>(entity =>
        {
            entity.HasKey(e => e.SiparisId).HasName("PK__Siparisl__C3F03BFD6B0EF4DA");

            entity.ToTable("Siparisler");

            entity.Property(e => e.SiparisDurumu)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SiparisTarihi)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TeslimatAdresi)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ToplamTutar).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.Siparislers)
                .HasForeignKey(d => d.KullaniciId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Siparisle__Kulla__4E88ABD4");
        });

        modelBuilder.Entity<StokHareketleri>(entity =>
        {
            entity.HasKey(e => e.StokHareketId).HasName("PK__StokHare__8F9B28E0A70C5832");

            entity.ToTable("StokHareketleri");

            entity.Property(e => e.Fiyat).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.HareketTipi)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Tarih)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Urun).WithMany(p => p.StokHareketleris)
                .HasForeignKey(d => d.UrunId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StokHarek__UrunI__6E01572D");
        });

        modelBuilder.Entity<Urunler>(entity =>
        {
            entity.HasKey(e => e.UrunId).HasName("PK__Urunler__623D366B96FF8B5C");

            entity.ToTable("Urunler");

            entity.Property(e => e.Aciklama).HasColumnType("text");
            entity.Property(e => e.Ad)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EklemeTarihi)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Fiyat).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Kategori).WithMany(p => p.Urunlers)
                .HasForeignKey(d => d.KategoriId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Urunler__Kategor__48CFD27E");
        });

        modelBuilder.Entity<Yorumlar>(entity =>
        {
            entity.HasKey(e => e.YorumId).HasName("PK__Yorumlar__F2BE14E8F20C8F26");

            entity.ToTable("Yorumlar");

            entity.Property(e => e.YorumMetni).HasColumnType("text");
            entity.Property(e => e.YorumTarihi)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.Yorumlars)
                .HasForeignKey(d => d.KullaniciId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Yorumlar__Kullan__5812160E");

            entity.HasOne(d => d.Urun).WithMany(p => p.Yorumlars)
                .HasForeignKey(d => d.UrunId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Yorumlar__UrunId__571DF1D5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
