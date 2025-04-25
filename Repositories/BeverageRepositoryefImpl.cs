using BeverageAPI.Models;
using CIS106ExceptionHandling.exceptions;
using Microsoft.EntityFrameworkCore;

namespace BeverageAPI.Repositories{
    public class BeverageRepositoryEfImpl : IBeverageRepository
    {
        private readonly BeverageDbContext dbContext;

        public BeverageRepositoryEfImpl(BeverageDbContext userDbContext) {
            dbContext = userDbContext;
        }

        public Beverage CreateBeverage(Beverage beverage)
        {
            dbContext.Beverages.Add(beverage);
            dbContext.SaveChanges();
            return beverage;
        }

        public Beverage? GetBeverageById(int id, bool includeUserData = false)
        {
            var query = dbContext.Beverages.AsQueryable();
            if (includeUserData) {
                query = query.Include(beverage => beverage.User);
            }
            return query.FirstOrDefault(beverage => beverage.Id == id);
        }

        public List<Beverage> GetBeverages()
        {
            return dbContext.Beverages.ToList();
        }

        public List<Beverage> GetBeveragesWithUser()
        {
            return dbContext.Beverages.Include(beverage => beverage.User).ToList();
        }
    }
}