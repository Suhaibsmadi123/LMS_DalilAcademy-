using Dalilacademy_.Core.DTOs;
using Dalilacademy_.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Dalilacademy_.Core.Mapping
{
    public static class StudentMapping
    {
        public static Student ToEntity(this CreateStudentDto dto)
        {
            return new Student
            {
                fullname = dto.fullname,
                email = dto.email,
                phonenumber = dto.phonenumber
            };
        }

        public static Student ToEntity(this UpdateStudentDto dto, int id = 0)
        {
            return new Student
            {
                id = id,
                fullname = dto.fullname,
                email = dto.email,
                phonenumber = dto.phonenumber
            };
        }

        public static void UpdateEntity(this Student student, UpdateStudentDto dto)
        {
            student.fullname = dto.fullname;
            student.email = dto.email;
            student.phonenumber = dto.phonenumber;
        }
    }
}

