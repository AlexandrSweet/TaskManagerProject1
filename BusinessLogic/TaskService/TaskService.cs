using BusinessLogic.Models;
using DataAccess;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.TaskService
{
    public class TaskService: ITaskService
    {

        private readonly IApplicationDbContext _applicationDbContext;

        public TaskService(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public string AddTask(TaskDto taskDto)
        {
            var task = new Task
            {
                Title = taskDto.Title,
                Description = taskDto.Description,
                StatusId = taskDto.StatusId
                
            };
            
            _applicationDbContext.Tasks.Add(task);
            _applicationDbContext.SaveChanges();
            return task.Id;
        }
    }
}
