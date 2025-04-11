namespace BeverageAPI.Models {
    public class Beverage {
        public int Id { get; set; }
        public string BeverageName { get; set; }
        public int FluidOz {get; set;}
        public int CaffeineConent {get; set;}
        public DateTime DateDrank { get; set; }
        

        // Relational Information (A Beverage is drank by one person)
        
        // Foreign Key
        // This column links Beverage to User by storing the User's Id (primary key).
        public int UserId {get; set; }

        // Navigation Property
        // This allows you to access the related User object directly in code.
        public User User { get; set; }
    }
}