using Dalilacademy_.Core.Entities;

namespace Dalilacademy.Core.Entities
{
    public class Course
    {
        public int id { get; set; }
        public string title { get; set; }
        public int price { get; set; }
        public string? level { get; set; }
        public int instructorId { get; set; }
        public Instructor? instructor { get; set; }
        public List<Enrollment>? enrollments { get; set; }
    }
}
