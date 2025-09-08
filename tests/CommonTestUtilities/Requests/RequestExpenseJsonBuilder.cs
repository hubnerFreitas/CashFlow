using Bogus;
using CashFlow.Communication.Enum;
using CashFlow.Communication.Requests.User;

namespace CommonTestUtilities.Requests
{
    public  class RequestExpenseJsonBuilder
    {
        public static RequestRegisterExpensesJson Build()
        {
            return new Faker<RequestRegisterExpensesJson>()
                .RuleFor(x => x.Title, faker => faker.Commerce.ProductName())
                .RuleFor(x => x.Description, faker => faker.Commerce.ProductDescription())
                .RuleFor(x => x.Date, faker => faker.Date.Past())
                .RuleFor(x => x.Amount, faker => faker.Random.Decimal(min: 1, max: 1000))
                .RuleFor(x => x.PaymentType, faker => faker.PickRandom<PaymentType>());
        }
    }
}
