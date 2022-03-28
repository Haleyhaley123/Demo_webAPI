using Demo.Common.Domain.Models;
using Demo.Common.Domain.ViewModelsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Common.Service.IService
{
    public interface IUsersService
    {
        Task<User> GetUserByName(string username);
        Task<bool> ChangePassWord(ChangePassWord changePass);
    }
}
