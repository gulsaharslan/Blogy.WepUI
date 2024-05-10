using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WepUI.Areas.Writer.ViewComponents.LayoutViewComponenet
{
    [Area("Writer")]
    public class _LayoutNavbarComponentPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IArticleService _articleService;

        public _LayoutNavbarComponentPartial(UserManager<AppUser> userManager, IArticleService articleService)
        {
            _userManager = userManager;
            _articleService = articleService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.picture = values.ImageUrl;
            ViewBag.name = values.Name + "" + values.Surname;
            return View();
        }
    }
}
