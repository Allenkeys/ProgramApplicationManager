using ProgramApplicationManager.Domain.Entities;
using ProgramApplicationManager.Persistence.Repositories;
using ProgramApplicationManager.Services.Interfaces;

namespace ProgramApplicationManager.Services.Implements
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<User> _userRepo;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepo = _unitOfWork.GetRepository<User>();
        }

        public async Task<User> GetUser(string id)
        {
            var user = _userRepo.FindBy(x => x.UserId == id).SingleOrDefault();

            if(user == null)
            {
                throw new ArgumentException($"User with id: {id} does not exist");
            }

            return await Task.FromResult(user);
        }
    }
}
