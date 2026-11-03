using Dalilacademy.Core.Entities;
using Dalilacademy_.Core.DTOs;
using Dalilacademy_.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dalilacademy_.Core.Mapping
{
    public static class EnrollmentMapping
    {
        public static Enrollment ToEntity(this CreateEnrollmentDto dto)
        {
            return new Enrollment
            {
                studentId = dto.studentId,
                courseId = dto.courseId
            };
        }

        public static Enrollment ToEntity(this UpdateEnrollmentDto dto, int id = 0)
        {
            return new Enrollment
            {
                id = id,
                studentId = dto.studentId,
                courseId = dto.courseId
            };
        }

        public static void UpdateEntity(this Enrollment enrollment, UpdateEnrollmentDto dto)
        {
            enrollment.studentId = dto.studentId;
            enrollment.courseId = dto.courseId;
        }
    }
}
