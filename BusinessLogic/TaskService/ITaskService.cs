using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.TaskService
{
    public interface ITaskService
    {
        public string AddTask(TaskDto taskDto);
    }
}
