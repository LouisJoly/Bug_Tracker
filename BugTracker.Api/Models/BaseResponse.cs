namespace BugTracker.Api.Models
{
    public interface IBaseResponse
    {
        bool Success { get; set; }
        string? Message { get; set; }
        int StatusCode { get; set; }
        List<string> Errors { get; set; }
        DateTime Timestamp { get; set; }
        bool Validate();
    }

    public class BaseResponse<T> : IBaseResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }
        public DateTime Timestamp { get; set; }
        public T? Data { get; set; }
        public int? TotalCount { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }

        public BaseResponse()
        {
            Success = true;
            Timestamp = DateTime.UtcNow;
            StatusCode = 200;
            Errors = new List<string>();
        }

        public BaseResponse(T data)
        {
            Data = data;
        }

        public BaseResponse(string message, bool success = false)
        {
            Success = success;
            Message = message;
            if (!success)
            {
                StatusCode = 400;
            }
        }

        public BaseResponse(Exception ex)
        {
            Success = false;
            Message = ex.Message;
            StatusCode = 500;
            Errors.Add(ex.Message);
        }

        public bool Validate()
        {
            if (Data == null && Success)
            {
                Errors.Add("No data provided for successful response");
                Success = false;
                StatusCode = 400;
                return false;
            }

            if (Errors.Count > 0)
            {
                Success = false;
                StatusCode = 400;
                return false;
            }

            return true;
        }
    }

    public class BaseResponse : BaseResponse<object>
    {
        public BaseResponse() : base() { }
        public BaseResponse(object data) : base(data) { }
        public BaseResponse(string message, bool success = false) : base(message, success) { }
        public BaseResponse(Exception ex) : base(ex) { }
    }
}
