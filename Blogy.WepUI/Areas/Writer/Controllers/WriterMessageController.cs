using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WepUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize(Roles = "Writer", AuthenticationSchemes = "Identity.Application", Policy = "WriterAccessDenied")]
    public class WriterMessageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMessageService _messageService;

        public WriterMessageController(UserManager<AppUser> userManager, IMessageService messageService)
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
