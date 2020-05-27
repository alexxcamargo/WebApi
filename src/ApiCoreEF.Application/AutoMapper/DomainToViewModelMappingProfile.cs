using ApiCoreEF.Application.ViewModels;
using ApiCoreEF.Domain.User;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCoreEF.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {

        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserViewModel>();
        }
      
    }
}
