using System;
using FluentValidation;
using SignUpSystem.WebApi.Dtos;

namespace SignUpSystem.WebApi.Validators
{
    /// <summary>
    /// Validate input data on high level. Business validations (for example age) must be in domain validators.
    /// </summary>
    public class SignUpRequestDtoValidator: AbstractValidator<SignUpRequestDto>
    {
        public SignUpRequestDtoValidator()
        {
            //here we can inject repository to check that Course exists
            RuleFor(x => x.Age).GreaterThan(0);
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.CourseId).NotEqual(default(Guid));
        }
    }
}
