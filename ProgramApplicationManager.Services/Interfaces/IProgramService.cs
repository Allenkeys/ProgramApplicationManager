using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramApplicationManager.Domain.DTOs.Request;
using ProgramApplicationManager.Domain.Entities;

namespace ProgramApplicationManager.Services.Interfaces
{
    public interface IProgramService
    {
        Task CreateProgram(CreateProgramRequest request);
        Task DeleteProgram(string programId);
        Task<ProgramDetail> GetProgram(string programId);
        Task UpdateProgram(UpdateProgramRequest request);
    }
}
