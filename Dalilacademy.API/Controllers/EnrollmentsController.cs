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
    public class EnrollmentsController(IEnrollmentService enrollmentService) : ControllerBase
    {
        // GetAll
        [HttpGet]
        public async Task<ActionResult<List<EnrollmentResponseDto>>> GetAll()
        {
            return Ok(await enrollmentService.GetAllasync());
        }

        // GetById
        [HttpGet("{id:int}")]
        public async Task<ActionResult<EnrollmentResponseDto>> GetById(int id)
        {
            var enrollment = await enrollmentService.GetByIdasync(id);
            if (enrollment is null)
            {
                return NotFound();
            }
            return Ok(enrollment);
        }

        // Create
        [HttpPost]
        public async Task<ActionResult<EnrollmentResponseDto>> Create(CreateEnrollmentDto enrollment)
        {
            try
            {
                var createdEnrollment = await enrollmentService.Createasync(enrollment);
                return CreatedAtAction(nameof(GetById), new { id = createdEnrollment.id }, createdEnrollment);
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
            return Ok(await enrollmentService.Deleteasync(id));
        }

        // Update
        [HttpPut("{id:int}")]
        public async Task<ActionResult<EnrollmentResponseDto>> Update(int id, UpdateEnrollmentDto updatedEnrollment)
        {
            try
            {
                var updated = await enrollmentService.Updateasync(id, updatedEnrollment);
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
