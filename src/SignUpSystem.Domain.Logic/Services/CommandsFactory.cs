using System;
using SignUpSystem.Domain.Models;
using SignUpSystem.Domain.Models.Commands;

namespace SignUpSystem.Domain.Logic.Services
{
    internal interface ICommandsFactory
    {
        SignUpCommand CreateSignUpCommand(Guid courseId, User user);
    }
}
