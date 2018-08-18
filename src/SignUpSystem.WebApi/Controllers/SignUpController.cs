using Microsoft.AspNetCore.Mvc;
using SignUpSystem.Domain.Logic;
using SignUpSystem.Domain.Models;
using SignUpSystem.WebApi.Dtos;
using System.Threading.Tasks;

namespace SignUpSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly ISignUpManager _signUpManager;

        public SignUpController(ISignUpManager signUpManager)
        {
            _signUpManager = signUpManager;
        }

        [HttpPost]
        public async Task<ActionResult> SingUpUserForCourse([FromBody] SignUpRequestDto signUpRequest)
        {
            //for more complex mappings better to use AutoMapper.
            var user = new User { Name = signUpRequest.UserName, Age = signUpRequest.Age };
            var result = await _signUpManager.SignUpAsync(signUpRequest.CourseId, user);

            if (result.Success)
                return Ok();

            return Conflict("All places are booked.");
        }

        [HttpPost]
        public async Task<ActionResult> SingUpUserForCourseAsync([FromBody] SignUpRequestDto signUpRequest)
        {
            //call bus
            await Task.CompletedTask;
            return Accepted();
        }
    }
}
