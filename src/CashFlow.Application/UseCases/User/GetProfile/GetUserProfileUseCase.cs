using AutoMapper;
using CashFlow.Communication.Responses.User;
using CashFlow.Domain.Services;

namespace CashFlow.Application.UseCases.User.GetProfile
{
    public class GetUserProfileUseCase : IGetUserProfileUseCase
    {
        private readonly ILoggedUser _loggedUser;
        private readonly IMapper _mapper;

        public GetUserProfileUseCase(ILoggedUser loggedUser, IMapper mapper)
        {
            _loggedUser = loggedUser;
            _mapper = mapper;
        }


        public async Task<ResponseUserJson> Execute()
        {
            var loggedUser = await  _loggedUser.Get();

            return _mapper.Map<ResponseUserJson>(loggedUser);

        }
    }
}
