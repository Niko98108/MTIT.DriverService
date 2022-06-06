using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTIT.DriverService.Data;
using MTIT.DriverService.Models;

namespace MTIT.DriverService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {

        private static List<Driver> drivers = new List<Driver>
        {
            new Driver
                {
                    Id = 1,
                    DriverName="Saman",
                    DriverId ="001",
                    DriverType="Part Time",
                    IdNumber="123456789V",
                    Status="1"

                }
        };
        private readonly DataContext context;

        public DriverController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Driver>>> GetDriver()
        {
          
            return Ok(await context.Drivers.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Driver>> GetDriver(int id)
        {
            var driver = await context.Drivers.FindAsync(id);
            if (driver == null)
                return BadRequest("Driver Not Found");
            return Ok(driver);
        }

        [HttpPost]
        public async Task<ActionResult<List<Driver>>> AddDriver(Driver driver)
        {
            context.Drivers.Add(driver);
            await context.SaveChangesAsync();

            return Ok(await context.Drivers.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Driver>>> UpdateDriver(Driver request)
        {
            var dbdriver = await context.Drivers.FindAsync(request.Id);
            if (dbdriver == null)
                return BadRequest("Driver Not Found");

            dbdriver.DriverName = request.DriverName;
            dbdriver.DriverId = request.DriverId;
            dbdriver.DriverType = request.DriverType;
            dbdriver.IdNumber = request.IdNumber;
            dbdriver.Status = request.Status;

            await context.SaveChangesAsync();

            return Ok(await context.Drivers.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Driver>>> DeleteDriver(int id)
        {
            var dbdriver = await context.Drivers.FindAsync(id);
            if (dbdriver == null)
                return BadRequest("Driver Not Found");
            context.Drivers.Remove(dbdriver);
            await context.SaveChangesAsync();
            return Ok(await context.Drivers.ToListAsync());
        }
    }
}
