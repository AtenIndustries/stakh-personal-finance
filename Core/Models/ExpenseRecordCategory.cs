using SQLite;
using Stakh.Core.Models.Interfaces;

namespace Stakh.Core.Models
{
    public class ExpenseRecordCategory : IAuditable, IIdentifiable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}