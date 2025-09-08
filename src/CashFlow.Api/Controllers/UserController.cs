using CashFlow.Application.UseCases.User.ChangePassword;
using CashFlow.Application.UseCases.User.Delete;
using CashFlow.Application.UseCases.User.GetProfile;
using CashFlow.Application.UseCases.User.GetProfileById;
using CashFlow.Application.UseCases.User.Register;
using CashFlow.Application.UseCases.User.UpdateProfile;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Requests.User;
using CashFlow.Communication.Responses;
using CashFlow.Communication.Responses.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterUserJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(
            [FromServices] IRegisterUserUseCase usecase,
            [FromBody] RequestRegisterUserJson request
            )
        {
            var response = await usecase.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseUserJson), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProfile(
            [FromServices] IGetUserProfileUseCase useCase)
        {
            var response = await useCase.Execute();

            return Ok(response);
        }

        [HttpGet]
        [Route("{Id}")]
        [ProducesResponseType(typeof(ResponseUserJson), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProfileById(
            [FromServices] IGetUserProfileById useCase,
            [FromRoute] long Id)
        {
            var response = await useCase.Execute(Id);

            return Ok(response);
        }

        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateProfile(
        [FromServices] IUpdateUserUseCase useCase,
        [FromBody] RequestUpdateUserJson request)
        {
            await useCase.Execute(request);

            return NoContent();
        }

        [HttpPut("change-password")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ChangePassword(
            [FromServices] IChangePasswordUseCase useCase,
            [FromBody] RequestChangePasswordJson request)
        {
            await useCase.Execute(request);

            return NoContent();
        }

        [HttpDelete]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteProfile([FromServices] IDeleteUserAccountUseCase useCase)
        {
            await useCase.Execute();

            return NoContent();
        }
    }
}
