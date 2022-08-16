namespace PointOfSale.Pages.Handheld;

//[INotifyPropertyChanged]
[QueryProperty("Order","Order")]
public partial class PayViewModel : MyNotifyPropertyChanged
{
    //[ObservableProperty]
    public Order Order { get; set; }

    //[RelayCommand]
    async void Scan()
    {
        // do something to scan a QR code
        var navigationParameter = new Dictionary<string, object>
        {
            { "Order", Order }
        };
        await Shell.Current.GoToAsync($"{nameof(SignaturePage)}", navigationParameter);
    }

    public async void OnScan(object sender, EventArgs args)
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { "Order", Order }
        };
        await Shell.Current.GoToAsync($"{nameof(SignaturePage)}", navigationParameter);
    }

}