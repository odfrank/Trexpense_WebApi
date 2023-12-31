﻿using Trexpense.DB;

namespace Expenses.Core
{
    public class ExpensesServices : IExpensesServices
    {
        private AppDbContext _context;

        public ExpensesServices(AppDbContext context)
        {
            _context = context;
        }

        public Expense CreateExpense(Expense expense)
        {
            _context.Add(expense);
            _context.SaveChanges();

            return expense;
        }

        
        public Expense GetExpense(int id)
        {
            return _context.Expenses.First(e => e.Id == id);
        }

        public List<Expense> GetExpenses()
        {
            return _context.Expenses.ToList();
        }

        public Expense EditExpense(Expense expense)
        {
            var dbExpense = _context.Expenses.FirstOrDefault(e => e.Id == expense.Id);
            dbExpense.Description = expense.Description;
            dbExpense.Amount = expense.Amount;
            _context.SaveChanges();
            return dbExpense;
        }

        //public void DeleteExpense(Expense expense)
        //{
        //    _context.Expenses.Remove(expense);
        //    _context.SaveChanges();
        //}

        public void DeleteExpense(int id)
        {
            var expense = _context.Expenses.First(e => e.Id == id);
            _context.Expenses.Remove(expense);
            _context.SaveChanges();
        }
    }
}