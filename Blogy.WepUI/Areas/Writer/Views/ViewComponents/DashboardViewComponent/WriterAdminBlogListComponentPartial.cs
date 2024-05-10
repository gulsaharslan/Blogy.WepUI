using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WepUI.Areas.Writer.Views.ViewComponents.DashboardViewComponent
{
    [Area("Writer")]
    public class WriterAdminBlogListComponentPartial:ViewComponent
    {


        private readonly IArticleService _articleService;

        public WriterAdminBlogListComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }
        public IViewComponentResult Invoke(int id)
        {
            var values = _articleService.TGetArticlesByWriter(id);
            return View(values);
        }
    }
}
