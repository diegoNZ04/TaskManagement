using TaskManagement.Domain.Entities;
using TaskManagement.Infraestructure.Data;
using TaskManagementAPI.Domain.Entities.Interfaces;

namespace TaskManagementAPI.Infraestructure.Repositories
{
    public class TaskItemRepository : GenericRepository<TaskItem>, ITaskItemRepository
    {
        public TaskItemRepository(ApplicationDbContext context) : base(context) { }
    }
}