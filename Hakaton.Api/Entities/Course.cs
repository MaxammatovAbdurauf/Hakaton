namespace HakatonApi.Entities;

public class Course
{
    public Guid Id { get; set; }
    public Guid Key { get; set; }
    public string? CourceName { get; set; }
    public virtual List<UserCourse>? UserCourseList { get; set; }
    public virtual List<Task>? Tasklist { get; set; }

}