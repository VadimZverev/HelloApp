﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HelloApp.Components
{
    public class PhonesList : ViewComponent
    {
        Dictionary<string, int> phones;
        public PhonesList()
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

        public IViewComponentResult Invoke(int maxPrice)
        {
            var items = phones.Where(p => p.Value <= maxPrice).ToList();

            return View("Phones",items);
        }
    }
}
