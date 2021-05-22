using System.ComponentModel.DataAnnotations;

namespace StudentApi.Dtos
{
    public class StudentUpdateDto
    {
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }

    }

}