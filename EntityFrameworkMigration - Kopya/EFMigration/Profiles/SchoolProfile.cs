using AutoMapper;
using EntityFrameworkMigration.DataAccess.Operations;
using EntityFrameworkMigration.Entities;
using EntityFrameworkMigration.Entities.DTO;
using EntityFrameworkMigration.ViewModels.SchoolViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkMigration.Profiles
{
    public class SchoolProfile : Profile
    {
        public SchoolProfile()
        {
            CreateMap<SchoolDetail, SchoolDetailViewModel>().ForMember(desc => desc.Name, opr => opr.MapFrom(src => src.Name))
                .ForMember(desc => desc.City, opr => opr.MapFrom(src => src.CityName))
                .ForMember(desc => desc.SchoolType, opr => opr.MapFrom(src => src.SchoolTypeName));
        }
    }
}
