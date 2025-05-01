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
    public class BeverageLogController : ControllerBase
    {
        private readonly IBeverageLogRepository beverageRepository;

        public BeverageLogController(IBeverageLogRepository context)
        {
            beverageRepository = context;
        }

        [HttpPost("", Name = "CreateBeverageLog")]
        public BeverageLog CreateBeverageLog(BeverageLogCreateRequest request) {
            // Map BeverageCreateRequest to Beverage to create.
            BeverageLog beverage = new BeverageLog (); 
                beverage.DateDrank = request.DateDrank;
                beverage.UserId = request.UserId;
                beverage.BeverageId = request.BeverageId;
            

            if(!ModelState.IsValid) {
                throw new InvalidInputException("Beverage Create Request is invalid", ModelState);
            } else {
                return beverageRepository.CreateBeverage(beverage);
            }
        }

        [HttpGet("{id}", Name = "GetBeverageLogById")]
        public BeverageLog? GetBeverageLogById(int id, [FromQuery] bool includeUserData = false) {
            // This allows us to dynamically modify the query before executing it.
            return beverageRepository.GetBeverageById(id, includeUserData);
        }

        [HttpGet("/BeverageLog/{userId}", Name = "GetBeverageLogByUserId")]
        public List<BeverageLog?> GetBeverageLogByUserId(int userId, [FromQuery] bool includeUserData = false) {
            // This allows us to dynamically modify the query before executing it.
            return beverageRepository.GetBeverageByUserId(userId, includeUserData);
        }

        [HttpGet("/BeverageLog", Name = "GetBeverageLogs")]
        public List<BeverageLog> GetBeverageLogs() {
            return beverageRepository.GetBeverages();
        }
        [HttpGet("/BeverageLogWithUsers", Name = "GetBeverageLogsWithUser")]
        public List<BeverageLog> GetBeverageLogsWithUser() {
            return beverageRepository.GetBeveragesWithUser();
        }

        [HttpDelete("{id}", Name = "DeleteBeverageLogById")]
        public void DeleteBeverageById(int id) {
            // Find the user we need to delete by its ID.
            BeverageLog? beverageLogToDelete = beverageRepository.GetBeverageById(id);

            if (beverageLogToDelete != null) {
                beverageRepository.DeleteBeverageById(beverageLogToDelete);
            } else {
                throw new EntityNotFoundException($"Beverage Log with ID {id} could not be found. Unable to Delete user.");
            }

        }
    }
}