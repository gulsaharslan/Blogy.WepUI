using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WepUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin", AuthenticationSchemes = "Identity.Application", Policy = "AdminAccessDenied")]
    public class MessageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMessageService _messageService;

        public MessageController(UserManager<AppUser> userManager, IMessageService messageService)
        {

            _messageService = messageService;
            _userManager = userManager;
        }

        public async Task<ActionResult> Inbox()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _messageService.TGetMessagesByWriter(user.Id);
            return View(values);
        }

        public async Task<ActionResult> Outbox()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _messageService.TGetOutgoingMessageByWriter(user.Id);
            return View(values);
        }
    }
}
