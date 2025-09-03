using AutoMapper;
using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Application.UseCases.User.Register;
using CashFlow.Communication.Requests.User;
using CashFlow.Communication.Responses.User;
using CashFlow.Domain.Entities;

namespace CashFlow.Application.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            MappingEntity();
        }

        private void MappingEntity()
        {
            CreateMap<RequestRegisterUserJson, Users>()
                .ForMember(dest => dest.Password, config => config.Ignore());

            CreateMap<ResponseRegisterUserJson, Users>().ReverseMap();



            CreateMap<RegisterExpenseUseCase, Expense>().ReverseMap();
            CreateMap<ResponseRegisterUserJson, Users>().ReverseMap();
        }
    }
}
