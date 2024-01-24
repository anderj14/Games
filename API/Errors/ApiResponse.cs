
namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetMessageStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request has been made.",
                401 => "Unauthorized access.",
                403 => "Forbidden from performing this action.",
                404 => "The requested resource was not found.",
                500 => "Internal Server Error: Something went wrong on our end. We're working to fix it",
                _ => null
            } ?? "And unexpected error occurred";
        }
    }
}