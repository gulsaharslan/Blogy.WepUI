using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WepUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin", AuthenticationSchemes = "Identity.Application", Policy = "AdminAccessDenied")]
    public class WriterController : Controller
    {
        private readonly IAppUserService _appUserService;

        public WriterController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
            
        }

   
        public IActionResult WriterList()
        {
            var values=_appUserService.TGetListAll();
            return View(values);
        }

  
        public async Task <IActionResult> ChangeApproval(int id)
        {
            _appUserService.TChangeApproval(id);
            return Redirect("/Admin/Writer/WriterList");
        }
    }
}
