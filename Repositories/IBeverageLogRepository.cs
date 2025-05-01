using BeverageAPI.Models;

namespace BeverageAPI.Repositories{
    public interface IBeverageLogRepository{

        BeverageLog CreateBeverage(BeverageLog beverage);
        BeverageLog? GetBeverageById(int id, bool includeUserData = false);
        void DeleteBeverageById(BeverageLog beverageLogToDelete);
        List<BeverageLog> GetBeverages();
        List<BeverageLog> GetBeveragesWithUser();
        List<BeverageLog?> GetBeverageByUserId(int id, bool includeUserData = false);
    }
}