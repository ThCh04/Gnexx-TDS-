using AutoMapper;
using Gnexx.Models.Entities;
using Gnexx.Services.DTOs.Account;
using Gnexx.Services.Helpers;
using Gnexx.Services.Interfaces.Repository;
using Gnexx.Services.Interfaces.Services;
using Gnexx.Services.ViewModels.UserEntitie;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnexx.Services.Services
{
    public class UserEntityService : GenericServices<UserEntitieViewModel, UsersEntitie>, IUserEntityService
    {
        private readonly IUserEntityrepo _teamRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _http;
        private readonly AuthenticationResponse userView;

        public UserEntityService(IUserEntityrepo repository, IMapper mapper, IHttpContextAccessor http) : base(repository, mapper)
        {
            _teamRepository = repository;
            _mapper = mapper;
            _http = http;
            userView = _http.HttpContext.Session.Get<AuthenticationResponse>("user");
        }
    }
}
