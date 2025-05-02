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
            
            BeverageLog? beverageLogToGet = beverageRepository.GetBeverageLogById(id);

            if (beverageLogToGet != null) {
                return beverageRepository.GetBeverageLogById(id, includeUserData);
            } else {
                throw new EntityNotFoundException($"Beverage Log with ID {id} could not be found. Unable to get Beverage Log.");
            }
            
        }

        [HttpGet("/BeverageLogs/{userId}", Name = "GetBeverageLogByUserId")]
        public List<BeverageLog?> GetBeverageLogByUserId(int userId, [FromQuery] bool includeUserData = false) 
        {
            
            List<BeverageLog?> beverageLogToGet = beverageRepository.GetBeverageLogsByUserId(userId);

            if (beverageLogToGet.Count != 0) {
                return beverageRepository.GetBeverageLogsByUserId(userId, includeUserData);
            } else {
                throw new EntityNotFoundException($"Beverage Logs with User ID {userId} could not be found. Unable to get Beverage Logs.");
            }
        }

        /// <summary>
        /// Gets a list of beverage logs
        /// </summary>
        /// <returns>A list of beverage log objects</returns>
        /// <exception cref="EntityNotFoundException">Happens if the list is empty</exception>
        [HttpGet("/BeverageLog", Name = "GetBeverageLogs")]
        public List<BeverageLog> GetBeverageLogs() 
        {
            List<BeverageLog?> beverageLogs = beverageRepository.GetBeverageLogs();

            if (beverageLogs.Count != 0) {
                return beverageRepository.GetBeverageLogs();
            } else {
                throw new EntityNotFoundException($"Beverage Logs could not be found. Please add beverage logs.");
            }
            
        }

        /// <summary>
        /// Get a list of beverage logs with user and beverage data
        /// </summary>
        /// <returns>A list of users</returns>
        /// <exception cref="EntityNotFoundException">If the list is empty</exception>
        [HttpGet("/BeverageLogWithUsers", Name = "GetBeverageLogsWithUser")]
        public List<BeverageLog> GetBeverageLogsWithUser() 
        {
            
            List<BeverageLog?> beverageLogs = beverageRepository.GetBeverageLogsWithUser();

            if (beverageLogs.Count != 0) {
                return beverageRepository.GetBeverageLogsWithUser();
            } else {
                throw new EntityNotFoundException($"Unable to get Beverage Logs. Please add beverage logs.");
            }
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
            
            List<BeverageLog?> beverageLogToDelete = beverageRepository.GetBeverageLogsByUserId(userId);

            if (beverageLogToDelete.Count != 0) {
                beverageRepository.deleteBeverageLogsByUserId(userId);
            } else {
                throw new EntityNotFoundException($"Beverage Logs with User ID {userId} could not be found. Unable to Delete Beverage Logs.");
            }

        }
    }
}