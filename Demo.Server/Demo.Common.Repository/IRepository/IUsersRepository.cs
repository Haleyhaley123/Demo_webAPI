using Demo.Common.Domain.Models;
using Demo.Common.Domain.ViewModelsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Common.Repository.IRepository
{
    public interface IUsersRepository
    {
       Task<User> GetUserByName(string username);
       bool ChangePassWord(ChangePassWord changePass);
    }
}
