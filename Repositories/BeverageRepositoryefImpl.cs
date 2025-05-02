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

        /// <summary>
        /// Adds a beverage object to the beverage table of the database
        /// </summary>
        /// <param name="beverage">The beverage to be added</param>
        /// <returns>The beverage object to be added</returns>
        public Beverage CreateBeverage(Beverage beverage)
        {
            dbContext.Beverages.Add(beverage);
            dbContext.SaveChanges();
            return beverage;
        }

        /// <summary>
        /// Deletes a beverage from the database
        /// </summary>
        /// <param name="beverageToDelete">The beverage that will be deleted</param>
        public void DeleteBeverageById(Beverage beverageToDelete)
        {
            dbContext.Beverages.Remove(beverageToDelete);
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Gets beverage by id from database
        /// </summary>
        /// <param name="id">The id to be looked up</param>
        /// <returns>The beverage with the matching id</returns>
        public Beverage GetBeverageById(int id)
        {
            var query = dbContext.Beverages.AsQueryable();
            
            return query.FirstOrDefault(beverage => beverage.Id == id);
        }

        /// <summary>
        /// Gets a list of all beverages in the database
        /// </summary>
        /// <returns>A list of beverage objects</returns>
        public List<Beverage> GetBeverages()
        {
            return dbContext.Beverages.ToList();
        }
    }
}