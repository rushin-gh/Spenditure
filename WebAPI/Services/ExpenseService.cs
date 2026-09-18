using Microsoft.EntityFrameworkCore;
using WebAPI.Database;
using WebAPI.Models;
using WebAPI.Contracts;
using WebAPI.Data;
using WebAPI.Custom;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebAPI.Services
{
    public class ExpenseService
    {
        private readonly AppDbContext _context;
        private readonly IMessageService _messageService;

        public ExpenseService(
            AppDbContext context,
            IMessageService messageService
        )
        {
            _context = context;
            _messageService = messageService;
        }

        public ExpenseDisplayDto GetExpense(int id)
        {
            var exp = _context.Expenses.FirstOrDefault(exp => exp.Id == id);
            if (exp == null)
            {
                throw new NotFoundException(string.Format(_messageService.GetMessage(Messages.Expense.NotFound), id));
            }

            var expense = new ExpenseDisplayDto()
            {
                Id = exp.Id,
                Title = exp.Title,
                Amount = exp.Amount,
                Desc = exp.Desc,
                CreatedBy = exp.CreatedBy,
                CreatedAt = exp.CreatedAt,
                ModifiedBy = exp.ModifiedBy,
                ModifiedAt = exp.ModifiedAt
            };

            return expense;
        }

        public ExpenseDisplayDtoList GetAllExpenses()
        {
            var expenses = new ExpenseDisplayDtoList();

            foreach (var exp in _context.Expenses)
            {
                expenses.ExpenseDtoLst.Add(new ExpenseDisplayDto()
                {
                    Id = exp.Id,
                    Title = exp.Title,
                    Amount = exp.Amount,
                    Desc = exp.Desc,
                    CreatedBy = exp.CreatedBy,
                    CreatedAt = exp.CreatedAt,
                    ModifiedBy = exp.ModifiedBy,
                    ModifiedAt = exp.ModifiedAt
                });
            }

            return expenses;
        }

        public void AddExpense(ExpenseWriteDto expense)
        {
            // TODO - Validations
            _context.Expenses.Add(new Expense()
            {
                Title = expense.Title,
                Amount = expense.Amount,
                Desc = expense.Desc,
                CreatedAt = DateTime.Now,
                CreatedBy = string.IsNullOrWhiteSpace(expense.CreatedBy)
                            ? "system"
                            : expense.CreatedBy,
                Status = true
            });
            _context.SaveChanges();
        }

        public ExpenseDisplayDto UpdateExpense(int id, ExpenseUpdateDto expense)
        {
            ExpenseDisplayDto expDisplayDto = null;

            // TODO - Add validations
            if (expense == null)
            {
                throw new BadRequestException(_messageService.GetMessage(Messages.Expense.InvalidUpdateModel));
            }

            var exp = _context.Expenses.FirstOrDefault(exp => exp.Id == id);
            if (exp == null)
            {
                throw new NotFoundException(string.Format(_messageService.GetMessage(Messages.Expense.NotFound), id));
            }

            bool isExpModified = false;
            if (expense.Title != null && expense.Title != exp.Title)
            {
                exp.Title = expense.Title;
                isExpModified = true;
            }

            if (expense.Amount > 0 && expense.Amount != exp.Amount)
            {
                exp.Amount = expense.Amount;
                isExpModified = true;
            }

            if (expense.Desc != null && expense.Desc != exp.Desc)
            {
                exp.Desc = expense.Desc;
                isExpModified = true;
            }

            if (isExpModified)
            {
                exp.ModifiedAt = DateTime.Now;
                exp.ModifiedBy = expense.ModifiedBy;
                _context.SaveChanges();

                expDisplayDto = _context.Expenses
                                    .Where(exp => exp.Id == id)
                                    .Select(exp => new ExpenseDisplayDto
                                    {
                                        Id = exp.Id,
                                        Title = exp.Title,
                                        Amount = exp.Amount,
                                        Desc = exp.Desc,
                                        CreatedBy = exp.CreatedBy,
                                        CreatedAt = exp.CreatedAt,
                                        ModifiedBy = exp.ModifiedBy,
                                        ModifiedAt = exp.ModifiedAt
                                    })
                                    .FirstOrDefault()!;
                return expDisplayDto;
            }

            throw new BadRequestException(string.Format(_messageService.GetMessage(Messages.Expense.NothingToUpdate), id));
        }


        public ExpenseDisplayDto DeleteExpense(int id)
        {
            var expDisplayDto = new ExpenseDisplayDto();

            // TODO - Add validations
            var exp = _context.Expenses.FirstOrDefault(exp => exp.Id == id);

            // TODO - Add meaningful messages to failure
            if (exp == null)
            {
                throw new NotFoundException(string.Format(_messageService.GetMessage(Messages.Expense.NotFound), id));
            }

            expDisplayDto = _context.Expenses
                                .Where(exp => exp.Id == id)
                                .Select(exp => new ExpenseDisplayDto
                                {
                                    Id = exp.Id,
                                    Title = exp.Title,
                                    Amount = exp.Amount,
                                    Desc = exp.Desc,
                                    CreatedBy = exp.CreatedBy,
                                    CreatedAt = exp.CreatedAt,
                                    ModifiedBy = exp.ModifiedBy,
                                    ModifiedAt = exp.ModifiedAt
                                })
                                .FirstOrDefault()!;

            _context.Expenses.Remove(exp);
            _context.SaveChanges();

            return expDisplayDto;
        }
    }
}
