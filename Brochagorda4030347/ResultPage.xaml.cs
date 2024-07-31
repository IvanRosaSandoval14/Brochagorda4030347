namespace Brochagorda4030347;

public partial class ResultPage : ContentPage
{
    public ResultPage(double budget)
    {
        InitializeComponent();
        ResultLabel.Text = $"Presupuesto: {budget:C}";
    }
}