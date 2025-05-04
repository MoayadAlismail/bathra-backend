using System.Net;

namespace Bathra.Application.DTOs
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string[] Errors { get; set; }

        public static ApiResponse<T> SuccessResponse(T data, string message = "Operation completed successfully")
        {
            return new ApiResponse<T>
            {
                Success = true,
                Message = message,
                Data = data,
                StatusCode = HttpStatusCode.OK,
                Errors = Array.Empty<string>()
            };
        }

        public static ApiResponse<T> ErrorResponse(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest, string[] errors = null)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = message,
                Data = default,
                StatusCode = statusCode,
                Errors = errors ?? Array.Empty<string>()
            };
        }
    }
} 