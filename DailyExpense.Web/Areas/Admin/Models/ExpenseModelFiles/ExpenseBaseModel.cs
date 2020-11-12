using Autofac;
using DailyExpense.Framework.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyExpense.Web.Areas.Admin.Models.ExpenseModelFiles
{
    public class ExpenseBaseModel : AdminBaseModel, IDisposable
    {
        protected readonly IExpenseService _expenseService;
        public ExpenseBaseModel(IExpenseService expenseService) 
        {
            _expenseService = expenseService;
        }
        public ExpenseBaseModel()
        {
            _expenseService = Startup.AutofacContainer.Resolve<IExpenseService>();
        }
        public void Dispose()
        {
            _expenseService?.Dispose();
        }
    }
}
