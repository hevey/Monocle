using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Monocle.Shared.Models;
using Monocle.Shared.Services;

namespace Monocle.Server.Controllers
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
            return Ok("Thank you for contacting us!");
        }

        [HttpGet]
        public ActionResult<List<Contact>> Get()
        {
            Platform? platform = _platformService.FindPlatform(1);

            if (platform == null) return BadRequest("Platform not found");
            // var messages = _platformService.GetMessages(platform);

            var contacts = _platformService.GetMessages(platform);
            return Ok(contacts);
        }
    }
}