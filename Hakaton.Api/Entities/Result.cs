using System.ComponentModel.DataAnnotations.Schema;

namespace HakatonApi.Entities;

public class Result
{
    public Guid Id { get; set; }
    public string? Description { get; set; }
    public string? AdminComment { get; set; }
    public EUserTaskStatus ResultStatus { get; set; }

    public Guid UserId { get; set; }
    [ForeignKey(nameof(UserId))]  //UserConfiguration : IEntityTypeConfiguration<User> bu yerda foreign key va relational yozilgan
    public virtual User? User { get; set; }

    public Guid TaskId { get; set; }
    [ForeignKey(nameof(TaskId))]
    public virtual Task? Task { get; set; }
}

public enum EUserTaskStatus
{
    created,
    finished,
    accepted,
    rejected,
    allowedAgain
}