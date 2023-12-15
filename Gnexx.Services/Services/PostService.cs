using AutoMapper;
using Gnexx.Data.Entities;
using Gnexx.Services.DTOs.Account;
using Gnexx.Services.Interfaces.Repository;
using Gnexx.Services.Interfaces.Services;
using Gnexx.Services.ViewModels.PostulationViewModel;
using Microsoft.AspNetCore.Http;
using Gnexx.Services.Helpers;

namespace Gnexx.Services.Services
{
    public class PostService : GenericServices<PostulationViewModel,Postulation>, IPostService
    {
        private readonly IPostRepo _playerRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _http;
        private readonly AuthenticationResponse userView;

        public PostService(IPostRepo repository, IMapper mapper, IHttpContextAccessor http) : base(repository, mapper)
        {
            _playerRepository = repository;
            _mapper = mapper;
            _http = http;
            userView = _http.HttpContext.Session.Get<AuthenticationResponse>("user");
        }
    }
}
