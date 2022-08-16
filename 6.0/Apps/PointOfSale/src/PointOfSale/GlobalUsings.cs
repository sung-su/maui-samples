global using System.Collections.ObjectModel;
global using System.Diagnostics;
//global using CommunityToolkit.Mvvm;
//global using CommunityToolkit.Mvvm.ComponentModel;
//global using CommunityToolkit.Mvvm.Input;
global using PointOfSale.Models;

global using System.ComponentModel;
using System.Runtime.CompilerServices;

public class MyNotifyPropertyChanged : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}