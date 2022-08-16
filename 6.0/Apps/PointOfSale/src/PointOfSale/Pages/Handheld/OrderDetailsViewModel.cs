namespace PointOfSale.Pages.Handheld;

//[INotifyPropertyChanged]
[QueryProperty("Order", "Order")]
[QueryProperty("Added", "Added")]
public partial class OrderDetailsViewModel : MyNotifyPropertyChanged
{
    //[ObservableProperty]
    public Order Order { get; set; }

    //[ObservableProperty]
    public Item Added { get; set; }

    //[RelayCommand]
    async Task Pay()
    {
        try
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "Order", Order }
            };
            await Shell.Current.GoToAsync($"{nameof(TipPage)}", navigationParameter);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    public async Task onPay(object sender, EventArgs args)
    {
        try
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "Order", Order }
            };
            await Shell.Current.GoToAsync($"{nameof(TipPage)}", navigationParameter);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    //[RelayCommand]
    async Task Add()
    {
        await Shell.Current.GoToAsync($"{nameof(ScanPage)}");
    }

    public async Task OnAdd(object sender, EventArgs args)
    {
        await Shell.Current.GoToAsync($"{nameof(ScanPage)}");
    }
}