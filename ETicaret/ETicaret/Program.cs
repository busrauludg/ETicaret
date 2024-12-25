using ETicaret.Data;
using ETicaret.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// DbContext ve Identity servisini ekleyin. veri taban� yap�land�r�l�yor
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity servisi ekleniyor.
//kimlik do�rulama ve yetkilendirme i�lemi i�in 
builder.Services.AddIdentity<ApplicationUser,ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();//s�f�rlama onay gibi i�lem i�in gerekli �retir

// �ifre politikalar�n� yap�land�rma
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;//en az 1 rakam
    options.Password.RequireLowercase = true;//en az k���k 1 harf
    options.Password.RequireUppercase = true;//�ifrede en az b�y�k 1 harf
    options.Password.RequiredLength = 6;//�ifre en az 6 karakterli
    options.Password.RequireNonAlphanumeric = false;//�ifrede �zel karakter olma zorunlulu�u
});

// Cookie yap�land�rmas�
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";//Kullan�c� giri� yapmad���nda y�nlendirilece�i giri� sayfas�.
    options.LogoutPath = "/Account/Logout";//Kullan�c� ��k�� yap�ld���nda y�nlendirilece�i sayfa.
    options.AccessDeniedPath = "/Account/AccessDenied";//Kullan�c� yetkilendirilmedi�inde(�rne�in, bir sayfaya eri�meye �al��t���nda) y�nlendirilece�i sayfa.
});

// MVC servisini ekleyin mvc �al��mas�n� sa�lar
builder.Services.AddControllersWithViews();

//Bu sat�r, yap�land�rma i�lemleri tamamland�ktan sonra uygulaman�n bir �rne�ini olu�turur.
var app = builder.Build();

// Hata y�netimi ve g�venlik yap�land�rmas�
//UseExceptionHandler ile hata y�netimi yap�l�r ve kullan�c�ya �zel bir hata sayfas� g�sterilir.
//UseHsts ile HTTP Strict Transport Security (HSTS)
//protokol� aktif edilir, yani HTTPS kullan�m�
//zorunlu hale gelir.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


//T�m HTTP isteklerini HTTPS'ye y�nlendirir.
//Uygulaman�n g�venli ba�lant�lar kullanmas�n� sa�lar.
app.UseHttpsRedirection();

//Statik dosyalar�n (CSS, JavaScript, resimler vb.)
//sunulmas�n� sa�lar.
app.UseStaticFiles();


app.UseRouting();

app.UseAuthentication(); // Kimlik do�rulama kullan�ma al�n�r.
app.UseAuthorization(); // Yetkilendirme kullan�ma al�n�r.

// Varsay�lan route yap�land�rmas�
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();//uygulamay� �al��t�r�r
