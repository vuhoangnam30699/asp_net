using CodeFirst.Models;

namespace CodeFirst.DTOs
{
    public class GradeDto
    {
        public int GradeId { get; set; }
        public string? GradeName { get; set; }

        public required IList<StudentDto> Students { get; set; }
    }
}
