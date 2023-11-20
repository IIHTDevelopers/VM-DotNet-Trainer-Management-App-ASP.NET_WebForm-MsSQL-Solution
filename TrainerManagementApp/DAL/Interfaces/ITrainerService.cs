using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainerManagementApp.Model;

namespace TrainerManagementApp.DAL.Interfaces
{
    public interface ITrainerService
    {
        string GetAll();
        string Add();
        string Update();
        string Delete();
        TrainerModel GetById(string id);
    }
}
