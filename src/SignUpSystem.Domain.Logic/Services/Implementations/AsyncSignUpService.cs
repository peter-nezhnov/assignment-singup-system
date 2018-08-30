using System;
using System.Threading.Tasks;
using SignUpSystem.Domain.Models;
using SignUpSystem.QueueInfrastructure.Manager;

namespace SignUpSystem.Domain.Logic.Services.Implementations
{
    internal class AsyncSignUpService : ISignUpService
    {
        private readonly IQueuesManager _queuesManager;
        private readonly ICommandsFactory _commandsFactory;

        public AsyncSignUpService(IQueuesManager queuesManager, ICommandsFactory commandsFactory)
        {
            _queuesManager = queuesManager;
            _commandsFactory = commandsFactory;
        }

        public async Task<Result> SignUpAsync(Guid courseId, User user)
        {
            var command = _commandsFactory.CreateSignUpCommand(courseId, user);

            await _queuesManager.SendSignUpCommandAsync(command);

            return Result.SuccessResult;
        }
    }
}
