using CashFlow.Communication.Requests.User;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.User;
using CashFlow.Domain.Sercurity.Cryptography;
using CashFlow.Domain.Services;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionBase;
using FluentValidation.Results;

namespace CashFlow.Application.UseCases.User.ChangePassword
{
    public class ChangePasswordUseCase : IChangePasswordUseCase
    {
        private readonly ILoggedUser _loggedUser;
        private readonly IUserUpdateOnlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IPasswordEncripter _passwordEncripter;

        public ChangePasswordUseCase(
            ILoggedUser loggedUser,
            IPasswordEncripter passwordEncripter,
            IUserUpdateOnlyRepository repository,
            IUnitOfWork unitOfWork,
            IUserReadOnlyRepository userReadOnlyRepository)
        {
            _loggedUser = loggedUser;
            _repository = repository;
            _unitOfWork = unitOfWork;
            _passwordEncripter = passwordEncripter;
            _userReadOnlyRepository = userReadOnlyRepository;
        }
        public async Task Execute(RequestChangePasswordJson request)
        {
            var loggedUser = await _loggedUser.Get();
            if (loggedUser is null) throw new System.Exception("User not foud");

            Validate(request, loggedUser);

            var user = await _userReadOnlyRepository.GetUserById(loggedUser.Id);
            if (user is null)
                throw new KeyNotFoundException("User not found");

            user.Password = _passwordEncripter.Encrypt(request.NewPassword);

            _repository.Update(user);

            await _unitOfWork.Commit();
        }

        private void Validate(RequestChangePasswordJson request, Domain.Entities.Users loggedUser)
        {
            var validator = new ChangePasswordValidator();

            var result = validator.Validate(request);

            var passwordMatch = _passwordEncripter.Verify(request.Password, loggedUser.Password);

            if (passwordMatch == false)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessage.PASSWORD_DIFFERENT_CURRENT_PASSWORD));
            }

            if (result.IsValid == false)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
