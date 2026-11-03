using Dalilacademy_.Core.DTOs;
using Dalilacademy.Core.Service;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dalilacademy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController(IStudentService studentService) : ControllerBase
    {
        // GetAll
        [HttpGet]
        public async Task<ActionResult<PageResult<StudentResponseDto>>> GetAll(
            [FromQuery] int page = 1,
            [FromQuery] int pagesize = 10)
        {
            page = Math.Max(page, 1);
            pagesize = Math.Clamp(pagesize, 1, 50);
            return Ok(await studentService.Getpageasync(page, pagesize));
        }

        [HttpGet("{id:int}/courses")]
        public async Task<ActionResult<List<CourseResponseDTo>>> GetCourses(int id)
        {
            return Ok(await studentService.GetCoursesasync(id));
        }

        // GetById
        [HttpGet("{id:int}")]
        public async Task<ActionResult<StudentResponseDto>> GetById(int id)
        {
            var student = await studentService.GetByIdasync(id);
            if (student is null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        // Create
        [HttpPost]
        public async Task<ActionResult<StudentResponseDto>> Create(CreateStudentDto student)
        {
            try
            {
                var createdStudent = await studentService.Createasync(student);
                if (createdStudent is null)
                {
                    return BadRequest();
                }

                return CreatedAtAction(nameof(GetById), new { id = createdStudent.id }, createdStudent);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return Ok(await studentService.Deleteasync(id));
        }

        // Update
        [HttpPut("{id:int}")]
        public async Task<ActionResult<StudentResponseDto>> Update(int id, UpdateStudentDto updatedStudent)
        {
            try
            {
                var updated = await studentService.Updateasync(id, updatedStudent);
                if (updated is null)
                {
                    return NotFound();
                }
                return Ok(updated);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }));
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
