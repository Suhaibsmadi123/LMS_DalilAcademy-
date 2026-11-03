using System;
using System.Collections.Generic;
using System.Text;

namespace Dalilacademy_.Core.DTOs
{
    public record CreateInstructorDto(string fullname, int price);
    public record UpdateInstructorDto(string fullname, int price);
    public record InstructorResponseDto(int id, string fullname, int price);
}
