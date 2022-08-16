namespace PointOfSale.Pages.Handheld;

//[INotifyPropertyChanged]
[QueryProperty("Order","Order")]
public partial class TipViewModel : MyNotifyPropertyChanged
{
    //[ObservableProperty]
    public Order Order { get; set; }

    //[ObservableProperty]
    public double Tip
    {
        get => Tip;
        set
        {
            OnTipChanged(value);
        }
    }

    void OnTipChanged(double value)
    {
        Order.Tip = value;
        OnPropertyChanged(nameof(Order));
    }

    //[RelayCommand]
    async void Continue()
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { "Order", Order }
        };
        await Shell.Current.GoToAsync($"{nameof(PayPage)}", navigationParameter);
    }

    public async void OnContinue(object sender, EventArgs args)
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { "Order", Order }
        };
        await Shell.Current.GoToAsync($"{nameof(PayPage)}", navigationParameter);
    }
}   