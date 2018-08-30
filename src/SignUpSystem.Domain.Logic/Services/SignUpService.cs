using System;
using System.Threading.Tasks;
using SignUpSystem.DataAccess.AbstractRepositories;
using SignUpSystem.Domain.Models;

namespace SignUpSystem.Domain.Logic.Services
{
    internal class SignUpService : ISignUpService
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