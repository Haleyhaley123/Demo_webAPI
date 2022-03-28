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
    public class PeopleService : IPeopleService
    {
        private readonly IPeopleRepository _iPeopleRepository;
        public PeopleService(IPeopleRepository iPeopleRepository)
        {
            _iPeopleRepository = iPeopleRepository;
        }
        public async Task<List<People>> GetPeople()
        {
            return await _iPeopleRepository.GetPeople();
        }
        public async Task<People> GetPeopleById(string Id)
        {
            return await _iPeopleRepository.GetPeopleByID(Id);
        }
        public async Task<bool> EditData(People EditId)
        {
            return _iPeopleRepository.EditData(EditId);
        }
        public async Task<bool> InsertData(People insertdata)
        {
            return await _iPeopleRepository.InsertData(insertdata);
        }
        public async Task<bool> DeleteData(int id)
        {
            return await _iPeopleRepository.DeleteData(id);
        }
    }
}
