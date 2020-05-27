using ApiCoreEF.Application.ViewModels;
using ApiCoreEF.Domain.User;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCoreEF.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UserViewModel, User>()
                .ConvertUsing(c => new User(c.Id, c.Nome, c.Login, c.Email, c.Senha));
        }
    }
}
