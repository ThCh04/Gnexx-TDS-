using AutoMapper;
using Gnexx.Models.Entities;
using Gnexx.Services.DTOs.Account;
using Gnexx.Services.Helpers;
using Gnexx.Services.Interfaces.Repository;
using Gnexx.Services.Interfaces.Services;
using Gnexx.Services.ViewModels.NewsViewModel;
using Gnexx.Services.ViewModels.TeamViewModel;
using Microsoft.AspNetCore.Http;

namespace Gnexx.Services.Services
{
    public class TeamsService : GenericServices<TeamViewModel, Team>, ITeamsService
    {
        private readonly ITeamsRepo _teamRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _http;
        private readonly AuthenticationResponse userView;

        public TeamsService(ITeamsRepo repository, IMapper mapper, IHttpContextAccessor http) : base(repository, mapper)
        {
            _teamRepository = repository;
            _mapper = mapper;
            _http = http;
            userView = _http.HttpContext.Session.Get<AuthenticationResponse>("user");
        }

        public async Task SeedAsync()
        {
            Team defaultTeam = new();
            defaultTeam.Description = "Lorem epsilum";
            defaultTeam.TeamName = "Juana";
            defaultTeam.CoachID = null;
            defaultTeam.PlayerID = null;
            defaultTeam.UserId = null;
            defaultTeam.Create_date = DateTime.Now;

            var seed = await _teamRepository.GetById(1);
            if (seed == null)
            {
                await _teamRepository.CreateAsync(defaultTeam);
            }

        }
    }
}
