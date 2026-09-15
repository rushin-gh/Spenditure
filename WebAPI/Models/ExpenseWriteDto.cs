namespace WebAPI.Models
{
    public class ExpenseWriteDto
    {
        public string Title { get; set; } = null!;

        public decimal Amount { get; set; }

        public string? Desc { get; set; }

        public string CreatedBy { get; set; } = null!;
    }
}
