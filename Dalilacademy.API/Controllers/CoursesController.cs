using Dalilacademy.Core.Entities;
using Dalilacademy.Core.Service;
using Dalilacademy_.Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using FluentValidation;

namespace Dalilacademy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController(ICourseService courseService) : ControllerBase
    {
        // GetAll
        [HttpGet]
        public async Task<ActionResult<PageResult<CourseResponseDTo>>> GetAll(
            [FromQuery] int page = 1,
            [FromQuery] int pagesize = 10,
            [FromQuery] int? minPrice = null,
            [FromQuery] int? maxPrice = null)
        {   
            page=Math.Max(page, 1);
            pagesize=Math.Clamp(pagesize, 1, 50);
            return Ok(await courseService.Getpageasync(page, pagesize, minPrice, maxPrice));
        }

        [HttpGet("count")]
        public async Task<ActionResult<int>> Count()
        {
            return Ok(await courseService.Countasync());
        }

        // GetById
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CourseResponseDTo>> GetById(int id)
        {
            var course = await courseService.GetByIdasync(id);
            if (course is null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        // Create
        [HttpPost]
        public async Task<ActionResult<CourseResponseDTo>> Create(CreateCourseDTo course)
        {
            
                var createdCourse = await courseService.Createasync(course);
                if (createdCourse is null)
                {
                    return BadRequest();
                }

                return CreatedAtAction(nameof(GetById), new { id = createdCourse.id }, createdCourse);
           
        }

        // Delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return Ok(await courseService.Deleteasync(id));
        }

        // Update
        [HttpPut("{id:int}")]
        public async Task<ActionResult<CourseResponseDTo>> Update(int id, UpdateCourseDto updatedCourse)
        {
            {
                var result = await courseService.Updateasync(id, updatedCourse);
                if (result is null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }
    }
}
