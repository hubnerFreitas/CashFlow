using CashFlow.Communication.Requests.User;

namespace CashFlow.Application.UseCases.User.ChangePassword
{
    public  interface IChangePasswordUseCase
    {
        Task Execute(RequestChangePasswordJson request);
    }
}
