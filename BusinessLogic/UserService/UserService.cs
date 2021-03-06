using AutoMapper;
using BusinessLogic.Models;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.UserService
{
    public class UserService : IUserService
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly Mapper _autoMapper;

        public UserService (IApplicationDbContext applicationDbContex)
        {
            _applicationDbContext = applicationDbContex;

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();                
                cfg.CreateMap<Task, TaskDto>();
            });
            _autoMapper = new Mapper(mapperConfig);
        }

        public string AddUser(UserDto userDto)
        {            
            var resultSearch = _applicationDbContext.Users.FirstOrDefault(u => u.Email == userDto.Email);


            if (resultSearch == null)
            {
                var user = new User
                {
                    Email = userDto.Email,
                    Password = userDto.Password,
                    RoleId = userDto.RoleId
                };
                
                _applicationDbContext.Users.Add(user);
                _applicationDbContext.SaveChanges();
                return user.Id;
            }
            return "email not unique";
        }

        public List<UserDto> GetAllUsers()
        {
            var Users = _applicationDbContext.Users.Include(t => t.Tasks).ToList();
            var resultList = _autoMapper.Map<List<User>, List<UserDto>>(Users);           
            return resultList;
        }

    public Models.UserDto GetUserById(string id)
        {
            throw new NotImplementedException();
        }      
    }   
}
