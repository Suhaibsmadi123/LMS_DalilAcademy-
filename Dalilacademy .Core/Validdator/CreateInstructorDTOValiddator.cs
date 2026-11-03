using Dalilacademy_.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dalilacademy_.Core.Validdator
{
    public class CreateInstructorDTOValiddator : AbstractValidator<CreateInstructorDto>
    {
        public CreateInstructorDTOValiddator()
        {
            RuleFor(i => i.fullname)
                .NotEmpty().WithMessage("Full name is required.")
                .MaximumLength(100).WithMessage("Full name cannot exceed 100 characters.");

            RuleFor(i => i.price)
                .GreaterThan(0).WithMessage("Price must be a positive number.");
        }
    }
}
