using AutoMapper;
using EntityFrameworkMigration.DataAccess.Operations;
using EntityFrameworkMigration.Entities;
using EntityFrameworkMigration.Entities.DTO;
using EntityFrameworkMigration.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkMigration.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDetail, UserDetailViewModel>()
                .ForMember(desc => desc.Name, opr => opr.MapFrom(src => src.FirstName + " " + src.LastName))
                .ForMember(desc => desc.School, opr => opr.MapFrom(src => src.SchoolName))
                .ForMember(desc => desc.Email, opr => opr.MapFrom(src => src.Email));

            CreateMap<UserDetail, AddUserViewModel>()
                .ForMember(desc => desc.FirstName, opr => opr.MapFrom(src => src.FirstName))
                .ForMember(desc => desc.LastName, opr => opr.MapFrom(src => src.LastName))
                .ForMember(desc => desc.SchoolName, opr => opr.MapFrom(src => src.SchoolName))
                .ForMember(desc => desc.PhoneNumber, opr => opr.MapFrom(src => src.PhoneNumber))
                .ForMember(desc => desc.Email, opr => opr.MapFrom(src => src.Email));
        }
    }
}
