using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserTaskService
    {
        Task updateTask(UserTask task);
        Task deleteTask(int id);
        Task<UserTask> getTaskById(int id);
        Task<IEnumerable<UserTask>> getTasks();
    }
}
