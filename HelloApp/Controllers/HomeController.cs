using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace HelloApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _appEnvironment;
        public HomeController(IHostingEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        // отправка файла с помощью физического пути файла
        public IActionResult GetFile()
        {
            // Путь к файлу
            string file_path = Path.Combine(_appEnvironment.ContentRootPath, "Files/book.pdf");
            // Тип файла - content-type
            string file_type = "application/pdf";
            // Имя файла - необязательный параметр
            string file_name = "book.pdf";
            return PhysicalFile(file_path, file_type, file_name);
        }

        // Отправка файла через массив байт
        public FileResult GetBytes()
        {
            string path = Path.Combine(_appEnvironment.ContentRootPath, "Files/book.pdf");
            byte[] mas = System.IO.File.ReadAllBytes(path);
            string file_type = "application/pdf";
            string file_name = "book2.pdf";
            return File(mas, file_type, file_name);
        }

        // Отправка файла через поток
        public FileResult GetStream()
        {
            string path = Path.Combine(_appEnvironment.ContentRootPath, "Files/book.pdf");
            FileStream fs = new FileStream(path, FileMode.Open);
            string file_type = "application/pdf";
            string file_name = "book3.pdf";
            return File(fs, file_type, file_name);
        }
    }
}