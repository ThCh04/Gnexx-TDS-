using AutoMapper;
using Gnexx.Data.Entities;
using Gnexx.Models.Entities;
using Gnexx.Services.DTOs.Account;
using Gnexx.Services.Helpers;
using Gnexx.Services.Interfaces.Repository;
using Gnexx.Services.Interfaces.Services;
using Gnexx.Services.ViewModels.CoachViewModel;
using Microsoft.AspNetCore.Http;

namespace Gnexx.Services.Services
{
    public class CoachService : GenericService<CoachViewModel, Coach>, ICoachService
    {
        private readonly ICoachRepo _coachRepo;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _http;
        private readonly AuthenticationResponse userView;

        public CoachService(ICoachRepo repository, IMapper mapper, IHttpContextAccessor http) : base(repository, mapper)
        {
            _coachRepo = repository;
            _mapper = mapper;
            _http = http;
            userView = _http.HttpContext.Session.Get<AuthenticationResponse>("user");
        }
    }
}
