using Blogy.EntityLayer.Concrete;
using Blogy.WepUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.DependencyInjection;

namespace Blogy.WepUI.Controllers
{
    public class RegisterController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
           
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateRegisterViewModel p)
        {
            if (p.Password != null)
            {
                AppUser appuser = new AppUser()
                {
                    Name = p.Name,
                    Email = p.Email,
                    Surname = p.Surname,
                    UserName = p.Username,
                    IsAdmin = false,
                    Description = "Mesleğinizi yazınız",
                    ImageUrl = "Profil Fotoğrafı Ekleyiniz"
                };

                var result = await _userManager.CreateAsync(appuser, p.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Şifre boş bırakılamaz");
            }

            // Hata durumunda kayıt sayfasına geri dön
            return View();
        }
    }
}
