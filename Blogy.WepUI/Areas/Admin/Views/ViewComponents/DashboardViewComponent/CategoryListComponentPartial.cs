using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WepUI.Areas.Admin.Views.ViewComponents.DashboardViewComponent
{
   
    public class CategoryListComponentPartial:ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoryListComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _categoryService.TGetLatestCategories(5);
            return View(values);
        }
    }
}
