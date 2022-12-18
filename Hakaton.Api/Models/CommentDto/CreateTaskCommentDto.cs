namespace HakatonApi.Models.CommentDto;

public class CreateTaskCommentDto
{
    public string? Comment { get; set; }
    public Guid? ParentId { get; set; }
}