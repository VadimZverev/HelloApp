using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HelloApp.Components
{
    public class Header : ViewComponent
    {
        // В компоненте может быть только один метод Invoke() или InvokeAsync(),
        // иначе будет вызвано исключение.
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string htmlContent = string.Empty;

            using (FileStream fileStream = new FileStream("Files/header.html", FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    htmlContent = await reader.ReadToEndAsync();
                }
            }
            return new HtmlContentViewComponentResult(
                new HtmlString(htmlContent));
        }
    }
}
