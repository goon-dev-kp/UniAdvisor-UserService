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
    public class StudentProfileController : ControllerBase
    {
        private readonly IStudentProfileService _service;

        public StudentProfileController(IStudentProfileService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentProfileResponseDto>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentProfileResponseDto>> GetById(Guid id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<StudentProfileResponseDto>> Create(CreateStudentProfileRequestDto request)
        {
            var result = await _service.CreateAsync(request);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<StudentProfileResponseDto>> Update(UpdateStudentProfileRequestDto request)
        {
            var result = await _service.UpdateAsync(request);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteStudentProfileRequestDto request)
        {
            var success = await _service.DeleteAsync(request);
            return success ? NoContent() : NotFound();
        }
    }
}
