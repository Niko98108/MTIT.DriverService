using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public async Task<ActionResult<List<Driver>>> GetDriver()
        {
          
            return Ok(drivers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Driver>> GetDriver(int id)
        {
            var driver = drivers.Find(d => d.Id == id);
            if (driver == null)
                return BadRequest("Driver Not Found");
            return Ok(driver);
        }

        [HttpPost]
        public async Task<ActionResult<List<Driver>>> AddDriver(Driver driver)
        {
            drivers.Add(driver);
            return Ok(drivers);
        }

        [HttpPut]
        public async Task<ActionResult<List<Driver>>> UpdateDriver(Driver request)
        {
            var driver = drivers.Find(d => d.Id == request.Id);
            if (driver == null)
                return BadRequest("Driver Not Found");

            driver.DriverName = request.DriverName;
            driver.DriverId = request.DriverId;     
            driver.DriverType = request.DriverType; 
            driver.IdNumber = request.IdNumber; 
            driver.Status = request.Status;

            return Ok(driver);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Driver>>> DeleteDriver(int id)
        {
            var driver = drivers.Find(d => d.Id == id);
            if (driver == null)
                return BadRequest("Driver Not Found");
            drivers.Remove(driver);
            return Ok(driver);
        }
    }
}
