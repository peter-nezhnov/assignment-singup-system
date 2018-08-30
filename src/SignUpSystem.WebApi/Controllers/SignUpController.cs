using Microsoft.AspNetCore.Mvc;
using SignUpSystem.WebApi.Dtos;
using System.Threading.Tasks;
using Autofac.Features.Indexed;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SignUpSystem.Domain.Logic;
using SignUpSystem.Domain.Logic.Services;

namespace SignUpSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly ISignUpService _asyncSignUpService;
        private readonly ISignUpService _syncSignUpService;
        private readonly ILogger<SignUpController> _logger;

        public SignUpController(IIndex<SignUpServiceType, ISignUpService> signUpServices, ILogger<SignUpController> logger)
        {
            _asyncSignUpService = signUpServices[SignUpServiceType.Async];
            _syncSignUpService = signUpServices[SignUpServiceType.Sync];

            _logger = logger;
        }


        [HttpPost]
        [Route("sync")]
        public async Task<ActionResult> SingUpUserForCourse([FromBody] SignUpRequestDto signUpRequest)
        {
            var (courseId, user) = signUpRequest;
            
            var result = await _syncSignUpService.SignUpAsync(courseId, user);

            if (result.Success)
                return Ok();

            //then only way our logic can return fail - if there is no empty places
            return new StatusCodeResult(StatusCodes.Status410Gone);
        }

        [HttpPost]
        [Route("async")]
        public async Task<ActionResult> SingUpUserForCourseAsync([FromBody] SignUpRequestDto signUpRequest)
        {
            var (courseId, user) = signUpRequest;

            await _asyncSignUpService.SignUpAsync(courseId, user);

            return Accepted();
        }
    }
}
