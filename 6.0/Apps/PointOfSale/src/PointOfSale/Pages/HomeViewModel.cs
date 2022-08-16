using System;
namespace PointOfSale.Pages;

//[INotifyPropertyChanged]
public partial class HomeViewModel : MyNotifyPropertyChanged
{
    //[ObservableProperty]
    public ObservableCollection<Item> Products { get; set; }

    //[ObservableProperty]
    public string Category
    {
        get
        {
            return ItemCategory.Noodles.ToString();
        }
        set
        {
            OnCategoryChanged(value);
        }

    }

    void OnCategoryChanged(string cat)
    {
        ItemCategory category = (ItemCategory)Enum.Parse(typeof(ItemCategory), cat);
        Products = new ObservableCollection<Item>(
            AppData.Items.Where(x => x.Category == category).ToList()
        );
        OnPropertyChanged(nameof(Products));
    }

    public HomeViewModel()
    {
        Products = new ObservableCollection<Item>(
            AppData.Items.Where(x=>x.Category == ItemCategory.Noodles).ToList()
        );
    }

    //[RelayCommand]
    async Task Preferences()
    {
        await Shell.Current.GoToAsync($"{nameof(SettingsPage)}?sub=appearance");
    }

    public async Task OnPreferences(object sender, EventArgs args)
    {
        await Shell.Current.GoToAsync($"{nameof(SettingsPage)}?sub=appearance");
    }

    //[RelayCommand]
    async Task AddProduct()
    {
        MessagingCenter.Send<HomeViewModel, string>(this, "action", "add");
    }

    public void OnAddProduct(object sender, EventArgs args)
    {
        MessagingCenter.Send<HomeViewModel, string>(this, "action", "add");
    }
}