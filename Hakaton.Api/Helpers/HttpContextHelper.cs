namespace HakatonApi.Helpers
{
    public class HttpContextHelper
    {
        public static HttpContextAccessor Accessor { get; set; }
        public static HttpContext HttpContext => Accessor?.HttpContext;
        public static Guid UserId => Guid.Parse(HttpContext?.User?.FindFirst(p => p.Value == "Id")?.Value);
    }
}
