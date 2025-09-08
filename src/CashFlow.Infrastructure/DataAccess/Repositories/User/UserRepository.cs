using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories.User
{
    internal class UserRepository : IUserWriteOnlyRepository, IUserReadOnlyRepository, IUserUpdateOnlyRepository
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

        public async Task Delete(Users user)
        {
            var userToRemove = await _context.Users.FindAsync(user.Id);
            _context.Users.Remove(userToRemove!);
        }

        public async Task<bool> ExistActiveUserWithEmail(string email)
        {
            return await _context.Users.AnyAsync(user => user.Email.Equals(email));
        }

        public async Task<Users?> GetUserByEmail(string email)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Email.Equals(email));
        }

        public async Task<Users?> GetUserById(long Id)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Id == Id);
        }

        public void Update(Users user)
        {
            _context.Users.Update(user);
        }
    }
}
