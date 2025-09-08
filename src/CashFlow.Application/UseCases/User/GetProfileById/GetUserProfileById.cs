using AutoMapper;
using CashFlow.Communication.Responses.User;
using CashFlow.Domain.Repositories.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Application.UseCases.User.GetProfileById
{
    public class GetUserProfileById : IGetUserProfileById
    {
        private readonly IMapper _mapper;
        private readonly IUserReadOnlyRepository _repository;

        public GetUserProfileById(IMapper mapper,
            IUserReadOnlyRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ResponseUserJson> Execute(long Id)
        {
            var user = await _repository.GetUserById(Id);

            return _mapper.Map<ResponseUserJson>(user);
        }
    }
}
