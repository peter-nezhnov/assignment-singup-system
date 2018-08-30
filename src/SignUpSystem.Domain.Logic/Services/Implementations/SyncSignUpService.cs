using System;
using System.Threading.Tasks;
using SignUpSystem.DataAccess.AbstractRepositories;
using SignUpSystem.Domain.Models;

namespace SignUpSystem.Domain.Logic.Services.Implementations
{

    internal class SyncSignUpService : ISignUpService
    {
        private readonly ICoursesRepository _coursesRepository;

        public SyncSignUpService(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }

        public async Task<Result> SignUpAsync(Guid courseId, User user)
        {
            var course = await _coursesRepository.GetCourseAsync(courseId);

            var emptyPlace = course.FindEmptyPlace();

            //can be used Maybe<> wrapper to add readablity
            if (emptyPlace == null)
                return Result.FailedResult;

            emptyPlace.BookPlaceForUser(user);

            await _coursesRepository.SaveChangesAsync(course);

            return Result.SuccessResult;
        }
    }
}