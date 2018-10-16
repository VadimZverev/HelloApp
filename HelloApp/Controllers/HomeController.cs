using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HelloApp.Controllers
{
    public class HomeController : Controller
    {
        // Вывод всех имеющихся заголовков
        public void Index()
        {
            string table = "";
            // Добавление в строку заголовком через запрос к ним
            foreach (var header in Request.Headers)
            {
                table += $"<tr><td>{header.Key}</td><td>{header.Value}</td></tr>";
            }
            // Ответ сформированной строки в браузер
            Response.WriteAsync(string.Format($"<table>{table}</table>"));
        }
    }
}