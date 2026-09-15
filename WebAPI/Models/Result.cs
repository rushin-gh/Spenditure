namespace WebAPI.Models
{
    public class Response
    {
        public bool Result { get; set; }

        public string Message { get; set; }

        public Response() 
        {
            Result = true;
            Message = "";
        }

        public Response(bool result = true, string message = "")
        {
            Result = result;
            Message = message;
        }

        public Response(bool result) : this(result, "") { }

        public Response(string message) : this(true, message) { }
    }
}
