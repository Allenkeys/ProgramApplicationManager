using ProgramApplicationManager.Domain.DTOs.Request;
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

        public async Task<User> CreateUser(CreateUserRequest request)
        {
            var user = _userRepo.FindBy(x => x.Email == request.Email).SingleOrDefault();

            if (user != null)
                throw new ArgumentException($"User with email: {request.Email} already exist");

            var CreateUser = new User
            {
                Email = request.Email,
                FirstName = request.Firstname,
                LastName = request.Lastname
            };

            var newUser = _userRepo.Create(CreateUser);

            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);

            return newUser;
        }
    }
}
