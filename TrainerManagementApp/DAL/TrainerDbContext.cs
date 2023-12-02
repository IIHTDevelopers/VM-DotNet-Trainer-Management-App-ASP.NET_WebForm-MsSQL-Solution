using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TrainerManagementApp.Model;

namespace TrainerManagementApp.DAL
{
    public class TrainerDbContext : DbContext
    {
        public DbSet<Model.TrainerModel> TrainerModels { get; set; }

        public TrainerDbContext() : base("ConnStr")
        {
        }
    }
}