using CashFlow.Domain.Repositories.Expenses;


namespace CashFlow.Infrastructure.DataAccess.Repositories.Expense
{
    internal class ExpensesRepository : IExpensesRepository
    {
        private readonly CashFlowDbContext _context;

        public ExpensesRepository(CashFlowDbContext context)
        {
            _context = context;
        }

        public void Add(Domain.Entities.Expense expense)
        {
            _context.Expenses.Add(expense);
        }
    }
}
