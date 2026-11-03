using Dalilacademy_.Core.DTOs;
using Dalilacademy_.Core.Repository;
using Dalilacademy.Core.Service;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dalilacademy.infra.Service
{
    public class EnrollmentService(
        IEnrollmentRepository enrollmentRepository,
        IValidator<CreateEnrollmentDto> createValidator,
        IValidator<UpdateEnrollmentDto> updateValidator) : IEnrollmentService
    {
        public async Task<List<EnrollmentResponseDto>> GetAllasync()
        {
            return await enrollmentRepository.GetAllasync();
        }

        public async Task<EnrollmentResponseDto?> GetByIdasync(int id)
        {
            return await enrollmentRepository.GetByIdasync(id);
        }

        public async Task<EnrollmentResponseDto> Createasync(CreateEnrollmentDto enrollment)
        {
            await createValidator.ValidateAndThrowAsync(enrollment);
            return await enrollmentRepository.Createasync(enrollment);
        }

        public async Task<EnrollmentResponseDto> Updateasync(int id, UpdateEnrollmentDto updatedEnrollment)
        {
            await updateValidator.ValidateAndThrowAsync(updatedEnrollment);

            var existing = await enrollmentRepository.GetByIdasync(id)
                ?? throw new InvalidOperationException("Enrollment not found");

            return await enrollmentRepository.Updateasync(id, updatedEnrollment);
        }

        public async Task<bool> Deleteasync(int id)
        {
            var existing = await enrollmentRepository.GetByIdasync(id);
            if (existing == null)
            {
                throw new InvalidOperationException("Enrollment not found");
            }
            return await enrollmentRepository.Deleteasync(id);
        }
    }
}
