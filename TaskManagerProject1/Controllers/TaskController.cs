using BusinessLogic.Models;
using BusinessLogic.TaskService;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagerProject1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;


        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpPost]
        [Route("add-task")]
        public ActionResult<string> AddTask(TaskDto task)
        {
            if (task.Title != null)
            {
                return _taskService.AddTask(task);
            }
            return BadRequest("Dont try to add an invalid data !!!");
        }

        [HttpGet]
        [Route("get-tasks")]
        public ActionResult<List<TaskDto>> GetAllTasks()
        {
            return _taskService.GetAllTasks();
        }

        [HttpPut]
        [Route("edit-task")]
        public bool EditTask(TaskDto task)
        {
            if (task != null)
            {
                _taskService.EditTask(task);
                return true;
            }
            return false;
        }
        [HttpPost]
       
        [Route("delete-task")]       
        public ActionResult DeleteTask(TaskDto task)
        {
            var isSuccess = _taskService.DeleteTask(task.Id);

            if (isSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
