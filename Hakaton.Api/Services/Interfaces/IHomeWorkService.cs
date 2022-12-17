using HakatonApi.Models.HomeWorkView;
using Microsoft.AspNetCore.Mvc;

namespace HakatonApi.Services.Interfaces;

public interface IHomeWorkRepository
{
    Task<HomeWorkView> CreateHomeWork(Guid Id,CreateHomeWorkDto createHomeWorkDto);
    Task<HomeWorkView> UpdateHomeWork(Guid CourseKey,UpdateHomeWorkDto updateHomeWorkDto);
    Task<List<HomeWorkView>> GetTasks(Guid courseId);
    Task DeleteHomeWork();

}