using HakatonApi.Models.CommentDto;
using System.Security.Claims;

namespace HakatonApi.Services.Interfaces;

public interface ITaskCommentService
{
    Task<List<TaskCommentDto>> GetTaskComments(Guid courseId, Guid taskId);
    Task AddTaskComments(ClaimsPrincipal claims,Guid courseId, Guid taskId, CreateTaskCommentDto taskCommentDto);
}