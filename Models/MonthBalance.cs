using SQLite;

namespace Stakh.Models
{
    public class MonthBalance : IAuditable, IIdentifiable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public int BalanceId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [Ignore]
        public List<ExpenseReport> ExpenseReports { get; set; } = [];
    }
}