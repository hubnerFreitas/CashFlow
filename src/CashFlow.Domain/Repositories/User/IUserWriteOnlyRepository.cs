using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.User
{
    public interface IUserWriteOnlyRepository
    {
        Task Add(Users user);
        Task Delete(Users user);
    }
}
