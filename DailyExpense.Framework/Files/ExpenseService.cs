using DailyExpense.Framework.EntityFiles;
using DailyExpense.Framework.ResponseFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DailyExpense.Framework.Files
{
    public class ExpenseService : IExpenseService
    {
        private IExpenseUnitOfWork _expenseUnitOfWork;
        public ExpenseService(IExpenseUnitOfWork expenseUnitOfWork)
        {
            _expenseUnitOfWork = expenseUnitOfWork;
        }

        public void AddNewExpense(Expense expense)
        {
            var count = _expenseUnitOfWork.ExpenseRepository.GetCount(x => x.Name == expense.Name);
            if (count > 0)
                throw new DuplicationException("Name Exists", nameof(expense.Name));
            _expenseUnitOfWork.ExpenseRepository.Add(expense);
            _expenseUnitOfWork.Save();
        }

        public void DeleteRecord(int id)
        {
            _expenseUnitOfWork.ExpenseRepository.Remove(id);
            _expenseUnitOfWork.Save();
        }

        public void Dispose()
        {
            _expenseUnitOfWork?.Dispose();
        }

        public void EditRecord(Expense uprecord)
        {
            var count = _expenseUnitOfWork.ExpenseRepository.GetCount(x => x.Name == uprecord.Name && x.Id != uprecord.Id);
            if (count > 0)
                throw new DuplicationException("Name Exists", nameof(uprecord.Name));
            var exitRecord = _expenseUnitOfWork.ExpenseRepository.GetById(uprecord.Id);
            exitRecord.Name = uprecord.Name;
            exitRecord.Type = uprecord.Type;
            exitRecord.Quantity = uprecord.Quantity;
            exitRecord.Price = uprecord.Price;
            exitRecord.Datetime = uprecord.Datetime;
            _expenseUnitOfWork.ExpenseRepository.Edit(exitRecord);
            _expenseUnitOfWork.Save();
        }

        public (IList<Expense> records, int total, int totalDisplay) GetExpenses(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var result = _expenseUnitOfWork.ExpenseRepository.GetAll().ToList();
            return (result, 0, 0);
        }

        public Expense GetRecordById(int id)
        {
            return _expenseUnitOfWork.ExpenseRepository.GetById(id);
        }
    }
}
