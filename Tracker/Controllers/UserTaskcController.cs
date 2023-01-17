using Application.Interfaces;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Tracker.Controllers
{
    public class UserTaskcController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserTaskService _userTaskService;
        private readonly ICommentService _commentService;

        public UserTaskcController(IUserService userService, IUserTaskService userTaskService, ICommentService commentService)
        {
            _userService = userService;
            _userTaskService = userTaskService;
            _commentService = commentService;
        }

        public async Task<IActionResult> Index() => View("Index", await _userTaskService.getTasks());
    }
}
