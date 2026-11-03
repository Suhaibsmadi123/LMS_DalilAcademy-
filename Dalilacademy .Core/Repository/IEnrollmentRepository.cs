using Dalilacademy_.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dalilacademy_.Core.Repository
{
    public interface IEnrollmentRepository
    {
        Task<List<EnrollmentResponseDto>> GetAllasync();
        Task<EnrollmentResponseDto?> GetByIdasync(int id);
        Task<EnrollmentResponseDto> Createasync(CreateEnrollmentDto enrollment);
        Task<EnrollmentResponseDto> Updateasync(int id, UpdateEnrollmentDto updatedEnrollment);
        Task<bool> Deleteasync(int id);
    }
}
