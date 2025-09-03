using CashFlow.Application.UseCases.User.Register;
using CashFlow.Communication.Requests.User;
using CashFlow.Communication.Responses;
using CashFlow.Communication.Responses.User;
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
            var response =  await usecase.Execute(request);

            return Created(string.Empty, response);
        }
    }
}
