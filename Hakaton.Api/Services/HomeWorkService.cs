using HakatonApi.Models.HomeWorkView;
using HakatonApi.Services.Interfaces;

namespace HakatonApi.Services;

public class HomeWorkRepository : IHomeWorkRepository
{
    public Task<HomeWorkView> CreateHomeWork(Guid Id, CreateHomeWorkDto createHomeWorkDto)
    {
        throw new NotImplementedException();
    }

    public Task<HomeWorkView> UpdateHomeWork(Guid CourseKey, UpdateHomeWorkDto updateHomeWorkDto)
    {
        throw new NotImplementedException();
    }

    public Task<List<HomeWorkView>> GetTasks(Guid courseId)
    {
        throw new NotImplementedException();
    }

    public Task DeleteHomeWork(Guid HomeWorkId)
    {
        throw new NotImplementedException();
    }
}