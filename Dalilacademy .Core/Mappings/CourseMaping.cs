using Dalilacademy.Core.Entities;
using Dalilacademy_.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dalilacademy_.Core.Mapping
{
    public static class CourseMappings
    {
        public static Course ToEntity(this CreateCourseDTo dto)
        {
            return new Course
            {
                title = dto.title,
                price = dto.price,
                instructorId = dto.instructorId
            };
        }

        public static Course ToEntity(this UpdateCourseDto dto, int id = 0)
        {
            return new Course
            {
                id = id,
                title = dto.title,
                price = dto.price
            };
        }

        public static void UpdateEntity(this Course course, UpdateCourseDto dto)
        {
            course.title = dto.title;
            course.price = dto.price;
        }
    }
}
