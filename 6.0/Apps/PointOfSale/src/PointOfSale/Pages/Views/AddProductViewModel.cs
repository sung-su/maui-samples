using System;
namespace PointOfSale.Pages;

//[INotifyPropertyChanged]
public partial class AddProductViewModel : MyNotifyPropertyChanged
{
    //[ObservableProperty]
    Item item = new Item();
    public Item Item
    {
        get => item;
        set => item = value;
    }

    //[ObservableProperty]
    string category = ItemCategory.Noodles.ToString();
    public string Category
    {
        get => category;
        set => category = value;
    }

    //[ObservableProperty]
    string imagePath = "noimage.png";
    public string ImagePath
    {
        get => imagePath;
        set => imagePath = value;
    }

    //[ObservableProperty]
    ImageSource image;
    public ImageSource Image { get; set; }

    //[RelayCommand]
    async void Save()
    {
        ItemCategory cat = (ItemCategory)Enum.Parse(typeof(ItemCategory), category);
        item.Category = cat;
        AppData.Items.Add(item);

        MessagingCenter.Send<AddProductViewModel, string>(this, "action", "done");
    }
    public async void OnSave(object sender, EventArgs args)
    {
        ItemCategory cat = (ItemCategory)Enum.Parse(typeof(ItemCategory), category);
        item.Category = cat;
        AppData.Items.Add(item);

        MessagingCenter.Send<AddProductViewModel, string>(this, "action", "done");
    }

    //[RelayCommand]
    async Task ChangeImage()
    {
        PickOptions options = new()
        {
            PickerTitle = "Please select a photo file"
        };

        var file = await PickAndShow(options);
        Item.Image = ImagePath = file.FullPath;
    }
    public async Task OnChangeImage(object sender, EventArgs args)
    {
        PickOptions options = new()
        {
            PickerTitle = "Please select a photo file"
        };

        var file = await PickAndShow(options);
        Item.Image = ImagePath = file.FullPath;
    }

    public async Task<FileResult> PickAndShow(PickOptions options)
    {
        try
        {
            var result = await FilePicker.Default.PickAsync(options);
            if (result != null)
            {
                if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                    result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                {
                    using var stream = await result.OpenReadAsync();
                    Image = ImageSource.FromStream(() => stream);
                }
            }

            return result;
        }
        catch (Exception ex)
        {
            // The user canceled or something went wrong
        }

        return null;
    }
}

