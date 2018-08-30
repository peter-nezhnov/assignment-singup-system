using System;

namespace SignUpSystem.Domain.Models.Commands
{
    public class SignUpCommand : IBaseSignUpSystemCommand
    {
        public Guid CourseId { get; set; }

        public User User { get; set; }
    }
}
