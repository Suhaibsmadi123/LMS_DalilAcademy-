using Dalilacademy_.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dalilacademy_.Core.DTOs
{
    //public class CreateCourseDTo
    //{
    //    public string title { get; init; }
    //    public int price { get; init; }
    //    public string? level { get; init; }
    //    public int instructorId { get; init; }
    //}

    public record CreateCourseDTo(string title, int price, int instructorId);
    public record UpdateCourseDto(string title, int price);
    public record CourseResponseDTo(int id, string title, int price, String instructorName);    
}
