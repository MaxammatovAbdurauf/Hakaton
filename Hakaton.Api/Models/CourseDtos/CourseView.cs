using HakatonApi.Entities;

namespace HakatonApi.Models.CourseDtos;

public class CourseView
{
    public Guid Id { get; set; }
    public Guid Key { get; set; }
    public string? CourseName { get; set; }
    public virtual List<CourseUser>? UserCourseList { get; set; }
    public virtual List<HomeWork>? Tasklist { get; set; }
}