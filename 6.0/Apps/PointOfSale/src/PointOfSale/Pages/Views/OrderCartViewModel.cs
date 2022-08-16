using System;
namespace PointOfSale.Pages.Views;

//[INotifyPropertyChanged]
public partial class OrderCartViewModel : MyNotifyPropertyChanged
{
    //[ObservableProperty]
    public Order Order { get; set; }

    public OrderCartViewModel()
    {
        Order = AppData.Orders.First();
    }
}