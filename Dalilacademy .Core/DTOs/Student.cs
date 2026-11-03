using System;

namespace Dalilacademy_.Core.DTOs
{
    public record CreateStudentDto(string fullname, string email, string? phonenumber = null);
    public record UpdateStudentDto(string fullname, string email, string? phonenumber = null);
    public record StudentResponseDto(int id, string fullname, string email, string? phonenumber = null);
}

