using Microsoft.AspNetCore.Mvc;

namespace Blogy.WepUI.Controllers
{
    public class WriterLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
