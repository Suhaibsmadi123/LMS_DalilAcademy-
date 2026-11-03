using Dalilacademy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dalilacademy_.Core.Entities
{
    public class Instructor
    {
        public int id { get; set; }
        public string fullname { get; set; }
        public int price { get; set; }
        public List<Course>? courses { get; set; }
    }
}
