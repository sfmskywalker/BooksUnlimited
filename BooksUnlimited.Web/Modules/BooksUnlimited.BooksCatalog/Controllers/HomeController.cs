using System.Threading.Tasks;
using BooksUnlimited.Services.BooksCatalog.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BooksUnlimited.BooksCatalog.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IBooksCatalogService booksCatalogService)
        {
            this.booksCatalogService = booksCatalogService;
        }

        private readonly IBooksCatalogService booksCatalogService;

        public async Task<IActionResult> Index()
        {
            ViewBag.Books = await booksCatalogService.GetBooksAsync();
            return View();
        }
    }
}
