using System;
using System.Collections.Generic;
using System.Linq;

namespace SignUpSystem.Domain.Models
{
    public class Course
    {
        public Guid Id { get; set; }

        public Teacher Teacher { get; set; }

        public long Capacity { get; set; }

        public List<User> RegisteredUsers => Places.Where(x => x.Booked).Select(x => x.RegisterdUser).ToList();

        public List<CourseUserPlace> Places { get; set; }

        public CourseStatistics CourseStatiscStatistics { get; set; }
    }
}