using BookMyShow.Data.Repository.IRepository;
using BookMyShow.Models;
using BookMyShow.Models.ViewModels;
using BookMyShow.Utilities;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookMyShow.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class MovieController : Controller
    {
        private readonly IRepository<Movie> _repository;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public MovieController(IRepository<Movie> repository, IWebHostEnvironment hostingEnvironment)
        {
            _repository = repository;
            this._hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<Movie> movies = _repository.GetAll().OrderByDescending(m => m.ReleaseDate);
            return View(movies);
        }

        public IActionResult Create()
        {
            return View(new Movie { });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie, IFormFile? file)
        {
            movie.Id = Guid.NewGuid();
            if (movie.ReleaseDate > DateOnly.FromDateTime(DateTime.Now))
            {
                movie.MovieState = 2;
            }
            else
            {
                movie.MovieState = 1;
            }
            string ext = Path.GetExtension(file.FileName);
            string fileName = Guid.NewGuid().ToString() + ext;
            string imagePath = Path.Combine(_hostingEnvironment.WebRootPath, @"images");

            using (var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            movie.Poster = @"\images\" + fileName;
            _repository.Create(movie);
            _repository.Save();
            return RedirectToAction("Index");
        }
        public IActionResult Details(Guid id)
        {
            Movie movie = _repository.Get(m => m.Id == id);
            return View(movie);
        }

        public IActionResult Update(Guid id)
        {
            Movie movie = _repository.Get(m => m.Id == id);
            IEnumerable<SelectListItem> MovieState = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Active",
                    Value = "0"
                },
                new SelectListItem
                {
                    Text = "Inctive",
                    Value = "1"
                },
                new SelectListItem
                {
                    Text = "Upcoming",
                    Value = "2"
                },
                new SelectListItem
                {
                    Text = "Banned",
                    Value = "3"
                }
            };
            UpdateMovieVM updateMovieVM = new UpdateMovieVM
            {
                Movie = movie,
                MovieState = MovieState
            };
            return View(updateMovieVM);
        }
        [HttpPost]
        public IActionResult Update(UpdateMovieVM updateMovieVM)
        {
            _repository.Update(updateMovieVM.Movie);
            _repository.Save();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Guid id)
        {
            Movie movieFromDb = _repository.Get(m => m.Id == id);
            return View(movieFromDb);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(Guid id)
        {
            Movie movie = _repository.Get(m => m.Id == id);
            _repository.Delete(movie);
            _repository.Save();
            return RedirectToAction("Index");
        }
    }
}
