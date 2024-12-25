using ETicaret.Data;
using ETicaret.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// DbContext ve Identity servisini ekleyin. veri tabaný yapýlandýrýlýyor
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity servisi ekleniyor.
//kimlik doðrulama ve yetkilendirme iþlemi için 
builder.Services.AddIdentity<ApplicationUser,ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();//sýfýrlama onay gibi iþlem için gerekli üretir

// Þifre politikalarýný yapýlandýrma
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;//en az 1 rakam
    options.Password.RequireLowercase = true;//en az küçük 1 harf
    options.Password.RequireUppercase = true;//þifrede en az büyük 1 harf
    options.Password.RequiredLength = 6;//þifre en az 6 karakterli
    options.Password.RequireNonAlphanumeric = false;//þifrede özel karakter olma zorunluluðu
});

// Cookie yapýlandýrmasý
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";//Kullanýcý giriþ yapmadýðýnda yönlendirileceði giriþ sayfasý.
    options.LogoutPath = "/Account/Logout";//Kullanýcý çýkýþ yapýldýðýnda yönlendirileceði sayfa.
    options.AccessDeniedPath = "/Account/AccessDenied";//Kullanýcý yetkilendirilmediðinde(örneðin, bir sayfaya eriþmeye çalýþtýðýnda) yönlendirileceði sayfa.
});

// MVC servisini ekleyin mvc çalýþmasýný saðlar
builder.Services.AddControllersWithViews();

//Bu satýr, yapýlandýrma iþlemleri tamamlandýktan sonra uygulamanýn bir örneðini oluþturur.
var app = builder.Build();

// Hata yönetimi ve güvenlik yapýlandýrmasý
//UseExceptionHandler ile hata yönetimi yapýlýr ve kullanýcýya özel bir hata sayfasý gösterilir.
//UseHsts ile HTTP Strict Transport Security (HSTS)
//protokolü aktif edilir, yani HTTPS kullanýmý
//zorunlu hale gelir.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


//Tüm HTTP isteklerini HTTPS'ye yönlendirir.
//Uygulamanýn güvenli baðlantýlar kullanmasýný saðlar.
app.UseHttpsRedirection();

//Statik dosyalarýn (CSS, JavaScript, resimler vb.)
//sunulmasýný saðlar.
app.UseStaticFiles();


app.UseRouting();

app.UseAuthentication(); // Kimlik doðrulama kullanýma alýnýr.
app.UseAuthorization(); // Yetkilendirme kullanýma alýnýr.

// Varsayýlan route yapýlandýrmasý
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();//uygulamayý çalýþtýrýr
