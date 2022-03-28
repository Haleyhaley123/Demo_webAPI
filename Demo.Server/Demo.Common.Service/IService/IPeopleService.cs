using Demo.Common.Domain.Models;
using Demo.Common.Domain.ViewModelsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Common.Service.IService
{
    public interface IPeopleService
    {
        Task<List<People>> GetPeople();
        Task<People> GetPeopleById(string Id);
        Task<bool> EditData(People EditId);
        Task<bool> InsertData(People insertdata);
        Task<bool> DeleteData(int id);
    }
}
