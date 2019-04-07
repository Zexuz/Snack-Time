using System;

namespace SnackTime.WebApi.Helpers
{
    public class ApiResponse<T>
    {
        public bool      Success { get; set; }
        public T         Payload { get; set; }
        public Exception Error   { get; set; }
    }
}