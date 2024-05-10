using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WepUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin", AuthenticationSchemes = "Identity.Application", Policy = "AdminAccessDenied")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
      

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult CategoryList()
        {
            var values = _categoryService.TGetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _categoryService.TInsert(category);
          
            return Redirect("/Admin/Category/CategoryList");
        }

        public IActionResult DeleteCategory(int id)
        {
            _categoryService.TDelete(id);
            return Redirect("/Admin/Category/CategoryList");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            return View(value);

        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {

            _categoryService.TUpdate(category);
            return Redirect("/Admin/Category/CategoryList");
        }


    }
}
