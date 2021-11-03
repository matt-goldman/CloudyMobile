using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHops.Maui.Services.Abstractions
{
    public interface IAuthService
    {
        Task<bool> Authenticate();
    }
}
