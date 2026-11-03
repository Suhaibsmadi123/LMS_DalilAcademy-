using Dalilacademy_.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dalilacademy_.Core.Validdator
{
    public class CreateCourseDTOValiddator : AbstractValidator<CreateCourseDTo>
    {
        public CreateCourseDTOValiddator()
        {
            RuleFor(c => c.title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");
             
            RuleFor(c => c.price)
                .GreaterThan(0).WithMessage("Price must be a positive number.");
            RuleFor(c => c.instructorId)
                .GreaterThan(0).WithMessage("Instructor ID must be a positive integer.");
        }
    }
}
