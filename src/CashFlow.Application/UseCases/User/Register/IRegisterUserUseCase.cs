using CashFlow.Communication.Requests.User;
using CashFlow.Communication.Responses.User;

namespace CashFlow.Application.UseCases.User.Register
{
    public  interface IRegisterUserUseCase
    {
        public Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson request);

    }
}
