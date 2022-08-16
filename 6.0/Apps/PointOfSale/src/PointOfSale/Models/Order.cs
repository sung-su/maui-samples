//using CommunityToolkit.Mvvm.ComponentModel;
using PointOfSale.Pages.Handheld;

namespace PointOfSale.Models;

//[INotifyPropertyChanged]
public partial class Order : MyNotifyPropertyChanged
{
    //[ObservableProperty]
    int table;
    public int Table { get => table; set => table = value; }

    //[ObservableProperty]
    double tip;
    public double Tip { get => tip; set => tip = value; }

    public string Total
    {
        get
        {
            var tot = Items.Sum(i => (i.Price * i.Quantity));
            if (Tip != 0)
                tot = tot + (tot * Tip);
            return tot.ToString("N2");
        }
    }

    //[ObservableProperty]
    List<Item> items;
    public List<Item> Items { get => items; set => items = value; }

    //[ObservableProperty]
    string status;
    public string Status { get => status; set => status = value; }

    private static readonly Random _random = new Random();
    
    private static readonly string[] brushes = new string[] { "#FFB572", "#65B0F6", "#FF7CA3", "#50D1AA", "#9290FE" };
    public static Brush RandomBrush
    {
        get
        {
            var id = _random.Next(0, 4);
            return new SolidColorBrush(Color.Parse(brushes[id]));
        }
    }

    //[RelayCommand]
    private async void Pay()
    {
        try
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "Order", this }
            };
            await Shell.Current.GoToAsync($"{nameof(OrderDetailsPage)}", navigationParameter);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    public async void OnPay(object sender, EventArgs args)
    {
        try
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "Order", this }
            };
            await Shell.Current.GoToAsync($"{nameof(OrderDetailsPage)}", navigationParameter);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}