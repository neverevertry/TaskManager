using Application.Interfaces;
using Domain.Interfaces;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserTaskService : IUserTaskService
    {
        private readonly IUserTaskRepository _userTaskRepository;

        public UserTaskService(IUserTaskRepository userTaskRepository)
        {
            _userTaskRepository = userTaskRepository;
        }

        public async Task<UserTask> getTaskById(int id)
        {
            var result = await _userTaskRepository.getUserTaskById(id);

            return result == null ? throw new Exception("Задача не найдена") : result;
        }

        public async Task<IEnumerable<UserTask>> getTasks()
        {
            var result = await _userTaskRepository.getUserTask();

            return result == null ? throw new Exception("У пользователя нет задач") : result;
        }

        public async Task deleteTask(int id)
        {
            var result = await _userTaskRepository.getUserTaskById(id);

            if (result != null)
            {
                await _userTaskRepository.Delete(result);
                return;
            }

            throw new Exception("Не удалось удалить задачу");
        }

        public async Task updateTask(UserTask task)
        {
            var result = await _userTaskRepository.getUserTaskById(task.id);

            if(result != null)
            {
                result.statusId = task.statusId;
                result.comments = task.comments;

                await _userTaskRepository.Update(result);
                return;
            }

            throw new Exception("Не удалось обновить");
        }

        public async Task Create(UserTask task)
        {
            if(task != null)
            {
                await _userTaskRepository.Create(task);
                return;
            }
            throw new Exception("Невозможно создать задачу");
        }
    }
}
