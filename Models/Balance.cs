using SQLite;
using Stakh.Models.Interfaces;

namespace Stakh.Models
{
    public class Balance : IAuditable, IIdentifiable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [Ignore]
        public List<MonthBalance> MonthBalances { get; set; } = [];
    }
}