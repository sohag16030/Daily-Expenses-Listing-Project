using DailyExpense.Data;
using DailyExpense.Framework.ContextModule;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyExpense.Framework.Files
{
    public class ExpenseUnitOfWork : UnitOfWork,IExpenseUnitOfWork
    {
        public IExpenseRepository ExpenseRepository { get; set; }
        public ExpenseUnitOfWork(FrameworkContext context ,IExpenseRepository expenseRepository) : base(context)
        {
            ExpenseRepository = expenseRepository;
        }
    }
}
