using DailyExpense.Framework.EntityFiles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace DailyExpense.Framework.Files
{
    public interface IExpenseService
    {
        (IList<Expense> records, int total, int totalDisplay) GetExpenses(
                                                                     int pageIndex,
                                                                     int pageSize,
                                                                     string searchText,
                                                                     string sortText);
        void Dispose();
        void AddNewExpense(Expense expense);
        void DeleteRecord(int id);
        Expense GetRecordById(int id);
        void EditRecord(Expense uprecord);
    }
}
