using System.Collections.Generic;
using Trexpense.DB;

namespace Expenses.Core
{
    public interface IExpensesServices
    {
        List<Expense> GetExpenses();
        Expense GetExpense(int id);
        Expense CreateExpense(Expense expense);
        //void DeleteExpense(Expense expense);  //Update this later to take in only the id

        Expense EditExpense(Expense expense);
        void DeleteExpense(int id);  //Update this later to take in only the id
    }
}
