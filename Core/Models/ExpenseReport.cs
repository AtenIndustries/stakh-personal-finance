using SQLite;
using Stakh.Core.Models.Interfaces;

namespace Stakh.Core.Models
{
    public class ExpenseReport : IAuditable, IIdentifiable //can have multiple expense records, reserve funds and incomes
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [Indexed]
        public int MonthBalanceId { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [Ignore]
        public List<ExpenseRecord> ExpenseRecords { get; set; } = [];
        [Ignore]
        public List<ReserveFund> ReserveFunds { get; set; } = [];
        [Ignore]
        public List<Income> Incomes { get; set; } = [];
    }
}