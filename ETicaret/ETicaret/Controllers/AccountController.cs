using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using ETicaret.Models;

namespace ETicaret.Controllers
{
    //githuba yüklendii
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        // AddErrors metodunu tanımlayın
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }


        // Register (Kayıt) işlemi
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Roller mevcut mu kontrol et ve oluştur
                    await EnsureRolesExist();

                    // Rol belirleme (Satıcı mı, Müdür mü?)
                    string role = model.IsVendor ? "Vendor" : model.IsManager ? "Manager" : "User";
                    await _userManager.AddToRoleAsync(user, role);

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "AdminPanel");

                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }


        // Giriş sayfasına yönlendiren aksiyon
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);

                    if (await _userManager.IsInRoleAsync(user, "Manager"))
                    {
                        return RedirectToAction("Index", "AdminPanel"); // Müdür paneline yönlendirme
                    }
                    if (await _userManager.IsInRoleAsync(user, "Vendor"))
                    {
                        return RedirectToAction("Index", "VendorPanel"); // Satıcı paneline yönlendirme
                    }
                    return RedirectToAction("Index", "Home"); // Normal kullanıcılar için
                }

                ModelState.AddModelError(string.Empty, "Geçersiz giriş denemesi.");
            }
            return View(model);
        }

        /*****ÇIKIŞ*****/
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        /**admin rolunu yapar **/
        private async Task EnsureRolesExist()
        {
            var roles = new[] { "Vendor", "Manager" };

            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new ApplicationRole(role));
                }
            }
        }

        [Authorize(Roles = "Manager")]
        public IActionResult AdminPanel()
        {
            return View();
        }

        [Authorize(Roles = "Vendor")]
        public IActionResult VendorPanel()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

