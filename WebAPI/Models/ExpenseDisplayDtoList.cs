namespace WebAPI.Models
{
    public class ExpenseDisplayDtoList
    {
        public List<ExpenseDisplayDto> ExpenseDtoLst { get; set; }

        public ExpenseDisplayDtoList()
        {
            ExpenseDtoLst = new List<ExpenseDisplayDto>();
        }
    }
}
