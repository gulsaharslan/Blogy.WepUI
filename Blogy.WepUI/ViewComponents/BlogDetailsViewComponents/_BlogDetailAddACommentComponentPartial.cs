using Blogy.BusinessLayer.Abstract;
using Blogy.WepUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Blogy.WepUI.ViewComponents.BlogDetailsViewComponents
{
    public class _BlogDetailAddACommentComponentPartial:ViewComponent
    {
        private readonly ICommentService _commentService;

        public _BlogDetailAddACommentComponentPartial(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpGet]
        public IViewComponentResult Invoke(int id)
        {

            var values = new CommentViewModel()
            {
                ArticleId = id
            };

            return View (values);
        }

    }
}
