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
    public class InstructorsController(IInstructorService instructorService) : ControllerBase
    {
        // GetAll
        [HttpGet]
        public async Task<ActionResult<List<InstructorResponseDto>>> GetAll()
        {
            return Ok(await instructorService.GetAllasync());
        }

        // GetById
        [HttpGet("{id:int}")]
        public async Task<ActionResult<InstructorResponseDto>> GetById(int id)
        {
            var instructor = await instructorService.GetByIdasync(id);
            if (instructor is null)
            {
                return NotFound();
            }
            return Ok(instructor);
        }

        // Create
        [HttpPost]
        public async Task<ActionResult<InstructorResponseDto>> Create(CreateInstructorDto instructor)
        {
            try
            {
                var createdInstructor = await instructorService.Createasync(instructor);
                return CreatedAtAction(nameof(GetById), new { id = createdInstructor.id }, createdInstructor);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }));
            }
        }

        // Delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return Ok(await instructorService.Deleteasync(id));
        }

        // Update
        [HttpPut("{id:int}")]
        public async Task<ActionResult<InstructorResponseDto>> Update(int id, UpdateInstructorDto updatedInstructor)
        {
            try
            {
                var updated = await instructorService.Updateasync(id, updatedInstructor);
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
        }
    }
}
