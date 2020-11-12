using DailyExpense.Data;
using DailyExpense.Framework.ContextModule;
using DailyExpense.Framework.EntityFiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyExpense.Framework.Files
{
    public interface IExpenseUnitOfWork : IUnitOfWork
    {
        IExpenseRepository ExpenseRepository { get; set; }
    }
}
