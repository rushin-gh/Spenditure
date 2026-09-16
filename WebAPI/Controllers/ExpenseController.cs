using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("expense")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly ExpenseService _expenseService;

        public ExpenseController(ExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpGet("get/{id}")]
        public ActionResult<ExpenseDisplayDto> GetExpense(int id)
        {
            return _expenseService.GetExpense(id);
        }

        [HttpGet("get")]
        public ActionResult<ExpenseDisplayDtoList> GetExpenses()
        {
            return _expenseService.GetAllExpenses();
        }

        [HttpPost("add")]
        public ActionResult<Response> AddExpense(ExpenseWriteDto expense) 
        {
            Response response = new Response();
            bool addExpense = _expenseService.AddExpense(expense);

            if (!addExpense)
            {
                response.Result = false;
                response.Message = "Internal server error!";
            }

            return response;
        }

        [HttpPatch("update/{id}")]
        public ActionResult<Response> UpdateExpense(int id, ExpenseUpdateDto expense)
        {
            // Add validations
            Response response = new Response();
            bool updateExpense = _expenseService.UpdateExpense(id, expense);

            if (!updateExpense)
            {
                response.Result = false;
                response.Message = "Internal server error!";
            }

            return response;
        }

        [HttpDelete("delete/{id}")]
        public ActionResult<Response> DeleteExpense(int id)
        {
            // Add validations
            Response response = new Response();
            bool updateExpense = _expenseService.DeleteExpense(id);

            if (!updateExpense)
            {
                response.Result = false;
                response.Message = "Internal server error!";
            }

            return response;
        }
    }
}
