using Constant = User.Domain.CONSTANTS.Constant;

namespace User.Domain.Models
{
    public class MetaApiResponse<T>
    {
        public string? Status { get; set; }
        public string? Message { get; set; }
        public MetaResponse? Meta { get; set; }
        public T? Data { get; set; }        
        public string? Exception { get; set; }
        public MetaApiResponse() { Status = Constant.ApiResponse_Success; }
    }
}
