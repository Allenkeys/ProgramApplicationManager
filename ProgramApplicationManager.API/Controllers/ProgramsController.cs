using Microsoft.AspNetCore.Mvc;
using ProgramApplicationManager.Domain.DTOs.Request;
using ProgramApplicationManager.Domain.Entities;
using ProgramApplicationManager.Services.Interfaces;

namespace ProgramApplicationManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramsController : ControllerBase
    {
        private readonly IProgramService _programService;

        public ProgramsController(IProgramService programService)
        {
            _programService = programService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProgram(string id)
        {
            ProgramDetail result = await _programService.GetProgram(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateProgram([FromBody] CreateProgramRequest request)
        {
            await _programService.CreateProgram(request);
            return Ok();
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateProgram([FromBody] UpdateProgramRequest request)
        {
            await _programService.UpdateProgram(request);
            return Ok();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _programService.DeleteProgram(id);
            return Ok();
        }
    }
}
