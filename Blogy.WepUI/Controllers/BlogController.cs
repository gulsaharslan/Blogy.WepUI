using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WepUI.Controllers
{
  
    public class BlogController : Controller
    {
        private readonly IArticleService _articleService;

        public BlogController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IActionResult BlogList()
        {
            var values = _articleService.TGetListAll();
            return View(values);
        }
        public IActionResult BlogDetail(int id)
        {
            ViewBag.i = id;
            return View();
        }

        public IActionResult AllBlog()
        {
            var values = _articleService.TGetListAll();
            return View(values);
        }

    }
}
