using Dalilacademy_.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dalilacademy_.Core.Validdator
{
    public class UpdateCourseDTOValiddator : AbstractValidator<UpdateCourseDto>
    {
        public UpdateCourseDTOValiddator()
        {
            RuleFor(c => c.title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");

            RuleFor(c => c.price)
                .GreaterThan(0).WithMessage("Price must be a positive number.");
        }
    }
}
