using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TrainerManagementApp.DAL.Interfaces;

namespace TrainerManagementApp.DAL.Services
{
    public class TrainerRepository : Interfaces.ITrainerRepository
    {
        private TrainerDbContext _context;

        public TrainerRepository(TrainerDbContext context)
        {
            _context = context;
        }

        public Model.TrainerModel GetById(string id)
        {
            return _context.TrainerModels.FirstOrDefault(t => t.Id == int.Parse(id));
        }

        public string GetAll()
        {
            string qry = "select* from TrainerModels";
            return qry;
        }

        public string Add()
        {
            string qry = "insert into TrainerModels(Title, IsCompleted, DueDate)" +
                "values('";
            return qry;
        }

        public string Update()
        {
            var query = "update TrainerModels set Title='";
            return query;
        }

        public string Delete()
        {
            var query = "delete from TrainerModels where Id='";
            return query;
        }
    }
}