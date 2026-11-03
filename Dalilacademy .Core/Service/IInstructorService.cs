using Dalilacademy_.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dalilacademy.Core.Service
{
    public interface IInstructorService
    {
        Task<List<InstructorResponseDto>> GetAllasync();
        Task<InstructorResponseDto?> GetByIdasync(int id);
        Task<InstructorResponseDto> Createasync(CreateInstructorDto instructor);
        Task<InstructorResponseDto> Updateasync(int id, UpdateInstructorDto updatedInstructor);
        Task<bool> Deleteasync(int id);
    }
}
