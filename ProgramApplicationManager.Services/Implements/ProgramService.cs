using Azure.Core;
using Microsoft.EntityFrameworkCore;
using ProgramApplicationManager.Domain.DTOs.Request;
using ProgramApplicationManager.Domain.Entities;
using ProgramApplicationManager.Persistence.Repositories;
using ProgramApplicationManager.Services.Interfaces;

namespace ProgramApplicationManager.Services.Implements
{
    public class ProgramService : IProgramService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ProgramDetail> _programRepo;

        public ProgramService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _programRepo = _unitOfWork.GetRepository<ProgramDetail>();
        }

        public async Task<ProgramDetail> GetProgram(string programId)
        {
            var program = _programRepo.FindBy(x => x.ProgramId == programId)
                .WithPartitionKey(programId)
                .FirstOrDefault();

            if (program == null)
            {
                throw new InvalidOperationException($"Program with ID: {programId} does not exist");
            }

            return await Task.FromResult(program);
        }


        public async Task CreateProgram(CreateProgramRequest request)
        {
            var existingProgram = _programRepo.FindBy(x => x.EmployerId ==  request.EmployerId && x.Title == request.Title)
                .FirstOrDefault();

            if (existingProgram != null)
            {
                throw new ArgumentException("Application form already exist");
            }

            var program = new ProgramDetail
            {
                EmployerId = request.EmployerId,
                Title = request.Title,
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                PersonalInfo = request.PersonalDetails.Select(x => new Question
                {
                    Text = x.Text,
                    Type = x.Type.ToString(),
                    Options = x.Options,
                }).ToList(),
                AdditionalInfo = request.AdditionalQuestions.Select(x => new Question
                {
                    Text = x.Text,
                    Type = x.Type.ToString(),
                    Options = x.Options,
                }).ToList()
            };

            _programRepo.Create(program);
        }

        public async Task UpdateProgram(UpdateProgramRequest request)
        {
            var program = _programRepo.FindBy(x => x.ProgramId == request.ProgramId)
               .WithPartitionKey(request.ProgramId)
               .FirstOrDefault();

            if (program == null)
            {
                throw new InvalidOperationException($"Program with ID: {request.ProgramId} does not exist");
            }
            
            program.Title = request.Title;
            program.Description = request.Description;
            program.StartDate = request.StartDate;
            program.EndDate = request.EndDate;

            if(request.PersonalDetails.Any())
            {
                program.PersonalInfo = request.PersonalDetails.Select(x => new Question
                {
                    Text = x.Text,
                    Type = x.Type.ToString(),
                    Options = x.Options,
                }).ToList();
            }

            if (request.AdditionalQuestions.Any())
            {
                program.AdditionalInfo = request.AdditionalQuestions.Select(x => new Question
                {
                    Text = x.Text,
                    Type = x.Type.ToString(),
                    Options = x.Options,
                }).ToList();
            }

            _programRepo.Update(program);
            await Task.CompletedTask;
        }

        public async Task DeleteProgram(string programId)
        {
            var program = _programRepo.FindBy(x => x.ProgramId == programId)
                  .WithPartitionKey(programId)
                  .FirstOrDefault();

            if (program == null)
            {
                throw new InvalidOperationException($"Program with ID: {programId} does not exist");
            }

            _programRepo.Delete(program);
        }
    }
}
