using Dalilacademy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dalilacademy_.Core.Entities
{
    public class Enrollment
    {
        public int id { get; set; }
        public int studentId { get; set; }
        public Student? student { get; set; }
        public int courseId { get; set; }
        public Course? course { get; set; }
        public DateTime enrollmentAt { get; set; }
    }
}
