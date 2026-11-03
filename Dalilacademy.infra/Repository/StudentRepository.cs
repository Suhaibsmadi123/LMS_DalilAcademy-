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
    public class StudentRepository(AppDbContext db) : IStudentRepository
    {
        public async Task<List<StudentResponseDto>> GetAllasync()
        {
            return await db.Students
                .Select(s => new StudentResponseDto(
                    s.id,
                    s.fullname,
                    s.email,
                    s.phonenumber))
                .ToListAsync();
        }

        public async Task<PageResult<StudentResponseDto>> Getpageasync(int page, int pagesize)
        {
            var query = db.Students
                .OrderBy(s => s.id)
                .Select(s => new StudentResponseDto(
                    s.id,
                    s.fullname,
                    s.email,
                    s.phonenumber));

            var count = await query.CountAsync();
            var items = await query
                .Skip((page - 1) * pagesize)
                .Take(pagesize)
                .ToListAsync();

            return new PageResult<StudentResponseDto>(items, page, pagesize, count);
        }

        public async Task<List<CourseResponseDTo>> GetCoursesasync(int studentId)
        {
            return await db.Enrollments
                .Where(e => e.studentId == studentId)
                .OrderBy(e => e.courseId)
                .Select(e => new CourseResponseDTo(
                    e.course!.id,
                    e.course.title,
                    e.course.price,
                    e.course.instructor != null ? e.course.instructor.fullname : string.Empty))
                .ToListAsync();
        }

        public async Task<StudentResponseDto?> GetByIdasync(int id)
        {
            return await db.Students
                .Where(s => s.id == id)
                .Select(s => new StudentResponseDto(
                    s.id,
                    s.fullname,
                    s.email,
                    s.phonenumber))
                .FirstOrDefaultAsync();
        }

        public async Task<StudentResponseDto> Createasync(CreateStudentDto studentDto)
        {
            var student = studentDto.ToEntity();
            db.Students.Add(student);
            await db.SaveChangesAsync();

            return (await GetByIdasync(student.id))!;
        }

        public async Task<StudentResponseDto> Updateasync(int id, UpdateStudentDto updatedStudent)
        {
            var existingStudent = await db.Students.FirstOrDefaultAsync(s => s.id == id);
            if (existingStudent == null)
            {
                throw new InvalidOperationException("Student not found");
            }

            existingStudent.UpdateEntity(updatedStudent);
            await db.SaveChangesAsync();

            return (await GetByIdasync(id))!;
        }

        public async Task<bool> Deleteasync(int id)
        {
            var existingStudent = await db.Students.FindAsync(id);
            if (existingStudent == null)
            {
                return false;
            }
            db.Students.Remove(existingStudent);
            await db.SaveChangesAsync();
            return true;
        }
    }
}
