using AutoMapper;
using Gnexx.Data.Entities;
using Gnexx.Services.DTOs.Account;
using Gnexx.Services.Helpers;
using Gnexx.Services.Interfaces.Repository;
using Gnexx.Services.Interfaces.Services;
using Gnexx.Services.ViewModels.ResponseViewModel;
using Microsoft.AspNetCore.Http;

namespace Gnexx.Services.Services
{
    public class ResponseServices : GenericServices<ResponseViewModel, Response>, IResponseService
    {
        private readonly IResponsesRepo _responseRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _http;
        private readonly AuthenticationResponse userView;

        public ResponseServices(IResponsesRepo repository, IMapper mapper, IHttpContextAccessor http) : base(repository, mapper)
        {
            _responseRepository = repository;
            _mapper = mapper;
            _http = http;
            userView = _http.HttpContext.Session.Get<AuthenticationResponse>("user");
        }
    }
}
