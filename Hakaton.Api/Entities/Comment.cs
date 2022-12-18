using System.ComponentModel.DataAnnotations.Schema;

namespace HakatonApi.Entities;

public class Comment
{
    public Guid Id { get; set; }
    public string? Comments { get; set; }
    public DateTime? CreatedDate { get; set; } = DateTime.Now;

    public Guid? ParentId { get; set; }
    [ForeignKey(nameof(ParentId))]
    public virtual Comment? Parent { get; set; }
    public virtual List<Comment>? Children { get; set; }

    public Guid? TaskId { get; set; }
    [ForeignKey(nameof(TaskId))]
    public virtual Task? Task { get; set; }

    public Guid UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public virtual User? User { get; set; }

}