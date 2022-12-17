using TaskStatus = HakatonApi.Entities.TaskStatus;

namespace HakatonApi.Models.HomeWorkView;

public class HomeWorkView
{
    public string? TaskName { get; set; }
    public string? TaskDescription { get; set; }
    public int MaxScore { get; set; }
    public string? FilePath { get; set; }
}