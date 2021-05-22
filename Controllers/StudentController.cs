using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using StudentApi.Data;
using StudentApi.Dtos;
using StudentApi.Models;

namespace StudentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepo _repository;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StudentReadDto>> GetResult()
        {
            var students = _repository.GetAllStudents();
            
            return Ok(_mapper.Map<IEnumerable<StudentReadDto>>(students));
        }

        [HttpGet("{id}", Name="GetStudentById")]
        public ActionResult<StudentReadDto> GetStudentById(int id)
        {
            var student = _repository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<StudentReadDto>(student));
        }

        [HttpPost]
        public ActionResult<StudentReadDto> Create(StudentCreateDto stu)
        {
            var student = _mapper.Map<Student>(stu);
            _repository.CreateStudent(student);
            _repository.SaveChanges();
            var readDto = _mapper.Map<StudentReadDto>(student);

            
            return CreatedAtRoute(nameof(GetStudentById),new { Id = readDto.Id}, readDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, StudentUpdateDto studentUpdateDto)
        {
            var studentModelFromRepo = _repository.GetStudentById(id);
            if (studentModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(studentUpdateDto,studentModelFromRepo);
            _repository.UpdateStudent(studentModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PatchStudent(int id, JsonPatchDocument<StudentUpdateDto> patchDocument)
        {
            var studentModelFromRepo = _repository.GetStudentById(id);
            if (studentModelFromRepo == null){
                return NotFound();
            }
            var studentToPatch = _mapper.Map<StudentUpdateDto>(studentModelFromRepo);
            patchDocument.ApplyTo(studentToPatch, ModelState);
            if(!TryValidateModel(studentToPatch)){
                return ValidationProblem(ModelState);
            }
            _mapper.Map(studentToPatch, studentModelFromRepo);
            _repository.UpdateStudent(studentModelFromRepo);
            _repository.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            var student = _repository.GetStudentById(id);
            if( student == null){
                return NotFound();
            }
            _repository.DeleteStudent(student);
            _repository.SaveChanges();
            return NoContent();
        }

    }
}