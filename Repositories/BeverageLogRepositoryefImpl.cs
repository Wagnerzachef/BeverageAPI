using BeverageAPI.Models;
using CIS106ExceptionHandling.exceptions;
using Microsoft.EntityFrameworkCore;

namespace BeverageAPI.Repositories{
    public class BeverageLogRepositoryEfImpl : IBeverageLogRepository
    {
        private readonly BeverageDbContext dbContext;

        public BeverageLogRepositoryEfImpl(BeverageDbContext userDbContext) {
            dbContext = userDbContext;
        }

        /// <summary>
        /// Method to add a beverage log to the database
        /// </summary>
        /// <param name="beverage">The beverage log to be added</param>
        /// <returns>the beverage log added</returns>
        public BeverageLog CreateBeverageLog(BeverageLog beverage)
        {
            dbContext.BeveragesLog.Add(beverage);
            dbContext.SaveChanges();
            return beverage;
        }

        /// <summary>
        /// Deletes a beverage log from the database
        /// And catchs an dbupdateexception
        /// </summary>
        /// <param name="beverageLogToDelete">The beverage log that will be deleted</param>
        public void DeleteBeverageLogById(BeverageLog beverageLogToDelete)
        {
            try {
                dbContext.BeveragesLog.Remove(beverageLogToDelete);
                dbContext.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine("Could not delete beverage log from database. Make sure the log exists. " + e.Message);
            }
            
        }

        /// <summary>
        /// Deletes beverage logs that include user id from the database
        /// </summary>
        /// <param name="userId">the user whose logs will be deleted</param>
        public void deleteBeverageLogsByUserId(int userId)
        {
            dbContext.BeveragesLog.Where(beverage => beverage.UserId == userId).ExecuteDelete();
            
        }

        /// <summary>
        /// Method that gets a beverage log by id and can include user and beverage data
        /// </summary>
        /// <param name="id">The beverage log id to look up</param>
        /// <param name="includeUserData">Boolean value to add user and beverage data to look up</param>
        /// <returns>A beverage log</returns>
        public BeverageLog? GetBeverageLogById(int id, bool includeUserData = false)
        {
            var query = dbContext.BeveragesLog.AsQueryable();
            if (includeUserData) {
                query = query.Include(beverage => beverage.User);
                query = query.Include(beverage => beverage.Beverage);
            }
            return query.FirstOrDefault(beverage => beverage.Id == id);
        }

        /// <summary>
        /// Get a list of beverage logs using a user id
        /// </summary>
        /// <param name="userId">The user id the will be looked up</param>
        /// <param name="includeUserData">Boolean to include user and beverage data when looking up beverage logs</param>
        /// <returns>List of beverage log objects</returns>
        public List<BeverageLog> GetBeverageLogsByUserId(int userId, bool includeUserData = false)
        {
            var query = dbContext.BeveragesLog.AsQueryable();
            if (includeUserData) {
                query = query.Include(beverage => beverage.User);
                query = query.Include(beverage => beverage.Beverage);
            }
            return query.Where(beverage => beverage.UserId == userId).ToList();
        }

        /// <summary>
        /// Gets a list of beverages without user or beverage data
        /// </summary>
        /// <returns>a list of beverage logs</returns>
        public List<BeverageLog> GetBeverageLogs()
        {
            return dbContext.BeveragesLog.ToList();
        }

        /// <summary>
        /// Get a list of beverge logs with user and beverage data
        /// </summary>
        /// <returns>A list of beverage logs with user and beverage data</returns>
        public List<BeverageLog> GetBeverageLogsWithUser()
        {
            return dbContext.BeveragesLog.Include(beverage => beverage.User).Include(beverage => beverage.Beverage).ToList();
        }
    }
}