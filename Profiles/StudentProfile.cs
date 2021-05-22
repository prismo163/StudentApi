using AutoMapper;
using StudentApi.Dtos;
using StudentApi.Models;

namespace StudentApi.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
           CreateMap<Student,StudentReadDto>(); 
           CreateMap<StudentCreateDto,Student>();
           CreateMap<StudentUpdateDto,Student>();
           CreateMap<Student,StudentUpdateDto>();
        }
    }
}
