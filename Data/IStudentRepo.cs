using System.Collections.Generic;
using StudentApi.Models;

namespace StudentApi.Data
{
    public interface IStudentRepo
    {
        bool SaveChanges();
        IEnumerable<Student> GetAllStudents();
        
        Student GetStudentById(int id);
        void CreateStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(Student student); 
    }
}