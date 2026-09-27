using SQLite;

namespace Stakh.Models
{
    public class ExpenseRecord : IAuditable, IIdentifiable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [Indexed] 
        public int ExpenseRecordCategoryId { get; set; }
        [Indexed] 
        public int ExpenseReportId { get; set; }
        public decimal Reserved { get; set; }
        public decimal Executed { get; set; }
        public bool Closed { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [Ignore]
        public List<ReserveFundRecord> ReserveFundRecords { get; set; } = [];
        [Ignore]
        public List<ReserveFund> ReserveFunds { get; set; } = [];
        [Ignore]
        public ExpenseRecordCategory ExpenseRecordCategory { get; set; } = new();
    }
}