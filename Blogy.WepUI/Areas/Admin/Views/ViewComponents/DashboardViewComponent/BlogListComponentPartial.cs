using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WepUI.Areas.Admin.Views.ViewComponents.DashboardViewComponent
{
    [Area("Admin")]
    public class BlogListComponentPartial:ViewComponent
    {
        private readonly IArticleService _articleService;

        public BlogListComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }
        public IViewComponentResult Invoke()
        {
            var values = _articleService.TGetLatestArticles(5);
            return View(values);
        }
    }
}
