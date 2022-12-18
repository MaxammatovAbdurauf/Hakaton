using HakatonApi.Models.UserDtos;
using HakatonApi.Entities;

namespace HakatonApi.Services.Interfaces;

public interface IUserService 
{
    void LeaveCourse(Guid courseId, Guid userId);
    Task JoinToCourse(Guid courseId, Guid userId);
}