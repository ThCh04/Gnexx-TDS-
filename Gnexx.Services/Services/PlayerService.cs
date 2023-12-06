using AutoMapper;
using Gnexx.Models.Entities;
using Gnexx.Services.DTOs.Account;
using Gnexx.Services.Helpers;
using Gnexx.Services.Interfaces.Repository;
using Gnexx.Services.Interfaces.Services;
using Gnexx.Services.ViewModels.PlayerViewModel;
using Microsoft.AspNetCore.Http;

namespace Gnexx.Services.Services
{
    public class PlayerService : GenericService<PlayerViewModel, Player>, IPlayerService
    {
        private readonly IPlayerRepo _playerRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _http;
        private readonly AuthenticationResponse userView;

        public PlayerService(IPlayerRepo repository, IMapper mapper, IHttpContextAccessor http) : base(repository, mapper)
        {
            _playerRepository = repository;
            _mapper = mapper;
            _http = http;
            userView = _http.HttpContext.Session.Get<AuthenticationResponse>("user");
        }
    }
}
