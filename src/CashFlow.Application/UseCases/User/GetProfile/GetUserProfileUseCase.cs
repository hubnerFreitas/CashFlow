using AutoMapper;
using CashFlow.Communication.Responses.User;
using CashFlow.Domain.Repositories.User;
using CashFlow.Domain.Services;

namespace CashFlow.Application.UseCases.User.GetProfile
{
    public class GetUserProfileUseCase : IGetUserProfileUseCase
    {
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IMapper _mapper;

        public GetUserProfileUseCase(IUserReadOnlyRepository usereadOnlyRepository, IMapper mapper)
        {
            _userReadOnlyRepository = usereadOnlyRepository;
            _mapper = mapper;
        }


        public async Task<List<ResponseUserJson>> Execute()
        {
            var loggedUser = await _userReadOnlyRepository.GetAllUsers();

            return _mapper.Map<List<ResponseUserJson>>(loggedUser);

        }
    }
}
