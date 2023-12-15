using AutoMapper;
using Gnexx.Models.Entities;
using Gnexx.Services.DTOs.Account;
using Gnexx.Services.Interfaces;
using Gnexx.Services.Interfaces.Repository;
using Gnexx.Services.Services.Interfaces;
using Gnexx.Services.UserIdentity;
using RealEstateApp.Core.Aplication.DTOs.Account;

namespace Gnexx.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IAccountService _accountServices;
        private readonly IMapper _mapper;
        private readonly IUserEntityrepo _userEntityrepo;

        public UserService(IUserEntityrepo userEntityrepo,IAccountService accountServices, IMapper mapper)
        {
            _userEntityrepo = userEntityrepo;
            _accountServices = accountServices;
            _mapper = mapper;
        }

        public async Task<AuthenticationResponse> LoginAsync(LoginVM vm)
        {
            AuthenticationRequest LoginRequest = _mapper.Map<AuthenticationRequest>(vm);
            AuthenticationResponse response = await _accountServices.AuthenticateAsync(LoginRequest);

            return response;
        }

        public async Task SignOutAsync()
        {
            await _accountServices.SignOutAsync();
        }

        public async Task<string> ConfirmEmailAsync(string userId, string token)
        {
            return await _accountServices.ConfirmAccountAsync(userId, token);

        }

        public Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordVM vm, string origin)
        {
            ForgotPasswordRequest forgotPassword = _mapper.Map<ForgotPasswordRequest>(vm);

            return _accountServices.ForgotPasswordAsync(forgotPassword, origin);
        }

        public async Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordVM vm)
        {
            ResetPasswordRequest resetPasswordRequest = _mapper.Map<ResetPasswordRequest>(vm);
            return await _accountServices.ResetPasswordAsync(resetPasswordRequest);
        }

        public Task<List<UserVM>> GetAllClientsAsync()
        {
            throw new NotImplementedException();
        }



        public async Task<RegisterResponse> RegisterAsync(SaveUserVM vm, string origin)
        {
            UsersEntitie usersEntitie = new();
            usersEntitie.Username = vm.Username;
            usersEntitie.Email = vm.Email;
            usersEntitie.Name = vm.Firstname;
            usersEntitie.Lastname = vm.Lastname;
            usersEntitie.Type_user = vm.Rol;
            usersEntitie.Country = "DR";

            await _userEntityrepo.CreateAsync(usersEntitie);
            RegisterRequest registerRequest = _mapper.Map<RegisterRequest>(vm);
            return await _accountServices.RegistereBasicAsync(registerRequest, origin);
        }


    }
}
