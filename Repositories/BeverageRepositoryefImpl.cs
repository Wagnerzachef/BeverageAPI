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

        public void DeleteBeverageById(Beverage beverageToDelete)
        {
            dbContext.Beverages.Remove(beverageToDelete);
            dbContext.SaveChanges();
        }

        public Beverage GetBeverageById(int id)
        {
            var query = dbContext.Beverages.AsQueryable();
            
            return query.FirstOrDefault(beverage => beverage.Id == id);
        }

        public List<Beverage> GetBeverages()
        {
            return dbContext.Beverages.ToList();
        }
    }
}