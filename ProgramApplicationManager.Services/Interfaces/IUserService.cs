using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramApplicationManager.Domain.DTOs.Request;
using ProgramApplicationManager.Domain.Entities;

namespace ProgramApplicationManager.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUser(CreateUserRequest request);
        Task<User> GetUser(string id);
    }
}
