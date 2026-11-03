using System;
using System.Collections.Generic;
using System.Text;

namespace Dalilacademy_.Core.DTOs
{
    public record CreateEnrollmentDto(int studentId, int courseId);
    public record UpdateEnrollmentDto(int studentId, int courseId);
    public record EnrollmentResponseDto(
        int id,
        int studentId,
        string? studentName,
        int courseId,
        string? courseTitle,
        DateTime enrollmentAt);
}
