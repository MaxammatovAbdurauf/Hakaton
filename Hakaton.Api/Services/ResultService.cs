using HakatonApi.DataBase;
using HakatonApi.DataBase.Repositories;
using HakatonApi.Models.ResultDtos;
using HakatonApi.Services.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HakatonApi.Services
{
    public class ResultService : IResultService
    {
        private readonly IUnitOfWork context;

        public ResultService(IUnitOfWork context)
        {
            this.context = context;
        }


        public async Task<IActionResult> GetTaskResults(Guid courseId, Guid taskId)
        {
            var task = await context.ResultRepository.FirstOrDefaultAsync(t => t.Id == taskId && t.CourseId == courseId);
             
            var taskDto = task.Adapt<UsersTaskResultsDto>();

        }

        public async Task<IActionResult> UpdateUserResult(UsersTaskResult resultDto)
        {
            var result = await context.ResultRepository.GetById(resultDto.Id);
            result.Status = resultDto.Status;
            result.Description = resultDto.Description;
            await context.SaveChangesAsync();
        }
    }
}
