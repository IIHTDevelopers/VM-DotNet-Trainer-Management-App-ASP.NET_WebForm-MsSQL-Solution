
using TimeManagementApp.Models;
using System.Data.Entity;


namespace TimeManagementApp.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DefaultConnection") { }

        public DbSet<Time> Times { get; set; }
    }
}