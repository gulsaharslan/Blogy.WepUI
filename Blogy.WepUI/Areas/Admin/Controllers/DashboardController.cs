using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WepUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin", AuthenticationSchemes = "Identity.Application", Policy = "AdminAccessDenied")]
    public class DashboardController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IArticleService _articleService;
        private readonly IAppUserService _appUserService;
        private readonly ICommentService _commentService;

        public DashboardController(ICommentService commentService,ICategoryService categoryService,IArticleService articleService,IAppUserService appUserService)
        {
            _commentService = commentService;
            _categoryService = categoryService;
            _articleService = articleService;
            _appUserService = appUserService;
        }

        public IActionResult Index()
        {
            ViewBag.article = _articleService.TGetListAll().Count();
            ViewBag.category = _categoryService.TGetListAll().Count();
            ViewBag.writer=_appUserService.TGetListAll().Count();
            ViewBag.comment= _commentService.TGetListAll().Count();
            return View();
        }
    }
}
