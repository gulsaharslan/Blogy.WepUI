using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WepUI.ViewComponents.BlogDetailsViewComponents
{
    public class _BlogDetailOtherPostsComponentPartial:ViewComponent
    {
        private readonly IArticleService _articleService;

        public _BlogDetailOtherPostsComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }
        public IViewComponentResult Invoke()
        {
           var values= _articleService.TGetLast4Article();
            return View(values);
        }
    }
}
