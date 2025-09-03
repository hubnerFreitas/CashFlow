using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories.User
{
    internal class UserRepository : IUserWriteOnlyRepository, IUserReadOnlyRepository
    {

        private readonly CashFlowDbContext _context;

        public UserRepository(CashFlowDbContext context)
        {
            _context = context;
        }
        public async Task Add(Users user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<bool> ExistActiveUserWithEmail(string email)
        {
            return await _context.Users.AnyAsync(user => user.Email.Equals(email));
        }
    }
}
