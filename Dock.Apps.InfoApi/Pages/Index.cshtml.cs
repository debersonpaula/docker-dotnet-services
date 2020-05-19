using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dock.Apps.InfoApi.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Dock.Apps.InfoApi.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IUserHttpClient _userHttpClient;
        public string[] userList = new string[] { };

        public IndexModel(ILogger<IndexModel> logger, IUserHttpClient userHttpClient)
        {
            _logger = logger;
            _userHttpClient = userHttpClient;
        }

        public void OnGet()
        {
            try
            {
                _logger.LogInformation("Trying to request...");
                userList = _userHttpClient.GetUsers();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on connection");
            }
        }
    }
}
