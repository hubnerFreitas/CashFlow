using CashFlow.Communication.Responses.User;

namespace CashFlow.Application.UseCases.User.GetProfileById
{
    public interface IGetUserProfileById
    {
        Task<ResponseUserJson> Execute(long Id);
    }
}
