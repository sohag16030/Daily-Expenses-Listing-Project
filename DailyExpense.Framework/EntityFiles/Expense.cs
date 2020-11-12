using DailyExpense.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyExpense.Framework.EntityFiles
{
    public class Expense : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public decimal Price {get;set;}         
        public DateTime Datetime { get; set; }

    }
}
