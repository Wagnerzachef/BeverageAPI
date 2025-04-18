using BeverageAPI.Models;

namespace BeverageAPI.Repositories{
    public interface IBeverageRepository{

        Beverage CreateBeverage(Beverage beverage);
        Beverage? GetBeverageById(int id, bool includeUserData = false);
        List<Beverage> GetBeverages();
        List<Beverage> GetBeveragesWithUser();
    }
}