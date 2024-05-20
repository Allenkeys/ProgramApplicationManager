using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgramApplicationManager.Domain.DTOs.Request;
using ProgramApplicationManager.Services.Interfaces;

namespace ProgramApplicationManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IApplicationService _applicationService;
        public ApplicationsController(IApplicationService service)
        {
            _applicationService = service;
        }

        [HttpGet]
        [Route("{programId}/{applicationId}")]
        public async Task<IActionResult> GetApplication(string programId, string applicationId)
        {
            var response = await _applicationService.GetApplication(programId, applicationId);
            return Ok(response);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Apply(CreateApplicationRequest request)
        {
            await _applicationService.CreateApplication(request);
            return Ok();
        }
    }
}
