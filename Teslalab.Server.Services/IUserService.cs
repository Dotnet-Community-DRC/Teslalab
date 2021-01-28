using System.Threading.Tasks;
using Teslalab.Shared;

namespace Teslalab.Server.Services
{
    public interface IUserService
    {
        Task<OperationResponse<string>> RegisterUserAsync(RegisterRequest model);

        Task<LoginResponse> GenerateTokenAsync(LoginRequest model);
    }
}