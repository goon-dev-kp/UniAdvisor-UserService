using BLL.Services.Interface;
using Common.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserService.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class InterestController : ControllerBase
    {
        private readonly IInterestService _interestService;

        public InterestController(IInterestService interestService)
        {
            _interestService = interestService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InterestResponseDto>>> GetAll()
        {
            var result = await _interestService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InterestResponseDto>> GetById(Guid id)
        {
            try
            {
                var result = await _interestService.GetByIdAsync(id);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<InterestResponseDto>> Create([FromBody] CreateInterestRequestDto request)
        {
            var result = await _interestService.CreateAsync(request);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<InterestResponseDto>> Update([FromBody] UpdateInterestRequestDto request)
        {
            var result = await _interestService.UpdateAsync(request);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteInterestRequestDto request)
        {
            var success = await _interestService.DeleteAsync(request);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}