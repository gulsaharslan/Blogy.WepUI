using Microsoft.AspNetCore.Mvc;

namespace Blogy.WepUI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
        
    }
}
