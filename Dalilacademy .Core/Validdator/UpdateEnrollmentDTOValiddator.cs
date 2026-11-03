using Dalilacademy_.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dalilacademy_.Core.Validdator
{
    public class UpdateEnrollmentDTOValiddator : AbstractValidator<UpdateEnrollmentDto>
    {
        public UpdateEnrollmentDTOValiddator()
        {
            RuleFor(e => e.studentId)
                .GreaterThan(0).WithMessage("Student ID must be a positive integer.");

            RuleFor(e => e.courseId)
                .GreaterThan(0).WithMessage("Course ID must be a positive integer.");
        }
    }
}
