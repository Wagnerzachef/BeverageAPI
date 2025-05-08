using BeverageAPI.Models;

namespace BeverageAPI.Repositories{
    public interface IBeverageLogRepository{

        BeverageLog CreateBeverageLog(BeverageLog beverage);
        BeverageLog? GetBeverageLogById(int id, bool includeUserData = false);
        void DeleteBeverageLogById(BeverageLog beverageLogToDelete);
        List<BeverageLog> GetBeverageLogs();
        List<BeverageLog> GetBeverageLogsWithUser();
        List<BeverageLog> GetBeverageLogsByUserId(int id, bool includeUserData = false);
        void deleteBeverageLogsByUserId(int userId);
    }
}