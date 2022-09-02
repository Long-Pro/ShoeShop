namespace WebAPI.Models
{
    public class ApiResponse
    {
        public string Message;
        public object Data;
        public int? TotalPage;


        public ApiResponse(string message, object data = null, int? totalPage = null)
        {
            Message = message;
            Data = data;
            TotalPage = totalPage;
        }
    }
}
