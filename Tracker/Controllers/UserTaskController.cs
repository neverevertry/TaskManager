using Application.Interfaces;
using Domain.DTO;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Tracker.Controllers
{
    public class UserTaskController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserTaskService _userTaskService;
        private readonly ICommentService _commentService;

        public UserTaskController(IUserService userService, IUserTaskService userTaskService, ICommentService commentService)
        {
            _userService = userService;
            _userTaskService = userTaskService;
            _commentService = commentService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userService.getUserById(1);
            var task = await _userTaskService.getTasks();
            var status = await _commentService.getComments();
            var resStatus = status.FirstOrDefault();

            List<TaskDTO> taskDTOs = new List<TaskDTO>();

            TaskDTO dto = new TaskDTO();
            dto.id = 3;
            dto.authorName = "testName";
            dto.status = "test";
            dto.DateTimeOfStarting = DateTime.Now;
            dto.PredictedDateTimeOfClosing = DateTime.Now;

            taskDTOs.Add(dto);

            return View("Index", taskDTOs);
        }

        public IActionResult Create() => View("Create");

        [HttpPost]
        public async Task<IActionResult> Create(UserTask task)
        {
            task.userId = 3;
            await _userTaskService.Create(task);

            return View("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            id = 3;
            await _userTaskService.deleteTask(id);

            return View("Index");
        }
    }
}
