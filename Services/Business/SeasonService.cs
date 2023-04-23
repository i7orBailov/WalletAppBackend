using WalletAppBackend.Models.Enums;
using WalletAppBackend.Services.Interfaces;

namespace WalletAppBackend.Services.Business
{
    public class SeasonService : ISeasonService
    {
        public int GetDayNumberInSeason()
        {
            Dictionary<int, Season> seasonMap = new()
            {
                { 12, Season.Winter },
                { 1, Season.Winter },
                { 2, Season.Winter },
                { 3, Season.Spring },
                { 4, Season.Spring },
                { 5, Season.Spring },
                { 6, Season.Summer },
                { 7, Season.Summer },
                { 8, Season.Summer },
                { 9, Season.Autumn },
                { 10, Season.Autumn },
                { 11, Season.Autumn }
            };
            DateTime today = DateTime.Today;
            DateTime seasonStart = new(today.Year, (int)seasonMap[today.Month], 1);
            int dayNumber = (today - seasonStart).Days + 1;
            return dayNumber;
        }

    }
}
