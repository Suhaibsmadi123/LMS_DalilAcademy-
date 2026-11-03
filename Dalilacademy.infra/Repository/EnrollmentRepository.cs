using Dalilacademy_.Core.DTOs;
using Dalilacademy_.Core.Exciptions;
using Dalilacademy_.Core.Mapping;
using Dalilacademy_.Core.Repository;
using Dalilacademy.infra.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dalilacademy.infra.Repository
{
    public class EnrollmentRepository(AppDbContext db) : IEnrollmentRepository
    {
        public async Task<List<EnrollmentResponseDto>> GetAllasync()
        {
            return await db.Enrollments
                .Select(e => new EnrollmentResponseDto(
                    e.id,
                    e.studentId,
                    e.student != null ? e.student.fullname : null,
                    e.courseId,
                    e.course != null ? e.course.title : null,
                    e.enrollmentAt))
                .ToListAsync();
        }

        public async Task<EnrollmentResponseDto?> GetByIdasync(int id)
        {
            return await db.Enrollments
                .Where(e => e.id == id)
                .Select(e => new EnrollmentResponseDto(
                    e.id,
                    e.studentId,
                    e.student != null ? e.student.fullname : null,
                    e.courseId,
                    e.course != null ? e.course.title : null,
                    e.enrollmentAt))
                .FirstOrDefaultAsync();
        }

        public async Task<EnrollmentResponseDto> Createasync(CreateEnrollmentDto enrollmentDto)
        {
            try
            {
                var enrollment = enrollmentDto.ToEntity();
                enrollment.enrollmentAt = DateTime.UtcNow;
                db.Enrollments.Add(enrollment);
                await db.SaveChangesAsync();

                return (await GetByIdasync(enrollment.id))!;
            }
            catch (DbUpdateException ex) when (ex.InnerException is PostgresException { SqlState: PostgresErrorCodes.UniqueViolation })
            {
                throw new ConflictException("This student is already enrolled in that course.");
            }
        }

        public async Task<EnrollmentResponseDto> Updateasync(int id, UpdateEnrollmentDto updatedEnrollment)
        {
            var existingEnrollment = await db.Enrollments.FirstOrDefaultAsync(e => e.id == id);
            if (existingEnrollment == null)
            {
                throw new InvalidOperationException("Enrollment not found");
            }

            existingEnrollment.UpdateEntity(updatedEnrollment);
            await db.SaveChangesAsync();

            return (await GetByIdasync(id))!;
        }

        public async Task<bool> Deleteasync(int id)
        {
            var existingEnrollment = await db.Enrollments.FindAsync(id);
            if (existingEnrollment == null)
            {
                return false;
            }
            db.Enrollments.Remove(existingEnrollment);
            await db.SaveChangesAsync();
            return true;
        }
    }
}
