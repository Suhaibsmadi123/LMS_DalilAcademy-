using Dalilacademy_.Core.DTOs;
using Dalilacademy_.Core.Mapping;
using Dalilacademy_.Core.Repository;
using Dalilacademy.infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dalilacademy.infra.Repository
{
    public class InstructorRepository(AppDbContext db) : IInstructorRepository
    {
        public async Task<List<InstructorResponseDto>> GetAllasync()
        {
            return await db.Instructors
                .Select(i => new InstructorResponseDto(
                    i.id,
                    i.fullname,
                    i.price))
                .ToListAsync();
        }

        public async Task<InstructorResponseDto?> GetByIdasync(int id)
        {
            return await db.Instructors
                .Where(i => i.id == id)
                .Select(i => new InstructorResponseDto(
                    i.id,
                    i.fullname,
                    i.price))
                .FirstOrDefaultAsync();
        }

        public async Task<InstructorResponseDto> Createasync(CreateInstructorDto instructorDto)
        {
            var instructor = instructorDto.ToEntity();
            db.Instructors.Add(instructor);
            await db.SaveChangesAsync();

            return (await GetByIdasync(instructor.id))!;
        }

        public async Task<InstructorResponseDto> Updateasync(int id, UpdateInstructorDto updatedInstructor)
        {
            var existingInstructor = await db.Instructors.FirstOrDefaultAsync(i => i.id == id);
            if (existingInstructor == null)
            {
                throw new InvalidOperationException("Instructor not found");
            }

            existingInstructor.UpdateEntity(updatedInstructor);
            await db.SaveChangesAsync();

            return (await GetByIdasync(id))!;
        }

        public async Task<bool> Deleteasync(int id)
        {
            var existingInstructor = await db.Instructors.FindAsync(id);
            if (existingInstructor == null)
            {
                return false;
            }
            db.Instructors.Remove(existingInstructor);
            await db.SaveChangesAsync();
            return true;
        }
    }
}
