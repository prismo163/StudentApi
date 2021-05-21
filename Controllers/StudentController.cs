using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StudentApi.Data;
using StudentApi.Models;

namespace StudentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepo _repository;

        public StudentController(IStudentRepo repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetResult()
        {
            return Ok(_repository.GetAllStudents());
        }
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var student = _repository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

    }
}