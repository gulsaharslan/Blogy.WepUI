using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WepUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize(Roles = "Writer", AuthenticationSchemes = "Identity.Application", Policy = "WriterAccessDenied")]
    public class WriterSupportController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMessageService _messageService;

        public WriterSupportController(UserManager<AppUser> userManager, IMessageService messageService)
        {
            
            _messageService = messageService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> SendMessage(Message message)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            message.ReceiverUserId = 2;
            message.AppUserId = user.Id;
            message.SenderUserId=user.Id;
            message.Date = DateTime.Now;
            _messageService.TInsert(message);


            return RedirectToAction("/Writer/WriterMessage/Index/");
        }
    }
}
