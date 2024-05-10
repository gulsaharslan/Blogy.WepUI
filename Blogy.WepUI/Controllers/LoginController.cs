using Blogy.EntityLayer.Concrete;
using Blogy.WepUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.CompilerServices;

namespace Blogy.WepUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Index(UserSignInViewModel model)
        {
            if (model.Username!=null && model.Password!=null)
            {
                var result=await _signInManager.PasswordSignInAsync(model.Username, model.Password,false,true);
                if(result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(model.Username);
                    if (user != null)
                    {
                        if (user.IsAdmin == true)
                        {
                            return Redirect("/Admin/Dashboard/Index");
                        }
                        else
                        {
                            return Redirect("/Writer/Dashboard/Index");
                        }
                    }
                   
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                }
            }
            else
            {
                ModelState.AddModelError("", "Lütfen alanları boş geçmeyin!");
            }
            return View();
        }
    }
}
