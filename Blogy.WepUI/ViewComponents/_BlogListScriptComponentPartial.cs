using Microsoft.AspNetCore.Mvc;

namespace Blogy.WepUI.ViewComponents
{
	public class _BlogListScriptComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
