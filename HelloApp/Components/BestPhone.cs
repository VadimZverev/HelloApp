using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Collections.Generic;
using System.Linq;

namespace HelloApp.Components
{
    public class BestPhone : ViewComponent
    {
        Dictionary<string, int> phones;
        public BestPhone()
        {
            phones = new Dictionary<string, int>
            {
                {"iPhone 7", 56000 },
                {"Alcatel Idol S4", 26000 },
                {"Samsung Galaxy S7", 50000 },
                {"HP Elite x3", 56000 },
                {"Xiaomi Mi5S", 22000 },
                {"Meizu Pro 6", 22000 },
                {"Huawei Honor 8", 23000 },
                {"Google Pixel", 30000 }
            };
        }

        public IViewComponentResult Invoke()
        {
            var item = phones.OrderByDescending(p => p.Value).Take(1).FirstOrDefault();

            // Возвращает объект ViewComponent с тектовым контентов
            //return Content($"Самый дорогой телефон: {item.Key} - {item.Value.ToString("c")}");

            // Возвращает объект ViewComponent в виде фрагмента кода HTML
            return new HtmlContentViewComponentResult(
                new HtmlString($"<h3>Самый дорогой телефон: {item.Key} - {item.Value.ToString("c")}</h3>"));
        }
    }
}
