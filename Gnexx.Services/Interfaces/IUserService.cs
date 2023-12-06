using Gnexx.Services.DTOs.Account;
using Gnexx.Services.UserIdentity;
using RealEstateApp.Core.Aplication.DTOs.Account;

namespace Gnexx.Services.Services.Interfaces
{
    public interface IUserService
    {
        Task<string> ConfirmEmailAsync(string userId, string token);
        Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordVM vm, string origin);
        Task<List<UserVM>> GetAllClientsAsync();
        Task<AuthenticationResponse> LoginAsync(LoginVM vm);
        Task<RegisterResponse> RegisterAsync(SaveUserVM vm, string origin);
        Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordVM vm);
        Task SignOutAsync();
    }
}