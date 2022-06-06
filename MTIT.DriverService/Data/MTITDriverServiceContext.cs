using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MTIT.DriverService.Models;

namespace MTIT.DriverService.Data
{
    public class MTITDriverServiceContext : DbContext
    {
        public MTITDriverServiceContext (DbContextOptions<MTITDriverServiceContext> options)
            : base(options)
        {
        }

        public DbSet<MTIT.DriverService.Models.Driver>? Driver { get; set; }
    }
}
