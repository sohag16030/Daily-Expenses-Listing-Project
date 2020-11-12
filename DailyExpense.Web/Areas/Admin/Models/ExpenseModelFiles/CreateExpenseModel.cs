using DailyExpense.Framework.EntityFiles;
using DailyExpense.Framework.Files;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyExpense.Web.Areas.Admin.Models.ExpenseModelFiles
{
    public class CreateExpenseModel : ExpenseBaseModel
    {
        public string Name { get; set; }
        public string Type { get; set; }  
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime Datetime { get; set; }
        public CreateExpenseModel(IExpenseService expenseService) : base(expenseService) { }
        public CreateExpenseModel() : base() { }

        internal void Create()
        {
            var expense = new Expense
            {
                Name = this.Name,
                Type = this.Type,
                Quantity = this.Quantity,
                Price = this.Price,
                Datetime = this.Datetime
            };
            _expenseService.AddNewExpense(expense);
        }
    }
}
