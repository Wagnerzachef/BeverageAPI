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

        /// <summary>
        /// Adds a user to the database
        /// </summary>
        /// <param name="user">The user to be added</param>
        /// <returns>The added user</returns>
        public User CreateUser(User user)
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return user;
        }

        /// <summary>
        /// Deletes a user from the database
        /// </summary>
        /// <param name="userToDelete">The user to be deleted</param>
        public void DeleteUserById(User userToDelete)
        {
            dbContext.Users.Remove(userToDelete);
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Gets a user with a matching id
        /// </summary>
        /// <param name="id">The id to look up</param>
        /// <returns>The user with a matching id</returns>
        public User? GetUserById(int id)
        {
            return dbContext.Users.Find(id);
        }

        /// <summary>
        /// Get a list of all users
        /// </summary>
        /// <returns>A list of users</returns>
        public List<User> GetUsers()
        {
            return dbContext.Users.ToList();
        }

        /// <summary>
        /// Updates a user in the database
        /// </summary>
        /// <param name="userToChange">The changed user that will be updated</param>
        /// <returns>The updated user</returns>
        public User UpdateUserById(User userToChange)
        {
            try {
                dbContext.Users.Update(userToChange);
                dbContext.SaveChanges();
            }
            catch (DbUpdateException e){
                Console.WriteLine("Error: Could not save changes to database. Make sure that the User you are trying to change exists. " + e.Message);
            }
            
            return userToChange;
        }
    }
}