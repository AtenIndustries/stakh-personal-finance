using SQLite;
using Stakh.Models.Interfaces;

namespace Stakh.Models
{
    public class ReserveFund : IAuditable, IIdentifiable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public int ExpenseReportId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [Ignore]
        public List<ReserveFundRecord> ReserveFundRecords { get; set; } = [];
    }
}