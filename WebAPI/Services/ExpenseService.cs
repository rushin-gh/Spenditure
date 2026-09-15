using Microsoft.EntityFrameworkCore;
using WebAPI.Database;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class ExpenseService
    {
        private readonly AppDbContext _context;

        public ExpenseService(AppDbContext context)
        {
            _context = context;
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

        public bool AddExpense(ExpenseWriteDto expense)
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
            return true;
        }

        public bool UpdateExpense(int id, ExpenseUpdateDto expense)
        {
            // TODO - Add validations
            if (expense == null)
            {
                return false;
            }

            var exp = _context.Expenses.FirstOrDefault(exp => exp.Id == id);
            // TODO - Add meaningful messages to failure
            if (exp == null)
            {
                return false;
            }

            if (expense.Title != null) exp.Title = expense.Title;
            if (expense.Amount > 0) exp.Amount = expense.Amount;
            if (expense.Desc != null) exp.Desc = expense.Desc;

            exp.ModifiedAt = DateTime.Now;
            exp.ModifiedBy = expense.ModifiedBy;

            _context.SaveChanges();
            return true;
        }
    }
}
