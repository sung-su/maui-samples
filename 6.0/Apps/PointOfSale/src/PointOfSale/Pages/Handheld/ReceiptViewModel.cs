namespace PointOfSale.Pages.Handheld;

//[INotifyPropertyChanged]
[QueryProperty("Order","Order")]
public partial class ReceiptViewModel : MyNotifyPropertyChanged
{
    //[ObservableProperty]
    public Order Order { get; set; }

    //[RelayCommand]
    async void Done()
    {
        await Shell.Current.GoToAsync("///orders");
    }

    public async void OnDone(object sender, EventArgs args)
    {
        await Shell.Current.GoToAsync("///orders");
    }
}