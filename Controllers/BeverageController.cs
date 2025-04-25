using Microsoft.AspNetCore.Mvc;
using BeverageAPI.Repositories;
using BeverageAPI.Models.Requests;
using BeverageAPI.Models;
using Microsoft.EntityFrameworkCore;
using CIS106ExceptionHandling.exceptions;

namespace BeverageAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BeverageController : ControllerBase
    {
        private readonly IBeverageRepository beverageRepository;

        public BeverageController(IBeverageRepository context)
        {
            beverageRepository = context;
        }

        [HttpPost("", Name = "CreateBeverage")]
        public Beverage CreateBeverage(BeverageCreateRequest request) {
            // Map BeverageCreateRequest to Beverage to create.
            Beverage beverage = new Beverage (); 
                beverage.BeverageName = request.BeverageName;
                beverage.FluidOz = request.FluidOz;
                beverage.CaffeineConent = request.CaffeineConent;
                beverage.DateDrank = request.DateDrank;
                beverage.UserId = request.UserId;
            

            if(!ModelState.IsValid) {
                throw new InvalidInputException("Beverage Create Request is invalid", ModelState);
            } else {
                return beverageRepository.CreateBeverage(beverage);
            }
        }

        [HttpGet("{id}", Name = "GetBeverageById")]
        public Beverage? GetBeverageById(int id, [FromQuery] bool includeUserData = false) {
            // This allows us to dynamically modify the query before executing it.
            return beverageRepository.GetBeverageById(id, includeUserData);
        }

        [HttpGet("/Beverages", Name = "GetBeverages")]
        public List<Beverage> GetBeverages() {
            return beverageRepository.GetBeverages();
        }
        [HttpGet("/BeveragesWithUsers", Name = "GetBeveragesWithUser")]
        public List<Beverage> GetBeveragesWithUser() {
            return beverageRepository.GetBeveragesWithUser();
        }
    }
}