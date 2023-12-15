using Gnexx.Services.DTOs.Account;
using RealEstateApp.Core.Aplication.DTOs.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnexx.Services.Interfaces
{
    public interface IAccountService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        public async Task<AcceptResponse> SendTeamAccept(AcceptRequest request, string team);
        Task<string> ConfirmAccountAsync(string userId, string token);
        Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordRequest request, string origin);
        Task<List<AuthenticationResponse>> GetAllUsersAsync();
        Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordRequest request);
        Task<RegisterResponse> RegistereBasicAsync(RegisterRequest request, string origin);
        Task SignOutAsync();
    }
}
