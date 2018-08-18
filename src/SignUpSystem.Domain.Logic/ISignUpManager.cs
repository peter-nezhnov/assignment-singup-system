using System;
using System.Threading.Tasks;
using SignUpSystem.Domain.Models;

namespace SignUpSystem.Domain.Logic
{
    //should have 2 implementations. 1 doing processing. 1 sending to the queue
    public interface ISignUpManager
    {
        Task<Result> SignUpAsync(Guid courseId, User user);
    }
}
