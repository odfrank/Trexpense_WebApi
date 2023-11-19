using Expenses.Core;
using Microsoft.AspNetCore.Mvc;
using Trexpense.DB;

namespace Trexpense.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpensesController : ControllerBase
    {
        private IExpensesServices _expensesServices;
        public ExpensesController(IExpensesServices expensesServices)
        {
            _expensesServices = expensesServices;

          
        }

        [HttpGet]
        public IActionResult GetExpenses()
        {
            return Ok(_expensesServices.GetExpenses());
        }

        [HttpGet("{id}", Name = "GetExpense")]
        public IActionResult GetExpense(int id)
        {
            return Ok(_expensesServices.GetExpense(id));
        }

        [HttpPost]
        public IActionResult CreateExpense(Expense expense)
        {
            var newExpense = _expensesServices.CreateExpense(expense);

            return CreatedAtRoute("GetExpense", new {newExpense.Id}, newExpense);
        }

        [HttpPut]
        public IActionResult EditExpense(Expense expense)
        {
            return Ok(_expensesServices.EditExpense(expense));
        }

        //[HttpDelete]
        //public IActionResult DeleteExpense(Expense expense)
        //{
        //    _expensesServices.DeleteExpense(expense);
        //    return Ok();
        //}

        [HttpDelete]
        public IActionResult DeleteExpense(int id)
        {
            _expensesServices.DeleteExpense(id);
            return Ok();
        }
    }
}