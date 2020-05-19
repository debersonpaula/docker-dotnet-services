using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Dock.Apps.UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly List<string> _users;

        public UsersController()
        {
            _users = new List<string>();
            _users.Add("Joseph");
            _users.Add("Mary");
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _users;
        }
    }
}
