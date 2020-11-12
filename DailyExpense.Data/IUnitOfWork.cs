using System;
using System.Collections.Generic;
using System.Text;

namespace DailyExpense.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
