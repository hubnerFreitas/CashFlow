﻿using CashFlow.Communication.Responses.User;

namespace CashFlow.Application.UseCases.User.GetProfile
{
    public interface IGetUserProfileUseCase
    {
        Task<List<ResponseUserJson>> Execute();
    }
}
