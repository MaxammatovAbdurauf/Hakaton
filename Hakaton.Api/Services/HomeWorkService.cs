using HakatonApi.DataBase.Repositories;
using HakatonApi.Extensions.AddServiceFromAttribute;
using HakatonApi.Models.HomeWorkDtos;
using HakatonApi.Services.Interfaces;

namespace HakatonApi.Services;

[Scoped]
public class HomeWorkService : IHomeWorkService
{
    private readonly IUnitOfWork _context;

    public HomeWorkService(IUnitOfWork context)
    {
        _context = context;
    }

    public Task<HomeWorkView> CreateHomeWork(Guid courseId, CreateHomeWorkDto createHomeWorkDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteHomeWork(Guid courseId, Guid homeWorkId)
    {
        throw new NotImplementedException();
    }

    public Task<HomeWorkView> GetHomeWorkById(Guid homeWorkId)
    {
        throw new NotImplementedException();
    }

    public Task<List<HomeWorkView>> GetHomeWorks()
    {
        throw new NotImplementedException();
    }

    public Task<HomeWorkView> UpdateHomeWork(UpdateHomeWorkDto updateHomeWorkDto)
    {
        throw new NotImplementedException();
    }
}