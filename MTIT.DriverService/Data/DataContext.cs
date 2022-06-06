using Microsoft.EntityFrameworkCore;
using MTIT.DriverService.Models;

namespace MTIT.DriverService.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        

        public DbSet<Driver> Drivers { get; set; }
    }
}
