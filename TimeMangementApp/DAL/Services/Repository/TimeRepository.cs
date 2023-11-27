using TimeManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TimeManagementApp.DAL.Services.Repository
{
    public class TimeRepository : ITimeRepository
    {
        private readonly DatabaseContext _dbContext;
        public TimeRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Time> CreateTime(Time expense)
        {
            try
            {
                var result =  _dbContext.Times.Add(expense);
                await _dbContext.SaveChangesAsync();
                return expense;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool> DeleteTimeById(long id)
        {
            try
            {
                _dbContext.Times.Remove(_dbContext.Times.Single(a => a.Id == id));
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<Time> GetAllTimes()
        {
            try
            {
                var result = _dbContext.Times.ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Time> GetTimeById(long id)
        {
            try
            {
                return await _dbContext.Times.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

      
        

        public async Task<Time> UpdateTime(Time model)
        {
            var ex = await _dbContext.Times.FindAsync(model.Id);
            try
            {
                await _dbContext.SaveChangesAsync();
                return ex;
            }
            catch (Exception exc)
            {
                throw (exc);
            }
        }
    }
}