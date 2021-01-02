using Microsoft.AspNetCore.Mvc;
using Monocle.Models;
using Monocle.Services;

namespace Monocle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IDBService _dbService;
        
        public ContactController(IDBService dbService)
        {
            _dbService = dbService;
        }
        
        [HttpPost]
        public ActionResult<Contact> Post(Contact contact)
        {
            _dbService.PostMessage(contact);
            
            return Ok();
        }
    }
}