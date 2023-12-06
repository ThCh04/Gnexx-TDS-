using AutoMapper;
using Gnexx.Data.Entities;
using Gnexx.Services.DTOs.Account;
using Gnexx.Services.Helpers;
using Gnexx.Services.Interfaces.Repository;
using Gnexx.Services.Interfaces.Services;
using Gnexx.Services.ViewModels.CommentsViewModel;
using Microsoft.AspNetCore.Http;

namespace Gnexx.Services.Services
{
    public class CommentsServices : GenericService<CommentsViewModel, Comments>, ICommentsService
    {
        private readonly ICommentsRepo _newsRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _http;
        private readonly AuthenticationResponse userView;

        public CommentsServices(ICommentsRepo repository, IMapper mapper, IHttpContextAccessor http) : base(repository, mapper)
        {
            _newsRepository = repository;
            _mapper = mapper;
            _http = http;
            userView = _http.HttpContext.Session.Get<AuthenticationResponse>("user");
        }
    }
}
