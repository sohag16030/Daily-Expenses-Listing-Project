using DailyExpense.Framework.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyExpense.Web.Areas.Admin.Models.ExpenseModelFiles
{
    public class ExpenseModel : ExpenseBaseModel
    {
        public ExpenseModel(IExpenseService expenseService) : base(expenseService) { }
        public ExpenseModel() : base() { }

        internal object GetExpenses(DataTablesAjaxRequestModel tableModel)
        {
            var data = _expenseService.GetExpenses(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "Name", "Type", "Quantity","Price","DateTime"}));
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Name,
                            record.Type,
                            record.Quantity.ToString(),
                            record.Price.ToString(),
                            record.Datetime.ToString(),
                            record.Id.ToString()
                        }
                    ).ToArray()

            };
        }

        internal void Delete(int id)
        {
            _expenseService.DeleteRecord(id);
        }
    }
}
