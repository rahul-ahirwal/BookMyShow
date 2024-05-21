using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShow.Areas.User.Controllers
{
    public class UserController : Controller
    {
        [Area("User")]
        [Authorize]
        public IActionResult Bookings()
        {
            return View();
        }
    }
}
