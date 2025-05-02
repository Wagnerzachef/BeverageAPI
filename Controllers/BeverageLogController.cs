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

        /// <summary>
        /// Makes a beverage log object and adds it to the database
        /// </summary>
        /// <param name="request">The beverage log create request to be added</param>
        /// <returns>The added beverage log</returns>
        /// <exception cref="InvalidInputException">The beverage create request was invalid</exception>
        [HttpPost("", Name = "CreateBeverageLog")]
        public BeverageLog CreateBeverageLog(BeverageLogCreateRequest request) 
        {
            // Map BeverageLogCreateRequest to BeverageLog to create a beverage log.
            BeverageLog beverage = new BeverageLog (); 
                beverage.DateDrank = request.DateDrank;
                beverage.UserId = request.UserId;
                beverage.BeverageId = request.BeverageId;
            

            if(!ModelState.IsValid) {
                throw new InvalidInputException("Beverage Create Request is invalid", ModelState);
            } else {
                return beverageRepository.CreateBeverageLog(beverage);
            }
        }

        [HttpGet("/BeverageLog/{id}", Name = "GetBeverageLogById")]
        public BeverageLog? GetBeverageLogById(int id, [FromQuery] bool includeUserData = false) 
        {
            return beverageRepository.GetBeverageLogById(id, includeUserData);
        }

        [HttpGet("/BeverageLogs/{userId}", Name = "GetBeverageLogByUserId")]
        public List<BeverageLog?> GetBeverageLogByUserId(int userId, [FromQuery] bool includeUserData = false) 
        {
            return beverageRepository.GetBeverageLogsByUserId(userId, includeUserData);
        }

        /// <summary>
        /// Gets a list of beverage logs without extra data
        /// </summary>
        /// <returns>A list of beverage logs</returns>
        [HttpGet("/BeverageLog", Name = "GetBeverageLogs")]
        public List<BeverageLog> GetBeverageLogs() 
        {
            return beverageRepository.GetBeverageLogs();
        }

        /// <summary>
        /// Gets a list of beverage logs with user and beverage data
        /// </summary>
        /// <returns>a list of beverage logs</returns>
        [HttpGet("/BeverageLogWithUsers", Name = "GetBeverageLogsWithUser")]
        public List<BeverageLog> GetBeverageLogsWithUser() 
        {
            return beverageRepository.GetBeverageLogsWithUser();
        }

        [HttpDelete("{id}", Name = "DeleteBeverageLogById")]
        public void DeleteBeverageById(int id) 
        {
            // Find the beverage log we need to delete by its ID.
            BeverageLog? beverageLogToDelete = beverageRepository.GetBeverageLogById(id);

            if (beverageLogToDelete != null) {
                beverageRepository.DeleteBeverageLogById(beverageLogToDelete);
            } else {
                throw new EntityNotFoundException($"Beverage Log with ID {id} could not be found. Unable to Delete Beverage Log.");
            }

        }
        [HttpDelete("/BeverageLog/Delete/{userId}", Name = "DeleteBeverageLogByUserId")]
        public void DeleteBeverageLogsByUserId(int userId) 
        {
            // Find the beverage logs we need to delete by their user ID.
            beverageRepository.deleteBeverageLogsByUserId(userId);

        }
    }
}