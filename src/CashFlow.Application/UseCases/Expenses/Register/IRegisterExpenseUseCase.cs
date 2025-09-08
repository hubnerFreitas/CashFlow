using CashFlow.Communication.Requests.User;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public interface IRegisterExpenseUseCase
    {
        public Task<ResponseRegisterExpenseJson> Execute(RequestRegisterExpensesJson request);
    }
}
