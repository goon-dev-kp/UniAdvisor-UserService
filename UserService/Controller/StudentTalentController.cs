using BLL.Services.Interface;
using Common.DTO;
using Microsoft.AspNetCore.Mvc;

namespace UserService.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentTalentController : ControllerBase
    {
        private readonly IStudentTalentService _service;

        public StudentTalentController(IStudentTalentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentTalentResponseDto>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentTalentResponseDto>> GetById(Guid id)
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
        public async Task<ActionResult<StudentTalentResponseDto>> Create(CreateStudentTalentRequestDto request)
        {
            var result = await _service.CreateAsync(request);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<StudentTalentResponseDto>> Update(UpdateStudentTalentRequestDto request)
        {
            var result = await _service.UpdateAsync(request);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteStudentTalentRequestDto request)
        {
            var success = await _service.DeleteAsync(request);
            return success ? NoContent() : NotFound();
        }
    }

}
