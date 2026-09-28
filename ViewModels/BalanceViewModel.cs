namespace Stakh.ViewModels
{
    public class BalanceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<MonthBalanceViewModel> MonthBalances { get; set; } = [];
    }
}