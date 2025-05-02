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

        /// <summary>
        /// Creates a beverage object and adds it to the database
        /// </summary>
        /// <param name="request">The beverage to be created</param>
        /// <returns>The created beverage</returns>
        /// <exception cref="InvalidInputException">The create request is invalid</exception>
        [HttpPost("", Name = "CreateBeverage")]
        public Beverage CreateBeverage(BeverageCreateRequest request) 
        {
            // Map BeverageCreateRequest to Beverage to create.
            Beverage beverage = new Beverage (); 
                beverage.BeverageName = request.BeverageName;
                beverage.FluidOz = request.FluidOz;
                beverage.CaffeineContent = request.CaffeineConent;
            

            if(!ModelState.IsValid) {
                throw new InvalidInputException("Beverage Create Request is invalid", ModelState);
            } else {
                return beverageRepository.CreateBeverage(beverage);
            }
        }

        [HttpGet("{id}", Name = "GetBeverageById")]
        public Beverage? GetBeverageById(int id) 
        {
            //gets beverage by id
            return beverageRepository.GetBeverageById(id);
        }

        

        [HttpGet("/Beverages", Name = "GetBeverages")]
        public List<Beverage> GetBeverages() 
        {
            return beverageRepository.GetBeverages();
        }
        

        [HttpDelete("{id}", Name = "DeleteBeverageById")]
        public void DeleteBeverageById(int id) 
        {
            // Find the beverage we need to delete by its ID.
            Beverage? beverageToDelete = beverageRepository.GetBeverageById(id);

            if (beverageToDelete != null) {
                beverageRepository.DeleteBeverageById(beverageToDelete);
            } else {
                throw new EntityNotFoundException($"Beverage with ID {id} could not be found. Unable to Delete Beverage.");
            }

        }
    }
}