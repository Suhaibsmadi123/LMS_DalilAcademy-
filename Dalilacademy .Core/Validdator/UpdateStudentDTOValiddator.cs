using Dalilacademy_.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dalilacademy_.Core.Validdator
{
    public class UpdateStudentDTOValiddator : AbstractValidator<UpdateStudentDto>
    {
        public UpdateStudentDTOValiddator()
        {
            RuleFor(s => s.fullname)
                .NotEmpty().WithMessage("Full name is required.")
                .MaximumLength(100).WithMessage("Full name cannot exceed 100 characters.");

            RuleFor(s => s.email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email is not valid.")
                .MaximumLength(100).WithMessage("Email cannot exceed 100 characters.");

            RuleFor(s => s.phonenumber)
                .MaximumLength(20).WithMessage("Phone number cannot exceed 20 characters.")
                .When(s => !string.IsNullOrWhiteSpace(s.phonenumber));
        }
    }
}
