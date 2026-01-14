using BLL.Services.Interface;
using Common.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace UserService.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class TalentController : ControllerBase
    {
        private readonly ITalentService _talentService;

        public TalentController(ITalentService talentService)
        {
            _talentService = talentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTalentRequestDto request)
        {
            var result = await _talentService.CreateAsync(request);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTalentRequestDto request)
        {
            var result = await _talentService.UpdateAsync(request);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteTalentRequestDto request)
        {
            var success = await _talentService.DeleteAsync(request);
            if (!success)
                return NotFound();
            return NoContent();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TalentResponseDto>>> GetAll()
        {
            var result = await _talentService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TalentResponseDto>> GetById(Guid id)
        {
            try
            {
                var result = await _talentService.GetByIdAsync(id);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}