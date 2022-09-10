namespace WebAPI.Models
{
    public class ApiResponse
    {
        public string Message;
        public object Data;

        public ApiResponse(string message, object data = null)
        {
            Message = message;
            Data = data;
        }
    }
}
