using Dalilacademy_.Core.DTOs;
using Dalilacademy_.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dalilacademy.Core.Service
{
    public interface IStudentService
    {
        Task<List<StudentResponseDto>> GetAllasync();
        Task<PageResult<StudentResponseDto>> Getpageasync(int page, int pagesize);
        Task<List<CourseResponseDTo>> GetCoursesasync(int studentId);
        Task<StudentResponseDto?> GetByIdasync(int id);
        Task<StudentResponseDto> Createasync(CreateStudentDto student);
        Task<StudentResponseDto> Updateasync(int id, UpdateStudentDto updatedStudent);
        Task<bool> Deleteasync(int id);
    }
}
