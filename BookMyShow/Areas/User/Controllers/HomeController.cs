using BookMyShow.Data.Repository.IRepository;
using BookMyShow.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShow.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly IRepository<Movie> _repository;

        public HomeController(IRepository<Movie> repository)
        {
            this._repository = repository;
        }

        public IActionResult Index()
        {
            IEnumerable<Movie> movies = _repository.GetAll();
            return View(movies);
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
