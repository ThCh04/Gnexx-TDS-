using AutoMapper;
using Gnexx.Data.Entities;
using Gnexx.Models.Entities;
using Gnexx.Services.DTOs.Account;
using Gnexx.Services.UserIdentity;
using Gnexx.Services.ViewModels.CoachViewModel;
using Gnexx.Services.ViewModels.CommentsViewModel;
using Gnexx.Services.ViewModels.NewsViewModel;
using Gnexx.Services.ViewModels.PlayerViewModel;
using Gnexx.Services.ViewModels.ResponseViewModel;
using Gnexx.Services.ViewModels.TeamViewModel;
using Gnexx.Services.ViewModels.UserEntitie;

namespace Gnexx.Services.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region user
            CreateMap<AuthenticationRequest, LoginVM>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<RegisterRequest, SaveUserVM>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<AuthenticationResponse, SaveUserVM>()
                .ForMember(x => x.ConfirmPassword, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(x => x.Verified, opt => opt.Ignore())
                .ForMember(x => x.Roles, opt => opt.Ignore());


            CreateMap<ForgotPasswordRequest, ForgotPasswordVM>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ResetPasswordRequest, ResetPasswordVM>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<AuthenticationResponse, UserVM>()
               .ReverseMap()
               .ForMember(x => x.HasError, opt => opt.Ignore())
               .ForMember(x => x.Error, opt => opt.Ignore());
            #endregion

            #region entities

            CreateMap<News, NewsViewModel>()
                .ReverseMap();
            CreateMap<Coach, CoachViewModel>()
                .ReverseMap();
            CreateMap<Response, ResponseViewModel>()
                .ReverseMap();
            CreateMap<Comments, CommentsViewModel>()
                .ReverseMap();
            CreateMap<Team, TeamViewModel>()
                .ReverseMap();
            CreateMap<Player, PlayerViewModel>()
                .ReverseMap();
            CreateMap<UsersEntitie, UserEntitieViewModel>()
                .ReverseMap();

            #endregion
        }
    }
}
