using System.Text.Json.Serialization;

namespace BeverageAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }

        // Navigation property to represent one (user) to many (beverages) relationship.
        [JsonIgnore]
        public List<BeverageLog> BeveragesLog { get; set; }
        
    }
}