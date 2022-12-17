using System.ComponentModel.DataAnnotations.Schema;

namespace HakatonApi.Entities;
public class HomeWork
{
    public string? TaskName { get; set; }
    public string? TaskDescription { get; set; }
    public int MaxScore { get; set; }
    public string? FilePath { get; set; }
}

public enum TaskStatus
{
    created,
    delayed,
    finished,
}