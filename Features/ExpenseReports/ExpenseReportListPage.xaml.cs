using Stakh.ViewModels; 

namespace Stakh.Features.ExpenseReports;

public partial class ExpenseReportListPage : ContentPage
{ 
    private readonly ExpenseReportListViewModel _vm;

    public ExpenseReportListPage(ExpenseReportListViewModel vm)
    {
        InitializeComponent();
        BindingContext = _vm = vm;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _vm.LoadExpenseReportsCommand.ExecuteAsync(null);
    }
}
