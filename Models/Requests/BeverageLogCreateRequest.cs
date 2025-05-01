using System.ComponentModel.DataAnnotations;

namespace BeverageAPI.Models.Requests {
    public class BeverageLogCreateRequest {

        [Required]
        public DateTime DateDrank { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int BeverageId {get; set;}
    }
}