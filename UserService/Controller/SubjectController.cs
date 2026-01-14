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
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectResponseDto>>> GetAll()
        {
            var result = await _subjectService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectResponseDto>> GetById(Guid id)
        {
            try
            {
                var result = await _subjectService.GetByIdAsync(id);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<SubjectResponseDto>> Create([FromBody] CreateSubjectRequestDto request)
        {
            var result = await _subjectService.CreateAsync(request);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<SubjectResponseDto>> Update([FromBody] UpdateSubjectRequestDto request)
        {
            var result = await _subjectService.UpdateAsync(request);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteSubjectRequestDto request)
        {
            var success = await _subjectService.DeleteAsync(request);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}