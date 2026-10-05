namespace Stakh.Features.ExpenseReports;
public partial class AddExpenseReportPage : ContentPage
{
    public AddExpenseReportPage(AddExpenseReportViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}