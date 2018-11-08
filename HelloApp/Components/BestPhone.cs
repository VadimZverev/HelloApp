using HelloApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HelloApp.Components
{
    public class BestPhone : ViewComponent
    {
        IRepository repo;
        public BestPhone(IRepository r)
        {
            repo = r;
        }

        public string Invoke(int maxPrice, int minPrice = 0)
        {
            int count = repo.GetPhones().Count(x => x.Price < maxPrice && x.Price > minPrice);
            return $"В диапозоне от {minPrice} до {maxPrice} найдено {count} модели(ей)";
        }
    }
}
