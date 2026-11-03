using System;
using System.Collections.Generic;
using System.Text;

namespace Dalilacademy_.Core.Entities
{
    public class Student
    {
        public int id { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public string? phonenumber { get; set; }
        public List<Enrollment>? enrollments { get; set; }
    }
}
