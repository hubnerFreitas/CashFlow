using CashFlow.Communication.Requests.Login;
using CashFlow.Communication.Responses.User;

namespace CashFlow.Application.UseCases.LoginDoLogin
{
    public interface IDoLoginUseCase
    {
        Task<ResponseRegisterUserJson> Execute(RequestLoginJson request);
    }
}
