using System;
using SignUpSystem.Domain.Models;

namespace SignUpSystem.WebApi.Dtos
{
    public class SignUpRequestDto
    {
        public Guid CourseId { get; set; }

        public string UserName { get; set; }

        public byte Age { get; set; }

        public void Deconstruct(out Guid courseId, out User user)
        {
            courseId = CourseId;
            user = new User
            {
                Age = Age,
                Name = UserName
            };
        }
    }
}
