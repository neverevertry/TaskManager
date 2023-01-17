using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserTaskRepository
    {
        Task<UserTask> getUserTaskById(int id);

        Task<IEnumerable<UserTask>> getUserTask();

        Task Update(UserTask userTask);

        Task Delete(UserTask userTask);

        Task Create(UserTask task);
    }
}
