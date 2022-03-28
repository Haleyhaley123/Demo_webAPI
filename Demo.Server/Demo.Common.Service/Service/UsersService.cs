using Demo.Common.Domain.Models;
using Demo.Common.Domain.ViewModelsEntity;
using Demo.Common.Repository.IRepository;
using Demo.Common.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Common.Service.Service
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _iUsersRepository;
        public UsersService(IUsersRepository iUsersRepository)
        {
            _iUsersRepository = iUsersRepository;
        }
        public async Task<User> GetUserByName(string username)
        {
             return await _iUsersRepository.GetUserByName(username);
        }
        public async Task<bool> ChangePassWord(ChangePassWord changePass)
        {
            return  _iUsersRepository.ChangePassWord(changePass);
        }
    }
}
