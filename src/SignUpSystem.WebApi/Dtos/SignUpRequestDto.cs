using System;

namespace SignUpSystem.WebApi.Dtos
{
    public class SignUpRequestDto
    {
        public Guid CourseId { get; set; }

        public string UserName { get; set; }

        public byte Age { get; set; }
    }
}
