namespace WebAPI.Models
{
    public class ExpenseDisplayDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public decimal Amount { get; set; }

        public string? Desc { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime? ModifiedAt { get; set; }

        public string? ModifiedBy { get; set; }
    }
}
