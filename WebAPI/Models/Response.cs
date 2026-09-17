namespace WebAPI.Models
{
    public class Response<T>
    {
        public bool Result { get; set; }

        public string Message { get; set; }

        public T Data { get; set; } = default!;

        public Response() 
        {
            Result = true;
            Message = "";
        }

        public Response(bool result = true, string message = "", T data = default)
        {
            Result = result;
            Message = message;
            Data = data;
        }

        public Response(bool result) : this(result, "") { }

        public Response(string message) : this(true, message) { }

        public Response(T Data) : this(true, "", Data) { }
    }


}
