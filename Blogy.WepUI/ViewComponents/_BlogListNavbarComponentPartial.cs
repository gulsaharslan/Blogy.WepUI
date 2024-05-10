using Microsoft.AspNetCore.Mvc;

namespace Blogy.WepUI.ViewComponents
{
	public class _BlogListNavbarComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
