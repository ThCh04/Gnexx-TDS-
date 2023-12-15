using AutoMapper;
using Gnexx.Data.Entities;
using Gnexx.Services.DTOs.Account;
using Gnexx.Services.Helpers;
using Gnexx.Services.Interfaces.Repository;
using Gnexx.Services.Interfaces.Services;
using Gnexx.Services.ViewModels.PostulationViewModel;
using Microsoft.AspNetCore.Http;

namespace Gnexx.Services.Services
{
    public class PostService : GenericService<PostulationViewModel,Postulation>,IPostService
    {
        private readonly IPostRepo _postRepo;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly AuthenticationResponse response;

        public PostService(IPostRepo postRepo, IMapper mapper, IHttpContextAccessor httpContext): base(postRepo,mapper)
        {
            _postRepo = postRepo;
            _mapper = mapper;
            _httpContext = httpContext;

            response = _httpContext.HttpContext.Session.Get<AuthenticationResponse>("user");
        }
    }
}
