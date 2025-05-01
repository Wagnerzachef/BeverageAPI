namespace BeverageAPI.Models {
    public class BeverageLog {
        public int Id { get; set; }
        
        public DateTime DateDrank { get; set; }
        

        // Relational Information (A Beverage is drank by one person)
        
        // Foreign Key
        // This column links Beverage to User by storing the User's Id (primary key).
        public int BeverageId {get; set;}
        public int UserId {get; set; }

        // Navigation Property
        // This allows you to access the related User object directly in code.
        public User User { get; set; }
        public Beverage beverage {get; set;}
    }
}