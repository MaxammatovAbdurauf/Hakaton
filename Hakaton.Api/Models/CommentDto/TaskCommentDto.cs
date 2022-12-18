using HakatonApi.Entities;

namespace HakatonApi.Models.CommentDto;

public class TaskCommentDto
{
    public Guid Id { get; set; }
    public string? Comment { get; set; }
    public DateTime? CreatedDate { get; set; }

    public virtual List<TaskCommentDto>? Children { get; set; }

    public virtual User? User { get; set; }
}