using System.Text.Json.Serialization;

namespace BeverageAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        // Navigation property to represent one (user) to many (beverages) relationship.
        [JsonIgnore]
        public List<Beverage> Beverages { get; set; }
        
    }
}