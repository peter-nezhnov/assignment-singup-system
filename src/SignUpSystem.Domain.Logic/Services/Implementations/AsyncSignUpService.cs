using System;
using System.Threading.Tasks;
using SignUpSystem.Domain.Models;
using SignUpSystem.Domain.Models.Commands;
using SignUpSystem.QueueInfrastructure.Manager;

namespace SignUpSystem.Domain.Logic.Services.Implementations
{
    internal class AsyncSignUpService : ISignUpService
    {
        private readonly IQueuesManager _queuesManager;

        public AsyncSignUpService(IQueuesManager queuesManager)
        {
            _queuesManager = queuesManager;
        }

        public async Task<Result> SignUpAsync(Guid courseId, User user)
        {
            var command = new SignUpCommand
            {
                CourseId = courseId,
                User = user
            };

            await _queuesManager.SendSignUpCommandAsync(command);

            return Result.SuccessResult;
        }
    }
}
