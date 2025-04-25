using BeverageAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeverageAPI.Repositories{
    public interface IUserRepository{

        User CreateUser(User user);
        User? GetUserById(int id);
        List<User> GetUsers();
        User UpdateUserById(User userToChange);
        void DeleteUserById(User userToDelete);
        
    }
}