using Gnexx.Services.DTOs.Account;
using Gnexx.Services.DTOs.Email;
using RealEstateApp.Core.Aplication.DTOs.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnexx.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
