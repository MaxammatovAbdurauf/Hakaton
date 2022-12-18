using HakatonApi.Entities;
using HakatonApi.Models.UserDtos;

namespace HakatonApi.Services.Interfaces;

public interface IAccountService
{
    void DeleteAccount(User user);
    void UpdateAccount(Guid userId, UpdateUserDto updateUserDto);
}