namespace PointOfSale.Pages.Handheld;

//[INotifyPropertyChanged]
public partial class OrdersViewModel : MyNotifyPropertyChanged
{
    //[ObservableProperty]
    public ObservableCollection<Order> Orders { get; set; }

    public OrdersViewModel()
    {
        Orders = new ObservableCollection<Order>(AppData.Orders);
    }
}