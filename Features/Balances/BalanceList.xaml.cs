namespace Stakh.Features.Balances
{
    public partial class BalanceList : ContentPage
    {
        private readonly BalanceListViewModel _vm;

        public BalanceList(BalanceListViewModel vm)
        {
            InitializeComponent();
            BindingContext = _vm = vm;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _vm.LoadBalancesCommand.ExecuteAsync(null);
        }
    }
}

