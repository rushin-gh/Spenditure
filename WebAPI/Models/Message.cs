namespace WebAPI.Models
{
    public class Message
    {
        public int Id { get; set; }

        public string Code { get; set; } = null!;

        public string Text { get; set; } = null!;

        public bool Status { get; set; }
    }
}
