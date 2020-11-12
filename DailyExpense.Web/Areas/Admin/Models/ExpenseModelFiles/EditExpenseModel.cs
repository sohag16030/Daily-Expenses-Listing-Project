using DailyExpense.Framework.EntityFiles;
using DailyExpense.Framework.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyExpense.Web.Areas.Admin.Models.ExpenseModelFiles
{
    public class EditExpenseModel : ExpenseBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime Datetime { get; set; }
        public EditExpenseModel(IExpenseService expenseService) : base(expenseService) { }
        public EditExpenseModel() : base() { }

        internal void Load(int id)
        {
           var record = _expenseService.GetRecordById(id);
            if(record != null)
            {
                Id = record.Id;
                Name = record.Name;
                Type = record.Type;
                Quantity = record.Quantity;
                Price = record.Price;
                Datetime = record.Datetime;
            }
        }

        internal void Edit()
        {
            var uprecord = new Expense
            {
                Id = this.Id,
                Name = this.Name,
                Type = this.Type,
                Quantity= this.Quantity,
                Price = this.Price,
                Datetime = this.Datetime
            };
            _expenseService.EditRecord(uprecord);
        }
    }
}
