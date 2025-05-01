using BeverageAPI.Models;

namespace BeverageAPI.Repositories{
    public interface IBeverageRepository{

        Beverage CreateBeverage(Beverage beverage);
        Beverage GetBeverageById(int id);
        void DeleteBeverageById(Beverage beverageToDelete);
        List<Beverage> GetBeverages();
        
    }
}