using Application.Interfaces;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Tracker.Controllers
{
    public class RegController : Controller
    {
        private readonly IUserService _userService;

        public RegController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Registration() => View("Registration");

        [HttpPost]
        public async Task<IActionResult> Registration(User user)
        {
            await _userService.createUser(user);

            return RedirectToAction("Index");
        }
    }
}
