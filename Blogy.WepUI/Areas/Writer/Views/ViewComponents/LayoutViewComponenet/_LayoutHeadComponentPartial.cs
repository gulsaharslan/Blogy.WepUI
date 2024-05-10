using Microsoft.AspNetCore.Mvc;

namespace Blogy.WepUI.Areas.Writer.ViewComponents.LayoutViewComponenet
{
    public class _LayoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
