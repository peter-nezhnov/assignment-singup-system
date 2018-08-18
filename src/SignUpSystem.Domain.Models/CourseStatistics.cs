using System;

namespace SignUpSystem.Domain.Models
{
    public class CourseStatistics
    {
        public Guid CourseId { get; set; }

        public byte MinAge { get; set; }

        public byte MaxAge { get; set; }

        public byte AverageAge { get; set; }

        public long NumberOfSignedUsers { get; set; }
    }
}