using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WepUI.Areas.Writer.Views.ViewComponents.DashboardViewComponent
{
    [Area("Writer")]
    public class WriterAdminBlogListComponentPartial:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly IArticleService _articleService;
        
        public WriterAdminBlogListComponentPartial(UserManager<AppUser> userManager, IArticleService articleService)
        {
            _userManager = userManager;
            _articleService = articleService;
        }



        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _articleService.TGetArticlesByWriter(user.Id);
            return View(values);
        }
    }
}
