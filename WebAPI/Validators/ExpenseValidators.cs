using System.Text;
using WebAPI.Models;
using WebAPI.Services;
using WebAPI.Data;
using WebAPI.Custom;
using WebAPI.Contracts;

namespace WebAPI.Validators
{
    public class ExpenseValidators
    {
        private readonly IMessageService _messageService;

        public ExpenseValidators (IMessageService messageService)
        {
            _messageService = messageService;
        }

        public void Validate(ExpenseWriteDto expense)
        {
            List<string> validations = new();

            if (string.IsNullOrWhiteSpace(expense.Title))
            {
                validations.Add(_messageService.GetMessage(Messages.Expense.Validations.EmptyTitle));
            } 
            
            if (expense.Amount <= 0)
            {
                validations.Add(_messageService.GetMessage(Messages.Expense.Validations.InvalidAmount));
            }

            if (validations.Count > 0)
                throw new BadRequestException(string.Join(" | ", validations));
        }
    }
}
