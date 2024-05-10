using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WepUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin", AuthenticationSchemes = "Identity.Application", Policy = "AdminAccessDenied")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public IActionResult Index()
        {
            var values=_commentService.TGetListAll();
            return View(values);
        }

        public IActionResult DeleteComment(int id)
        {
            _commentService.TDelete(id);
            return Redirect("/Admin/Comment/Index");
        }

        public IActionResult BlogComments(int id)
        {
            var values =  _commentService.TGetCommentsByArticleId(id);
            return View(values);
        }
    }
}
