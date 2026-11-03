using Dalilacademy_.Core.DTOs;
using Dalilacademy_.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dalilacademy_.Core.Mapping
{
    public static class InstructorMapping
    {
        public static Instructor ToEntity(this CreateInstructorDto dto)
        {
            return new Instructor
            {
                fullname = dto.fullname,
                price = dto.price
            };
        }

        public static Instructor ToEntity(this UpdateInstructorDto dto, int id = 0)
        {
            return new Instructor
            {
                id = id,
                fullname = dto.fullname,
                price = dto.price
            };
        }

        public static void UpdateEntity(this Instructor instructor, UpdateInstructorDto dto)
        {
            instructor.fullname = dto.fullname;
            instructor.price = dto.price;
        }
    }
}
