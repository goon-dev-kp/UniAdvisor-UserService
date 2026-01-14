using BLL.Services.Interface;
using Common.DTO;
using Microsoft.AspNetCore.Mvc;

namespace UserService.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentInterestController : ControllerBase
    {
        private readonly IStudentInterestService _service;

        public StudentInterestController(IStudentInterestService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentInterestResponseDto>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentInterestResponseDto>> GetById(Guid id)
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
        public async Task<ActionResult<StudentInterestResponseDto>> Create([FromBody] CreateStudentInterestRequestDto request)
        {
            var result = await _service.CreateAsync(request);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<StudentInterestResponseDto>> Update([FromBody] UpdateStudentInterestRequestDto request)
        {
            var result = await _service.UpdateAsync(request);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteStudentInterestRequestDto request)
        {
            var success = await _service.DeleteAsync(request);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}
