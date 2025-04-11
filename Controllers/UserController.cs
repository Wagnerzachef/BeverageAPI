using Microsoft.AspNetCore.Mvc;
using BeverageAPI.Repositories;
using BeverageAPI.Models.Requests;
using BeverageAPI.Models;

namespace BeverageAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        // Constructor to inject the DbContext
        public UserController(IUserRepository repository)
        {
            userRepository = repository;
        }

        [HttpPost("", Name = "CreateUser")]
        public User CreateUser(UserCreateRequest request){
            // Map the user create request to the actual ski brand.
            User user = new User();
            user.Name = request.Name;
            user.Age = request.Age;
            
            return userRepository.CreateUser(user);
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public User? GetUserById(int id) {
        // Returns the User with the given id (or null if not found).
            return userRepository.GetUserById(id);
        }

        [HttpGet("/Users", Name = "GetUsers")]
        public List<User> GetUsers() {
         // Returns the list of Users (or an empty collection if none existed).
          return userRepository.GetUsers();
        }

        [HttpPut("{id}", Name = "UpdateUserById")]
        public User UpdateUserById(int id, UserCreateRequest request) {
            // Find the ski brand we need to update by its ID.
            User? userToUpdate = userRepository.GetUserById(id);

            // If it's null (not found) throw an exception stating such.
            if (userToUpdate == null) {
                throw new Exception($"User {id} was not found.");
            }

            // Map our updated data to our existing ski brand.
            userToUpdate.Age = request.Age;
            userToUpdate.Name = request.Name;

            // Return our updated ski brand to the requester.
            return userRepository.UpdateUserById(userToUpdate);
        }


        [HttpDelete("{id}", Name = "DeleteUserById")]
        public void DeleteUserById(int id) {
            // Find the user we need to delete by its ID.
            User? userToDelete = userRepository.GetUserById(id);

            if (userToDelete == null) {
                throw new Exception($"Ski brand {id} was not found.");
            }

            userRepository.DeleteUserById(userToDelete);
        }

        // CRUD endpoints will be added here
    }
}