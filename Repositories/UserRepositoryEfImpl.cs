using BeverageAPI.Models;

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

        public User UpdateUserById(User userToChange)
        {
            dbContext.Users.Update(userToChange);
            dbContext.SaveChanges();
            return userToChange;
        }
    }
}