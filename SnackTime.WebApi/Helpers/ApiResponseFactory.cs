namespace SnackTime.WebApi.Helpers
{
    public static class ApiResponseFactory
    {
        public static ApiResponse<T> CreateSuccess<T>(T payload)
        {
            return new ApiResponse<T>
            {
                Payload = payload,
                Success = true,
                Error = null,
            };
        }
    }
}