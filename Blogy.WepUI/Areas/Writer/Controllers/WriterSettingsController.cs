using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WepUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize(Roles = "Writer", AuthenticationSchemes = "Identity.Application", Policy = "WriterAccessDenied")]
    public class WriterSettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public WriterSettingsController(UserManager<AppUser> userManager, IAppUserService appUserService)
        {
            _userManager = userManager;
            _appUserService = appUserService;
        }

        private readonly IAppUserService _appUserService;

        [HttpGet]
        public async Task<IActionResult> Index(AppUser appUser)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile(AppUser appUser)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            user.Name = appUser.Name;
            user.Surname = appUser.Surname;
            user.ImageUrl = appUser.ImageUrl;
            user.Description = appUser.Description;

            await _userManager.UpdateAsync(user);
            return Redirect("/Writer/WriterSettings/Index/");


        }

    }
}

