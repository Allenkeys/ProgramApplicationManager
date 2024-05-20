using ProgramApplicationManager.Domain.DTOs.Request;
using ProgramApplicationManager.Domain.Entities;

namespace ProgramApplicationManager.Services.Interfaces
{
    public interface IApplicationService
    {
        Task CreateApplication(CreateApplicationRequest request);
        Task<Application> GetApplication(string applicationId, string programId);
    }
}
