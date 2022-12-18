using HakatonApi.DataBase;
using HakatonApi.Models.ResultDtos;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HakatonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ResultsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{courseId}/tasks/{taskId}/results")]
        public async Task<IActionResult> GetTaskResults(Guid courseId, Guid taskId)
        {

            if (task.Results is null) 
                return Ok();
               
            return Ok(taskDto);
        }


        [HttpPut("{courseId}/tasks/{taskId}/results/{resultId}")]
        public async Task<IActionResult> UpdateUserResult(Guid courseId, Guid taskId, Guid resultId, CreateUserTaskResultDto resultDto)
        {
            return Ok();
        }


    }
}
