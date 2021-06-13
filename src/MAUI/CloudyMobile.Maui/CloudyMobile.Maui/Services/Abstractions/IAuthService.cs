using System.Threading.Tasks;

namespace CloudyMobile.Maui.Services.Abstractions
{
    public interface IAuthService
    {
        Task<bool> Authenticate();
    }
}
