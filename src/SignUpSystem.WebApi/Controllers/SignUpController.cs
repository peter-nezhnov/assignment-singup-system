using Microsoft.AspNetCore.Mvc;
using SignUpSystem.Domain.Models;
using SignUpSystem.WebApi.Dtos;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SignUpSystem.Domain.Logic.Services;

namespace SignUpSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly ISignUpService _signUpService;
        private readonly ILogger<SignUpController> _logger;

        public SignUpController(ISignUpService signUpService, ILogger<SignUpController> logger)
        {
            _signUpService = signUpService;
            _logger = logger;
        }


        [HttpPost]
        [Route("sync")]
        public async Task<ActionResult> SingUpUserForCourse([FromBody] SignUpRequestDto signUpRequest)
        {

            //for more complex mappings better to use AutoMapper.
            var user = new User { Name = signUpRequest.UserName, Age = signUpRequest.Age };
            var result = await _signUpService.SignUpAsync(signUpRequest.CourseId, user);

            if (result.Success)
                return Ok();

            return Conflict("All places are booked.");
        }

        [HttpPost]
        [Route("async")]
        public async Task<ActionResult> SingUpUserForCourseAsync([FromBody] SignUpRequestDto signUpRequest)
        {
            //call bus
            await Task.CompletedTask;
            return Accepted();
        }
    }
}
