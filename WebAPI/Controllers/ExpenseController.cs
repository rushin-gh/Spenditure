using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Contracts;
using WebAPI.Services;
using WebAPI.Data;
using WebAPI.Custom;

namespace WebAPI.Controllers
{
    [Route("expense")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly ExpenseService _expenseService;
        private readonly IMessageService _messageService;

        public ExpenseController(
            ExpenseService expenseService,
            IMessageService messageService
        )
        {
            _expenseService = expenseService;
            _messageService = messageService;
        }

        [HttpGet("get/{id}")]
        public ActionResult<Response<ExpenseDisplayDto>> GetExpense(int id)
        {
            var response = new Response<ExpenseDisplayDto>();
            try
            {
                response.Data = _expenseService.GetExpense(id);
                response.Message = _messageService.GetMessage(Messages.Expense.Found);
            }
            catch(NotFoundException ex)
            {
                response.Result = false;
                response.Message = ex.Message;
                return StatusCode(StatusCodes.Status404NotFound, response);
            }
            catch(BadRequestException ex)
            {
                response.Result = false;
                response.Message = ex.Message;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Message = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            return response;
        }

        [HttpGet("get")]
        public ActionResult<Response<ExpenseDisplayDtoList>> GetExpenses()
        {
            var response = new Response<ExpenseDisplayDtoList>();
            try
            {
                response.Data = _expenseService.GetAllExpenses();
                response.Message = _messageService.GetMessage(Messages.Expense.Found);
            }
            catch (NotFoundException ex)
            {
                response.Result = false;
                response.Message = ex.Message;
                return StatusCode(StatusCodes.Status404NotFound, response);
            }
            catch (BadRequestException ex)
            {
                response.Result = false;
                response.Message = ex.Message;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Message = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            return response;
        }

        [HttpPost("add")]
        public ActionResult<Response<ExpenseWriteDto>> AddExpense(ExpenseWriteDto expense)
        {
            var response = new Response<ExpenseWriteDto>();
            try
            {
                _expenseService.AddExpense(expense);
                response.Message = _messageService.GetMessage(Messages.Expense.Added);
                response.Data = expense;
            }
            catch (NotFoundException ex)
            {
                response.Result = false;
                response.Message = ex.Message;
                return StatusCode(StatusCodes.Status404NotFound, response);
            }
            catch (BadRequestException ex)
            {
                response.Result = false;
                response.Message = ex.Message;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Message = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            return response;
        }

        [HttpPatch("update/{id}")]
        public ActionResult<Response<ExpenseDisplayDto>> UpdateExpense(int id, ExpenseUpdateDto expense)
        {
            // Add validations
            var response = new Response<ExpenseDisplayDto>();
            try
            {
                response.Data = _expenseService.UpdateExpense(id, expense);
                response.Message = string.Format(_messageService.GetMessage(Messages.Expense.UpdatedSuccessfully), id);
            }
            catch (NotFoundException ex)
            {
                response.Result = false;
                response.Message = ex.Message;
                return StatusCode(StatusCodes.Status404NotFound, response);
            }
            catch (BadRequestException ex)
            {
                response.Result = false;
                response.Message = ex.Message;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Message = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            return response;
        }

        [HttpDelete("delete/{id}")]
        public ActionResult<Response<ExpenseDisplayDto>> DeleteExpense(int id)
        {
            // Add validations
            var response = new Response<ExpenseDisplayDto>();
            try
            {
                response.Data = _expenseService.DeleteExpense(id);
                response.Message = string.Format(_messageService.GetMessage(Messages.Expense.Deleted), id);
            }
            catch (NotFoundException ex)
            {
                response.Result = false;
                response.Message = ex.Message;
                return StatusCode(StatusCodes.Status404NotFound, response);
            }
            catch (BadRequestException ex)
            {
                response.Result = false;
                response.Message = ex.Message;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Message = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            return response;
        }
    }
}
