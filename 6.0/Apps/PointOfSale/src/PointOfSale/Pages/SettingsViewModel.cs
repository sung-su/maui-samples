using System;
namespace PointOfSale.Pages;

//[INotifyPropertyChanged]
public partial class SettingsViewModel : MyNotifyPropertyChanged
{
    //[ObservableProperty]
    public ObservableCollection<Item> Products { get; set; }

    public SettingsViewModel()
    {
        Products = new ObservableCollection<Item>(
            AppData.Items
        );
    }
}

