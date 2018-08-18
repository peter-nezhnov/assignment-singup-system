using System;

namespace SignUpSystem.Domain.Models
{
    public class CourseUserPlace
    {
        public Guid CourseId { get; set; }

        public User RegisterdUser { get; set; }

        public long PlaceNumer { get; set; }

        public bool Booked => RegisterdUser != null;
    }
}