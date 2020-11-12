﻿using Autofac;
using DailyExpense.Framework.Files;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyExpense.Framework.ContextModule
{
    public class FrameworkModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public FrameworkModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FrameworkContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ExpenseUnitOfWork>().As<IExpenseUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ExpenseRepository>().As<IExpenseRepository>()
               .InstancePerLifetimeScope();

            builder.RegisterType<ExpenseService>().As<IExpenseService>()
                .InstancePerLifetimeScope();



            base.Load(builder);
        }
    }
}
