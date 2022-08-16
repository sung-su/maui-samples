namespace PointOfSale.Pages.Handheld;

//[INotifyPropertyChanged]
[QueryProperty("Order","Order")]
public partial class SignatureViewModel : MyNotifyPropertyChanged
{
    //[ObservableProperty]
    public Order Order { get; set; }

    //[RelayCommand]
    async Task Done()
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { "Order", Order }
        };
        await Shell.Current.GoToAsync($"{nameof(ReceiptPage)}", navigationParameter);
    }
    public async Task OnDone(object sender, EventArgs args)
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { "Order", Order }
        };
        await Shell.Current.GoToAsync($"{nameof(ReceiptPage)}", navigationParameter);
    }

    //[RelayCommand]
    void Clear()
    {
        // msg the signature pad
    }

    public void OnClear(object sender, EventArgs args)
    {

    }

}