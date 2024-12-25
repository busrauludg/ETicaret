using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ETicaret.Controllers
{
    [Authorize(Roles = "Manager")]
    public class AdminPanelController : Controller
    {
        public IActionResult Index()
        {
            return View(); // Admin paneline özel view
        }
    }
}
