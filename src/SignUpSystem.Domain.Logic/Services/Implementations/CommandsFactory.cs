using System;
using SignUpSystem.Domain.Models;
using SignUpSystem.Domain.Models.Commands;
using SingUpSystem.Infrastructure.Utils;

namespace SignUpSystem.Domain.Logic.Services.Implementations
{
    internal class CommandsFactory : ICommandsFactory
    {
        public SignUpCommand CreateSignUpCommand(Guid courseId, User user)
        {
            HolyGuard.ThrowExceptionIfObjectIsNull(user);

            return new SignUpCommand
            {
                CourseId = courseId,
                User = user
            };
        }
    }
}