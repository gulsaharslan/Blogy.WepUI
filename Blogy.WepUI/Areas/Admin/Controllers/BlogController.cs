using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WepUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin", AuthenticationSchemes = "Identity.Application", Policy = "AdminAccessDenied")]
    public class BlogController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;

        public BlogController(IArticleService articleService, ICategoryService categoryService)
        {
            _articleService = articleService;
            _categoryService = categoryService; 
        }

        public IActionResult Index()
        {
            var values = _articleService.TGetListAll().ToList();
            return View(values);
        }


        public IActionResult DeleteBlog(int id)
        {
            _articleService.TDelete(id);
            return Redirect("Admin/Blog/Index");
        }
    }
}
