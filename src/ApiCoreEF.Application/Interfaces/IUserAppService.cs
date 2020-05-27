using ApiCoreEF.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace ApiCoreEF.Application.Interfaces
{
    public interface IUserAppService
    {
        void Add(UserViewModel userViewModel);
        IEnumerable<UserViewModel> GetAll();
        void Update(UserViewModel userViewModel);
        void Remove(Guid id);  
    }
}
