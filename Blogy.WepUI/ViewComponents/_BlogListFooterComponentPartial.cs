using Microsoft.AspNetCore.Mvc;

namespace Blogy.WepUI.ViewComponents
{
	public class _BlogListFooterComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
