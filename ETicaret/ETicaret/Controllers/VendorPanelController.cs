using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ETicaret.Controllers
{
    [Authorize(Roles = "Vendor")]
    public class VendorPanelController : Controller
    {
        public IActionResult Index()
        {
            return View(); // Vendor paneline özel view
        }
    }
}
