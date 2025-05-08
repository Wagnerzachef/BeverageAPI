using Microsoft.AspNetCore.Mvc;
using BeverageAPI.Repositories;
using BeverageAPI.Models.Requests;
using BeverageAPI.Models;
using CIS106ExceptionHandling.exceptions;

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
        public User CreateUser(UserCreateRequest request)
        {
            // Map the user create request to the actual ski brand.
            User user = new User();
            user.Name = request.Name;
            user.Dob = request.Dob;

            if(!ModelState.IsValid) {
                throw new InvalidInputException("User Create Request is invalid", ModelState);
            } else {
                return userRepository.CreateUser(user);
            }
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public User? GetUserById(int id) 
        {
        // Returns the User with the given id or throws an exception.
            
            User? UserToGet = userRepository.GetUserById(id);

            if (UserToGet != null) {
                return userRepository.GetUserById(id);
            } else {
                throw new EntityNotFoundException($"User with ID {id} could not be found. Unable to Get User.");
            }
        }

        [HttpGet("/Users", Name = "GetUsers")]
        public List<User> GetUsers()
        {
         // Returns the list of Users (or an empty collection if none existed).
          
          List<User?> users = userRepository.GetUsers();

            if (users.Count != 0) {
                return userRepository.GetUsers();
            } else {
                throw new EntityNotFoundException($"Users could not be found. Please add Users.");
            }
        }

        [HttpPut("{id}", Name = "UpdateUserById")]
        public User UpdateUserById(int id, UserCreateRequest request) 
        {
            // Find the ski brand we need to update by its ID.
            User? userToUpdate = userRepository.GetUserById(id);

            // If it's null (not found) throw an exception stating such.
            if (userToUpdate != null) {
                // Map our updated data to our existing ski brand.
                userToUpdate.Dob = request.Dob;
                userToUpdate.Name = request.Name;

                // Return our updated ski brand to the requester.
                return userRepository.UpdateUserById(userToUpdate);
            } else {
                throw new EntityNotFoundException($"User with ID {id} could not be found. Unable to update user.");
            }

            
        }


        [HttpDelete("{id}", Name = "DeleteUserById")]
        public void DeleteUserById(int id) 
        {
            // Find the user we need to delete by its ID.
            User? userToDelete = userRepository.GetUserById(id);

            if (userToDelete != null) {
                userRepository.DeleteUserById(userToDelete);
            } else {
                throw new EntityNotFoundException($"User with ID {id} could not be found. Unable to Delete user.");
            }

        }

        

        // CRUD endpoints will be added here
    }
}