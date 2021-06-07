using BusinessLogic.Models;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.TaskService
{
    public interface ITaskService
    {
        public string AddTask(TaskDto taskDto);
        public bool EditTask(TaskDto taskDto);
        public List<TaskDto> GetAllTasks();
        public bool DeleteTask(string id);
    }
}
