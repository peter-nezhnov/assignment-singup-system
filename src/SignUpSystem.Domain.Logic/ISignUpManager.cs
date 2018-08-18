using System;
using System.Threading.Tasks;
using SignUpSystem.Domain.Models;

namespace SignUpSystem.Domain.Logic
{
    public interface ISignUpManager
    {
        Task<Result> SignUpAsync(Guid courseId, User user);
    }
}
