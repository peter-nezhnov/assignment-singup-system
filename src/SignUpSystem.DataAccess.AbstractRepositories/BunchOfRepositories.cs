using SignUpSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignUpSystem.DataAccess.AbstractRepositories
{
    public interface ICoursePlacesRepository
    {
        Task<CourseUserPlace> GetEmptyPlaceAsync(Guid courseId);

        Task<Result> UpdatePlaceAsync(CourseUserPlace place);
    }

    public interface ITeachersRepository
    {
        Task<Teacher> GetTeacherAsync(Guid teacherId);
    }

    public interface IStatisticsRepository
    {
        Task<CourseStatistics> GetCourseStatisticsAsync(Guid courseId);
    }

    public interface ICoursesRepository
    {
        Task<Course> GetCourseAsync(Guid courseId);

        Task<List<Course>> GetCoursesAsync();
        Task SaveChangesAsync(Course course);
    }
}
