using SQLite;
using Stakh.Models.Interfaces;

namespace Stakh.Models
{
    public class ReserveFundRecord : IAuditable, IIdentifiable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed] 
        public int ReserveFundId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}