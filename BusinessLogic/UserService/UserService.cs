using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.UserService
{
    public class UserService: IUserService
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public UserService (IApplicationDbContext applicationDbContex)
        {
            _applicationDbContext = applicationDbContex;
        }
    }
}
