using System;
using System.Threading.Tasks;
using SignUpSystem.DataAccess.AbstractRepositories;
using SignUpSystem.Domain.Models;
using SignUpSystem.Domain.Models.Commands;
using SignUpSystem.QueueInfrastructure.Manager;

namespace SignUpSystem.Domain.Logic.Services
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

    internal class SyncSignUpService : ISignUpService
    {
        private readonly ICoursePlacesRepository _placesRepository;

  
        //public SignUpService(ICoursePlacesRepository placesRepository)
        //{
        //    _placesRepository = placesRepository;
        //}

        public async Task<Result> SignUpAsync(Guid courseId, User user)
        {

            try
            {
                var emptyPlace = await _placesRepository.GetEmptyPlaceAsync(courseId);

                //can be used Maybe<> wrapper to add readablity
                if (emptyPlace == null)
                    return Result.FailedResult;

                var bookedPlace = AssignUserToEmptyPlace(emptyPlace, user);

                return await _placesRepository.UpdatePlaceAsync(bookedPlace);
            }
            catch (Exception anyException)
            {
                //TODO logging
                //Here should be custom exception from this project. Reference inner exception.
                throw new Exception("Can't perform sign up action. See inner exception for details.", anyException);

            }
        }

        private CourseUserPlace AssignUserToEmptyPlace(CourseUserPlace place, User user)
        {
            place.RegisterdUser = user;

            return place;
        }
    }
}