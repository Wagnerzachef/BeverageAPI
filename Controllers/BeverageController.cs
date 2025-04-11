using Microsoft.AspNetCore.Mvc;
using BeverageAPI.Repositories;
using BeverageAPI.Models.Requests;
using BeverageAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BeverageAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BeverageController : ControllerBase
    {
        private readonly BeverageDbContext dbContext;

        public BeverageController(BeverageDbContext context)
        {
            dbContext = context;
        }

        [HttpPost("", Name = "CreateBeverage")]
        public Beverage CreateSkiModel(BeverageCreateRequest request) {
            // Map BeverageCreateRequest to Beverage to create.
            Beverage beverage = new Beverage { 
                BeverageName = request.BeverageName,
                FluidOz = request.FluidOz,
                CaffeineConent = request.CaffeineConent,
                DateDrank = request.DateDrank,
                UserId = request.UserId
            };

            // Add the Beverage to the change tracker and database.
            dbContext.Beverages.Add(beverage);
            dbContext.SaveChanges();

            // Return our newly saved Beverage.
            return beverage;
        }

        [HttpGet("{id}", Name = "GetBeverageById")]
        public Beverage? GetBeverageById(int id, [FromQuery] bool includeUserData = false) {
            // This allows us to dynamically modify the query before executing it.
            var query = dbContext.Beverages.AsQueryable();
            // Conditionally include user data if includeBrandData is true.
            if (includeUserData) {
                query = query.Include(beverage => beverage.User);
            }
            // Execute the query, returning the beverage that matches this criteria.
            return query.FirstOrDefault(beverage => beverage.Id == id);
        }

        [HttpGet("/Beverages", Name = "GetBeverages")]
        public List<Beverage> GetBeverages() {
            return dbContext.Beverages.ToList();
        }
        [HttpGet("/BeveragesWithUSers", Name = "GetBeveragesWithUser")]
        public List<Beverage> GetBeveragesWithUser() {
            return dbContext.Beverages.Include(beverage => beverage.User).ToList();
        }
    }
}