using CustomApp.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace CustomApp.Controllers
{
    public class CategoryController : Controller
    {


        public async Task<IActionResult> IndexAsync()
        {
            using var client = new HttpClient();
            var result = await client.GetFromJsonAsync<IEnumerable<Category>>(@"https://gokartapp.azurewebsites.net/GokartAPI/Categories");
            return View(result);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(Category item)
        {
            using var client = new HttpClient();
            var result = await client.PostAsJsonAsync(@"https://gokartapp.azurewebsites.net/GokartAPI/Categories", item);
            return View(item);
            
        }
    }
}
