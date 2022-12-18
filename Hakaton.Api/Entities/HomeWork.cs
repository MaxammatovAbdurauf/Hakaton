﻿using System.ComponentModel.DataAnnotations.Schema;

namespace HakatonApi.Entities;
public class HomeWork
{
    public Guid Id { get; set; }
    public string? TaskName { get; set; }
    public string? TaskDescription { get; set; }
    public int MaxScore { get; set; }
    public TaskStatus Status { get; set; }
    public string? FilePath { get; set; }
    public DateTime? CreateDate { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public virtual List<Result>? UserTasks { get; set; }
}

public enum TaskStatus
{
    created,
    delayed,
    finished,
}