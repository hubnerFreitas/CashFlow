using CashFlow.Application.AutoMapper;
using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Application.UseCases.LoginDoLogin;
using CashFlow.Application.UseCases.User.ChangePassword;
using CashFlow.Application.UseCases.User.Delete;
using CashFlow.Application.UseCases.User.GetProfile;
using CashFlow.Application.UseCases.User.GetProfileById;
using CashFlow.Application.UseCases.User.Register;
using CashFlow.Application.UseCases.User.UpdateProfile;
using CashFlow.Application.UseCases.Users.Delete;
using CashFlow.Application.UseCases.Users.Update;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddUseCases(services);
            AddAutoMapper(services);
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(config => config.AddProfile<AutoMapping>());
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegisterExpenseUseCase, RegisterExpenseUseCase>();
            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
            services.AddScoped<IDoLoginUseCase, DoLoginUseCase>();

            services.AddScoped<IGetUserProfileUseCase, GetUserProfileUseCase>();
            services.AddScoped<IGetUserProfileById, GetUserProfileById>();

            services.AddScoped<IDeleteUserAccountUseCase, DeleteUserAccountUseCase>();
            services.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();
            services.AddScoped<IChangePasswordUseCase, ChangePasswordUseCase>();
        }
    }
}
