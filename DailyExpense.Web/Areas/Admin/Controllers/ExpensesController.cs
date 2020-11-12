using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using DailyExpense.Framework.ResponseFiles;
using DailyExpense.Web.Areas.Admin.Models;
using DailyExpense.Web.Areas.Admin.Models.ExpenseModelFiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DailyExpense.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExpensesController : Controller
    {
        public readonly IConfiguration _configuration;
        public ExpensesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            var model = Startup.AutofacContainer.Resolve<ExpenseModel>();
            return View(model);
        }
        public IActionResult AddExpense()
        {
            var model = new CreateExpenseModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddExpense(
            [Bind(nameof(CreateExpenseModel.Name),
            nameof(CreateExpenseModel.Type),
            nameof(CreateExpenseModel.Quantity),
            nameof(CreateExpenseModel.Price),
            nameof(CreateExpenseModel.Datetime))] CreateExpenseModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Create();
                    model.Response = new ResponseModel("Record Added successful.", ResponseType.Success);
                    //return View(model);
                    return RedirectToAction("Index");
                }
                catch (DuplicationException ex)
                {
                    model.Response = new ResponseModel(ex.Message, ResponseType.Failure);
                    // error logger code
                }
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Record added failed.", ResponseType.Failure);
                    // error logger code
                }
            }
            return View(model);
        }
        public IActionResult EditExpense(int id)
        {
            var model = new EditExpenseModel();
            model.Load(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditExpense(
            [Bind(nameof(EditExpenseModel.Id),
            nameof(EditExpenseModel.Name),
            nameof(EditExpenseModel.Type),
            nameof(EditExpenseModel.Quantity),
            nameof(EditExpenseModel.Price),
            nameof(EditExpenseModel.Datetime))] EditExpenseModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Edit();
                    model.Response = new ResponseModel("Record update successful.", ResponseType.Success);
                    //return View(model);
                    return RedirectToAction("Index");
                }
                catch (DuplicationException ex)
                {
                    model.Response = new ResponseModel(ex.Message, ResponseType.Failure);
                    // error logger code
                }
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Record update failed.", ResponseType.Failure);
                    // error logger code
                }
            }
            return RedirectToAction("index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteExpense(int id)
        {
            if (ModelState.IsValid)
            {
                var model = new ExpenseModel();
                try
                {
                    model.Delete(id);
                    model.Response = new ResponseModel($"Expense successfully deleted.", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Expense delete failued.", ResponseType.Failure);
                    // error logger code
                }
            }
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult GetExpenses()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<ExpenseModel>();
            var data = model.GetExpenses(tableModel);
            return Json(data);
        }
    }
}