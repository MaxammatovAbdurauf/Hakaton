using System.Security.Claims;
using HakatonApi.DataBase.Repositories;
using HakatonApi.Entities;
using HakatonApi.Models.CommentDto;
using HakatonApi.Models.UserDtos;
using HakatonApi.Services.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HakatonApi.Services;

public class TaskCommentService : ITaskCommentService
{
    private readonly IUnitOfWork _context;
    private readonly UserManager<User> _userManager;
    private readonly HttpContext _httpContext;

    public TaskCommentService(IUnitOfWork context, UserManager<User> userManager, HttpContext httpContext)
    {
        _context = context;
        _userManager = userManager;
        _httpContext = httpContext;
    }

    public async Task<List<TaskCommentDto>> GetTaskComments(Guid courseId, Guid taskId)
    {

        var task = await _context.HomeWorkRepository.GetAll()
            .FirstOrDefaultAsync(c => c.Id == taskId && c.CourseId == courseId);

        if (task is null)
            return new List<TaskCommentDto>();
         

        var comments = new List<TaskCommentDto>();

        if (task.Comments is null)
            return new List<TaskCommentDto>();

        var mainComments = task.Comments;

        foreach (var comment in mainComments)
        {
            var commentDto = ToTaskCommentDto(comment); 
            comments.Add(commentDto);
        }

        return comments;
    }
    private TaskCommentDto ToTaskCommentDto(Comment comment)
    {
        var commentDto = new TaskCommentDto()
        {
            Id = comment.Id,
            Comment = comment.Comments,
            CreatedDate = comment.CreatedDate,
            User = comment.User?.Adapt<User>(),
        };

        if (comment.Children is null)
            return commentDto;

        foreach (var child in comment.Children)
        {
            commentDto.Children ??= new List<TaskCommentDto>();
            commentDto.Children.Add(ToTaskCommentDto(child));
        }

        return commentDto;
    }
    public async Task AddTaskComments(ClaimsPrincipal claims,Guid courseId, Guid taskId, CreateTaskCommentDto taskCommentDto)
    {

        var task = await _context.HomeWorkRepository.GetAll().FirstOrDefaultAsync(t => t.Id == taskId && t.CourseId == courseId);
        if (task is null)
            return;
        
        var user = await _userManager.GetUserAsync(_httpContext.User);
        

        task.Comments ??= new List<Comment>();

        task.Comments.Add(new Comment()
        {
            TaskId = taskId,
            UserId = user.Id,
            Comments = taskCommentDto.Comment,
            ParentId = taskCommentDto.ParentId
        });

        await _context.SaveAsync();

        return ;
    }
}