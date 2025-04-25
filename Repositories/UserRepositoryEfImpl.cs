using BeverageAPI.Models;
using CIS106ExceptionHandling.exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeverageAPI.Repositories{
    public class UserRepositoryEfImpl : IUserRepository
    {
        private readonly BeverageDbContext dbContext;

        public UserRepositoryEfImpl(BeverageDbContext userDbContext) {
            dbContext = userDbContext;
        }

        public User CreateUser(User user)
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return user;
        }

        public void DeleteUserById(User userToDelete)
        {
            dbContext.Users.Remove(userToDelete);
            dbContext.SaveChanges();
        }

        public User? GetUserById(int id)
        {
            return dbContext.Users.Find(id);
        }

        public List<User> GetUsers()
        {
            return dbContext.Users.ToList();
        }

        public User GetUserWithBeverage(int id, [FromQuery] bool includeUserData = false)
        {
            var query = dbContext.Users.AsQueryable();
            if (includeUserData) {
                query = query.Include(user => user.Beverages);
            }
            return query.FirstOrDefault(user => user.Id == id);
        }

        public User UpdateUserById(User userToChange)
        {
            try {
                dbContext.Users.Update(userToChange);
                dbContext.SaveChanges();
            }
            catch (DbUpdateException){
                Console.WriteLine("Error: Could not save changes to database.");
            }
            
            return userToChange;
        }
    }
}