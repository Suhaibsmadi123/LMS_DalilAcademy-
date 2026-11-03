using Dalilacademy_.Core.DTOs;
using Dalilacademy_.Core.Repository;
using Dalilacademy.Core.Service;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dalilacademy.infra.Service
{
    public class InstructorService(
        IInstructorRepository instructorRepository,
        IValidator<CreateInstructorDto> createValidator,
        IValidator<UpdateInstructorDto> updateValidator) : IInstructorService
    {
        public async Task<List<InstructorResponseDto>> GetAllasync()
        {
            return await instructorRepository.GetAllasync();
        }

        public async Task<InstructorResponseDto?> GetByIdasync(int id)
        {
            return await instructorRepository.GetByIdasync(id);
        }

        public async Task<InstructorResponseDto> Createasync(CreateInstructorDto instructor)
        {
            await createValidator.ValidateAndThrowAsync(instructor);
            return await instructorRepository.Createasync(instructor);
        }

        public async Task<InstructorResponseDto> Updateasync(int id, UpdateInstructorDto updatedInstructor)
        {
            await updateValidator.ValidateAndThrowAsync(updatedInstructor);

            var existing = await instructorRepository.GetByIdasync(id)
                ?? throw new InvalidOperationException("Instructor not found");

            return await instructorRepository.Updateasync(id, updatedInstructor);
        }

        public async Task<bool> Deleteasync(int id)
        {
            var existing = await instructorRepository.GetByIdasync(id);
            if (existing == null)
            {
                throw new InvalidOperationException("Instructor not found");
            }
            return await instructorRepository.Deleteasync(id);
        }
    }
}
