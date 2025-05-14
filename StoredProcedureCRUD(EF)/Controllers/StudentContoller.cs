using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoredProcedureCRUD_EF_.Model;
using StoredProcedureCRUD_EF_.Services;

namespace StoredProcedureCRUD_EF_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentContoller : ControllerBase
    {
        private readonly StudentRepository _studentRepository;

        public StudentContoller(StudentRepository studentRepository) =>
            _studentRepository = studentRepository;

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _studentRepository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) =>
            Ok(await _studentRepository.GetByIdAsync(id));



        [HttpPost]
        public async Task<IActionResult> Add(Student student)
        {
            await _studentRepository.AddAsync(student);
            return Ok("Added");
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, Student student)
        {
            student.Id = id;
            await _studentRepository.UpdateAsync(student);
            return Ok("Updated");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _studentRepository.DeleteAsync(id);
            return Ok("Deleted");
        }
    }
}
