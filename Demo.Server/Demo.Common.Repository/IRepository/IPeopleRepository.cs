using Demo.Common.Domain.Models;
using Demo.Common.Domain.ViewModelsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Common.Repository.IRepository
{
    public interface IPeopleRepository
    {
        Task<List<People>> GetPeople();
        Task<People> GetPeopleByID(string Id);
        bool EditData(People EditId);
        Task<bool> InsertData(People insertdata);
        Task<bool> DeleteData(int id);

    }
}
