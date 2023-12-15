using Gnexx.Models.Entities;
using Gnexx.Services.Interfaces.Services;
using Gnexx.Services.Services;
using Gnexx.Services.ViewModels.TeamViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnexx.Repository.SeedsR
{
    public class TeamSeed
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITeamsService _teams;
        public TeamSeed(ITeamsService team, IHttpContextAccessor httpContextAccessor)
        {
            _teams = team;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task SeedAsync(TeamViewModel team)
        {
            TeamViewModel defaultTeam = new();
            defaultTeam.Description = "Lorem epsilum";
            defaultTeam.TeamName = "Juana";
            defaultTeam.CoachID = null;
            defaultTeam.PlayerID = null;
            defaultTeam.UserId = null;
            defaultTeam.Create_date = DateTime.Now;

            var seed = await _teams.GetByIdSaveViewModel(1);
            if (seed == null)
            {
                await _teams.Add(defaultTeam);
            }
            
        }
    }
}
