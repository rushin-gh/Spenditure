namespace WebAPI.Models
{
    public class ExpenseUpdateDto
    {
        public string? Title { get; set; } = null!;

        public decimal Amount { get; set; }

        public string? Desc { get; set; }

        public string? ModifiedBy { get; set; }
    }
}
