using Microsoft.EntityFrameworkCore;
using ProgramApplicationManager.Domain.DTOs.Request;
using ProgramApplicationManager.Domain.Entities;
using ProgramApplicationManager.Persistence.Repositories;
using ProgramApplicationManager.Services.Interfaces;

namespace ProgramApplicationManager.Services.Implements
{
    public class ApplicationService : IApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Application> _appRepo;

        public ApplicationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _appRepo = _unitOfWork.GetRepository<Application>();
        }

        public async Task CreateApplication(CreateApplicationRequest request)
        {
            var application = new Application
            {
                ProgramId = request.ProgramId,
                PersonalInfoAnswers = request.PersonalInfoAnswers.Select(x => new Answer
                {
                    QuestionId = x.QuestionId,
                    Multiplechoice = x.Multiplechoice,
                    SingleAnswer = x.SingleAnswer,
                }).ToList(),
                AdditionalInfoAnswers = request.AdditionalInfoAnswers.Select(x => new Answer
                {
                    QuestionId = x.QuestionId,
                    Multiplechoice = x.Multiplechoice,
                    SingleAnswer = x.SingleAnswer,
                }).ToList()
            };

            _appRepo.Create(application);
            await Task.CompletedTask;
        }

        public async Task<Application> GetApplication(string applicationId, string programId)
        {
            var application =  await _appRepo.FindBy(x => x.ApplicationId == applicationId)
                .WithPartitionKey(programId)
                .FirstOrDefaultAsync();

            if(application == null)
            {
                throw new ArgumentException("Sorry this application does not exist");
            }

            return application;
        }
    }
}
