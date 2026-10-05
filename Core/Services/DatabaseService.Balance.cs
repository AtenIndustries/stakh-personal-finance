using SQLite;
using Stakh.Core.Models;

namespace Stakh.Core.Services;

public partial class DatabaseService
{
        public async Task<Balance> LoadBalanceAsync(int id)
        {
            await InitAsync();
            var balance = await _db.FindAsync<Balance>(id);

            var monthBalances = await _db.Table<MonthBalance>()
                .Where(mb => mb.BalanceId == id)
                .ToListAsync();
            balance.MonthBalances = monthBalances;

            foreach (var monthBalance in balance.MonthBalances)
            {
                var expenseReports = await _db.Table<ExpenseReport>()
                    .Where(er => er.MonthBalanceId == monthBalance.Id)
                    .ToListAsync();
                monthBalance.ExpenseReports = expenseReports;

                foreach (var expenseReport in monthBalance.ExpenseReports)
                {
                    var expenseRecords = await _db.Table<ExpenseRecord>()
                        .Where(er => er.ExpenseReportId == expenseReport.Id)
                        .ToListAsync();
                    expenseReport.ExpenseRecords = expenseRecords;
                    expenseReport.ExpenseRecords.ForEach(er => er.ExpenseRecordCategory = _db.FindAsync<ExpenseRecordCategory>(er.ExpenseRecordCategoryId).Result);

                    var reserveFunds = await _db.Table<ReserveFund>()
                        .Where(rf => rf.ExpenseReportId == expenseReport.Id)
                        .ToListAsync();
                    expenseReport.ReserveFunds = reserveFunds;
                    expenseReport.ReserveFunds.ForEach(rf => rf.ReserveFundRecords = _db.Table<ReserveFundRecord>().Where(rfr => rfr.ReserveFundId == rf.Id).ToListAsync().Result);

                    var incomes = await _db.Table<Income>()
                        .Where(i => i.ExpenseReportId == expenseReport.Id)
                        .ToListAsync();
                    expenseReport.Incomes = incomes;
                }
            }

            return balance;
        }
}