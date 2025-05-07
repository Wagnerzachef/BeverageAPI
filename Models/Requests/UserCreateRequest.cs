using System.ComponentModel.DataAnnotations;

namespace BeverageAPI.Models.Requests {
    public class UserCreateRequest {
        [Required]
        [MaxLength(255)]
        [MinLength(1)]
        public string Name {get; set;}
        [Required]
        public DateTime dob {get; set;}
    }
}