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
    public class SubjectScoreController : ControllerBase
    {
        private readonly ISubjectScoreService _subjectScoreService;

        public SubjectScoreController(ISubjectScoreService subjectScoreService)
        {
            _subjectScoreService = subjectScoreService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectScoreResponseDto>>> GetAll()
        {
            var result = await _subjectScoreService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectScoreResponseDto>> GetById(Guid id)
        {
            try
            {
                var result = await _subjectScoreService.GetByIdAsync(id);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<SubjectScoreResponseDto>> Create([FromBody] CreateSubjectScoreRequestDto request)
        {
            var result = await _subjectScoreService.CreateAsync(request);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<SubjectScoreResponseDto>> Update([FromBody] UpdateSubjectScoreRequestDto request)
        {
            var result = await _subjectScoreService.UpdateAsync(request);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteSubjectScoreRequestDto request)
        {
            var success = await _subjectScoreService.DeleteAsync(request);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}