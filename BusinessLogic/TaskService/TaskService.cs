using AutoMapper;
using BusinessLogic.Models;
using DataAccess;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.TaskService
{
    public class TaskService: ITaskService
    {

        private readonly IApplicationDbContext _applicationDbContext;
        private readonly Mapper _autoMapper;

        public TaskService(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;

            var mapperConfig = new MapperConfiguration(cfg =>
            {                
                cfg.CreateMap<Task, TaskDto>();
            });
            _autoMapper = new Mapper(mapperConfig);
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

        public List<TaskDto> GetAllTasks()
        {
            var Tasks = _applicationDbContext.Tasks?.ToList();
            var resultList = _autoMapper.Map<List<Task>, List<TaskDto>>(Tasks);

            foreach ( var item in resultList)
            {
                var id = item.UserId;
                var user = _applicationDbContext.Users.FirstOrDefault(u => u.Id == id);
                item.EmailUser = user?.Email;
            }          

            return resultList;
        }
    }
}
