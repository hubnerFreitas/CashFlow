using CashFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Domain.Repositories.User
{
    public interface IUserReadOnlyRepository
    {
        Task<bool> ExistActiveUserWithEmail(string email);

        Task<List<Users>> GetAllUsers();
        Task<Users?> GetUserByEmail(string email);
        Task<Users?> GetUserById(long Id);
    }
}
