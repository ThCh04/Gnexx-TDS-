using Gnexx.Identity.Entities;
using Gnexx.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Gnexx.Services.Enums;
using Gnexx.Services.DTOs.Account;
using RealEstateApp.Core.Aplication.DTOs.Account;

namespace Gnexx.Identity.Services
{
    public class AccountServices : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailService _mail;

        public AccountServices(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInMannager, IEmailService mail)
        {
            _userManager = userManager;
            _signInManager = signInMannager;
            _mail = mail;
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            AuthenticationResponse response = new();

            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                response.HasError = true;
                response.Error = $"No Account registetres with {request.Email}";

                return response;
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                response.HasError = true;
                response.Error = $"Invalid credentials for {request.Email}";

                return response;
            }

            if (!user.EmailConfirmed)
            {
                response.HasError = true;
                response.Error = $"Acount not confirmed for {request.Email}";

                return response;
            }

            response.Id = user.Id;
            response.UserName = user.UserName;
            response.FirstName = user.FirstName;
            response.LastName = user.LastName;
            response.Email = user.Email;
            var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
            response.Roles = rolesList.ToList();
            response.Verified = user.EmailConfirmed;

            return response;

        }

        public async Task<RegisterResponse> RegistereBasicAsync(RegisterRequest request, string origin)
        {
            RegisterResponse register = new();
            register.HasError = false;

            var userWithSameUsername = await _userManager.FindByNameAsync(request.UserName);
            if (userWithSameUsername != null)
            {
                register.HasError = true;
                register.Error = $"user name {request.UserName} already exist";
                return register;
            }

            var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);
            if (userWithSameEmail != null)
            {
                register.HasError = true;
                register.Error = $"The email {request.UserName} is already taken";
                return register;
            }

            if (request.Password != request.ConfirmPassword)
            {
                register.HasError = true;
                register.Error = $"The password does'nt match";
                return register;
            }
            

            var user = new ApplicationUser
            {
                UserName = request.UserName,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, request.Rol);

                var verificationUri = await SendVerificationEmail(user, origin);

                await _mail.SendAsync(new Gnexx.Services.DTOs.Email.EmailRequest()
                {
                    To = user.Email,
                    Body = $"Confirme su cuenta:\n{verificationUri}",
                    Subject = "Confirme",
                });
            }
            else
            {
                register.HasError = true;
                register.Error = $"Quizas su contraseña no cumple con los requisitos";
                return register;
            }


            return register;
        }

        public async Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordRequest request, string origin)
        {
            ForgotPasswordResponse response = new()
            {
                HasError = false,
            };

            var account = await _userManager.FindByEmailAsync(request.Email);
            if (account == null)
            {
                response.HasError = true;
                response.Error = $"No Account registetres with {request.Email}";

                return response;
            }

            var verificationUri = await SendForgotPassword(account, origin);

            await _mail.SendAsync(new Gnexx.Services.DTOs.Email.EmailRequest()
            {
                To = account.Email,
                Body = $"Renueve su contraseña dando click aqui:\n{verificationUri}",
                Subject = "Resetear contraseña",
            });
            return response;
        }

        public async Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordRequest request)
        {
            ResetPasswordResponse response = new()
            {
                HasError = false
            };

            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                response.HasError = true;
                response.Error = $"No Account registetres with {request.Email}";

                return response;
            }

            request.token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request.token));

            var resul = await _userManager.ResetPasswordAsync(user, request.token, request.Password);

            if (!resul.Succeeded)
            {
                response.HasError = true;
                response.Error = "An error ocurred while reseting password";

                return response;
            }
            return response;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<List<AuthenticationResponse>> GetAllUsersAsync()
        {
            var items = await _userManager.Users.ToListAsync();

            List<AuthenticationResponse> list = new();

            foreach (var vm in items)
            {
                var rol = await _userManager.GetRolesAsync(vm).ConfigureAwait(false);

                AuthenticationResponse item = new AuthenticationResponse
                {
                    Id = vm.Id,
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                    UserName = vm.UserName,
                    Email = vm.Email,
                    Roles = rol.ToList(),
                    Verified = vm.Verified
                };

                if (item.Roles.Count() == 1)
                {
                    if (item.Roles[0] == "Player")
                    {
                        item.Roles.Clear();
                        item.Roles.Add("Cliente");
                    }
                }

                list.Add(item);
            };

            return list;
        }

        //VerifyEmail
        public async Task<string> ConfirmAccountAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return "No accounts with this user";
            }

            token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));

            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
            {
                return "Congrats you can now used de app";
            }
            else
            {
                return $"An error has ocurred whie confirming {user.Email}";
            }
        }
        private async Task<string> SendVerificationEmail(ApplicationUser user, string origin)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var route = "Auth/ConfirmEmail";
            var Uri = new Uri(String.Concat($"{origin}/", route));
            var verificationUrl = QueryHelpers.AddQueryString(Uri.ToString(), "userId", user.Id);
            verificationUrl = QueryHelpers.AddQueryString(verificationUrl, "token", code);

            return verificationUrl;
        }
        private async Task<string> SendForgotPassword(ApplicationUser user, string origin)
        {
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var route = "Auth/ResetPassword";
            var Uri = new Uri(String.Concat($"{origin}/", route));
            var verificationUrl = QueryHelpers.AddQueryString(Uri.ToString(), "token", code);

            return verificationUrl;
        }
    }
}
