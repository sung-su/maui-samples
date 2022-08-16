using System.ComponentModel;
namespace PointOfSale.Models;

//[INotifyPropertyChanged]
public partial class Item : MyNotifyPropertyChanged
{
    //[ObservableProperty]
    string title;
    public string Title { get => title; set => title = value;}

    //[ObservableProperty]
    int quantity = 0;
    public int Quantity
    {
        get => quantity;
        set
        {
            quantity = value;
            OnQuantityChanged(value);
        }
    }

    //[ObservableProperty]
    string image;
    public string Image { get => image; set => image = value; }

    //[ObservableProperty]
    double price = 0;
    public double Price { get => price; set => price = value; }

    void OnQuantityChanged(int value)
    {
        OnPropertyChanged(nameof(SubTotal));
    }

    public ItemCategory Category { get; set; }

    public double SubTotal {
        get
        {
            return Price * Quantity;
        }
    }
}