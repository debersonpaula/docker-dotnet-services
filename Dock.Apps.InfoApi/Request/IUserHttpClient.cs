using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dock.Apps.InfoApi.Request
{
    public interface IUserHttpClient
    {
        public string[] GetUsers();
    }
}
