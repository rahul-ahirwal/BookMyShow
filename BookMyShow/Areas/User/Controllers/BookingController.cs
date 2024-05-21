using BookMyShow.Data.Repository.IRepository;
using BookMyShow.Models;
using BookMyShow.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;

namespace BookMyShow.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class BookingController : Controller
    {
        private readonly IRepository<Show> _repository;
        private readonly IRepository<Movie> _movieRepository;
        private readonly IRepository<BookingCart> _bookingCartRepository;
        private readonly IRepository<Booking> _bookingRepository;

        public BookingController(IRepository<Show> repository,
            IRepository<Movie> movieRepository,
            IRepository<Booking> bookingRepository,
            IRepository<BookingCart> bookingCartRepository)
        {
            _repository = repository;
            _movieRepository = movieRepository;
            _bookingRepository = bookingRepository;
            _bookingCartRepository = bookingCartRepository;
        }

        public IActionResult Bookings()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            List<Booking> bookings = _bookingRepository.GetAll().Where(b => b.UserId == userId)
                .AsEnumerable().OrderByDescending(b => b.BookingTime).ToList();
            return View(bookings);
        }
        public IActionResult SelectShow(Guid id)
        {
            List<Show> shows = _repository.GetAll(includeProperties: "Movie,Theatre").AsQueryable()
                .Where(s => s.MovieId == id).ToList();
            Movie movie = new Movie();
            if (shows != null)
            {
                movie = _movieRepository.Get(m => m.Id == id);
            }
            List<Theatre> theatres = new List<Theatre>();
            foreach (var show in shows)
            {
                if (!theatres.Contains(show.Theatre))
                {
                    theatres.Add(show.Theatre);
                }
            }
            Dictionary<Guid, DateTimeData[]> keyValuePairs = new Dictionary<Guid, DateTimeData[]>();
            foreach (var show in shows)
            {
                List<DateTimeData> values = new List<DateTimeData>();
                foreach (var show1 in shows)
                {
                    Dictionary<TimeOnly, Guid> times = new Dictionary<TimeOnly, Guid>();
                    foreach (var show2 in shows)
                    {
                        if ((show1.TheatreId == show2.TheatreId) && (show1.TheatreId == show.TheatreId))
                        {
                            if (show1.Date == show2.Date)
                            {
                                times.Add(show2.Time, show2.Id);
                            }
                        }
                    }
                    if (show1.TheatreId == show.TheatreId)
                    {
                        if (values.FirstOrDefault(d => d.Date == show1.Date) == null)
                        {
                            values.Add(new DateTimeData { Date = show1.Date, Time = times.AsEnumerable().OrderBy(t => t.Key).ToDictionary<TimeOnly, Guid>() });
                        }
                    }
                }
                if (!keyValuePairs.ContainsKey(show.TheatreId))
                {
                    keyValuePairs.Add(show.TheatreId, values.ToArray());
                }
                else
                {

                }
            }

            BookShowVM bookShowVM = new BookShowVM()
            {
                Movie = movie,
                Theatres = theatres,
                ShowsData = keyValuePairs
            };
            return View(bookShowVM);
        }
        public IActionResult SelectSeats(Guid showId)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            Show show = _repository.Get(s => s.Id == showId, includeProperties:"Theatre");
            Movie movie = _movieRepository.Get(m => m.Id == show.MovieId);
            BookingCart cart = _bookingCartRepository.GetAll()
                .Where(bc => bc.MovieId == movie.Id)
                .Where(bc => bc.ShowId == show.Id)
                .Where(bc => bc.UserId == Guid.Parse(userId))
                .FirstOrDefault()!;
            if (cart == null)
            {
                cart = new BookingCart
                {
                    BookingCartId = Guid.NewGuid(),
                    MovieId = movie.Id,
                    TheatreId = show.TheatreId,
                    ShowId = showId,
                    UserId = Guid.Parse(userId),
                    NumberOfSeats = 1
                };
                _bookingCartRepository.Create(cart);
                _bookingCartRepository.Save();
            }
            SelectSeatsVM selectSeatsVM = new SelectSeatsVM()
            {
                Show = show,
                MovieName = movie.Name,
                BookingCart = cart
            };
            return View(selectSeatsVM);
        }
        public IActionResult MakePayment(Guid bookingCartId)
        {
            BookingCart cart = _bookingCartRepository.Get(bc => bc.BookingCartId == bookingCartId);
            return View(cart);
        }
        public IActionResult BookTicket(Guid bookingCartId)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            BookingCart cart = _bookingCartRepository.Get(bc => bc.BookingCartId == bookingCartId);
            Show show = _repository.Get(s => s.Id == cart.ShowId, includeProperties: "Theatre,Movie");
            Movie movie = show.Movie;
            Theatre theatre = show.Theatre;
            string seats = null;
            for (int i = show.BookedSeats + 1; i < (show.BookedSeats+1+cart.NumberOfSeats); i++)
            {
                seats += i.ToString() + ",";
            }
            Booking booking = new Booking
            {
                BookingId = Guid.NewGuid(),
                BookingTime = DateTime.Now,
                UserId = userId,
                TotalPrice = show.Price*cart.NumberOfSeats,
                PaymentStatus = "Paid",
                PaymentRefId = "Random payment ref ID",
                ShowId = cart.ShowId,
                TheatreId = cart.TheatreId,
                MovieId = cart.MovieId,
                NoOfSeats = cart.NumberOfSeats,
                SeatNumbers = seats.Remove(seats.LastIndexOf(','))
            };

            _bookingRepository.Create(booking);
            _bookingRepository.Save();

            show.AvailableSeats = show.AvailableSeats - cart.NumberOfSeats;
            show.BookedSeats = show.BookedSeats + cart.NumberOfSeats;
            _repository.Update(show);
            _repository.Save();

            List<BookingCart> carts = _bookingCartRepository.GetAll()
                .Where(bc => bc.UserId == Guid.Parse(userId)).ToList();
            foreach(var cart1 in carts)
            {
                _bookingCartRepository.Delete(cart1);
            }
            _bookingCartRepository.Save();
            return View(booking);
        }

        #region Supporting methods
        public IActionResult DecreaseSeat(Guid id, Guid showId)
        {
            BookingCart cart = _bookingCartRepository.Get(bc => bc.BookingCartId == id);
            if (cart.NumberOfSeats != 0)
            {
                cart.NumberOfSeats -= 1;
                _bookingCartRepository.Update(cart);
                _bookingCartRepository.Save();
                return RedirectToAction("SelectSeats", new { showId });
            }
            return RedirectToAction("SelectSeats", new { showId });
        }
        public IActionResult IncreaseSeat(Guid id, Guid showId)
        {
            BookingCart cart = _bookingCartRepository.Get(bc => bc.BookingCartId == id);
            if (cart.NumberOfSeats <= 100)
            {
                cart.NumberOfSeats += 1;
                _bookingCartRepository.Update(cart);
                _bookingCartRepository.Save();
                return RedirectToAction("SelectSeats", new { showId });
            }
            return RedirectToAction("SelectSeats", new { showId });
        }
        #endregion
    }
}
