using BookMyShow.Data.Repository.IRepository;
using BookMyShow.Models;
using BookMyShow.Models.ViewModels;
using BookMyShow.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookMyShow.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ShowController : Controller
    {
        private readonly IRepository<Show> _repository;
        private readonly IRepository<Movie> _movieRepository;
        private readonly IRepository<Theatre> _theatreRepository;

        public ShowController(IRepository<Show> repository, 
            IRepository<Movie> movieRepository, 
            IRepository<Theatre> theatreRepository)
        {
            _repository = repository;
            _movieRepository = movieRepository;
            _theatreRepository = theatreRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<Show> shows = _repository.GetAll(includeProperties: "Movie,Theatre");
            return View(shows);
        }

        public IActionResult Create()
        {
            IEnumerable<SelectListItem> showTypes = new List<SelectListItem> {
                new SelectListItem
                {
                    Text = SD.ShowType_2D,
                    Value = SD.ShowType_2D
                },
                new SelectListItem
                {
                    Text = SD.ShowType_3D,
                    Value = SD.ShowType_3D
                },
                new SelectListItem
                {
                    Text = SD.ShowType_4D,
                    Value = SD.ShowType_4D
                },
                new SelectListItem
                {
                    Text = SD.ShowType_4DX,
                    Value = SD.ShowType_4DX
                },
                new SelectListItem
                {
                    Text = SD.ShowType_MX4D,
                    Value = SD.ShowType_MX4D
                }
            };
            IEnumerable<SelectListItem> movies = _movieRepository.GetAll().OrderByDescending(m => m.ReleaseDate).ToList().Select(
                i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
            IEnumerable<SelectListItem> theatres = _theatreRepository.GetAll().ToList().Select(
                t => new SelectListItem
                {
                    Text = t.Name,
                    Value = t.Id.ToString()
                });
            CreateShowVM createShowVM = new CreateShowVM
            {
                MovieDD = movies,
                TheatreDD = theatres,
                ShowTypeDD = showTypes,
                Show = new Show { }
            };
            return View(createShowVM);
        }
        [HttpPost]
        public IActionResult Create(Show show)
        {
            show.Id = Guid.NewGuid();
            _repository.Create(show);
            _repository.Save();
            return RedirectToAction("Index");
        }
        public IActionResult Details(Guid id)
        {
            Show show = _repository.Get(m => m.Id == id, includeProperties: "Movie,Theatre");
            return View(show);
        }

        public IActionResult Update(Guid id)
        {
            IEnumerable<SelectListItem> showTypes = new List<SelectListItem> {
                new SelectListItem
                {
                    Text = SD.ShowType_2D,
                    Value = SD.ShowType_2D
                },
                new SelectListItem
                {
                    Text = SD.ShowType_3D,
                    Value = SD.ShowType_3D
                },
                new SelectListItem
                {
                    Text = SD.ShowType_4D,
                    Value = SD.ShowType_4D
                },
                new SelectListItem
                {
                    Text = SD.ShowType_4DX,
                    Value = SD.ShowType_4DX
                },
                new SelectListItem
                {
                    Text = SD.ShowType_MX4D,
                    Value = SD.ShowType_MX4D
                }
            };
            IEnumerable<SelectListItem> movies = _movieRepository.GetAll().OrderByDescending(m => m.ReleaseDate).ToList().Select(
                i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
            IEnumerable<SelectListItem> theatres = _theatreRepository.GetAll().ToList().Select(
                t => new SelectListItem
                {
                    Text = t.Name,
                    Value = t.Id.ToString()
                });
            Show showFromDb = _repository.Get(m => m.Id == id, includeProperties: "Movie,Theatre");
            CreateShowVM createShowVM = new CreateShowVM
            {
                MovieDD = movies,
                TheatreDD = theatres,
                ShowTypeDD = showTypes,
                Show = showFromDb
            };
            return View(createShowVM);
        }
        [HttpPost]
        public IActionResult Update(Show show)
        {
            _repository.Update(show);
            _repository.Save();
            return RedirectToAction("Details", new { id = show.Id });
        }
        public IActionResult Delete(Guid id)
        {
            Show showFromDb = _repository.Get(m => m.Id == id, includeProperties: "Movie,Theatre");
            return View(showFromDb);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(Guid id)
        {
            Show show = _repository.Get(m => m.Id == id);
            _repository.Delete(show);
            _repository.Save();
            return RedirectToAction("Index");
        }
    }
}
