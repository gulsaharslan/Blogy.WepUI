using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WepUI.ViewComponents.BlogDetailsViewComponents
{
    public class _BlogDetailTagsComponentPartial:ViewComponent
    {
        private readonly BlogContext _blogContext;

        public _BlogDetailTagsComponentPartial(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public IViewComponentResult Invoke()
        {
            var values = _blogContext.Tags.ToList();
            return View(values);
        }
    }
}
