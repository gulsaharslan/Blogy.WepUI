using Microsoft.AspNetCore.Mvc;

namespace Blogy.WepUI.ViewComponents
{
	public class _BlogListHeadComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
