using Microsoft.AspNetCore.Mvc;
using SignUpSystem.WebApi.Dtos;
using System.Threading.Tasks;
using Autofac.Features.Indexed;
using Microsoft.AspNetCore.Http;
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

        public SignUpController(IIndex<SignUpServiceType, ISignUpService> signUpServices)
        {
            _asyncSignUpService = signUpServices[SignUpServiceType.Async];
            _syncSignUpService = signUpServices[SignUpServiceType.Sync];
        }

        [HttpPost]
        [Route("sync")]
        public async Task<ActionResult> SingUpUserForCourse([FromBody] SignUpRequestDto signUpRequest)
        {
            //Can be moved to filter. Removes duplication.
            if (!ModelState.IsValid)
                return BadRequest();

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
            if (!ModelState.IsValid)
                return BadRequest();

            var (courseId, user) = signUpRequest;

            await _asyncSignUpService.SignUpAsync(courseId, user);

            return Accepted();
        }
    }
}
