using CashFlow.Communication.Requests.Login;
using CashFlow.Communication.Responses.User;
using CashFlow.Domain.Repositories.User;
using CashFlow.Domain.Sercurity.Cryptography;
using CashFlow.Domain.Sercurity.Tokens;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCases.LoginDoLogin
{
    public class DoLoginUseCase : IDoLoginUseCase
    {
        private readonly IUserReadOnlyRepository _repository;
        private readonly IPasswordEncripter _passwordEncripter;
        private readonly IAccessTokenGenerator _accessTokenGenerator;

        public DoLoginUseCase(
            IUserReadOnlyRepository repository,
            IPasswordEncripter passwordEncripter,
            IAccessTokenGenerator accessTokenGenerator)
        {
            _passwordEncripter = passwordEncripter;
            _repository = repository;
            _accessTokenGenerator = accessTokenGenerator;
        }
        public async Task<ResponseRegisterUserJson> Execute(RequestLoginJson request)
        {
            var user = await _repository.GetUserByEmail(request.Email);

            if (user is null)
                throw new InvalidLoginException();

            var passwordMatch = _passwordEncripter.Verify(request.Password, user.Password);

            if (passwordMatch == false)
                throw new InvalidLoginException();

            return new ResponseRegisterUserJson
            {
                Name = user.Name,
                Token = _accessTokenGenerator.GenerateToken(user)
            };
        }
    }
}
