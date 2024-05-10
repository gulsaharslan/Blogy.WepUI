using Blogy.DataAccessLayer.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Blogy.WepUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize(Roles = "Writer", AuthenticationSchemes = "Identity.Application", Policy = "WriterAccessDenied")]
    public class ChartController : Controller
    {
        private readonly BlogContext _context;

        public ChartController(BlogContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();

            var data = new[]
            {
                new object[] { "Kategori Adı", "Blog Sayısı" }
            };

            foreach (var category in categories)
            {
                var categoryCount = _context.Articles.Count(b => b.CategoryId == category.CategoryId);
                data = data.Append(new object[] { category.CategoryName, categoryCount }).ToArray();
            }

            ViewBag.CategoriesData = data;

            return View();
        }
    }
}
