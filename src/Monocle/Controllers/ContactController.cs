using Microsoft.AspNetCore.Mvc;
using Monocle.Models;
using Monocle.Services;

namespace Monocle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IPlatformService _platformService;
        
        public ContactController(IPlatformService platformService)
        {
            _platformService = platformService;
        }
        
        [HttpPost]
        public ActionResult<Contact> Post(Contact contact)
        {
            Platform? platform = _platformService.FindPlatform(1);

            if (platform == null) return BadRequest("Platform not found");
            _platformService.PostMessage(platform, contact);
            return Ok("Message Sent Successfully");
        }
    }
}