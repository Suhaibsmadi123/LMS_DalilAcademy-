using Dalilacademy.Core.Entities;
using Dalilacademy_.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dalilacademy.Core.Service
{
    public interface ICourseService
    {
        Task<PageResult<CourseResponseDTo>> Getpageasync(int page, int pagesize, int? minPrice = null, int? maxPrice = null);
        Task<int> Countasync();
        Task<CourseResponseDTo?> GetByIdasync(int id);
        Task<CourseResponseDTo> Createasync(CreateCourseDTo course);
        Task<CourseResponseDTo> Updateasync(int id, UpdateCourseDto updatedCourse);
        Task<bool> Deleteasync(int id);
    }
}
