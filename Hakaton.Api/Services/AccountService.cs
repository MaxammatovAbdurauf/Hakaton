﻿using HakatonApi.DataBase.Repositories;
using HakatonApi.Entities;
using HakatonApi.Models.UserDtos;
using HakatonApi.Services.Interfaces;

namespace HakatonApi.Services;

public class AccountService : IAccountService
{
    private readonly IUnitOfWork context;
    public AccountService(IUnitOfWork _context) => context = _context;

    public void DeleteAccount(User user) => context.UserRepository.Remove(user);

    public void UpdateAccount(Guid userId, UpdateUserDto updateUserDto)
    {
        var user = context.UserRepository.GetById(userId);
        if (user is null) throw new Exception();
        context.UserRepository.Update(user);
    }
}