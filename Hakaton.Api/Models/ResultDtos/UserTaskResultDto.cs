using HakatonApi.Entities;

namespace HakatonApi.Models.ResultDtos
{
    public class UserTaskResultDto : UserTaskResult
    {
        public UserTaskResult? UserResult { get; set; }
    }
    public class UserTaskResult 
    {
        public string? Description { get; set; }
        public EUserTaskStatus Status { get; set; }
    }

    public class UsersTaskResult : UserTaskResult
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
