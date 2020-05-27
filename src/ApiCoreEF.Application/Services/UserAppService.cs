using ApiCoreEF.Application.Interfaces;
using ApiCoreEF.Application.ViewModels;
using ApiCoreEF.Domain.User;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCoreEF.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserAppService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public void Add(UserViewModel userViewModel)
        {
            _userRepository.Add(_mapper.Map<User>(userViewModel));
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<UserViewModel>>(_userRepository.GetAll());
        }

        public void Remove(Guid id)
        {
            _userRepository.Remove(id);
        }

        public void Update(UserViewModel userViewModel)
        {
            _userRepository.Update(_mapper.Map<User>(userViewModel));
        }
    }
}
