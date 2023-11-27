using TimeManagementApp.DAL.Interrfaces;
using TimeManagementApp.DAL.Services.Repository;
using TimeManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TimeManagementApp.DAL.Services
{
    public class TimeService : ITimeService
    {
        private readonly ITimeRepository _repository;

        public TimeService(ITimeRepository repository)
        {
            _repository = repository;
        }

        public Task<Time> CreateTime(Time expense)
        {
            return _repository.CreateTime(expense);
        }

        public Task<bool> DeleteTimeById(long id)
        {
            return _repository.DeleteTimeById(id);
        }

        public List<Time> GetAllTimes()
        {
            return _repository.GetAllTimes();
        }

        public Task<Time> GetTimeById(long id)
        {
            return _repository.GetTimeById(id); ;
        }

        public Task<Time> UpdateTime(Time model)
        {
            return _repository.UpdateTime(model);
        }
    }
}