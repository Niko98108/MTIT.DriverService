using Microsoft.EntityFrameworkCore;
using MTIT.DriverService.Data;
using MTIT.DriverService.Models;
namespace MTIT.DriverService.Controllers;

public static class DriverEndpointsClass
{
    public static void MapDriverEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Driver", async (MTITDriverServiceContext db) =>
        {
            return await db.Driver.ToListAsync();
        })
        .WithName("GetAllDrivers");

        routes.MapGet("/api/Driver/{id}", async (int Id, MTITDriverServiceContext db) =>
        {
            return await db.Driver.FindAsync(Id)
                is Driver model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetDriverById");

        routes.MapPut("/api/Driver/{id}", async (int Id, Driver driver, MTITDriverServiceContext db) =>
        {
            var foundModel = await db.Driver.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            //update model properties here

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateDriver");

        routes.MapPost("/api/Driver/", async (Driver driver, MTITDriverServiceContext db) =>
        {
            db.Driver.Add(driver);
            await db.SaveChangesAsync();
            return Results.Created($"/Drivers/{driver.Id}", driver);
        })
        .WithName("CreateDriver");

        routes.MapDelete("/api/Driver/{id}", async (int Id, MTITDriverServiceContext db) =>
        {
            if (await db.Driver.FindAsync(Id) is Driver driver)
            {
                db.Driver.Remove(driver);
                await db.SaveChangesAsync();
                return Results.Ok(driver);
            }

            return Results.NotFound();
        })
        .WithName("DeleteDriver");
    }
}
