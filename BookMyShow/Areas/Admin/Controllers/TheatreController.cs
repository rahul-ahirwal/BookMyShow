using BookMyShow.Data.Repository.IRepository;
using BookMyShow.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShow.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TheatreController : Controller
    {
        private readonly IRepository<Theatre> _repository;
        public TheatreController(IRepository<Theatre> repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            IEnumerable<Theatre> theatres = _repository.GetAll();
            return View(theatres);
        }

        public IActionResult Create()
        {
            return View(new Theatre { });
        }
        [HttpPost]
        public IActionResult Create(Theatre theatre)
        {
            theatre.Id = Guid.NewGuid();
            _repository.Create(theatre);
            _repository.Save();
            return RedirectToAction("Index");
        }
        public IActionResult Details(Guid id)
        {
            Theatre theatre = _repository.Get(m => m.Id == id);
            return View(theatre);
        }

        public IActionResult Update(Guid id)
        {
            Theatre theatreFromDb = _repository.Get(m => m.Id == id);
            return View(theatreFromDb);
        }
        [HttpPost]
        public IActionResult Update(Theatre theatre)
        {
            _repository.Update(theatre);
            _repository.Save();
            return RedirectToAction("Details", new { id = theatre.Id});
        }
        public IActionResult Delete(Guid id)
        {
            Theatre theatreFromDb = _repository.Get(m => m.Id == id);
            return View(theatreFromDb);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(Guid id)
        {
            Theatre theatre = _repository.Get(m => m.Id == id);
            _repository.Delete(theatre);
            _repository.Save();
            return RedirectToAction("Index");
        }
    }
}
