using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer.Concrete;
using Blogy.WepUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Blogy.WepUI.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;

        public CommentController(ICommentService commentService, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task< IActionResult> Index(CommentViewModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);


            _commentService.TInsert(new Comment()
            {
                AppUserId = user.Id,
                ArticleId = model.ArticleId,
                NameSurname=model.NameSurname,
                Email=model.Email,
                Content = model.Content,
                CommentDate = DateTime.Now


            });

            return RedirectToAction("BlogDetail","Blog", new { @id = model.ArticleId });
        }

    }
}
