using System;
using System.Collections.Generic;
using System.Linq;
using SignUpSystem.Domain.Models.Interfaces;

namespace SignUpSystem.Domain.Models
{
    public class Course : IAggregate
    {
        public Guid Id { get; }

        public Teacher Teacher { get; }

        public long Capacity { get; }

        public List<User> RegisteredUsers => Places.Where(x => x.Booked).Select(x => x.RegisterdUser).ToList();

        public List<CourseUserPlace> Places { get; }

        public Course(Guid id, Teacher teacher, long capacity, List<CourseUserPlace> places)
        {
            Id = id;
            Teacher = teacher;
            Capacity = capacity;
            Places = places;
        }

        public CourseUserPlace FindEmptyPlace()
        {
            return Places.FirstOrDefault(x => !x.Booked);
        }
    }
}