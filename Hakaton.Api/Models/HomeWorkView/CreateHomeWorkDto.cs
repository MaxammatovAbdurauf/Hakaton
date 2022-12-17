﻿using TaskStatus = HakatonApi.Entities.TaskStatus;

namespace HakatonApi.Models.HomeWorkView;

public class CreateHomeWorkDto
{
    public string? TaskName { get; set; }
    public string? TaskDescription { get; set; }
    public int MaxScore { get; set; }
    public string? FilePath { get; set; }
    public DateTime? CreateDate { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}