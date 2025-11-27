using User.Domain.CONSTANTS;

namespace User.Domain.Models
{
    public class ApiResponse<T>
    {
        public string? Status { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public string? Exception { get; set; }
        public ApiResponse() { Status = Constant.ApiResponse_Success; }
    }
}
