using System.ComponentModel.DataAnnotations;

namespace BeverageAPI.Models.Requests {
    public class BeverageCreateRequest {

        [Required]
        [MinLength(1)]
        [MaxLength(255)]
        public string BeverageName { get; set; }

        [Required]
        public int FluidOz {get; set;}

        public int CaffeineContent {get; set;}

    }
}