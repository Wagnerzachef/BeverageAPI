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

        public BeverageLog CreateBeverage(BeverageLog beverage)
        {
            dbContext.BeveragesLog.Add(beverage);
            dbContext.SaveChanges();
            return beverage;
        }

        public void DeleteBeverageById(BeverageLog beverageLogToDelete)
        {
            dbContext.BeveragesLog.Remove(beverageLogToDelete);
            dbContext.SaveChanges();
        }

        public BeverageLog? GetBeverageById(int id, bool includeUserData = false)
        {
            var query = dbContext.BeveragesLog.AsQueryable();
            if (includeUserData) {
                query = query.Include(beverage => beverage.User);
            }
            return query.FirstOrDefault(beverage => beverage.Id == id);
        }

        public List<BeverageLog?> GetBeverageByUserId(int id, bool includeUserData = false)
        {
            var query = dbContext.BeveragesLog.AsQueryable();
            if (includeUserData) {
                query = query.Include(beverage => beverage.User);
            }
            return query.Where(beverage => beverage.UserId == id).ToList();
        }

        public List<BeverageLog> GetBeverages()
        {
            return dbContext.BeveragesLog.ToList();
        }

        public List<BeverageLog> GetBeveragesWithUser()
        {
            return dbContext.BeveragesLog.Include(beverage => beverage.User).ToList();
        }
    }
}