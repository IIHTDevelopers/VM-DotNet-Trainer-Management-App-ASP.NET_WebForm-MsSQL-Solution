using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TrainerManagementApp.DAL.Interfaces;
using TrainerManagementApp.Model;

namespace TrainerManagementApp.DAL.Services
{
    public class TrainerService : Interfaces.ITrainerService
    {
        private Interfaces.ITrainerRepository _repository;

        public TrainerService(Interfaces.ITrainerRepository repository)
        {
            _repository = repository;
        }


        public string GetAll()
        {
            return _repository.GetAll();
        }

        public string Add()
        {
            return _repository.Add();
        }

        public string Update()
        {
            return _repository.Update();
        }

        public string Delete()
        {
            return _repository.Delete();
        }

        public TrainerModel GetById(string id)
        {
            return _repository.GetById(id);
        }
    }
}