using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blogy.WepUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize(Roles = "Writer", AuthenticationSchemes = "Identity.Application", Policy = "WriterAccessDenied")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;
        private readonly INotificationService _notificationService;
        private readonly BlogContext _context;

        public DashboardController(ICommentService commentService,  IArticleService articleService,  UserManager<AppUser> userManager,INotificationService notificationService,BlogContext context)
        {
            _userManager = userManager;
            _commentService = commentService;
            _articleService = articleService;
            _notificationService = notificationService;
            _context = context;
        }

        public async Task< IActionResult>Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.article = _articleService.TGetArticlesByWriter(user.Id).Count();
            ViewBag.comment=_commentService.TGetCommentCountByWriter(user.Id);
            ViewBag.notification = _notificationService.TGetListAll().Count();
            ViewBag.latestArticle =_context.Articles.OrderByDescending(x => x.CreatedDate).FirstOrDefault().Title.ToString();
            return View();
        }
    }
}
